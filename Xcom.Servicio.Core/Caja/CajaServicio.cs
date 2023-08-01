using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcom.AccesoDatos;
using Xcom.Servicio.Core.Caja.DTOs;

namespace Xcom.Servicio.Core.Caja
{
    public class CajaServicio : ICajaServicio
    {
        public long Abrir(long usuarioId, decimal montoApertura)
        {
            using (var Context = new ModeloXCommerceContainer())
            {
                
                   var AbrirCaja = new AccesoDatos.Caja
                   {
                       FechaApertura = DateTime.Now,
                       MontoApertura = montoApertura,
                       UsuarioAperturaId = usuarioId,
                       UsuarioCierreId = usuarioId,
                       MontoCierre = montoApertura,
                       Diferencia = 0m,
                       MontoSistema = montoApertura,
                       FechaCierre = null, 

                   };
                Context.Cajas.Add(AbrirCaja);
                Context.SaveChanges();
                return AbrirCaja.Id;
            }
        }

        public void ActualizarMontoDelSistemaPorVenta(decimal MontoVenta , long cajaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ModificarMontoSistema = context.Cajas
                    .FirstOrDefault(x=>x.Id == cajaId);
                if (ModificarMontoSistema == null)
                {
                    throw new Exception("Error");
                }
                else
                {
                    ModificarMontoSistema.MontoSistema += MontoVenta;
                    context.SaveChanges();
                }
            }
        }

        public void Cerrar(long usuarioId, decimal MontoCierre , long cajaId , decimal montosistema)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var CerrarCaja = context.Cajas.OfType<AccesoDatos.Caja>()
                     .FirstOrDefault(x=>x.FechaCierre == null && x.Id ==  cajaId);
                if (CerrarCaja == null)
                {
                    throw new Exception("Error");
                }
                else
                {
                    CerrarCaja.FechaCierre = DateTime.Now;
                    CerrarCaja.UsuarioCierreId = usuarioId;
                    CerrarCaja.MontoCierre = MontoCierre;
                    CerrarCaja.Diferencia = MontoCierre - montosistema;
                    
                    context.SaveChanges();
                    
                }
            }
        }

        public CajaDto Obtener(long CajaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Cajas.OfType<AccesoDatos.Caja>()


                          .Select(x => new CajaDto
                          {

                           Id = x.Id,
                           Diferencia = x.Diferencia,
                           FechaApertura = x.FechaApertura,
                           FechaCierre = x.FechaCierre.Value,
                           MontoApertura = x.MontoApertura,
                           MontoCierre = x.MontoCierre,
                           MontoSistema = x.MontoSistema,
                           UsuarioAperturaId = x.UsuarioAperturaId,
                           UsuarioCierreId = x.UsuarioCierreId,


                          }).FirstOrDefault(x => x.Id == CajaId );
            }

        }

        public CajaDto ObtenerIdporUsuario(long UsuarioId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Cajas.OfType<AccesoDatos.Caja>()
                    .Select(x => new CajaDto
                    {
                        Id = x.Id,
                        Diferencia = x.Diferencia,
                        FechaApertura = x.FechaApertura,
                        MontoApertura = x.MontoApertura,
                        MontoSistema = x.MontoSistema,
                        UsuarioAperturaId = x.UsuarioAperturaId,
                        FechaCierre = x.FechaCierre,




                    }).FirstOrDefault(x=> x.FechaCierre == null && x.UsuarioAperturaId == UsuarioId  );
            }

        }

        public bool VerificarSiExisteCajaAbierta(long usuarioLogueadoId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Cajas.OfType<AccesoDatos.Caja>()
                    .Any(x=>x.FechaCierre == null && x.UsuarioAperturaId.Equals( usuarioLogueadoId));

            }
        }
    }
}
