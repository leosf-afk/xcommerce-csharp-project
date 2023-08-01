using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcom.Servicio.Core.Comprobante.DTOs;
using Xcom.Servicio.Core.Comprobante.Kiosco.DTOs;

namespace Xcom.Servicio.Core.Comprobante.Kiosco
{
   public interface IComprobanteKioscoServicio
    {
         long? Generar(ComprobanteKioskoDto dto);

        void AgregarDetallesComprobante(List<DetalleComprobanteKiosco> dtos);
    }
}
