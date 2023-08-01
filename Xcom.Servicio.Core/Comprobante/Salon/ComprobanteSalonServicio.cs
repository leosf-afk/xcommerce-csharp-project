using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcom.AccesoDatos;
using Xcom.Servicio.Core.Articulo.DTOs;
using Xcom.Servicio.Core.Comprobante.DTOs;

namespace Xcom.Servicio.Core.Comprobante
{
    public class ComprobanteSalonServicio : IComprobanteSalonServicio
    {
        public void AgregarItem(long mesaId, decimal cantidad, ArticuloMesaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var comprobante = context.Comprobantes.OfType<AccesoDatos.ComprobanteSalon>()
                    .FirstOrDefault(x => x.MesaId == mesaId && x.Estado == EstadoComprobanteSalon.EnProceso);

                if (comprobante == null)
                {
                    throw new Exception("Error al obtener el comprobante ");
                }
                var item = comprobante.DetalleComprobantes.FirstOrDefault(x => x.Codigo == dto.Codigo );

                if (item == null)
                {
                    comprobante.DetalleComprobantes.Add(new DetalleComprobante
                    {
                        ArticuloId = (int)dto.Id,
                        Cantidad = cantidad,
                        Codigo = dto.Codigo,
                        Descripcion = dto.Descripcion,
                        PrecioUnitario = dto.Precio,
                        SubTotal = dto.Precio * cantidad, 




                    });
                }
                else
                {
                    item.Cantidad += cantidad;
                    item.SubTotal = item.Cantidad * item.PrecioUnitario;

                }

                if (dto.DescuentaStock)
                {

                    
                   

                    

                    var articulo = context.Articulos.FirstOrDefault(x=>x.Id == dto.Id);
                    if (articulo == null)
                    {
                        throw new Exception("ocurrio un error");
                    }

                    articulo.Stock -=  cantidad;
                }



                context.SaveChanges();
            }
        }

        public void AsignarMozo(long ComprobanteId , long MozoId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var Asignar = context.Comprobantes.OfType<AccesoDatos.ComprobanteSalon>()
                     .FirstOrDefault(x=>x.Id == ComprobanteId);
                if (Asignar == null)
                {
                    throw new Exception("Error");
                }
                else
                {
                    Asignar.MozoId = MozoId;

                    context.SaveChanges();
                }
            }
        }

        public void CerrarCOmprobante(int Comensales , decimal subtotal, decimal Descuento , decimal Total, long ComprobanteId , long ClienteID , int numero)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var Cerrar = context.Comprobantes.OfType<AccesoDatos.ComprobanteSalon>()
                    .FirstOrDefault(x=>x.Id == ComprobanteId);

                if (Cerrar == null)
                {
                    throw new Exception("error");
                }
                else
                {
                    Cerrar.Descuento = Descuento;
                    Cerrar.SubTotal = subtotal;
                    Cerrar.Total = Total;
                    Cerrar.Comensal = Comensales;
                    Cerrar.Estado = EstadoComprobanteSalon.Facturado;
                    Cerrar.ClienteId = ClienteID;
                    Cerrar.Numero = numero;
                    context.SaveChanges();
                }

            }
        }

        public void EliminarItem(DetalleComprobanteSalonDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var Eliminar = context.DetalleComprobantes.FirstOrDefault(x => x.ComprobanteId == dto.ComprobanteId && x.Codigo == dto.CodigoProducto);

                context.DetalleComprobantes.Remove(Eliminar);


                var item = context.DetalleComprobantes.FirstOrDefault(x => x.Codigo == dto.CodigoProducto);

                if (item != null)
                {
                    item.Articulo.Stock += dto.Cantidad;

                }

                context.SaveChanges();

            }
        }

        public long? Generar(long mesaId, long usuarioId, int comensales, long? mozoId = null)
        {
            using (var context = new ModeloXCommerceContainer())
            {

                if (context.Comprobantes.OfType<AccesoDatos.ComprobanteSalon>()
                    .Any(x => x.MesaId == mesaId && x.Estado == EstadoComprobanteSalon.EnProceso))
                    return null;



                var clienteconsumidorFinal = context.Personas
                    .OfType<AccesoDatos.Cliente>()
                    .FirstOrDefault(x=>x.Dni == "99999999"); // dni por defecto para consumidor final
                
                if (clienteconsumidorFinal == null)
                {
                    throw new Exception("Ocurrio un error al obtener un consumidor final");
                    
                    
                }

                var mesa = context.Mesas.FirstOrDefault(x=>x.Id == mesaId);

                if (mesa == null)
                {
                    throw new Exception("Ocurrio un error al obtener la mesa ");
                }
                mesa.EstadoMesa = EstadoMesa.Abierta;

                var nuevoComprobante = new ComprobanteSalon
                {

                    MesaId = mesaId,
                    ClienteId = clienteconsumidorFinal.Id,
                    Comensal = comensales,
                    Descuento = 0m,
                    Estado = EstadoComprobanteSalon.EnProceso,
                    Fecha = DateTime.Now,
                    MozoId = mozoId,
                    Numero = 0,
                    SubTotal = 0m,
                    Total = 0m,
                    TipoComprobante = TipoComprobante.X,
                    UsuarioId = usuarioId,
                    DetalleComprobantes = new List<DetalleComprobante>()

                };

                context.Comprobantes.Add(nuevoComprobante);
                context.SaveChanges();
                return nuevoComprobante.Id;

            }
        }

        public ComprobanteMesaDto Obtener(long mesaId)
        {
            using (var Context = new ModeloXCommerceContainer())
            {
                return Context.Comprobantes.OfType<ComprobanteSalon>()
                    .Include(x => x.Mozo)
                    .AsNoTracking()
                    .Select(x => new ComprobanteMesaDto
                    {
                        ClienteId = x.ClienteId,
                        ComprobanteId = x.Id,
                        Descuento = x.Descuento,
                        Fecha = x.Fecha,
                        MesaId = x.MesaId,
                        MozoId = x.MozoId,
                        Legajo = x.MozoId.HasValue ? x.Mozo.Legajo : 0,
                        ApellidoMozo = x.MozoId.HasValue ? x.Mozo.Apellido : "NO",
                        NombreMozo = x.MozoId.HasValue ? x.Mozo.Nombre : "ASIGNADO",
                        Estado = x.Estado,
                        
                        UsuarioId = x.UsuarioId,
                        Items = x.DetalleComprobantes.Select(c => new DetalleComprobanteSalonDto
                        {
                            Cantidad = c.Cantidad,
                            PrecioUnitario = c.PrecioUnitario,
                            ComprobanteId = x.Id,
                            CodigoProducto = c.Codigo,
                            DescripcionProducto = c.Descripcion,
                            DetalleId = c.Id,
                            productoId = c.ArticuloId,
                            
                        }).ToList()

                    }).FirstOrDefault(x=>x.MesaId == mesaId  && x.Estado == EstadoComprobanteSalon.EnProceso  );

            }
        }

        public IEnumerable<DetalleComprobanteSalonDto> ObtenerDetalle(long ComprobanteId )
        {
            using (var context = new ModeloXCommerceContainer())
            {

               
                    var r = context.DetalleComprobantes.OfType<AccesoDatos.DetalleComprobante>()


                        .Where(x => x.ComprobanteId == ComprobanteId )
                        .Select(x => new DetalleComprobanteSalonDto
                        {
                            Cantidad = x.Cantidad,
                            CodigoProducto = x.Codigo,
                            ComprobanteId = x.ComprobanteId,
                            DescripcionProducto = x.Descripcion,
                            DetalleId = x.Id,
                            PrecioUnitario = x.PrecioUnitario,



                        }).ToList();

                if (r == null)
                {
                    return null;
                }
                else
                {
                    return r;
                }

              
                          

              

                  
                
            }
        }
    }
}
