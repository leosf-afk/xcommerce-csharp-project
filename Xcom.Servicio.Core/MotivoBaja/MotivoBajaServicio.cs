

namespace Xcom.Servicio.Core.MotivoBaja
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Xcom.AccesoDatos;
    using Xcom.Servicio.Core.MotivoBaja.DTOs;

    public class MotivoBajaServicio : IMotivoBajaServicio
    {
        public long Insertar(MotivoBajaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var NuevoMotivo = new AccesoDatos.MotivoBaja

                {
                    Descripcion = dto.Descripcion,
                   

                };

                context.MotivosBajas.Add(NuevoMotivo);

                context.SaveChanges();

                return NuevoMotivo.Id;

            }
        }

        public void Modificar(MotivoBajaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ModificarMotivo = context.MotivosBajas.OfType<AccesoDatos.MotivoBaja>()

                      .FirstOrDefault(x => x.Id == dto.Id);

                if (ModificarMotivo == null)
                {
                    throw new Exception("No se Encontro Motivo de Baja");
                }
                else
                {
                    ModificarMotivo.Descripcion = dto.Descripcion;
                    context.SaveChanges();

                }

            }
        }

        public IEnumerable<MotivoBajaDto> Obtener(string CadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.MotivosBajas.OfType<AccesoDatos.MotivoBaja>()
                    .AsNoTracking()

                    .Where(x => x.Descripcion.Contains(CadenaBuscar))
                    .Select(x => new MotivoBajaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                    }).ToList();






            }
        }

        public MotivoBajaDto ObtenerPorId(long EntidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.MotivosBajas.OfType<AccesoDatos.MotivoBaja>()
                    .AsNoTracking()

                    .Select(x => new MotivoBajaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        

                    }).FirstOrDefault(x => x.Id == EntidadId);
            }
        }
    }
}
