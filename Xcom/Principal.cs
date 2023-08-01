namespace Xcom
{
    using System;
    using System.Windows.Forms;
    using Pesentacion.Seguridad.Seguridad;
    using Presentacion.Core.Articulo;
    using Presentacion.Core.BajaArticulo;
    using Presentacion.Core.caja;
    using Presentacion.Core.Cliente;
    using Presentacion.Core.CondicionIva;
    using Presentacion.Core.Empleado;
    using Presentacion.Core.Empresa;
    using Presentacion.Core.ListaPrecio;
    using Presentacion.Core.Localidad;
    using Presentacion.Core.Marca;
    using Presentacion.Core.Mesa;
    using Presentacion.Core.MotivoBaja;
    using Presentacion.Core.MotivoReserva;
    using Presentacion.Core.Provincia;
    using Presentacion.Core.Reserva;
    using Presentacion.Core.Rubro;
    using Presentacion.Core.Salon;
    using Presentacion.Core.VentaKiosko;
    using Presentacion.Core.VentaSalon;
    using Xcom.Servicio.Core.Caja;
    using static Presentacion.Helpers.DatosParaReUtilizadar;

    public partial class Principal : Form
    {
        protected readonly ICajaServicio cajaServicio;

        public Principal()
             : this(new CajaServicio())
        {
            InitializeComponent();
        }
        public Principal(ICajaServicio _cajaServicio)
          
        {
            cajaServicio = _cajaServicio;
        }

        private void consultaDeEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormEmpleadoConsulta = new _00001_Empleados();
            FormEmpleadoConsulta.ShowDialog();
        }

        private void provinciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formProvinciasConsulta = new _00005_Provincias();
            formProvinciasConsulta.ShowDialog();
        }

        private void localidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formLocalidadesConsulta = new _00007_Localidad();
            formLocalidadesConsulta.ShowDialog();

        }

        private void consultaClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormClienteConsulta = new _00003_Clientes();
            FormClienteConsulta.ShowDialog();
        }

        private void consutaMarcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormMarcas = new _00009_Marcas();
            FormMarcas.ShowDialog();
        }

        private void consultaRubrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormRubros = new _00011_Rubro();
            FormRubros.ShowDialog();
        }

        private void consultaProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormArticulo = new _00013_Articulo();
            FormArticulo.ShowDialog();
        }

        private void consultaListaDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormListaPrecio = new _00015_ListaPrecios();
            FormListaPrecio.ShowDialog();
        }

        private void consultaSalonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormSalon = new _00017_Salon();
            FormSalon.ShowDialog();
        }

        private void consultaMesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormMesa = new _00020_Mesa();
            FormMesa.ShowDialog();
        }

        private void consultaMotivosDeBajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormMotivoBaja = new _00023_MotivoBaja();
            FormMotivoBaja.ShowDialog();
        }

        private void consultaBajaDeArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormMotivoBaja = new _00025_BajaArticulo();
            FormMotivoBaja.ShowDialog();

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fUsuarios = new _00027_Usuarios();
            fUsuarios.ShowDialog();
        }

        private void consultaReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fReserva = new _00028_Reserva();
            fReserva.ShowDialog();
        }

        private void consultaEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fEmpresa = new _00030_Empresa();
            fEmpresa.ShowDialog();
        }

        private void condicionIvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FCondicionIva = new _00032_CondicionIva();
            FCondicionIva.ShowDialog();
        }

        private void consultaMotivosDeReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fMotivoReserva = new _00034_MotivoReserva();
            fMotivoReserva.ShowDialog();
        }

        private void ventasDelSalonToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            try
              {
                if (cajaServicio.VerificarSiExisteCajaAbierta(UsuarioLogueadoId.Value))
                {
                    var fVentasSalon = new _00036_VentaSalon();
                    fVentasSalon.ShowDialog();
                }
                else
                {
                    MessageBox.Show("debe abrir Caja antes de realizar ventas ");
                }

            }
               catch (Exception exception)
            {

                MessageBox.Show("Debe crear consumidor final", "Alerta");
            }

        }

        private void abrirCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!cajaServicio.VerificarSiExisteCajaAbierta(UsuarioLogueadoId.Value))
            {
                var fCaja = new _00040_Caja();
                fCaja.ShowDialog();
            }
            else
            {
                ActivarMenuCaja();
            }
            
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            

            if (!(NombreUsuarioLogueado == "a"))
            {

                lblUsuario.Text += "'" + NombreUsuarioLogueado + "'";
                
            }
            else
            {
                
                MessageBox.Show($"El usuario '{NombreUsuarioLogueado}' cuenta con algunas restricciones: NO PODRA USAR NINGUNA OPCION DE VENTA","ADVERTENCIA",MessageBoxButtons.OK,MessageBoxIcon.Information);
                lblUsuario.Text +="'" + NombreUsuarioLogueado + "'" + ": " + "Este Usuario cuenta con algunas restricciones: Caja, Salon y Kiosco entre otras cosas";
                
                pictureBox2.Enabled = false;
                cerrarCajamenu.Visible = false;
                AbrirCajamenu.Visible = false;
                cajaToolStripMenuItem.Visible = false;
                ImagenSalon.Enabled = false;
                ImagenKiosco.Enabled = false;
                ventasToolStripMenuItem.Visible = false;
            }
        }

        

      

        private void cerrarCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {



                var fCerrarCaja = new _00041_CajaCerrar();
                fCerrarCaja.ShowDialog();
              
          
            
            
            
        }

        void ActivarMenuCaja()
        {

            if (NombreUsuarioLogueado == "a")
            {
                cerrarCajamenu.Visible = false;
                AbrirCajamenu.Visible = false;
                MessageBox.Show("ingrese con usuario correcto");
                return;
            }

            if (cajaServicio.VerificarSiExisteCajaAbierta(UsuarioLogueadoId.Value))
            {
              //  btn_menu.Visible = false;

                cerrarCajamenu.Visible = true;
                AbrirCajamenu.Visible = false;

            }
            else
            {
               // btn_menu.Visible = false;
                cerrarCajamenu.Visible = false;
                AbrirCajamenu.Visible = true;
            }

        }

        private void cajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActivarMenuCaja();
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void ventaKioscoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cajaServicio.VerificarSiExisteCajaAbierta(UsuarioLogueadoId.Value))
                {
                    MessageBox.Show("debe abrir caja antes de realizar ventas");
                    return;
                }
                var FKiosko = new _00043_VentaKiosko();
                FKiosko.ShowDialog();
            }
            catch (Exception exception)
            {
               MessageBox.Show("Debe crear consumidor final","Alerta");
            }
            ;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cajaServicio.VerificarSiExisteCajaAbierta(UsuarioLogueadoId.Value))
                {
                    var fCaja = new _00040_Caja();
                    fCaja.ShowDialog();
                }
                else
                {
                    var fCerrarCaja = new _00041_CajaCerrar();
                    fCerrarCaja.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                if (!(NombreUsuarioLogueado == "a"))
                {
                    MessageBox.Show("Por favor ingrese un monton correcto antes de cerrar caja");
                }
                else
                {
                    MessageBox.Show("Debe crear consumidor final","Alerta");
                }

            }
            
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
           // pictureBox2.BackColor = Presentacion.Constantes.Color.ColorFondo;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
          //  pictureBox2.BackColor = Presentacion.Constantes.Color.ColorMenu;
        }

        private void ImagenSalon_Click(object sender, EventArgs e)
        {
            try
            {
                if (cajaServicio.VerificarSiExisteCajaAbierta(UsuarioLogueadoId.Value))
                {
                    var fVentasSalon = new _00036_VentaSalon();
                    fVentasSalon.ShowDialog();
                }
                else
                {
                    MessageBox.Show("debe abrrir Caja antes de realizar ventas ");
                }
            }
            catch (Exception exception)
            {
               MessageBox.Show("Debe crear consumidor final","Alerta");
            }
            
        }

        private void ImagenSalon_MouseEnter(object sender, EventArgs e)
        {

          //  ImagenSalon.BackColor = Presentacion.Constantes.Color.ColorFondo;
        }

        private void ImagenSalon_MouseLeave(object sender, EventArgs e)
        {

         //   ImagenSalon.BackColor = Presentacion.Constantes.Color.ColorMenu;
        }

        private void ImagenKiosco_Click(object sender, EventArgs e)
        {
            try
            {
                if (UsuarioLogueadoId.Value !=null)
                {
                    if (!cajaServicio.VerificarSiExisteCajaAbierta(UsuarioLogueadoId.Value))
                    {
                        MessageBox.Show("debe abrir caja antes de realizar ventas");
                        return;
                    }
                    var FKiosko = new _00043_VentaKiosko();
                    FKiosko.ShowDialog();
                }
                else
                {
                    MessageBox.Show("no esta logueado");
                    return;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Debe crear consumidor final","Alerta");
            }
            

        }

        private void ImagenKiosco_MouseEnter(object sender, EventArgs e)
        {

          //  ImagenKiosco.BackColor = Presentacion.Constantes.Color.ColorFondo;
        }

        private void ImagenKiosco_MouseLeave(object sender, EventArgs e)
        {
         //   ImagenKiosco.BackColor = Presentacion.Constantes.Color.ColorMenu;

        }

      
            

        private void btn_menu_Click(object sender, EventArgs e)
        {
            
            if (pnl_menu.Visible == true)
            {
                pnl_menu.Visible = false;
            }
            else
            {
                pnl_menu.Visible = true;
            }
        }
    }
}
