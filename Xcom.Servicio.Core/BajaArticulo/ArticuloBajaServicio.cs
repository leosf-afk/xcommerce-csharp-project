

namespace Xcom.Servicio.Core.BajaArticulo
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Xcom.AccesoDatos;
    using Xcom.Servicio.Core.BajaArticulo.DTOs;

    public class ArticuloBajaServicio : IArticuloBajaServicio
    {
        public void DescontarStock(long Id, decimal Cantidad)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var Descontar = context.Articulos.FirstOrDefault(x => x.Id == Id);
                if (Descontar == null)
                {
                    throw new Exception("No se encontro el articulo");
                
                }
                else
                {
                    Descontar.Stock -= Cantidad;
                }

                context.SaveChanges();
            }
        }

        public long Insertar(ArticuloBajaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var NuevaBajaArticulo = new AccesoDatos.BajaArticulo

                {
                  Fecha = dto.FechaBaja,
                  Cantidad = dto.Cantidad,
                  Observacion = dto.Observacion,
                  ArticuloId = (int)dto.ArticuloId,
                  MotivoBajaId = dto.MotivoBajaId,
                  


                };

                context.BajaArticulos.Add(NuevaBajaArticulo);

                context.SaveChanges();

                return NuevaBajaArticulo.Id;

            }
        }

        public void Modificar(ArticuloBajaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ModificarBajaArticulo = context.BajaArticulos.OfType<AccesoDatos.BajaArticulo>()

                      .FirstOrDefault(x => x.Id == dto.Id);

                if (ModificarBajaArticulo == null)
                {
                    throw new Exception("No se Encontro La Baja Articulo");
                }
                else
                {
                    ModificarBajaArticulo.Fecha = DateTime.Now;
                    ModificarBajaArticulo.Cantidad = dto.Cantidad;
                    ModificarBajaArticulo.ArticuloId = (int)dto.ArticuloId;
                    ModificarBajaArticulo.MotivoBajaId = dto.MotivoBajaId;
                    ModificarBajaArticulo.Observacion = dto.Observacion;
                    ModificarBajaArticulo.Id = dto.Id;
                  
                    context.SaveChanges();

                }

            }
        }

        public IEnumerable<ArticuloBajaDto> Obtener(string CadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.BajaArticulos.OfType<AccesoDatos.BajaArticulo>()
                    .AsNoTracking()

                    .Where(x => x.Observacion.Contains(CadenaBuscar))
                    .Select(x => new ArticuloBajaDto
                    {
                        Id = x.Id,
                        Observacion = x.Observacion,
                        ArticuloId = x.ArticuloId,
                        Cantidad = x.Cantidad,
                        FechaBaja = x.Fecha,
                        MotivoBajaId = x.MotivoBajaId,
                        ArticuloDescripcion = x.Articulo.Descripcion,
                        MotivoBaja = x.MotivoBaja.Descripcion

                    }).ToList();






            }
        }

        public ArticuloBajaDto ObtenerPorId(long EntidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.BajaArticulos.OfType<AccesoDatos.BajaArticulo>()
                    .AsNoTracking()

                    .Select(x => new ArticuloBajaDto
                    {
                        Id = x.Id,
                        Observacion = x.Observacion,
                        ArticuloId = x.ArticuloId,
                        Cantidad = x.Cantidad,
                        FechaBaja = x.Fecha,
                        MotivoBajaId = x.MotivoBajaId


                    }).FirstOrDefault(x => x.Id == EntidadId);
            }
        }
    }
}
