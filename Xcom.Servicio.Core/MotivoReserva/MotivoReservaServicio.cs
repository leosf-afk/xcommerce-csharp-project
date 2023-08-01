

namespace Xcom.Servicio.Core.MotivoReserva
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xcom.AccesoDatos;
    using Xcom.Servicio.Core.MotivoReserva.DTOs;

    public class MotivoReservaServicio : IMotivoReservaServicio
    {
        public long Insertar(MotivoReservaDto dto)
        {
            using (var Context = new ModeloXCommerceContainer())
            { 

                var NuevoMotivo = new AccesoDatos.MotivoReserva

                {
                    Descripcion = dto.Descripcion

                };
                Context.MotivosReservas.Add(NuevoMotivo);
                Context.SaveChanges();

                return NuevoMotivo.Id;
            }
        }

        public void Modificar(MotivoReservaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {

                var ModificarMotivo = context.MotivosReservas.OfType<AccesoDatos.MotivoReserva>()

                    .FirstOrDefault(x => x.Id == dto.Id);

                if (ModificarMotivo == null)
                {
                    throw new Exception("No se Encontro Motivo de Reserva");
                }
                else
                {
                    ModificarMotivo.Descripcion = dto.Descripcion;
                    ModificarMotivo.Id = dto.Id;
                    context.SaveChanges();

                }

            }
        }

        public IEnumerable<MotivoReservaDto> Obtener(string CadenaBuscar)
        {
            using (var Context = new ModeloXCommerceContainer())
            {
                return Context.MotivosReservas.OfType<AccesoDatos.MotivoReserva>()
                    .Where(x => x.Descripcion.Contains(CadenaBuscar))
                    .Select(x => new MotivoReservaDto
                    {
                        Descripcion = x.Descripcion,
                        Id = x.Id,

                    }).ToList();
                

            }
        }

        public MotivoReservaDto ObtenerPorId(long EntidadId)
        {
            using ( var context = new ModeloXCommerceContainer())
            {
                return context.MotivosReservas.OfType<AccesoDatos.MotivoReserva>()
                    .Select(x => new MotivoReservaDto
                    {
                        Descripcion = x.Descripcion,
                        Id = x.Id

                    }).FirstOrDefault(x => x.Id == EntidadId);

            }
        }
    }
}
