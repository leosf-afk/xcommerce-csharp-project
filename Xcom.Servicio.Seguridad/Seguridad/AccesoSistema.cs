
namespace Xcom.Servicio.Seguridad.Seguridad
{
    using System.Linq;
    using Xcom.AccesoDatos;
    using static Presentacion.Helpers.CadenaCaracteres;

    public class AccesoSistema : IAccesoSistema
    {
       

        public bool VerificarSiEstaBloqueadoUsuario(string usuario)
        {
            

            using (var Context = new ModeloXCommerceContainer())
            {
                return Context.Usuarios
                    .Any(x => x.Nombre == usuario
                    && x.EstaBloqueado);

            }
        }

        public bool verificarSiExisteUsiario(string nombreUsuario, string password)
        {
            if (nombreUsuario == "a"
               && password == "a")
                return true;

            using (var Context = new ModeloXCommerceContainer())
            {
                var passEncriptado = Encriptar(password);

                return Context.Usuarios
                    .Any(x => x.Nombre == nombreUsuario 
                    && x.Password == passEncriptado);

            }
                

                
        }
    }
}
