using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcom.AccesoDatos;
using Xcom.Servicio.Core.Comprobante.DTOs;
using Xcom.Servicio.Core.Comprobante.Kiosco.DTOs;

namespace Xcom.Servicio.Core.Comprobante.Kiosco
{
   public class ComprobanteKioscoServicio : IComprobanteKioscoServicio
    {
        public void AgregarDetallesComprobante(List<DetalleComprobanteKiosco> dtos)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                foreach (var item in dtos)
                {
                    var Detalles = new AccesoDatos.DetalleComprobante
                    {
                      Cantidad = item.Cantidad,
                      ArticuloId = item.ArticuloId,
                      ComprobanteId = item.ComprobanteId,
                      Codigo = item.CodigoProducto,
                      Descripcion = item.DescripcionProducto,
                      PrecioUnitario = item.PrecioUnitario,
                      SubTotal = item.Subtotal,
                      
                    };
                    context.DetalleComprobantes.Add(Detalles);
                }

                foreach (var item2 in dtos)
                {

                    var items = context.Articulos.FirstOrDefault(x => x.Codigo == item2.CodigoProducto);

                    if (items != null && items.DescuentaStock)
                    {

                        items.Stock -= item2.Cantidad;

                    }
                    items = null;
                }

              

                context.SaveChanges();
            }
        }

        public long? Generar( ComprobanteKioskoDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {


                var NuevoComprobante = new AccesoDatos.ComprobanteFactura
                {
                    ClienteId = dto.ClienteId,
                    Descuento = dto.Descuento,
                    Fecha = dto.Fecha,
                    Numero = dto.Numero,
                    SubTotal = dto.SubTotal,
                    UsuarioId = dto.UsuarioId,
                    TipoComprobante = dto.TipoComprobante,
                    Total = dto.Total,
                };


                context.Comprobantes.Add(NuevoComprobante);

                context.SaveChanges();
                return NuevoComprobante.Id;
            }

        }



    }
}
