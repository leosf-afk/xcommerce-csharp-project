using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xcom.AccesoDatos;
using Xcom.Servicio.Core.Caja;
using Xcom.Servicio.Core.Mesa;
using static Presentacion.Helpers.DatosParaReUtilizadar;

namespace Presentacion.Core.caja
{
    public partial class _00041_CajaCerrar : FormularioBase.FormularioBase
    {
        protected IMesaServicio mesaServicio;
        protected ICajaServicio cajaServicio; 

        public _00041_CajaCerrar()
        {
            InitializeComponent();
            this.BackColor = Presentacion.Constantes.Color.ColorFondo;
            btnCerrarCaja.BackColor = Presentacion.Constantes.Color.ColorMenu;
            mesaServicio = new Mesaservicio();
            cajaServicio = new CajaServicio();
            lblfechaCierre.Text += DateTime.Now.ToString();
            LblUsuarioLogueado.Text += NombreUsuarioLogueado;
            CargarDatos();
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (!verificarMesasAbiertas())
            {
                MessageBox.Show("Debe cerrar todas las mesas para cerrar caja ");
                return;
            }

            if (cajaServicio.VerificarSiExisteCajaAbierta(UsuarioLogueadoId.Value))
                {
                var sd = cajaServicio.ObtenerIdporUsuario(UsuarioLogueadoId.Value);

                    cajaServicio.Cerrar(UsuarioLogueadoId.Value, nudMontoCierre.Value, sd.Id, nudMontoSistema.Value);
                    EstadodeCajaAbiertaCerrada = false;
                MessageBox.Show("La Caja se Cerro corectamente");
                CajaIdAbierta = null;
                
                this.Close();

                }
                else
                {
                    MessageBox.Show("la caja se encuentra cerrada");
                }
           
        }

          void CargarDatos()
          {
            var sd = cajaServicio.ObtenerIdporUsuario(UsuarioLogueadoId.Value);

            if (sd == null)
            {
                MessageBox.Show("la caja se encuentra cerrada");
               
                return;
            }
            if (CajaIdAbierta > 0)
            {
                nudMontoSistema.Value = sd.MontoSistema;
            }
            else
            {
                MessageBox.Show(" La caja se encuentra cerrada");
                
            }
         


          }

        private void nudMontoCierre_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void nudMontoCierre_KeyUp(object sender, KeyEventArgs e)
        {
            nudDiferencia.Value = nudMontoCierre.Value - nudMontoSistema.Value ;
        }


        bool verificarMesasAbiertas()
        {

            var MesasAbiertas = mesaServicio.Obtener(string.Empty);
            foreach (var mesa in MesasAbiertas)
            {
                if (mesa.EstadoMesa == EstadoMesa.Abierta)
                {
                    return false;


                }

            }
            return true;

        }

    }
}
