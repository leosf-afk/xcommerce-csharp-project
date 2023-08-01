
namespace Xcom.Servicio.Core.Articulo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xcom.AccesoDatos;
    using Xcom.Servicio.Core.Articulo.DTOs;
    using System.Data.Entity;
    using Xcom.Servicio.Core.Precio.DTOs;

    public class ArticuloServicio : IArticuloServicio
    {
        public void Eliminar(long ArticuloId)
        {
            using (var Context = new ModeloXCommerceContainer())
            {
                var ArticuloEliminar = Context.Articulos.OfType<AccesoDatos.Articulo>()
                    .FirstOrDefault(x => x.Id == ArticuloId);

                if (ArticuloEliminar == null)
                {
                    throw new Exception("No se Encontro El Empleado");
                }
                else
                {
                    ArticuloEliminar.EstaEliminado = true;
                    Context.SaveChanges();
                }

            }
        }
        public bool VerificarExistencia(string cadenaBuscar, long? entidadid , string codigo , string CodigoBarra)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Articulos.OfType<AccesoDatos.Articulo>()

                    .Any(x => ((x.Descripcion.Equals(cadenaBuscar)  || x.Codigo == codigo || x.CodigoBarra == CodigoBarra ||  x.CodigoBarra == codigo || x.Codigo == CodigoBarra)) && x.Id != entidadid);

            }
        }
        public long Insertar(ArticuloDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var NuevoArticulo = new AccesoDatos.Articulo
                {

                  

                        Codigo = dto.Codigo,
                        CodigoBarra = dto.CodigoBarra,
                        Abreviatura = dto.Abreviatura,
                        Descripcion = dto.Descripcion,
                        Detalle = dto.Detalle,
                        Foto = dto.Foto,
                        ActivarLimiteVenta = dto.ActivarLimiteVenta,
                        LimiteVenta = dto.LimiteVenta,
                        PermiteStockNegativo = dto.PermitirStockNegativo,
                        EstaDiscontinuado = dto.EstaDescontinuado,
                        StockMaximo = dto.StockMaximo,
                        StockMinimo = dto.StockMinimo,
                        DescuentaStock = dto.DescuentoStock,
                        MarcaId = dto.MarcaId,
                        RubroId = dto.RubroId,
                        Stock = dto.Stock,
                        EstaEliminado = false,


                    


                };
                context.Articulos.Add(NuevoArticulo);

                context.SaveChanges();
                return NuevoArticulo.Id;
            }
        }

        public void Modificar(ArticuloDto dto)
        {
            using (var Context = new ModeloXCommerceContainer())
            {
                var ModificarArticulo = Context.Articulos.OfType<AccesoDatos.Articulo>()
                  
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (ModificarArticulo == null)
                {
                    throw new Exception("No se Encontro El Empleado");
                }
                else
                {
                    ModificarArticulo.Codigo = dto.Codigo;
                    ModificarArticulo.CodigoBarra = dto.CodigoBarra;
                    ModificarArticulo.Abreviatura = dto.Abreviatura;
                    ModificarArticulo.Descripcion = dto.Descripcion;
                    ModificarArticulo.Detalle = dto.Detalle;
                    ModificarArticulo.Foto = dto.Foto;
                    ModificarArticulo.ActivarLimiteVenta = dto.ActivarLimiteVenta;
                    ModificarArticulo.LimiteVenta = dto.LimiteVenta;
                    ModificarArticulo.PermiteStockNegativo = dto.PermitirStockNegativo;
                    ModificarArticulo.EstaDiscontinuado = dto.EstaDescontinuado;
                    ModificarArticulo.StockMaximo = dto.StockMaximo;
                    ModificarArticulo.StockMinimo = dto.StockMinimo;
                    ModificarArticulo.DescuentaStock = dto.DescuentoStock;
                    ModificarArticulo.MarcaId = dto.MarcaId;
                    ModificarArticulo.RubroId = dto.RubroId;
                    ModificarArticulo.Stock = dto.Stock;

                    Context.SaveChanges();
                }

            }
        }

        public IEnumerable<ArticuloDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
                return context.Articulos.OfType<AccesoDatos.Articulo>()


                    .Where(x => x.Descripcion.Contains(cadenaBuscar))



                    .Select(x => new ArticuloDto()
                    {
                        Id = x.Id,
                        Codigo = x.Codigo,
                        CodigoBarra = x.CodigoBarra,
                        Abreviatura = x.Abreviatura,
                        Descripcion = x.Descripcion,
                        Detalle = x.Detalle,
                        Foto = x.Foto,
                        ActivarLimiteVenta = x.ActivarLimiteVenta,
                        LimiteVenta = x.LimiteVenta,
                        PermitirStockNegativo = x.PermiteStockNegativo,
                        EstaDescontinuado = x.EstaDiscontinuado,
                        StockMaximo = x.StockMaximo,
                        StockMinimo = x.StockMinimo,
                        DescuentoStock = x.DescuentaStock,
                        MarcaId = x.MarcaId,
                        RubroId = x.RubroId,
                        Stock = x.Stock,
                        EstaEliminado = x.EstaEliminado,
                        
                        

                    }).ToList();
        }

        public ArticuloMesaDto ObtenerPorCodigoMesa(string codigo, long mesaId)
        {


            using (var context = new ModeloXCommerceContainer())
            {
                var PrecioCalculado  = 0m;
                var Mesa = context.Mesas.FirstOrDefault(q => q.Id == mesaId);
                var SalonId1 = Mesa.SalonId;
                var salon2 = context.Salones.FirstOrDefault(w => w.Id == SalonId1);
                var ListaPrecioId = salon2.ListaPrecioId;
                var ListaPrecio = context.ListaPrecios.FirstOrDefault(o => o.Id == ListaPrecioId);
                var Articulo = context.Articulos.FirstOrDefault(r => r.Codigo == codigo || r.CodigoBarra == codigo);

                if (Articulo != null)
                {
                    var ArticuloId = Articulo.Id;

                    var Precio = context.Precios.FirstOrDefault(t => t.ArticuloId == ArticuloId);
                     PrecioCalculado = Precio.PrecioPublico * ListaPrecio.Rentabilidad / 100 + Precio.PrecioPublico;
                    
                     PrecioCalculado = decimal.Round(PrecioCalculado, 2, MidpointRounding.AwayFromZero);
                }
                else
                {
                     
                    throw new Exception("Error al obtener el articulo");
                   
                }
               
                return context.Articulos
                     .Include(x => x.Precios)
                     .Include("Precios.ListaPrecio")
                     .Include("Precios.ListaPrecio.Salones")
                     .Include("Precios.ListaPrecio.Salones.Mesas")
                    .AsNoTracking()
                    
                    .Select(x => new ArticuloMesaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado,
                        Codigo = x.Codigo,
                        CodigoBarra = x.CodigoBarra,
                        DescuentaStock = x.DescuentaStock,
                        StockNegativo = x.PermiteStockNegativo,
                        Precio = PrecioCalculado
                    //    context.Precios
                    //.FirstOrDefault(l => l.ListaPrecio.Salon.Any(s => s.Mesas.Any(m => m.Id == mesaId))
                    //&& l.ArticuloId == x.Id
                    //&& l.FechaActualizacion == context.Precios
                    //.Where(l2 => l2.ListaPrecio.Salon.Any(s2 => s2.Mesas.Any(m2 => m2.Id == mesaId))
                    //&& l.ArticuloId == x.Id)
                    //.Max(max => max.FechaActualizacion)).PrecioPublico,




            }).FirstOrDefault(x => x.Codigo == codigo || x.CodigoBarra == codigo);

            }
        }

        public ArticuloDto ObtenerPorId(long ArticuloId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Articulos.OfType<AccesoDatos.Articulo>()
                  
                   
                        .Select(x => new ArticuloDto
                        {

                            Id = x.Id,
                            Codigo = x.Codigo,
                            CodigoBarra = x.CodigoBarra,
                            Abreviatura = x.Abreviatura,
                            Descripcion = x.Descripcion,
                            Detalle = x.Detalle,
                            Foto = x.Foto,
                            ActivarLimiteVenta = x.ActivarLimiteVenta,
                            LimiteVenta = x.LimiteVenta,
                            PermitirStockNegativo = x.PermiteStockNegativo,
                            EstaDescontinuado = x.EstaDiscontinuado,
                            StockMaximo = x.StockMaximo,
                            StockMinimo = x.StockMinimo,
                            DescuentoStock = x.DescuentaStock,
                            MarcaId = x.MarcaId,
                            RubroId = x.RubroId,
                            Stock = x.Stock,
                            EstaEliminado = x.EstaEliminado


                        }).FirstOrDefault(x => x.Id == ArticuloId);

            }
        }

        public ArticuloKioscoDto ObtenerventaKiosko(string codigo , decimal Cantidad)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var articulo = context.Articulos
                 .FirstOrDefault(x=>x.Codigo == codigo || x.CodigoBarra == codigo);
                var precio = context.Precios
                    .FirstOrDefault(p=>p.ArticuloId == articulo.Id);


                return context.Articulos
                    .Select(x => new ArticuloKioscoDto
                    {
                        ArticuloId = x.Id,
                        Codigo = x.Codigo,
                        CodigoBarra = x.CodigoBarra,
                        Descripcion = x.Descripcion,
                        Precio = precio.PrecioPublico,
                        cantidad = Cantidad,
                        SubTotal = precio.PrecioPublico * Cantidad,
                        
                        DescuentaStock = x.DescuentaStock,
                        StockNegativo = x.PermiteStockNegativo,
                        
                    
                    }) .FirstOrDefault(x => x.Codigo == codigo || x.CodigoBarra == codigo);



            }
        }



        public bool VerificarPorCodigo(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Articulos.OfType<AccesoDatos.Articulo>()
                    .Any(x => x.Codigo == cadenaBuscar || x.CodigoBarra == cadenaBuscar);
                return false;
            }
        }

        public bool VerificarSobreExistencia(string codigo, string CodigoBarra)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Articulos.OfType<AccesoDatos.Articulo>()

                    .Any(x => ((x.Codigo == codigo || x.CodigoBarra == CodigoBarra )));

            }
        }
    }
}
