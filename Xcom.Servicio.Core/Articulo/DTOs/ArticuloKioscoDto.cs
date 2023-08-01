using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcom.Servicio.Core.Articulo.DTOs
{
   public  class ArticuloKioscoDto
    {
        public long ArticuloId { get; set; }

        public string Codigo { get; set; }

        public string CodigoBarra { get; set; }

        public string Descripcion { get; set; }

        public decimal cantidad { get; set; }

        public decimal Precio { get; set; }

        public bool DescuentaStock { get; set; }

        public bool StockNegativo { get; set; }

        public decimal SubTotal { get; set; }

    }
}
