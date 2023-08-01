

namespace Xcom.Servicio.Core.Precio
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Xcom.AccesoDatos;
    using Xcom.Servicio.Core.Precio.DTOs;

    public class PrecioServicio : IPrecioServicio
    {


        public long Insertar(PrecioDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var PrecioNuevo = new AccesoDatos.Precio
                {
                    PrecioCosto = dto.PrecioCosto,
                    PrecioPublico = dto.PrecioPublico,
                    FechaActualizacion = dto.FechaActualizacion,
                    ListaPrecioId = dto.ListaPrecioId,
                    ArticuloId = dto.ArticuloId,
                    ActivarHoraVenta = dto.ActivarHoraVenta,
                    HoraVenta = dto.HoraVenta






                };
                context.Precios.Add(PrecioNuevo);

                context.SaveChanges();
                return PrecioNuevo.Id;
            }


        }

        public void Modificar(PrecioDto dto)
        {
            using (var Context = new ModeloXCommerceContainer())
            {
                var ModificarPrecio = Context.Precios.OfType<AccesoDatos.Precio>()

                    .FirstOrDefault(x => x.Id == dto.Id);

                if (ModificarPrecio == null)
                {
                    throw new Exception("No se Encontro El Empleado");
                }
                else
                {
                    ModificarPrecio.PrecioCosto = dto.PrecioCosto;
                    ModificarPrecio.PrecioPublico = dto.PrecioPublico;
                    ModificarPrecio.FechaActualizacion = dto.FechaActualizacion;
                    ModificarPrecio.ListaPrecioId = dto.ListaPrecioId;
                    ModificarPrecio.ArticuloId = dto.ArticuloId;
                    ModificarPrecio.ActivarHoraVenta = dto.ActivarHoraVenta;
                    ModificarPrecio.HoraVenta = dto.HoraVenta;

                    Context.SaveChanges();
                }

            }
        }

       
        public long obtenerId(long? ArticuloId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Precios.OfType<AccesoDatos.Precio>()
                    .FirstOrDefault(x => x.ArticuloId == ArticuloId).Id;
            }
        }

        public PrecioDto ObtenerPorId(long? PrecioId)
        {

            using (var Context = new ModeloXCommerceContainer())
            {
                return Context.Precios.OfType<AccesoDatos.Precio>()


                    .Select(x => new PrecioDto
                    {

                        Id = x.Id,
                        PrecioCosto = x.PrecioCosto,
                        PrecioPublico = x.PrecioPublico,
                        FechaActualizacion = x.FechaActualizacion,
                        ListaPrecioId = x.ListaPrecioId,
                        ArticuloId = x.ArticuloId,
                        ActivarHoraVenta = x.ActivarHoraVenta,
                        HoraVenta = x.HoraVenta





                    }).FirstOrDefault(x => x.Id == PrecioId);


            }
        }

        public IEnumerable<PrecioProductoDto> obtenerPrecios(string CadenaBuscar, decimal rentabilidad)
        {
            var aaaa = decimal.Round(rentabilidad / 100 ,2 , MidpointRounding.AwayFromZero);

           
            using (var context = new ModeloXCommerceContainer())
            {



                return context.Precios.OfType<AccesoDatos.Precio>()
                .AsNoTracking()
                .Include(x => x.Articulo)
                .Include(x => x.ListaPrecio)
              .Where(x => x.Articulo.Descripcion.Contains(CadenaBuscar))



              .Select(x => new PrecioProductoDto()
              {
                  Descripcion = x.Articulo.Descripcion,
                  Codigo = x.Articulo.Codigo,
                  CodigoBarra = x.Articulo.CodigoBarra,
                  PrecioCosto = x.PrecioCosto,
                  Id = x.Articulo.Id,
                  PrecioPublicoRentabilidad = (x.PrecioPublico + (x.PrecioPublico * aaaa)),
                  PrecioPublico = x.PrecioPublico
                            


                        }).ToList();

              

            }
        }

    }
}