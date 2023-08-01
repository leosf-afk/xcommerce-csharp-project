

namespace Xcom.Servicio.Core.Reserva
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Xcom.AccesoDatos;
    using Xcom.Servicio.Core.Reserva.DTOs;

    public class ReservaServicio : IReservaServicio
    {
        public long Insertar(ReservaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
               

                var NuevaReserva = new AccesoDatos.Reserva

                {
                   Fecha = dto.Fecha,
                   Senia = dto.Senia,
                   EstadoReserva = dto.EstadoReserva,
                   MesaId = dto.MesaId,
                   ClienteId = dto.ClienteId,
                   UsuarioId = dto.UsuarioId,
                   MotivoReservaId = dto.MotivoReservaId
                   
                };

                context.Reservas.Add(NuevaReserva);

                context.SaveChanges();

                return NuevaReserva.Id;

            }
        }

        public void Modificar(ReservaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ModificarReserva = context.Reservas.OfType<AccesoDatos.Reserva>()

                      .FirstOrDefault(x => x.Id == dto.Id);

                if (ModificarReserva == null)
                {
                    throw new Exception("No se Encontro La Reserva");
                }
                else
                {

                    ModificarReserva.Fecha = dto.Fecha;
                    ModificarReserva.Senia = dto.Senia;
                    ModificarReserva.EstadoReserva = dto.EstadoReserva;
                   ModificarReserva.MesaId = dto.MesaId;
                    ModificarReserva.ClienteId = dto.ClienteId;
                    ModificarReserva.UsuarioId = dto.UsuarioId;
                    ModificarReserva.MotivoReservaId = dto.MotivoReservaId;
                        context.SaveChanges();

                }

            }
        }

        public IEnumerable<ReservaDto> Obtener(string CadenaBuscar)
        {

            using (var context = new ModeloXCommerceContainer())
            {
                return context.Reservas.OfType<AccesoDatos.Reserva>()
                    .AsNoTracking()
                    
                   
                    .Select(x => new ReservaDto
                    {   Id = x.Id,
                        Fecha = x.Fecha,
                        Senia =  x.Senia,
                        EstadoReserva = x.EstadoReserva,
                        MesaId = x.MesaId,
                        ClienteId = x.ClienteId,
                        UsuarioId = x.UsuarioId,
                        MotivoReservaId = x.MotivoReservaId
                        
                    }).ToList();






            }
        }

        public ReservaDto ObtenerPorId(long EntidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Reservas.OfType<AccesoDatos.Reserva>()
                    .AsNoTracking()

                    .Select(x => new ReservaDto
                    {   Id = x.Id,
                        Fecha = x.Fecha,
                        Senia = x.Senia,
                        EstadoReserva = x.EstadoReserva,
                        MesaId = x.MesaId,
                        ClienteId = x.ClienteId,
                        UsuarioId = x.UsuarioId,
                        MotivoReservaId = x.MotivoReservaId
                        
                        

                    }).FirstOrDefault(x => x.Id == EntidadId);
            }
        }

        public bool verificarFecha( DateTime Fecha , long mesaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {

                
               
                
                
             return context.Reservas.OfType<AccesoDatos.Reserva>()
                    .Any(x=>x.Fecha == Fecha && x.MesaId == mesaId);

            }
        }
    }
}
