using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcom.Servicio.Core.Base;

namespace Xcom.Servicio.Core.Articulo.DTOs
{
   public class ArticuloMesaDto : BaseDTOs
    {
        public string Codigo { get; set; }

        public string CodigoBarra { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public bool DescuentaStock { get; set; }

        public bool StockNegativo { get; set; }

      

    }
}
