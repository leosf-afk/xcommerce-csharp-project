namespace Xcom.Servicio.Core.Cliente
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Windows.Forms;
    using Xcom.AccesoDatos;
    using Xcom.Servicio.Core.Cliente.Dtos;
    using Xcom.Servicio.Core.FormaPago.DTOs;

    public class ClienteServicio : IClienteServicio
    {
        public void Eliminar(long clienteId)
        {
            using (var Context = new ModeloXCommerceContainer())
            {
                var ClienteELiminar = Context.Personas.OfType<AccesoDatos.Cliente>()
                    .FirstOrDefault(x => x.Id == clienteId);

                if (ClienteELiminar == null)
                {
                    throw new Exception("No se Encontro El Cliente");
                }
                else
                {
                    ClienteELiminar.EstaEliminado = true;
                    Context.SaveChanges();
                }

            }
        }
        public bool VerificarExistencia(string dni,long? entdidadID )
        {
            using (var context = new ModeloXCommerceContainer())
            {
               return context.Personas.OfType<AccesoDatos.Cliente>()

                    .Any(x => x.Dni == dni && x.Id != entdidadID );



            }
        }

        public long Insertar(ClienteDto clienteDto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var Nuevocliente = new AccesoDatos.Cliente
                {



                    Apellido = clienteDto.Apellido,
                    Nombre = clienteDto.Nombre,
                    Dni = clienteDto.Dni,
                    Celular = clienteDto.Celular,
                    Email = clienteDto.EMail,
                    Telefono = clienteDto.Telefono,
                    Cuil = clienteDto.Cuil,
                    FechaNacimiento = clienteDto.FechaNacimiento,
                    EstaEliminado = clienteDto.EstaEliminado,
                    MontoMaximoCtaCte = clienteDto.MontoMaximoCtaCte,
                   EsVisible = clienteDto.EsVisible,
                   
                    
                    

                    Direccion = new AccesoDatos.Direccion
                    {
                        Calle = clienteDto.Calle,
                        Numero = clienteDto.Numero,
                        Lote = clienteDto.Lote,
                        Mza = clienteDto.Mza,
                        Piso = clienteDto.Piso,
                        Barrio = clienteDto.Barrio,
                        Casa = clienteDto.Casa,
                        Dpto = clienteDto.Dpto,

                        LocalidadId = clienteDto.LocalidadId,
                         
                        

                    }

                };
                context.Personas.Add(Nuevocliente);
                
                context.SaveChanges();
                return Nuevocliente.Id;
            }
        }

        public void Modificar(ClienteDto clienteDto)
        {
            using (var Context = new ModeloXCommerceContainer())
            {
                var ClienteModificar = Context.Personas.OfType<AccesoDatos.Cliente>()
                   .Include(x => x.Direccion)
                    .FirstOrDefault(x => x.Id == clienteDto.Id);

                if (ClienteModificar == null)
                {
                    throw new Exception("No se Encontro El Empleado");
                }
                else
                {

                    ClienteModificar.Apellido = clienteDto.Apellido;
                    ClienteModificar.Nombre = clienteDto.Nombre;
                    ClienteModificar.Dni = clienteDto.Dni;
                    ClienteModificar.Celular = clienteDto.Celular;
                    ClienteModificar.Email = clienteDto.EMail;
                    ClienteModificar.Telefono = clienteDto.Telefono;
                    ClienteModificar.Cuil = clienteDto.Cuil;
                    ClienteModificar.FechaNacimiento = clienteDto.FechaNacimiento;
                    ClienteModificar.MontoMaximoCtaCte = clienteDto.MontoMaximoCtaCte;
                    ClienteModificar.Direccion.Calle = clienteDto.Calle;
                    ClienteModificar.Direccion.Numero = clienteDto.Numero;
                    ClienteModificar.Direccion.Lote = clienteDto.Lote;
                    ClienteModificar.Direccion.Mza = clienteDto.Mza;
                    ClienteModificar.Direccion.Piso = clienteDto.Piso;
                    ClienteModificar.Direccion.Barrio = clienteDto.Barrio;
                    ClienteModificar.Direccion.Casa = clienteDto.Casa;
                    ClienteModificar.Direccion.Dpto = clienteDto.Dpto;
                    ClienteModificar.EsVisible = clienteDto.EsVisible;
                    ClienteModificar.Direccion.LocalidadId = clienteDto.LocalidadId;
                    Context.SaveChanges();
                }

            }
        }

        public decimal MontoDisponibleCtaCte(long ClienteID)
        {
            var Monto = 0m;

            using (var context = new ModeloXCommerceContainer())
            {
                var cliente = context.Personas.OfType<Cliente>()
                     .FirstOrDefault(x => x.Id == ClienteID);

                var Deuda = context.FormasPagos.OfType<FormaPagoCtaCte>()
                    .Where(d => d.ClienteId == ClienteID && d.EstaPagado == false).ToList();

                foreach (var Item in Deuda)
                {
                    Monto += Item.Monto;
                }






                return cliente.MontoMaximoCtaCte - Monto;

            }
            
        }

        public ClienteDto ObtenerCFinal()
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<Cliente>()
                    .Select(x => new ClienteDto
                    {
                        Id = x.Id,

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
                        MontoMaximoCtaCte = x.MontoMaximoCtaCte

                    }).FirstOrDefault(x=>x.Dni == "99999999");

            }
        }

        public IEnumerable<ClienteDto> ObtenerCliente(string CadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<AccesoDatos.Cliente>()
                    .AsNoTracking()
                     .Include(x => x.Direccion)
                    .Include(x => x.Direccion.Localidad)
                    .Include(x => x.Direccion.Localidad.Provincia)
                     .Where(x => (x.Nombre.Contains(CadenaBuscar)
                    || x.Apellido.Contains(CadenaBuscar)
                    || x.Dni == CadenaBuscar
                    || x.Email == CadenaBuscar) && x.EsVisible == true) 


                     .Select(x => new ClienteDto()
                     {
                        
                         Id = x.Id,
                         EsVisible = x.EsVisible,
                         Apellido = x.Apellido,
                         Nombre = x.Nombre,
                         Dni = x.Dni,
                         Celular = x.Celular,
                         EMail = x.Email,
                         Telefono = x.Telefono,
                         Cuil = x.Cuil,
                         MontoMaximoCtaCte = x.MontoMaximoCtaCte,
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
                         

                     }).ToList();

            }
        }

        public IEnumerable<ClienteDto> ObtenerClienteActivos(string CadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<AccesoDatos.Cliente>()
                    .AsNoTracking()
                     .Include(x => x.Direccion)
                    .Include(x => x.Direccion.Localidad)
                    .Include(x => x.Direccion.Localidad.Provincia)
                     .Where(x => (x.Nombre.Contains(CadenaBuscar)
                    || x.Apellido.Contains(CadenaBuscar)
                    || x.Dni == (CadenaBuscar)
                    || x.Email == (CadenaBuscar))  && x.EstaEliminado == false)


                     .Select(x => new ClienteDto()
                     {

                         Id = x.Id,

                         Apellido = x.Apellido,
                         Nombre = x.Nombre,
                         Dni = x.Dni,
                         Celular = x.Celular,
                         EMail = x.Email,
                         Telefono = x.Telefono,
                         Cuil = x.Cuil,
                         MontoMaximoCtaCte = x.MontoMaximoCtaCte,
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


                     }).ToList();

            }
        }

        public ClienteDto ObtenerPorId(long ClienteId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<AccesoDatos.Cliente>()
                   .AsNoTracking()
                   .Include(x => x.Direccion)
                       .Include(x => x.Direccion.Localidad)
                       .Include(x => x.Direccion.Localidad.Provincia.Descripcion)
                        .Select(x => new ClienteDto
                        {
                            Id = x.Id,

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
                            MontoMaximoCtaCte = x.MontoMaximoCtaCte



                        }).FirstOrDefault(x => x.Id == ClienteId);

            }
        }

        public void PagarCtaCte(long clienteId)
        {
            using (var Context = new ModeloXCommerceContainer())
            {
                var Estado = Context.FormasPagos.OfType<AccesoDatos.FormaPagoCtaCte>()
                     .Where(x => x.ClienteId == clienteId);
                    

                if (Estado == null)
                {
                    throw new Exception("Error");
                }
                else
                {
                    foreach (var item in Estado)
                    {
                        item.EstaPagado = true;
                    }

                    Context.SaveChanges();
                }

            }
        }
    }
}
