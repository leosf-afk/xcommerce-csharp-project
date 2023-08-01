namespace Xcom.Servicio.Core.Articulo.DTOs
{
    using Xcom.Servicio.Core.Base;

    public class ArticuloDto: BaseDTOs
    {
        public string Codigo { get; set; }

        public string CodigoBarra { get; set; }

        public string Abreviatura { get; set; }

        public string Descripcion { get; set; }

        public string Detalle { get; set; }

        public byte[] Foto { get; set; }

        public bool ActivarLimiteVenta  { get; set; }

        public decimal LimiteVenta  { get; set; }

        public bool PermitirStockNegativo { get; set; }

        public bool EstaDescontinuado { get; set; }

        public decimal StockMaximo { get; set; }

        public decimal StockMinimo { get; set; }

        public bool  DescuentoStock { get; set; }

        public long MarcaId { get; set; }

        public long RubroId { get; set; }

        public decimal Stock { get; set; }

        //______________________________________________________________//

      
    }
}
