using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcom.AccesoDatos;
using Xcom.Servicio.Core.FormaPago.DTOs;

namespace Xcom.Servicio.Core.FormaPago
{
  public  class FormaPagoServicio : IFormaPagoServicio
    {
        public long InsertarCte(FormaPagoDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {


                var nuevoFormaPagoCtaCte = new FormaPagoCtaCte
                {
                    ClienteId = dto.clienteId,
                    ComprobanteId = dto.ComprobanteId,
                    Monto = dto.Monto,
                    TipoFormaPago = dto.FormaPago,
                    EstaPagado = false,
                };

                context.FormasPagos.Add(nuevoFormaPagoCtaCte);

                context.SaveChanges();

                return nuevoFormaPagoCtaCte.Id;

                  
            }
        }

        public long InsertarEfectivo(FormaPagoDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {


                var nuevoFormaPagoEfectivo = new FormaPagoEfectivo
                {
                    ClienteId = dto.clienteId,
                    ComprobanteId = dto.ComprobanteId,
                    Monto = dto.Monto,
                    TipoFormaPago = dto.FormaPago,

                };

                context.FormasPagos.Add(nuevoFormaPagoEfectivo);

                context.SaveChanges();

                return nuevoFormaPagoEfectivo.Id;

            }
        }

        public IEnumerable<CtaCteDto> ObtenerPorId(long IdCliente  )
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.FormasPagos.OfType<FormaPagoCtaCte>()
                    .Where(x => x.ClienteId == IdCliente )
                    .Select(x => new CtaCteDto
                    {
                        Id = x.Id,
                        comprobanteId = x.ComprobanteId,
                        Monto = x.Monto,
                        Fecha = x.Comprobante.Fecha,
                        NumeroComprobante = x.Comprobante.Numero,
                        EstaPagado = x.EstaPagado,

                    }).ToList();
            }
        }

        public IEnumerable<EfectivoDto> ObtenerporId(long IdCliente)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.FormasPagos.OfType<FormaPagoEfectivo>()
                    .Where(x => x.ClienteId == IdCliente)
                    .Select(x => new EfectivoDto
                    {
                        Id = x.Id,
                        comprobanteId = x.ComprobanteId,
                        Monto = x.Monto,
                        Fecha = x.Comprobante.Fecha,
                        NumeroComprobante = x.Comprobante.Numero,

                    }).ToList();
            }
        }




    }
}
