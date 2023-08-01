
namespace Xcom.Servicio.Core.Rubro
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Xcom.AccesoDatos;
    using Xcom.Servicio.Core.Rubro.DTOs;


    public class RubroServicio : IRubroservicio
    {
        public void Eliminar(long RubroId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var EliminarRubro = context.Rubros.OfType<AccesoDatos.Rubro>()
                      
                      .FirstOrDefault(x => x.Id == RubroId);

                if (EliminarRubro == null) throw new Exception("No se Encontro El Rubro");
                
                
                
                    EliminarRubro.EstaEliminado = true;

                context.SaveChanges();

                

            }
        }

        public long Insertar(RubroDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var NuevoRubro = new AccesoDatos.Rubro

                {
                    Descripcion = dto.Descripcion,
                    EstaEliminado = false

                };

                context.Rubros.Add(NuevoRubro);

                context.SaveChanges();

                return NuevoRubro.Id;

            }
            
        }

        public void Modificar(RubroDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ModificarRubro = context.Rubros.OfType<AccesoDatos.Rubro>()
                     
                      .FirstOrDefault(x => x.Id == dto.Id);

                if (ModificarRubro == null)
                {
                    throw new Exception("No se Encontro El Rubro");
                }
                else
                {
                    ModificarRubro.Descripcion = dto.Descripcion;
                    context.SaveChanges();

                }

            }
        }

        public IEnumerable<RubroDto> Obtener(string CadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Rubros.OfType<AccesoDatos.Rubro>()
                    .AsNoTracking()

                    .Where(x => x.Descripcion.Contains(CadenaBuscar))
                    .Select(x => new RubroDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();






            }
        }

        public RubroDto ObtenerPorId(long EntidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Rubros.OfType<AccesoDatos.Rubro>()
                    .AsNoTracking()

                    .Select(x => new RubroDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado

                    }).FirstOrDefault(x => x.Id == EntidadId);
            }
        }
    }
}
