using Presentacion.Core.Comprobante;
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
using Xcom.Servicio.Core.Cliente;
using Xcom.Servicio.Core.FormaPago;
using Xcom.Servicio.Core.FormaPago.DTOs;

namespace Presentacion.Core.Empleado
{
    public partial class _00044_Cliente_Cta_Cte : FormularioConsulta
    {
        protected readonly IFormaPagoServicio formaPagoServicio;

        protected readonly IClienteServicio clienteServicio;
        

        long ClienteID;
        public _00044_Cliente_Cta_Cte()
        {
            InitializeComponent();


        }

        public _00044_Cliente_Cta_Cte(long ClienteId )
        {
            formaPagoServicio = new FormaPagoServicio();

            clienteServicio = new ClienteServicio();
            ClienteID = ClienteId;

            Inicializador();
           
        }


        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);


            grilla.Columns["NumeroComprobante"].Visible = true;
            grilla.Columns["NumeroComprobante"].Width = 100;
            grilla.Columns["NumeroComprobante"].HeaderText = "Numero Comprobante";
            grilla.Columns["NumeroComprobante"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grilla.Columns["Fecha"].Visible = true;
            grilla.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Fecha"].HeaderText = "Fecha";
            grilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Monto"].Visible = true;
            grilla.Columns["Monto"].Width = 100;
            grilla.Columns["Monto"].HeaderText = "Monto";
            grilla.Columns["Monto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaPagadoStr"].Visible = true;
            grilla.Columns["EstaPagadoStr"].Width = 100;
            grilla.Columns["EstaPagadoStr"].HeaderText = "Pagado";
            grilla.Columns["EstaPagadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        public override void ActualizarDatos(DataGridView grilla , string CB )
        {
            grilla.DataSource = formaPagoServicio.ObtenerPorId(ClienteID);
        }

        private void _00044_Cliente_Cta_Cte_Load(object sender, EventArgs e)
        {

            ActualizarDatos(dgvGrilla, string.Empty);

           
        }

        public override void EjecutarNuevo()
        {
            if (dgvGrilla.SelectedRows.Count == 1)
            {
                var x = ((CtaCteDto)dgvGrilla.CurrentRow.DataBoundItem).comprobanteId;
                var FComprobante = new _00045_Comprobante(x);
                FComprobante.ShowDialog();
            }
            else
            {
                clienteServicio.PagarCtaCte(ClienteID);

                MessageBox.Show("no hay Datos Cargados", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
             
        }



        void Inicializador()
        {

            btnEliminar.Visible = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnModificar.Visible = false;
            btnActualizar.Visible = false;
            btnActualizar.Enabled = false;
            ImagenBuscar.Visible = false;
            btnNuevo.Text = "Ver Comprobante";
            btnNuevo.Image = Constantes.Imagen.ImagenOjo;
            panel2.Visible = false;
            lblCondicion.Visible = false;
            cmbCondicion.Visible = false;
            cmbCondicion.Enabled = false;
            lblDeuda.Visible = true;
            txtDeuda.Visible = true;
            btnPagar.Visible = true;
            btnPagar.Enabled = true;
            lblCtaPersona.Visible = true;

            lblCtaPersona.Text += clienteServicio.ObtenerPorId(ClienteID).ApyNom;
            lblCtaPersona.BackColor = Constantes.Color.ColorMenu;

            txtDeuda.Text = formaPagoServicio.ObtenerPorId(ClienteID).Where(x => x.EstaPagado == false).Sum(x => x.Monto).ToString(); 

        }

        

        public override void ejecutarPagarctacte()
        {
            if (!(decimal.Parse(txtDeuda.Text) == 0))
            {
                clienteServicio.PagarCtaCte(ClienteID);
                MessageBox.Show("Se a cancelado la deuda correctamente", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ActualizarDatos(dgvGrilla, string.Empty);
                txtDeuda.Text = formaPagoServicio.ObtenerPorId(ClienteID).Where(x => x.EstaPagado == false).Sum(x => x.Monto).ToString();

              
            }
            else
            {
                MessageBox.Show("El cliente no tiene que pagar ", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error); 
            }
            
            
        }
    }
}
