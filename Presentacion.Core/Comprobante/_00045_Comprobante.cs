using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xcom.Servicio.Core.Comprobante.Comprobantes;

namespace Presentacion.Core.Comprobante
{
    public partial class _00045_Comprobante : FormularioBase.FormularioBase
    {
        long _comprobanteID;
        protected readonly IComprobanteServicio comprobanteServicio;

        public _00045_Comprobante(long numero)

        {
            InitializeComponent();

            _comprobanteID = numero;

            comprobanteServicio = new ComprobanteServicio();
        }

        void cargarDatos()
        {
            lblTitulo.Text += comprobanteServicio.obtenernumero(_comprobanteID).ToString() ;

            lblPie.Text += comprobanteServicio.MontoDelcomprobante(_comprobanteID).ToString();
            

        }


        void ActualizarGrilla()
        {
            dgvGrilla.DataSource = comprobanteServicio.obtenerdetalleComprobante(_comprobanteID);

        }

        private void _00045_Comprobante_Load(object sender, EventArgs e)
        {

            ActualizarGrilla();
            FormatearGrilla();
            cargarDatos();
        }

        void FormatearGrilla()
        {



            for (int i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                dgvGrilla.Columns[i].Visible = false;
            }


            dgvGrilla.Columns["codigo"].Visible = true;
            dgvGrilla.Columns["codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["codigo"].HeaderText = " Codigo";
            dgvGrilla.Columns["codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dgvGrilla.Columns["descripcion"].Visible = true;
            dgvGrilla.Columns["descripcion"].Width = 150;
            dgvGrilla.Columns["descripcion"].HeaderText = " Descripcion";
            dgvGrilla.Columns["descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dgvGrilla.Columns["precioUnitario"].Visible = true;
            dgvGrilla.Columns["precioUnitario"].Width = 100;
            dgvGrilla.Columns["precioUnitario"].HeaderText = "Precio";
            dgvGrilla.Columns["precioUnitario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dgvGrilla.Columns["Cantidad"].Visible = true;
            dgvGrilla.Columns["Cantidad"].Width = 100;
            dgvGrilla.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvGrilla.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["subtotal"].Visible = true;
            dgvGrilla.Columns["subtotal"].Width = 100;
            dgvGrilla.Columns["subtotal"].HeaderText = @"subtotal";
            dgvGrilla.Columns["subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["subtotal"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }


        
    }
}
