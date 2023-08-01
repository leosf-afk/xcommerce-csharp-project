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

namespace Presentacion.Core.Cliente
{
    public partial class _00045_Cliente_Efectivo : FormularioConsulta
    {
        protected readonly IFormaPagoServicio formaPagoServicio;

        protected readonly IClienteServicio clienteServicio;

        long ClienteID;

     

        public _00045_Cliente_Efectivo(long ClienteId)
        {
            InitializeComponent();

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

           


        }

        public override void ActualizarDatos(DataGridView grilla, string CB)
        {
            grilla.DataSource = formaPagoServicio.ObtenerporId(ClienteID);
        }

        private void _00045_Cliente_Efectivo_Load(object sender, EventArgs e)
        {

            ActualizarDatos(dgvGrilla, string.Empty);
        }


        public override void EjecutarNuevo()
        {
            if (dgvGrilla.SelectedRows.Count == 1)
            {
                var x = ((EfectivoDto)dgvGrilla.CurrentRow.DataBoundItem).comprobanteId;
                var FComprobante = new _00045_Comprobante(x);
                FComprobante.ShowDialog();
            }
            else
            {

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
            lblDeuda.Visible = false;
            txtDeuda.Visible = false;
            btnPagar.Visible = false;
            btnPagar.Enabled = false;
            lblCtaPersona.Visible = true;

            lblCtaPersona.Text += clienteServicio.ObtenerPorId(ClienteID).ApyNom;
            lblCtaPersona.BackColor = Constantes.Color.ColorMenu;
        }


    }
}
