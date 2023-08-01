

namespace Xcom.Servicio.Core.BajaArticulo.DTOs
{
    using System;

    public class ArticuloBajaDto
    {
        public long Id { get; set; }

        public string ArticuloDescripcion { get; set; }

        public decimal Cantidad { get; set; }

        public string MotivoBaja { get; set; }

        public long MotivoBajaId { get; set; }

        public DateTime FechaBaja { get; set; }

      

        public string Observacion { get; set; }

       

        public long ArticuloId { get; set; }

      
    }
}
