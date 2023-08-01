using Presentacion.FormularioBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xcom.Servicio.Core.Caja;
using Xcom.Servicio.Core.Caja.DTOs;
using Xcom.Servicio.Seguridad.Usuarios;
using Xcom.Servicio.Seguridad.Usuarios.DTOs;
using static Presentacion.Helpers.DatosParaReUtilizadar;
namespace Presentacion.Core.caja
{
    public partial class _00040_Caja : FormularioBase.FormularioBase
    {
        protected readonly ICajaServicio cajaServicio;

        protected readonly IUsuarioServicio usuarioServicio;

        
        bool CajaAbierta;

      
        

        public _00040_Caja()
        {
            InitializeComponent();

            cajaServicio = new CajaServicio();

            usuarioServicio = new UsuarioServicio();
            lblUsuario.Text += NombreUsuarioLogueado;
            this.BackColor = Presentacion.Constantes.Color.ColorFondo;
            btnAbrirCerrarCaja.BackColor = Presentacion.Constantes.Color.ColorMenu;
            lblFecha.Text += DateTime.Now.ToString();
            CajaAbierta = false;
            

        }

        private void btnAbrirCerrarCaja_Click(object sender, EventArgs e)
        {
            
          
            ////////////////////////////
            if (!cajaServicio.VerificarSiExisteCajaAbierta(UsuarioLogueadoId.Value))
            {
                if (UsuarioLogueadoId != null)
                {

                  CajaIdAbierta =  cajaServicio.Abrir(UsuarioLogueadoId.Value, nudMontoApertura.Value);

                    CajaAbierta = true;
                    EstadodeCajaAbiertaCerrada = CajaAbierta;
                    MessageBox.Show("La caja se abrio correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ocurrio un error al abrir la caja");
                }
            }
            else
            {
                MessageBox.Show($"La caja ya se encuentra abierta con el usuario {NombreUsuarioLogueado}");
            }
          

        }




    }
}
