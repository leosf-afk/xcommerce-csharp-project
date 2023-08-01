namespace Xcom.Servicio.Seguridad.Seguridad
{
    public interface IAccesoSistema
    {
        bool verificarSiExisteUsiario(string nombreUsuario, string password);

        bool VerificarSiEstaBloqueadoUsuario(string usuario);

        
    }
}
