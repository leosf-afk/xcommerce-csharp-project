

namespace Xcom.Servicio.Core.Mesa.DTOs
{
    using Xcom.AccesoDatos;
    using Xcom.Servicio.Core.Base;

    public class MesaDto : BaseDTOs
    {
        public int Numero { get; set; }

        public string Descripcion { get; set; }

        public long SalonId { get; set; }

        public EstadoMesa EstadoMesa { get; set; }


    }
}
