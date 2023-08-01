namespace Xcom.Servicio.Core.Base
{
    public class BaseDTOs
    {

        public long Id { get; set; }

        public bool EstaEliminado { get; set; }

        public string EstaEliminadoStr => EstaEliminado ? "SI" : "NO";
    }
}
