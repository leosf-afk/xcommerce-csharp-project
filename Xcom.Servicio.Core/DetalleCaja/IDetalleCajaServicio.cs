using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcom.Servicio.Core.DetalleCaja.DTOs;

namespace Xcom.Servicio.Core.DetalleCaja
{
   public interface IDetalleCajaServicio
    {
        long Insertar(DetalleCajaDto dto);

        IEnumerable<DetalleCajaDto> ObtenerPorIdCaja( long CajaId);
        

    }
}
