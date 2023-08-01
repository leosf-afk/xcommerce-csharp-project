

namespace Xcom.Servicio.Core.Provincia
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Xcom.AccesoDatos;
    using Xcom.Servicio.Core.Provincia.DTOs;

    public class ProvinciaServicio : IProvinciaServicio
    {
        public void Eliminar(long ProvinciaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var provinciaEliminar = context.Provincias
                    .FirstOrDefault(x => x.Id == ProvinciaId);

                if (provinciaEliminar == null)
                    throw new Exception("Ocurrio un error al Obtener la Provincia");

                provinciaEliminar.EstaEliminado = true;

                context.SaveChanges();
            }
        }

        public long Insertar(ProvinciaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var NuevaProvincia = new AccesoDatos.Provincia
                {
                    Descripcion = dto.Descripcion
                };
                context.Provincias.Add(NuevaProvincia);
                context.SaveChanges();
                return NuevaProvincia.Id;

            }
        }

        public void Modificar(ProvinciaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ProvinciaModificar = context.Provincias.OfType<AccesoDatos.Provincia>()
                      .FirstOrDefault(x => x.Id == dto.Id);

                if (ProvinciaModificar == null)
                {
                    throw new Exception("No se Encontro La Provincia");
                }
                else
                {
                    ProvinciaModificar.Descripcion = dto.Descripcion;
                    context.SaveChanges();
                }
            }
        }

        public IEnumerable<ProvinciaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
           
            {
               return context.Provincias.OfType<AccesoDatos.Provincia>()
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar))

                    .Select(x => new ProvinciaDto()
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado
                        


                    }).ToList();
               
            }
        }

      

        public ProvinciaDto ObtenerPorId(long EntidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Provincias.OfType<AccesoDatos.Provincia>()
                    .AsNoTracking()
                    
                    .Select(x => new ProvinciaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado

                    }).FirstOrDefault(x => x.Id == EntidadId);
            }
        }

        public bool VerificarExistencia(string cadenaBuscar,  long? entidadid)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Provincias.OfType<AccesoDatos.Provincia>()

                  .Any(x => (x.Descripcion.Equals(cadenaBuscar) && x.Id != entidadid));

            }
        }

    }
}
