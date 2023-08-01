using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcom.Servicio.Core.FormaPago.DTOs;

namespace Xcom.Servicio.Core.FormaPago
{
    public interface IFormaPagoServicio
    {
        long InsertarCte(FormaPagoDto dto);

        long InsertarEfectivo(FormaPagoDto dto);

        IEnumerable<CtaCteDto> ObtenerPorId(long IdCliente);

        IEnumerable<EfectivoDto> ObtenerporId(long IdCliente);

    }
}
