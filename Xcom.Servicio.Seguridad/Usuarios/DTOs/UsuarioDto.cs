namespace Xcom.Servicio.Seguridad.Usuarios.DTOs
{
    public class UsuarioDto
    {

        public long Id { get; set; }

        public long PersonaId { get; set; }

        public string Apellidpersona { get; set; }

        public string NombrePersona { get; set; }

       public string ApyNom => $"{Apellidpersona} {NombrePersona}";

       public string Nombre { get; set; }

       public bool EstaBloqueado { get; set; }

       public string EstaBloqueadoStr => EstaBloqueado ? "SI" : "NO";

    }
}
