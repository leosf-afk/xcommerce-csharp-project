

namespace Xcom.Servicio.Core.Empresa
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Xcom.AccesoDatos;
    using Xcom.Servicio.Core.Empresa.DTOs;

    public class EmpresaServicio : IEmpresaServicio
    {
        public long Insertar(EmpresaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var NuevaEmpresa = new AccesoDatos.Empresa

                { 
                  CondicionIvaId = dto.CondicionIvaId,
                  Cuit = dto.Cuit,
                  RazonSocial = dto.RazonSocial,
                  NombreFantasia = dto.NombreFantasia,
                  Telefono = dto.Telefono,
                  Mail = dto.Mail,
                  Sucursal = dto.Sucursal,
                  Logo = dto.Logo,

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

                context.Empresas.Add(NuevaEmpresa);

                context.SaveChanges();

                return NuevaEmpresa.Id;

            }
        }

        public void Modificar(EmpresaDto dto)
        {
            using (var Context = new ModeloXCommerceContainer())
            {
                var EmpresaModificar = Context.Empresas.OfType<AccesoDatos.Empresa>()
                   .Include(x => x.Direccion)
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (EmpresaModificar == null)
                {
                    throw new Exception("No se Encontro El Empleado");
                }
                else
                {
                    EmpresaModificar.Id = dto.Id;
                    EmpresaModificar.CondicionIvaId = dto.CondicionIvaId;
                    EmpresaModificar.RazonSocial = dto.RazonSocial;
                    EmpresaModificar.NombreFantasia = dto.NombreFantasia;
                    EmpresaModificar.Cuit = dto.Cuit;
                    EmpresaModificar.Telefono = dto.Telefono;
                    EmpresaModificar.Mail = dto.Mail;
                    EmpresaModificar.Sucursal = dto.Sucursal;
                    EmpresaModificar.Direccion.Calle = dto.Calle;
                    EmpresaModificar.Direccion.Numero = dto.Numero;
                    EmpresaModificar.Direccion.Lote = dto.Lote;
                    EmpresaModificar.Direccion.Mza = dto.Mza;
                    EmpresaModificar.Direccion.Piso = dto.Piso;
                    EmpresaModificar.Direccion.Barrio = dto.Barrio;
                    EmpresaModificar.Direccion.Casa = dto.Casa;
                    EmpresaModificar.Direccion.Dpto = dto.Dpto;
                    EmpresaModificar.Logo = dto.Logo;
                    EmpresaModificar.Direccion.LocalidadId = dto.LocalidadId;
                    Context.SaveChanges();
                }

            }
        }

        public IEnumerable<EmpresaDto> Obtener(string CadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
                return context.Empresas.OfType<AccesoDatos.Empresa>()
                    .AsNoTracking()
                    .Include(x => x.Direccion)
                    .Include(x => x.Direccion.Localidad)
                    .Include(x => x.Direccion.Localidad.Provincia)
                    .Where(x => x.NombreFantasia.Contains(CadenaBuscar)
                    || x.Sucursal.Contains(CadenaBuscar)
                    || x.RazonSocial == CadenaBuscar
                    || x.Mail == CadenaBuscar)

                    .Select(x => new EmpresaDto()
                    {   Id = x.Id,
                        CondicionIvaId = x.CondicionIvaId,
                        Cuit = x.Cuit,
                        RazonSocial = x.RazonSocial,
                        NombreFantasia = x.NombreFantasia,
                        Telefono = x.Telefono,
                        Mail = x.Mail,
                        Sucursal = x.Sucursal,
                        Logo = x.Logo,

                        Calle = x.Direccion.Calle,
                        Numero = x.Direccion.Numero,
                        Lote = x.Direccion.Lote,
                        Mza = x.Direccion.Mza,
                        Piso = x.Direccion.Piso,
                        Barrio = x.Direccion.Barrio,
                        Casa = x.Direccion.Casa,
                        Dpto = x.Direccion.Dpto,
                        ProvinciaId = x.Direccion.Localidad.ProvinciaId,
                        LocalidadId = x.Direccion.LocalidadId,
                       

                    }).ToList();
        }

        public EmpresaDto ObtenerPorId(long EntidadId)
        {
            using (var context = new ModeloXCommerceContainer())
                return context.Empresas.OfType<AccesoDatos.Empresa>()
                    .AsNoTracking()
                    .Include(x => x.Direccion)
                    .Include(x => x.Direccion.Localidad)
                    .Include(x => x.Direccion.Localidad.Provincia)

                          .Select(x => new EmpresaDto
                          {   Id = x.Id,
                              CondicionIvaId = x.CondicionIvaId,
                              Cuit = x.Cuit,
                              RazonSocial = x.RazonSocial,
                              NombreFantasia = x.NombreFantasia,
                              Telefono = x.Telefono,
                              Mail = x.Mail,
                              Sucursal = x.Sucursal,
                              Logo = x.Logo,

                              Calle = x.Direccion.Calle,
                              Numero = x.Direccion.Numero,
                              Lote = x.Direccion.Lote,
                              Mza = x.Direccion.Mza,
                              Piso = x.Direccion.Piso,
                              Barrio = x.Direccion.Barrio,
                              Casa = x.Direccion.Casa,
                              Dpto = x.Direccion.Dpto,
                              ProvinciaId = x.Direccion.Localidad.ProvinciaId,
                              LocalidadId = x.Direccion.LocalidadId,


                          }).FirstOrDefault(x => x.Id == EntidadId);





    }
    }
}
