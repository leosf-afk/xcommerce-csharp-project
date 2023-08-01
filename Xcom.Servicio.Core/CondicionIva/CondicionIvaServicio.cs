

namespace Xcom.Servicio.Core.CondicionIva
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Xcom.AccesoDatos;
    using Xcom.Servicio.Core.CondicionIva.DTOs;

    public class CondicionIvaServicio : ICondicionIvaServicio
    {
        public long Insertar(CondicionIvaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var NuevacondicionIva = new AccesoDatos.CondicionIva

                {
                    Descripcion = dto.Descripcion

                };

                context.CondicionIvas.Add(NuevacondicionIva);

                context.SaveChanges();

                return NuevacondicionIva.Id;

            }
        }

        public void Modificar(CondicionIvaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ModificarCondicionIva = context.CondicionIvas.OfType<AccesoDatos.CondicionIva>()

                      .FirstOrDefault(x => x.Id == dto.Id);

                if (ModificarCondicionIva == null)
                {
                    throw new Exception("No se Encontro La Reserva");
                }
                else
                {

                    ModificarCondicionIva.Descripcion = dto.Descripcion;
                    ModificarCondicionIva.Id = dto.Id;
                      
                    
                    context.SaveChanges();

                }
            }

        }


        public IEnumerable<CondicionIvaDto> Obtener(string CadenaBuscar)
        {

            using (var context = new ModeloXCommerceContainer())
            {
                return context.CondicionIvas.OfType<AccesoDatos.CondicionIva>()
                     .AsNoTracking()

                     .Where(x => x.Descripcion.Contains(CadenaBuscar))
                     .Select(x => new CondicionIvaDto
                     {
                       Descripcion = x.Descripcion,
                       Id = x.Id,

                     }).ToList();

            }
        }

        public CondicionIvaDto ObtenerPorId(long EntidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.CondicionIvas.OfType<AccesoDatos.CondicionIva>()
                    .AsNoTracking()

                    .Select(x => new CondicionIvaDto
                    {
                        Id = x.Id,
                       Descripcion = x.Descripcion


                    }).FirstOrDefault(x => x.Id == EntidadId);
            }
        }
    }
    }

