using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcom.Servicio.Core.Comprobante.Comprobantes.ComprobanteDto;

namespace Xcom.Servicio.Core.Comprobante.Comprobantes
{
    public interface IComprobanteServicio
    {
        int ObtenerProximoNumero();

        IEnumerable<ComprobanteDetalleDto> obtenerdetalleComprobante(long comprobanteId);

        int obtenernumero(long comprobanteid);

        decimal MontoDelcomprobante(long ComprobanteId);
    }
}
