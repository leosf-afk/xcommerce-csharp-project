using System.Collections.Generic;
using Xcom.Servicio.Core.Articulo.DTOs;
using Xcom.Servicio.Core.Comprobante.DTOs;

namespace Xcom.Servicio.Core.Comprobante
{
  public  interface IComprobanteSalonServicio
    {
        long? Generar(long mesaId , long usuarioId , int comensales , long? mozoId = null);

        ComprobanteMesaDto Obtener(long mesaId );

        void AgregarItem(long mesaId, decimal cantidad ,ArticuloMesaDto dto);


        IEnumerable<DetalleComprobanteSalonDto> ObtenerDetalle(long ComprobanteId);

        void CerrarCOmprobante(int Comensales, decimal subtotal, decimal Descuento, decimal Total , long ComprobanteId , long ClienteID , int Numero);

        void AsignarMozo(long ComprobanteId, long MozoId);

        void EliminarItem(DetalleComprobanteSalonDto dto);
       
    }
}
