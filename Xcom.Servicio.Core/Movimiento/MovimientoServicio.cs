using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcom.AccesoDatos;
using Xcom.Servicio.Core.Movimiento.DTOs;

namespace Xcom.Servicio.Core.Movimiento
{
    public class MovimientoServicio : IMovimientoServicio
    {
        public long insertar(MovimientoDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var NuevoMovimiento = new AccesoDatos.Movimiento
                {

                CajaId = dto.CajaId,
                ComprobanteId = dto.ComprobanteId,
                TipoMovimento = TipoMovimiento.Ingreso,
                 UsuarioId = dto.UsuarioId,
                 Monto = dto.Monto,
                 Fecha = DateTime.Now,
                 Descripcion = dto.Descripcion,


                };

                context.Movimientos.Add(NuevoMovimiento);
                context.SaveChanges();
                return NuevoMovimiento.Id;

            }
        }
    }
}
