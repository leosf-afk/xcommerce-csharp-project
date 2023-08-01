using Presentacion.Core.Empleado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xcom.Servicio.Core.Caja;
using Xcom.Servicio.Core.Empleado;
using Xcom.Servicio.Seguridad.Seguridad;
using Xcom.Servicio.Seguridad.Usuarios;
using static Presentacion.Helpers.DatosParaReUtilizadar;
namespace Pesentacion.Seguridad

{
    public partial class Login : Form
    {
        //atributos   / variables



        private readonly IAccesoSistema _accesoSistema;

        private readonly IUsuarioServicio _usuarioServicio;

        protected readonly IEmpleadoServicio empleadoServicio;

        protected readonly ICajaServicio cajaServicio;

        private int _cantidadAccesosFallidos;

        //propiedades

        public bool PuedeAccederSistema { get; protected set;}



        public Login()
        {
            InitializeComponent();
        }

        public Login(IAccesoSistema accesoSistema , IUsuarioServicio usuarioServicio)
         :this()
        {
            _accesoSistema = accesoSistema;
            _usuarioServicio = usuarioServicio;
            empleadoServicio = new EmpleadoServicio();
            cajaServicio = new CajaServicio();
            _cantidadAccesosFallidos = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
          

                // 1- Verificar si esta cargado el usuario 

                // 2- verificar si esta cargado el password

                if (VerificarDatosObligatorios())
                {

                    // 3- verificar si el usuario y password estan correctas

                    if (_accesoSistema.verificarSiExisteUsiario(TxtUsuario.Text, TxtPassword.Text))
                    {
                    // 5- verivicar si esta bloqueado

                    

                        if (!_accesoSistema.VerificarSiEstaBloqueadoUsuario(TxtUsuario.Text))
                        {
                            PuedeAccederSistema = true;
                            
                            NombreUsuarioLogueado = TxtUsuario.Text;

                            var x = _usuarioServicio.ObtenerPorUsuario(NombreUsuarioLogueado);
                        if (x != null)
                        {
                            UsuarioLogueadoId = x.Id;

                            //Id del usuarioque abrio la caja
                            CajaIdAbierta = UsuarioLogueadoId.Value;
                        }
                           
                      

                        var Usuarios = _usuarioServicio.Obtener(string.Empty);
                        foreach (var Usuario in Usuarios)
                        {
                            if (Usuario.Nombre == NombreUsuarioLogueado)
                            {
                                UsuarioLogueadoId = Usuario.Id;

                                break;
                            }
                        }

                        this.Close(); // cierra formulario de login
                        }
                        else
                        {
                            // 6- si esta bloqueado mostrar mensaje 

                            PuedeAccederSistema = false;

                            MessageBox.Show(@"El Usuario esta Bloqueado");

                            TxtUsuario.Clear();

                            TxtPassword.Clear();

                            TxtUsuario.Focus();

                            _cantidadAccesosFallidos = 0;

                            return;
                        }
                    }
                    else
                    {
                        // 4- si no existen mostrar menssaje

                        PuedeAccederSistema = false;

                        MessageBox.Show(@"El Usuario o la contraseña son incorectos");

                        TxtPassword.Clear();

                        TxtPassword.Focus();



                        //intentos fallidos incrementar 

                        _cantidadAccesosFallidos++;

                        if (_cantidadAccesosFallidos >= 3)
                        {
                            try
                            {
                                // Bloquear Usuario y notificar al usario que esta bloqueado

                                _usuarioServicio.CambiarEstado(TxtUsuario.Text, true);
                                MessageBox.Show(@"El Usuario FUE BLOQUEADO. COMUNICARSE CON EL ADMINISTRADOR");
                                Application.Exit();
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show(exception.Message);
                                TxtPassword.Clear();
                                TxtPassword.Focus();
                            }


                        }
                    }

                }




                      // 7- cuando este correcto ingresar al sistema
        }

        private bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(TxtUsuario.Text))
            {

                MessageBox.Show(@"el nombre de usuario es obligatorio.");
                return false;
            }
            if (string.IsNullOrEmpty(TxtUsuario.Text))
            {

                MessageBox.Show(@" El password es obligatorio.");

                return false;
            }
            return true;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
