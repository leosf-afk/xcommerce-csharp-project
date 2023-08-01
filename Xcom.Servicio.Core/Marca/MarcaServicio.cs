

namespace Xcom.Servicio.Core.Marca
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Xcom.AccesoDatos;
    using Xcom.Servicio.Core.Marca.DTOs;

    public class MarcaServicio : IMarcaServicio
    {
        public void Eliminar(long MarcaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var EliminarMarca = context.Marcas.OfType<AccesoDatos.Marca>()
                    
                      .FirstOrDefault(x => x.Id == MarcaId);

                if (EliminarMarca == null)
                {
                    throw new Exception("No se Encontro La Marca");
                }
                else
                {
                    EliminarMarca.EstaEliminado = true;
                    context.SaveChanges();

                }

            }
        }

        public long Insertar(MarcaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
              var  NuevaMarca = new AccesoDatos.Marca
                    
              {
                 Descripcion = dto.Descripcion,
                 EstaEliminado = false

              };

                context.Marcas.Add(NuevaMarca);

                context.SaveChanges();

                return NuevaMarca.Id;
                    
            }
        }

        public void Modificar(MarcaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ModificarMarca = context.Marcas.OfType<AccesoDatos.Marca>()
                      
                      .FirstOrDefault(x => x.Id == dto.Id);

                if (ModificarMarca == null)
                {
                    throw new Exception("No se Encontro La Marca");
                }
                else
                {
                    ModificarMarca.Descripcion = dto.Descripcion;
                    context.SaveChanges();

                }

            }
        }

        public IEnumerable<MarcaDto> Obtener(string CadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Marcas.OfType<AccesoDatos.Marca>()
                    .AsNoTracking()

                    .Where(x => x.Descripcion.Contains( CadenaBuscar))
                    .Select(x => new MarcaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();
                   
                    

                    

               
            }
        }

        public MarcaDto ObtenerPorId(long EntidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Marcas.OfType<AccesoDatos.Marca>()
                    .AsNoTracking()

                    .Select(x => new MarcaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado

                    }).FirstOrDefault(x => x.Id == EntidadId);
            }
        }
    }
}
