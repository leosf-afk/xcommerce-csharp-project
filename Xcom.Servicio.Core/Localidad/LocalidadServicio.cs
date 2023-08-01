

namespace Xcom.Servicio.Core.Localidad
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Xcom.AccesoDatos;
    using Xcom.Servicio.Core.Localidad.DTOs;

    public class LocalidadServicio : ILocalidadServicio
    {
        public void Eliminar(long LocalidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var localidadEliminar = context.Localidades.OfType<AccesoDatos.Localidad>()
                    .FirstOrDefault(x => x.Id == LocalidadId);

                
                if (localidadEliminar == null)
                    throw new Exception("Ocurrio un error al Obtener la Localidad");

                 localidadEliminar.EstaEliminado = true;
                 
        
                context.SaveChanges();
            }
        }

        public long Insertar(LocalidadDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
                
            {
                var LocalidadNueva = new AccesoDatos.Localidad
                {
                    Descripcion = dto.Descripcion,
                    ProvinciaId = dto.ProvinciaId
                   


                };

                context.Localidades.Add(LocalidadNueva);

                context.SaveChanges();
                return LocalidadNueva.Id;



            }
        }

        public void Modificar(LocalidadDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var LocalidadModificar = context.Localidades.OfType<AccesoDatos.Localidad>()
                      .FirstOrDefault(x => x.Id == dto.Id);

                if (LocalidadModificar == null)
                {
                    throw new Exception("No se Encontro La Localidad");
                }
                else
                {
                    LocalidadModificar.Descripcion = dto.Descripcion;
                    LocalidadModificar.ProvinciaId = dto.ProvinciaId;
                    context.SaveChanges();
                }
            }
        }

        public IEnumerable<LocalidadDto> Obtener(long provinciaId, string CadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Localidades.OfType<AccesoDatos.Localidad>()
                    .AsNoTracking()
                    .Include(x => x.Provincia)

                    .Where(x => x.ProvinciaId == provinciaId
                                               && x.Descripcion.Contains(CadenaBuscar))
                    .Select(x => new LocalidadDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        ProvinciaId = x.ProvinciaId,
                        Provincia = x.Provincia.Descripcion,
                        EstaEliminado = x.EstaEliminado
                       
                    }).ToList();                           

            }
        }

        public IEnumerable<LocalidadDto> ObtenerLocalidades(string CadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Localidades.OfType<AccesoDatos.Localidad>()
                     .AsNoTracking()
                     .Include(x => x.Provincia.Descripcion)
                     .Where(x => x.Descripcion.Contains(CadenaBuscar)
                     || x.Provincia.Descripcion.Contains(CadenaBuscar))

                     .Select(x => new LocalidadDto()
                     {
                         Id = x.Id,
                         ProvinciaId = x.ProvinciaId,
                         Descripcion = x.Descripcion,
                         Provincia = x.Provincia.Descripcion,
                         EstaEliminado = x.EstaEliminado

                         


                     }).ToList();

            }
        }

        public LocalidadDto obtenerPorId(long? EntidadId)
        {
            using (var Context = new ModeloXCommerceContainer())
            {
                return Context.Localidades.OfType<AccesoDatos.Localidad>()
                    .AsNoTracking()
                    .Include(x=> x.Provincia.Descripcion)
                    .Select(x => new LocalidadDto
                    {

                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        Provincia = x.Provincia.Descripcion,
                        ProvinciaId = x.ProvinciaId,
                        EstaEliminado = x.EstaEliminado

                       



                    }).FirstOrDefault(x => x.Id == EntidadId);
                    

                    
            }
        }

        public bool VerificarExistencia(string cadenaBuscar, long? entidadid , long? provinciaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Localidades.OfType<AccesoDatos.Localidad>()

                  .Any(x => (x.Descripcion.Equals(cadenaBuscar) && x.Id != entidadid && x.ProvinciaId == provinciaId));

            }
        }
    }
}
