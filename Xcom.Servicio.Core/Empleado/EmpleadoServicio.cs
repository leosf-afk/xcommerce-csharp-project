

namespace Xcom.Servicio.Core.Empleado
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Xcom.AccesoDatos;
    using Xcom.Servicio.Core.Empleado.DTOs;

    public class EmpleadoServicio : IEmpleadoServicio
    {
        public void Eliminar(long empleadoId)
        {
            using (var Context = new ModeloXCommerceContainer())
            {
                var empleadoEliminar = Context.Personas.OfType<AccesoDatos.Empleado>()
                    .FirstOrDefault(x => x.Id == empleadoId);

                if (empleadoEliminar == null)
                {
                    throw new Exception("No se Encontro El Empleado");
                }
                else
                {
                    empleadoEliminar.EstaEliminado = true;
                    Context.SaveChanges();
                }

            }

        }

        public long Insertar(EmpleadoDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
              
                    var NuevoEmpleado = new AccesoDatos.Empleado
                    {


                        Legajo = dto.Legajo,
                        Apellido = dto.Apellido,
                        Nombre = dto.Nombre,
                        Dni = dto.Dni,
                        Celular = dto.Celular,
                        Email = dto.EMail,
                        Telefono = dto.Telefono,
                        Cuil = dto.Cuil,
                        FechaNacimiento = dto.FechaNacimiento,
                        EstaEliminado = false,
                        FechaIngreso = dto.FechaIngreso,
                        Foto = dto.Foto,


                        Direccion = new AccesoDatos.Direccion
                        {
                            Calle = dto.Calle,
                            Numero = dto.Numero,
                            Lote = dto.Lote,
                            Mza = dto.Mza,
                            Piso = dto.Piso,
                            Barrio = dto.Barrio,
                            Casa = dto.Casa,
                            Dpto = dto.Dpto,

                            LocalidadId = dto.LocalidadId,


                        }

                    };
                    context.Personas.Add(NuevoEmpleado);

                    context.SaveChanges();
                    return NuevoEmpleado.Id;
                
            }
        }

        public void Modificar(EmpleadoDto dto)
        {
            using (var Context = new ModeloXCommerceContainer())
            {
                var empleadoModificar = Context.Personas.OfType<AccesoDatos.Empleado>()
                   .Include(x => x.Direccion)
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (empleadoModificar == null)
                {
                    throw new Exception("No se Encontro El Empleado");
                }
                else
                {
                    empleadoModificar.Legajo = dto.Legajo;
                    empleadoModificar.Apellido = dto.Apellido;
                    empleadoModificar.Nombre = dto.Nombre;
                    empleadoModificar.Dni = dto.Dni;
                    empleadoModificar.Celular = dto.Celular;
                    empleadoModificar.Email = dto.EMail;
                    empleadoModificar.Telefono = dto.Telefono;
                    empleadoModificar.Cuil = dto.Cuil;
                    empleadoModificar.FechaNacimiento = dto.FechaNacimiento;
                    empleadoModificar.FechaIngreso = dto.FechaIngreso;
                    empleadoModificar.Direccion.Calle = dto.Calle;
                    empleadoModificar.Direccion.Numero = dto.Numero;
                    empleadoModificar.Direccion.Lote = dto.Lote;
                    empleadoModificar.Direccion.Mza = dto.Mza;
                    empleadoModificar.Direccion.Piso = dto.Piso;
                    empleadoModificar.Direccion.Barrio = dto.Barrio;
                    empleadoModificar.Direccion.Casa = dto.Casa;
                    empleadoModificar.Direccion.Dpto = dto.Dpto;
                    empleadoModificar.Foto = dto.Foto;
                    empleadoModificar.Direccion.LocalidadId = dto.LocalidadId;
                    Context.SaveChanges();
                }

            }
        }

        public IEnumerable<EmpleadoDto> Obtener(string cadenaBuscar)
        {

            using (var context = new ModeloXCommerceContainer())
                return context.Personas.OfType<AccesoDatos.Empleado>()
                    .AsNoTracking()
                    .Include(x => x.Direccion)
                    .Include(x => x.Direccion.Localidad)
                    .Include(x => x.Direccion.Localidad.Provincia)
                    .Where(x => x.Nombre.Contains(cadenaBuscar)
                    || x.Apellido.Contains(cadenaBuscar)
                    || x.Dni == cadenaBuscar
                    || x.Email == cadenaBuscar)

                    .Select(x => new EmpleadoDto()
                    {
                        Id = x.Id,
                        Legajo = x.Legajo,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Celular = x.Celular,
                        EMail = x.Email,
                        Telefono = x.Telefono,
                        Cuil = x.Cuil,
                        Foto = x.Foto,
                        EstaEliminado = x.EstaEliminado,
                        Calle = x.Direccion.Calle,
                        Numero = x.Direccion.Numero,
                        Lote = x.Direccion.Lote,
                        Mza = x.Direccion.Mza,
                        Piso = x.Direccion.Piso,
                        FechaNacimiento = x.FechaNacimiento,
                        Barrio = x.Direccion.Barrio,
                        Casa = x.Direccion.Casa,
                        Dpto = x.Direccion.Dpto,
                        ProvinciaId = x.Direccion.Localidad.ProvinciaId,
                        LocalidadId = x.Direccion.LocalidadId,
                        FechaIngreso = x.FechaIngreso

                    }).ToList();

        }

        public EmpleadoDto ObtenerPorId(long empleadoId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<AccesoDatos.Empleado>()
                   .AsNoTracking()
                   .Include(x => x.Direccion)
                       .Include(x => x.Direccion.Localidad)
                       .Include(x => x.Direccion.Localidad.Provincia.Descripcion)
                        .Select(x => new EmpleadoDto
                        {
                            Id = x.Id,
                            Legajo = x.Legajo,
                            Apellido = x.Apellido,
                            Nombre = x.Nombre,
                            Dni = x.Dni,
                            Celular = x.Celular,
                            EMail = x.Email,
                            EstaEliminado = x.EstaEliminado,
                            Telefono = x.Telefono,
                            Cuil = x.Cuil,
                            Calle = x.Direccion.Calle,
                            Numero = x.Direccion.Numero,
                            Lote = x.Direccion.Lote,
                            Mza = x.Direccion.Mza,
                            Piso = x.Direccion.Piso,
                            FechaNacimiento = x.FechaNacimiento,
                            Barrio = x.Direccion.Barrio,
                            Casa = x.Direccion.Casa,
                            Dpto = x.Direccion.Dpto,
                            ProvinciaId = x.Direccion.Localidad.ProvinciaId,
                            LocalidadId = x.Direccion.LocalidadId,
                            FechaIngreso = x.FechaIngreso,
                            Foto = x.Foto



                        }).FirstOrDefault(x => x.Id == empleadoId);

            }
        }

        public EmpleadoDto ObtenerPorLegajo(long Legajo)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<AccesoDatos.Empleado>()
                   .AsNoTracking()
                   .Include(x => x.Direccion)
                       .Include(x => x.Direccion.Localidad)
                       .Include(x => x.Direccion.Localidad.Provincia.Descripcion)
                        .Select(x => new EmpleadoDto
                        {
                            Id = x.Id,
                            Legajo = x.Legajo,
                            Apellido = x.Apellido,
                            Nombre = x.Nombre,
                            Dni = x.Dni,
                            Celular = x.Celular,
                            EMail = x.Email,
                            EstaEliminado = x.EstaEliminado,
                            Telefono = x.Telefono,
                            Cuil = x.Cuil,
                            Calle = x.Direccion.Calle,
                            Numero = x.Direccion.Numero,
                            Lote = x.Direccion.Lote,
                            Mza = x.Direccion.Mza,
                            Piso = x.Direccion.Piso,
                            FechaNacimiento = x.FechaNacimiento,
                            Barrio = x.Direccion.Barrio,
                            Casa = x.Direccion.Casa,
                            Dpto = x.Direccion.Dpto,
                            ProvinciaId = x.Direccion.Localidad.ProvinciaId,
                            LocalidadId = x.Direccion.LocalidadId,
                            FechaIngreso = x.FechaIngreso,
                            Foto = x.Foto



                        }).FirstOrDefault(x => x.Legajo == Legajo);
            }

        }

        public int ObtenerSiguienteNumeroLegajo()
        {

            using (var context = new ModeloXCommerceContainer())
            {
                if (context.Personas.OfType<AccesoDatos.Empleado>().Any())
                {
                    return context.Personas
                               .OfType<AccesoDatos.Empleado>()
                               .Max(x => x.Legajo) + 1;
                }
                else
                {
                    return 1;
                }
            }
        }

        public bool VerificarSiExisteLegajo(int legajo , long entidadId)
        {
            using (var Context = new ModeloXCommerceContainer())
            {
                return Context.Personas.OfType<AccesoDatos.Empleado>()
                    .Any(x => x.Legajo == legajo && x.Id != entidadId);
            }
        }
        public bool VerificarSiExisteLegajoNuevo(int legajo )
        {
            using (var Context = new ModeloXCommerceContainer())
            {
                return Context.Personas.OfType<AccesoDatos.Empleado>()
                    .Any(x => x.Legajo == legajo );
            }
        }

    }

   

    }





