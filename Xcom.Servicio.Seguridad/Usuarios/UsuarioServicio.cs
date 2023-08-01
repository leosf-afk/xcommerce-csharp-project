
namespace Xcom.Servicio.Seguridad.Usuarios
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Xcom.AccesoDatos;
    using Xcom.Servicio.Seguridad.Usuarios.DTOs;
    using static Presentacion.Helpers.CadenaCaracteres;

    public class UsuarioServicio : IUsuarioServicio
    {
        public void CambiarEstado(string nombreUsuario, bool estado)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var usuario = context.Usuarios
                    .FirstOrDefault(x => x.Nombre == nombreUsuario);

                   if (usuario == null) 
                
                    throw new Exception($"no se encontro el Usuario:  {nombreUsuario}");

                
                usuario.EstaBloqueado = estado;
                
                context.SaveChanges();
            }
        }

        public void Crear(long personaId, string Apellido, string Nombre)
        {
            var nombreUsuario = CrearNombreUsuario(Apellido,Nombre);
            using (var context = new ModeloXCommerceContainer())
            {
               

                context.Usuarios.Add(new AccesoDatos.Usuario
                {
                    PersonaId = personaId,
                    EstaBloqueado = false,
                    Nombre = nombreUsuario.ToLower(),
                    Password = Encriptar("p$assword")

                });
                context.SaveChanges();
            }
        }

        private string CrearNombreUsuario(string apellido , string nombre)
        {
            int contadorLetras = 1;
            int digito = 1;
            var UsuarioNuevo = $"{nombre.Substring(0, contadorLetras).Trim()}{apellido.Trim()}";
            using (var Context = new ModeloXCommerceContainer())
            {
                while (Context.Usuarios.Any(x => x.Nombre == UsuarioNuevo))
                {
                   
                    if (contadorLetras < nombre.Trim().Length)
                    {
                        contadorLetras++;
                        UsuarioNuevo = $"{nombre.Substring(0, contadorLetras)}{apellido.Trim()}";
                        
                    }
                    else
                    {
                        UsuarioNuevo = $"{nombre.Substring(0, contadorLetras)}{apellido.Trim()}{digito.ToString()}";
                        digito++;
                    }
                   
                }

                

            }

                return UsuarioNuevo.Trim();
        }


        public IEnumerable<UsuarioDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<Empleado>()
                    .AsNoTracking()
                    .Where(x => !x.EstaEliminado &&  (x.Apellido.Contains(cadenaBuscar) || x.Nombre.Contains(cadenaBuscar)))
                    .Select(x => new UsuarioDto
                    {
                        PersonaId = x.Id,
                        Apellidpersona = x.Apellido,
                        NombrePersona = x.Nombre,
                        Nombre = x.Usuarios.Any()
                        ? x.Usuarios.FirstOrDefault().Nombre 
                        : "NO ASIGNADO",

                          Id = x.Usuarios.Any()
                        ? x.Usuarios.FirstOrDefault().Id
                        : 0,

                        EstaBloqueado = x.Usuarios.Any() &&
                         x.Usuarios.FirstOrDefault()
                        .EstaBloqueado


                    }).ToList();

            }
        }



        public UsuarioDto ObtenerPorId(long EntidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Usuarios.OfType<AccesoDatos.Usuario>()
                    .AsNoTracking()

                    .Select(x => new UsuarioDto
                    {
                       Id = x.Id,
                       Nombre = x.Nombre,
                       PersonaId = x.PersonaId,
                       EstaBloqueado = x.EstaBloqueado,


                    }).FirstOrDefault(x => x.Id == EntidadId);
            }
        }

        public UsuarioDto Obtenernombre(long EntidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
              return  context.Usuarios.OfType<AccesoDatos.Usuario>()
             
                   .Select(x => new UsuarioDto
                   {


                       Id = x.Id,
                       Nombre = x.Nombre,
                       PersonaId = x.PersonaId,
                       EstaBloqueado = x.EstaBloqueado,




                   }).FirstOrDefault(x=>x.PersonaId == EntidadId);

                

            }
        }

        public UsuarioDto ObtenerPorUsuario(string Usuario)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                   return context.Usuarios.OfType<AccesoDatos.Usuario>()
                     .Select(x => new UsuarioDto
                     {
                         Id = x.Id,
                         Nombre = x.Nombre,

                     }).FirstOrDefault(x=>x.Nombre ==  Usuario);

            }
        }

        public bool VerificarQueExista(long Id)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Usuarios.Any(x=>x.PersonaId == Id);

            }
        }
    }
    }

