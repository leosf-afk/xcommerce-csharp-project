using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcom.AccesoDatos;
using Xcom.Servicio.Core.Comprobante.Comprobantes.ComprobanteDto;

namespace Xcom.Servicio.Core.Comprobante.Comprobantes
{
    public class ComprobanteServicio : IComprobanteServicio
    {

        
        public decimal MontoDelcomprobante(long ComprobanteId)
        {

            var c = 0m;
            using (var context = new ModeloXCommerceContainer())
            {
                var List = context.DetalleComprobantes.OfType<AccesoDatos.DetalleComprobante>()
                   .Where(x => x.ComprobanteId == ComprobanteId)
                   .Select(x => new ComprobanteDetalleDto
                   {
                       subtotal = x.SubTotal,

                   }).ToList();


                foreach (var Item in List)
                {
                   c += Item.subtotal;
                }

                return c;


            }        
    }

        public IEnumerable<ComprobanteDetalleDto> obtenerdetalleComprobante(long comprobanteId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.DetalleComprobantes.OfType<AccesoDatos.DetalleComprobante>()
                    .Where(x => x.ComprobanteId == comprobanteId)
                    .Select(a => new ComprobanteDetalleDto
                    {
                       descripcion = a.Descripcion,
                       Cantidad = a.Cantidad,
                       codigo = a.Codigo, 
                       precioUnitario = a.PrecioUnitario,
                       subtotal = a.SubTotal


                    }).ToList();
            }
        }

        public int obtenernumero(long comprobanteid)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Comprobantes.OfType<AccesoDatos.Comprobante>()
                   .FirstOrDefault(x => x.Id == comprobanteid).Numero;



            }
        }

        public int ObtenerProximoNumero()
        {
            using (var context = new ModeloXCommerceContainer())
            {
                if (context.Comprobantes.OfType<AccesoDatos.Comprobante>().Any())
                {
                    return context.Comprobantes
                             .OfType<AccesoDatos.Comprobante>()
                             .Max(x => x.Numero) + 1;

                }
                else
                {
                    return 1;
                }

                
                

            }
        }
    }
}
