

namespace Xcom.Servicio.Core.Salon.DTOs
{
    using Xcom.AccesoDatos;

    public  class MesasSalonDto
    {


        public string NombreMesa { get; set; }

        public int NumeroMesa { get; set; }

        public EstadoMesa EstadoMesa { get; set; }

        public long Id { get; set; }

        public long MesaSalonId {get; set;}

        public bool EstaEliminado { get; set; }

        public long listaDePrecioId { get; set; }
    }
}
