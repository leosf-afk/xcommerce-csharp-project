using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcom.AccesoDatos;
using Xcom.Servicio.Core.DetalleCaja.DTOs;

namespace Xcom.Servicio.Core.DetalleCaja
{
  public  class DetalleCajaServicio : IDetalleCajaServicio
    {
        public long Insertar(DetalleCajaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var NuevoDetalle = new AccesoDatos.DetalleCaja
                {
                    CajaId = dto.CajaId,
                    Monto = dto.Monto,
                    TipoPago = dto.TipoPago,
                    

                };
                context.DetalleCajas.Add(NuevoDetalle);
                context.SaveChanges();
                return NuevoDetalle.Id;
            }
        }

        public IEnumerable<DetalleCajaDto> ObtenerPorIdCaja(long CajaId)
        {
            throw new NotImplementedException();
        }
    }
}
