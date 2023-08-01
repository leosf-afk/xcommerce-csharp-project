

namespace Xcom.Servicio.Core.ListaPrecio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xcom.AccesoDatos;
    using Xcom.Servicio.Core.ListaPrecio.DTOs;
    public class ListaPrecioServicio : IListaPrecioServicio
    {
        public void Eliminar(long PrecioListaId)
        {
            using (var Context = new ModeloXCommerceContainer())
            {
                var listaPrecioEliminar = Context.ListaPrecios.OfType<AccesoDatos.ListaPrecio>()
                    .FirstOrDefault(x => x.Id == PrecioListaId);

                if (listaPrecioEliminar == null)
                {
                    throw new Exception("No se Encontro la lista");
                }
                else
                {
                    listaPrecioEliminar.EstaEliminado = true;
                    Context.SaveChanges();

                }

            }
        }

        public long Insertar(ListaPrecioDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var NuevaListaprecio = new AccesoDatos.ListaPrecio
                {

                    Descripcion = dto.Descripcion,
                    Rentabilidad = dto.Rentabilidad,
                    EstaEliminado = false

                  





                };
                context.ListaPrecios.Add(NuevaListaprecio);

                context.SaveChanges();
                return NuevaListaprecio.Id;
            }
        }

        public void Modificar(ListaPrecioDto dto)
        {
            using (var Context = new ModeloXCommerceContainer())
            {
                var ModificarListaPrecio = Context.ListaPrecios.OfType<AccesoDatos.ListaPrecio>()

                    .FirstOrDefault(x => x.Id == dto.Id);

                if (ModificarListaPrecio == null)
                {
                    throw new Exception("No se Encontro la lista");
                }
                else
                {
                    ModificarListaPrecio.Descripcion = dto.Descripcion;
                    ModificarListaPrecio.Rentabilidad = dto.Rentabilidad;

                    Context.SaveChanges();
                }

            }
        }

        public IEnumerable<ListaPrecioDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
                return context.ListaPrecios.OfType<AccesoDatos.ListaPrecio>()


                    .Where(x => x.Descripcion.Contains(cadenaBuscar))



                    .Select(x => new ListaPrecioDto()
                    {
                        Descripcion = x.Descripcion,
                        Rentabilidad = x.Rentabilidad,
                        Id = x.Id,
                        EstaEliminado = x.EstaEliminado


                    }).ToList();
        }

        public ListaPrecioDto ObtenerPorId(long? ArticuloId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.ListaPrecios.OfType<AccesoDatos.ListaPrecio>()


                        .Select(x => new ListaPrecioDto
                        {

                           Descripcion = x.Descripcion,
                           Rentabilidad = x.Rentabilidad,
                           Id = x.Id,
                           EstaEliminado = x.EstaEliminado


                        }).FirstOrDefault(x => x.Id == ArticuloId);

            }
        }

        public bool verificarExisteListaPrecio()
        {
            using (var Context = new ModeloXCommerceContainer())
            {
                return Context.ListaPrecios.OfType<AccesoDatos.ListaPrecio>()
                    .Any(x => x.Id  <= 1);
            }
        }
    }
}
