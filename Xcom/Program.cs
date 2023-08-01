using Pesentacion.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xcom.Servicio.Seguridad.Seguridad;
using Xcom.Servicio.Seguridad.Usuarios;

namespace Xcom
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // lanzo el forj¿mulario de login del sistema
            var fLogin = new Login(new AccesoSistema(), new UsuarioServicio());
            fLogin.ShowDialog();// abrir el formulario

            //verifico si puede o no acceder
            if (fLogin.PuedeAccederSistema)
            {
                Application.Run(new Principal());
            }
            else
            {
                Application.Exit(); // cierra app completa
            }


            
        }
    }
}
