using Presentacion.Core.Articulo;
using Presentacion.Core.Cliente;
using Presentacion.Core.Empleado;
using Presentacion.Core.FormaPago;
using Presentacion.Core.Mesa.Control;
using System;
using System.Linq;
using System.Windows.Forms;
using Xcom.Servicio.Core.Articulo;
using Xcom.Servicio.Core.Comprobante;
using Xcom.Servicio.Core.Comprobante.DTOs;
using Xcom.Servicio.Core.Empleado;
using Xcom.Servicio.Core.Mesa;

namespace Presentacion.Core.VentaSalon
{
    public partial class _00037_ComprobanteMesa : FormularioBase.FormularioBase
    {


        private readonly long _mesaId;

        
        private readonly IComprobanteSalonServicio _comprobanteSalonServicio;

        private readonly IArticuloServicio _articuloServicio;

        private readonly IEmpleadoServicio _empleadoServicio;

        public _00037_ComprobanteMesa()
            : this(new ComprobanteSalonServicio(), new ArticuloServicio(), new EmpleadoServicio() )
        {
            InitializeComponent();

            this.BackColor = Constantes.Color.ColorFondo;

            txtCodigo.MaxLength = 10;


        }

        public _00037_ComprobanteMesa(IComprobanteSalonServicio comprobanteSalonServicio, IArticuloServicio articuloServicio, IEmpleadoServicio empleadoServicio) 
        {
            _comprobanteSalonServicio = comprobanteSalonServicio;

            _articuloServicio = articuloServicio;

            _empleadoServicio = empleadoServicio;


        }

        public _00037_ComprobanteMesa(long mesaId, int numeroMesa  )
            : this()
        {

            this.Text = $"Venta - Mesa {numeroMesa}";

            _mesaId = mesaId;

            

            ObtenerComprobanteMesa(mesaId);

            txtCodigo.KeyPress += Presentacion.Helpers.Validacion.NoLetras;
            txtCodigo.KeyPress += Presentacion.Helpers.Validacion.NoSimbolos;
            txtMozoLegajo.KeyPress += Presentacion.Helpers.Validacion.NoLetras;
            txtMozoLegajo.KeyPress += Presentacion.Helpers.Validacion.NoSimbolos;

            txtCodigo.MaxLength = 20;
        }

        private void ObtenerComprobanteMesa(long mesaId)
        {
            var comprobanteMesaDto = _comprobanteSalonServicio.Obtener(_mesaId);

          
            var detalle = _comprobanteSalonServicio.ObtenerDetalle(comprobanteMesaDto.ComprobanteId);

         

            if (comprobanteMesaDto == null)
            {
                MessageBox.Show("ocurrio un error");
                this.Close();
            }

            txtMozo.Text = comprobanteMesaDto.ApyNom;
            txtMozoLegajo.Text = comprobanteMesaDto.Legajo.ToString();

            nudSubTotal.Value = comprobanteMesaDto.SubTotal;
            nuddescuento.Value = comprobanteMesaDto.Descuento;
            nudTotal.Value = comprobanteMesaDto.Total;

            
                dgvFacturar.DataSource = detalle;
            

          


        }

        public void FormatearGrilla(DataGridView grilla)
        {




            for (int i = 0; i < grilla.ColumnCount; i++)
            {
                grilla.Columns[i].Visible = false;
            }


            grilla.Columns["CodigoProducto"].Visible = true;
            grilla.Columns["CodigoProducto"].Width = 60;
            grilla.Columns["CodigoProducto"].HeaderText = "Codigo";
            grilla.Columns["CodigoProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["CodigoProducto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            grilla.Columns["DescripcionProducto"].Visible = true;
            grilla.Columns["DescripcionProducto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["DescripcionProducto"].HeaderText = "Descripcion";
            grilla.Columns["DescripcionProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["DescripcionProducto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grilla.Columns["PrecioUnitario"].Visible = true;
            grilla.Columns["PrecioUnitario"].Width = 120;
            grilla.Columns["PrecioUnitario"].HeaderText = " Precio Unitario";
            grilla.Columns["PrecioUnitario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["PrecioUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grilla.Columns["Cantidad"].Visible = true;
            grilla.Columns["Cantidad"].Width = 100;
            grilla.Columns["Cantidad"].HeaderText = "Cantidad";
            grilla.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grilla.Columns["SubTotalLinea"].Visible = true;
            grilla.Columns["SubTotalLinea"].Width = 100;
            grilla.Columns["SubTotalLinea"].HeaderText = @"SubTotal";
            grilla.Columns["SubTotalLinea"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["SubTotalLinea"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;





        }



        private void _00037_ComprobanteMesa_Load(object sender, System.EventArgs e)
        {
            FormatearGrilla(dgvFacturar);
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)

        {
            if ((char)Keys.Enter == e.KeyChar)
            {
                if (txtCodigo.Text == string.Empty)
                {
                    return;
                }

                if (!_articuloServicio.VerificarPorCodigo(txtCodigo.Text))
                {
                    MessageBox.Show("No exixte ningun producto con ese codigo ");
                    return;
                }
               

                if (string.IsNullOrEmpty(txtCodigo.Text))
                {
                    MessageBox.Show("Porfavor Ingrese un codigo");
                    return;
                }


                var Producto = _articuloServicio.ObtenerPorCodigoMesa(txtCodigo.Text, _mesaId);

                if (Producto != null)
                {
                    _comprobanteSalonServicio.AgregarItem(_mesaId, nudCantidad.Value, Producto);

                    ObtenerComprobanteMesa(_mesaId);


                }

                txtCodigo.Clear();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMozo.Text == "NO ASIGNADO")
            {
                MessageBox.Show("Debe Asignar un Mozo ");
                return;
            }
            if (dgvFacturar.RowCount <= 0)
            {
                MessageBox.Show("No hay productos cargados ");

                return;
            }


            
            var t = _comprobanteSalonServicio.Obtener(_mesaId);
         

            var fFormaPago = new _00042_FormaPagoSalon(nudTotal.Value , nudSubTotal.Value , nuddescuento.Value, (int)nudComesales.Value , t.ComprobanteId , _mesaId);

            fFormaPago.ShowDialog();
            if (_00042_FormaPagoSalon.Pagado)
            {
                this.Close();
            }
           
        }

        private void txtMozoLegajo_TextChanged(object sender, EventArgs e)
        {

        }



        private void txtMozoLegajo_KeyPress_1(object sender, KeyPressEventArgs e)
        {


            if ((char)Keys.Enter == e.KeyChar)
            {
                if (txtMozoLegajo.Text == string.Empty)
                {
                    return;
                }

             
                var Mozo = _empleadoServicio.ObtenerPorLegajo(long.Parse(txtMozoLegajo.Text));

                if (Mozo != null)
                {

                    var t = _comprobanteSalonServicio.Obtener(_mesaId);
                    txtMozo.Text = Mozo.ApyNom;
                    _comprobanteSalonServicio.AsignarMozo( t.ComprobanteId , Mozo.Id);
                }
                else
                {
                    MessageBox.Show("No exixte ese numero de legajo");
                }

            }

        }

        private void nuddescuento_KeyUp(object sender, KeyEventArgs e)
        {

            nudTotal.Value = (nudSubTotal.Value - (nudSubTotal.Value * (nuddescuento.Value / 100)));

        }

        private void btnMozo_Click(object sender, EventArgs e)
        {
            var formMozo = new _00001_Empleados(true);
            formMozo.ShowDialog();

            var mozo = _00001_Empleados.EmpleadoSeleccionado;
            if ( mozo != null)
            {
                var t = _comprobanteSalonServicio.Obtener(_mesaId);
                txtMozo.Text = mozo.ApyNom;
                txtMozoLegajo.Text = mozo.Legajo.ToString();

                _comprobanteSalonServicio.AsignarMozo(t.ComprobanteId, mozo.Id);
            }
           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
              

             if (txtCodigo.Text == string.Empty)
             {
                    var FromArticulo = new _00013_Articulo(true);
                    FromArticulo.ShowDialog();
                if (_00013_Articulo.ArticuloSeleccionado != null)
                {

                    var Producto0 = _articuloServicio.ObtenerPorCodigoMesa(_00013_Articulo.ArticuloSeleccionado.Codigo, _mesaId);
                    if (Producto0 != null)
                    {


                        txtPrecioUnitario.Text = Producto0.Precio.ToString();
                        txtProducto.Text = Producto0.Descripcion;
                        txtCodigo.Text = Producto0.Codigo;

                        return;
                    }
                    else
                    {
                        MessageBox.Show("ocurrio un error al obtener el articulo");
                    }
                }
             }

                if (!_articuloServicio.VerificarPorCodigo(txtCodigo.Text))
                {
                    MessageBox.Show("No exixte ningun producto con ese codigo ");
                    return;
                }


                if (string.IsNullOrEmpty(txtCodigo.Text))
                {
                    MessageBox.Show("Porfavor Ingrese un codigo");
                    return;
                }


                var Producto = _articuloServicio.ObtenerPorCodigoMesa(txtCodigo.Text, _mesaId);

                if (Producto != null)
                {
                    _comprobanteSalonServicio.AgregarItem(_mesaId, nudCantidad.Value, Producto);

                    ObtenerComprobanteMesa(_mesaId);


                }

                txtCodigo.Clear();
                txtProducto.Clear();
                txtPrecioUnitario.Clear();
            }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            var Comprobar = _articuloServicio.VerificarPorCodigo(txtCodigo.Text);
            if (Comprobar)
            {

            }
            else
            {
                txtProducto.Clear();
                txtPrecioUnitario.Clear();
            }
        }

        private void dgvFacturar_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((char)Keys.Back == e.KeyChar)
            {
                if (dgvFacturar.SelectedRows.Count == 1)
                {
                    var Borrar = (DetalleComprobanteSalonDto)dgvFacturar.CurrentRow.DataBoundItem;
                    _comprobanteSalonServicio.EliminarItem(Borrar);


                    ObtenerComprobanteMesa(_mesaId);
                }
               
            }
        }

        private void nuddescuento_ValueChanged(object sender, EventArgs e)
        {
            nudTotal.Value = (nudSubTotal.Value - (nudSubTotal.Value * (nuddescuento.Value / 100)));
        }
    }
}