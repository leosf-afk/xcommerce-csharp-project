

namespace Xcom.Servicio.Core.Salon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xcom.AccesoDatos;
    using Xcom.Servicio.Core.Salon.DTOs;

    public class SalonServicio : ISalonServicio
    {
        public void Eliminar(long salonId)
        {

            using (var context = new ModeloXCommerceContainer())
            {
                var EliminarSalon = context.Salones.OfType<AccesoDatos.Salon>()

                      .FirstOrDefault(x => x.Id == salonId);

                if (EliminarSalon == null) throw new Exception("No se Encontro El Rubro");



                EliminarSalon.EstaEliminado = true;

                context.SaveChanges();



            }
        }

        public long Insertar(SalonDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var NuevoSalon = new AccesoDatos.Salon

                {
                    Descripcion = dto.Descripcion,
                    ListaPrecioId = dto.ListaPrecioId,
                    EstaEliminado = false

                };

                context.Salones.Add(NuevoSalon);

                context.SaveChanges();

                return NuevoSalon.Id;

            }
        }

        public void Modificar(SalonDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ModificarSalon = context.Salones.OfType<AccesoDatos.Salon>()

                      .FirstOrDefault(x => x.Id == dto.Id);

                if (ModificarSalon == null)
                {
                    throw new Exception("No se Encontro El Rubro");
                }
                else
                {
                    ModificarSalon.ListaPrecioId = dto.ListaPrecioId;
                    ModificarSalon.Descripcion = dto.Descripcion;
                    context.SaveChanges();

                }

            }
        }

        public IEnumerable<SalonDto> Obtener(string CadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Salones.OfType<AccesoDatos.Salon>()

                    .Where(x => x.Descripcion.Contains(CadenaBuscar))
                    .Select(x => new SalonDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado,
                        ListaPrecioId = x.ListaPrecioId,

                    }).ToList();






            }
        }

        public IEnumerable<MesasSalonDto> ObtenerMesas(long?  SalonId ,  string CadenaBusacar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Mesas.OfType<AccesoDatos.Mesa>()
                    .Where(x => x.SalonId == SalonId && ((x.Descripcion.Contains(CadenaBusacar) || x.Numero.ToString() == CadenaBusacar))) 
                    .Select(x => new MesasSalonDto
                    {
                        NombreMesa = x.Descripcion,
                        EstadoMesa = x.EstadoMesa,
                        MesaSalonId = x.SalonId,
                        NumeroMesa = x.Numero,
                        Id = x.Id,
                        EstaEliminado = x.EstaEliminado,
                        listaDePrecioId = x.Salon.ListaPrecioId,
                        



                    }).ToList();
            }
        }

        public SalonDto ObtenerPorId(long EntidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Salones.OfType<AccesoDatos.Salon>()
                    

                    .Select(x => new SalonDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado,
                        ListaPrecioId = x.ListaPrecioId,
                        
                    }).FirstOrDefault(x => x.Id == EntidadId);
            }
        }

        public bool VerificarExistencia(string cadenaBuscar , long? EntidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Salones.OfType<AccesoDatos.Salon>()

                  .Any(x => x.Descripcion.Equals(cadenaBuscar) && x.Id != EntidadId );


            }
        }
    }
}
