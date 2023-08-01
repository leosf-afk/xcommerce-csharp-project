

using System.Windows.Forms;

namespace Xcom.Servicio.Core.Mesa
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xcom.AccesoDatos;
    using Xcom.Servicio.Core.Mesa.DTOs;

    public class Mesaservicio : IMesaServicio
    {
        public decimal CargarLabelprecio(long? mesaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                decimal numerito = 0;


                var obtenerComprobante = context.Comprobantes.OfType<AccesoDatos.ComprobanteSalon>()
                    .FirstOrDefault(x => x.MesaId == mesaId && x.Estado == EstadoComprobanteSalon.EnProceso);

                if (obtenerComprobante == null)
                {
                    
                    return numerito = 0m;
                }
                else
                {
                    var obtenerporID = context.DetalleComprobantes
                        .Where(x => x.ComprobanteId == obtenerComprobante.Id).ToList();



                    foreach (var itinerador in obtenerporID)
                    {
                        numerito += itinerador.SubTotal;
                    }


                }

                return numerito;
            }
        }

        public void CerrarMesa(long mesaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var cambiarEstado = context.Mesas.FirstOrDefault(x=>x.Id == mesaId);
                if (cambiarEstado == null)
                {
                    throw new Exception("Error");
                }
                else
                {
                   cambiarEstado.EstadoMesa = EstadoMesa.Cerrada;

                }
                context.SaveChanges();
            }
        }

        public void Eliminar(long MesaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var EliminarMesa = context.Mesas.OfType<AccesoDatos.Mesa>()

                      .FirstOrDefault(x => x.Id == MesaId);

                if (EliminarMesa == null) throw new Exception("No se Encontro la mesa");



                EliminarMesa.EstaEliminado = true;

                context.SaveChanges();



            }
        }

        public long Insertar(MesaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var NuevaMesa = new AccesoDatos.Mesa

                {
                    Descripcion = dto.Descripcion,
                    Numero = dto.Numero,

                    EstaEliminado = false,

                    SalonId = dto.SalonId,
                    EstadoMesa = dto.EstadoMesa


                };

                context.Mesas.Add(NuevaMesa);

                context.SaveChanges();

                return NuevaMesa.Id;

            }
        }

        public void Modificar(MesaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ModificarMesa = context.Mesas.OfType<AccesoDatos.Mesa>()

                      .FirstOrDefault(x => x.Id == dto.Id);

                if (ModificarMesa == null)
                {
                    throw new Exception("No se Encontro El Rubro");
                }
                else
                {
                    ModificarMesa.Id = dto.Id;
                    ModificarMesa.Descripcion = dto.Descripcion;
                    ModificarMesa.EstadoMesa = dto.EstadoMesa;
                    ModificarMesa.EstaEliminado = false;
                    ModificarMesa.Numero = dto.Numero;
                    ModificarMesa.SalonId = dto.SalonId;
                    
                    context.SaveChanges();

                }

            }
        }

        public IEnumerable<MesaDto> Obtener(string CadenaBuscar)
        {

            using (var context = new ModeloXCommerceContainer())
            {
                return context.Mesas.OfType<AccesoDatos.Mesa>()

                    .Where(x => x.Descripcion.Contains(CadenaBuscar))
                    .Select(x => new MesaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado,
                        Numero = x.Numero,
                        SalonId = x.SalonId,
                        EstadoMesa = x.EstadoMesa,
                        
                    }).ToList();

            }
        }

        public IEnumerable<MesaDto> ObtenerMesaEstado(string CadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ObtenerMesaCerrada = context.Mesas
                    .Where(x => x.EstadoMesa == EstadoMesa.Cerrada)
                    .Select(x => new MesaDto
                        {
                            Id = x.Id,
                            Descripcion = x.Descripcion,
                            EstaEliminado = x.EstaEliminado,
                            Numero = x.Numero,
                            SalonId = x.SalonId,
                            EstadoMesa = x.EstadoMesa,

                        }
                    ).ToList();

                return ObtenerMesaCerrada;
            }
        }

        public MesaDto ObtenerPorId(long EntidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Mesas.OfType<AccesoDatos.Mesa>()


                    .Select(x => new MesaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado,
                        Numero = x.Numero,
                        SalonId = x.SalonId,
                        EstadoMesa = x.EstadoMesa
                    }).FirstOrDefault(x => x.Id == EntidadId);
            }
        }

        public int ObtenerSiguienteNumeroMesa()
        {
            using (var context = new ModeloXCommerceContainer())
                if (context.Mesas.OfType<AccesoDatos.Mesa>().Any())
                    return context.Mesas
                        .OfType<AccesoDatos.Mesa>()
                        .Max(x => x.Numero) + 1;
                else
                {
                    return 1;
                }

        }

        public bool VerificarExistencia(string cadenaBuscar ,int numero , long? entidadid)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Mesas.OfType<AccesoDatos.Mesa>()

                  .Any(x => (x.Descripcion. Equals(cadenaBuscar) || x.Numero == numero) && x.Id != entidadid );

            }
        }
    }
}
