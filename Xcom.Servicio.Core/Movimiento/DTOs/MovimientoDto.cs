using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcom.AccesoDatos;

namespace Xcom.Servicio.Core.Movimiento.DTOs
{
    public class MovimientoDto
    {

        public long Id { get; set; }

        public long CajaId { get; set; }

        public long ComprobanteId { get; set; }

        public TipoMovimiento TipoMovimento { get; set; }

        public long UsuarioId { get; set; }

        public decimal Monto { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

    }
}
