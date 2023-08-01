using Presentacion.Core.Articulo;
using Presentacion.Core.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Xcom.AccesoDatos;
using Xcom.Servicio.Core.Articulo;
using Xcom.Servicio.Core.Articulo.DTOs;
using Xcom.Servicio.Core.Caja;
using Xcom.Servicio.Core.Cliente;
using Xcom.Servicio.Core.Cliente.Dtos;
using Xcom.Servicio.Core.Comprobante.Comprobantes;
using Xcom.Servicio.Core.Comprobante.DTOs;
using Xcom.Servicio.Core.Comprobante.Kiosco;
using Xcom.Servicio.Core.Comprobante.Kiosco.DTOs;
using Xcom.Servicio.Core.DetalleCaja;
using Xcom.Servicio.Core.DetalleCaja.DTOs;
using Xcom.Servicio.Core.FormaPago;
using Xcom.Servicio.Core.FormaPago.DTOs;
using Xcom.Servicio.Core.Movimiento;
using Xcom.Servicio.Core.Movimiento.DTOs;
using Xcom.Servicio.Core.Precio;
using Xcom.Servicio.Core.Precio.DTOs;
using static Presentacion.Helpers.DatosParaReUtilizadar;
namespace Presentacion.Core.VentaKiosko
{
    public partial class _00043_VentaKiosko : FormularioBase.FormularioBase
    {
        private readonly IComprobanteKioscoServicio _comprobanteKioskoServicio;

        protected readonly IClienteServicio clienteServicio;

        protected readonly IDetalleCajaServicio detalleCajaServicio;

        private readonly IArticuloServicio _articuloServicio;

        private readonly IComprobanteServicio _comprobanteServicio;

        private readonly IMovimientoServicio _movimientoServicio;

        protected readonly ICajaServicio CajaServicio;

        protected readonly IFormaPagoServicio formaPagoServicio;

        protected readonly IPrecioServicio precioServicio;

        List<ArticuloKioscoDto> articulos;

        long?  ComprobanteId;

        public _00043_VentaKiosko()
        {
            InitializeComponent();

            this.BackColor = Constantes.Color.ColorFondo;
            _comprobanteKioskoServicio = new ComprobanteKioscoServicio();

            clienteServicio = new ClienteServicio();
            CajaServicio = new CajaServicio();
            articulos = new List<ArticuloKioscoDto>();
            _articuloServicio = new ArticuloServicio();
            detalleCajaServicio = new DetalleCajaServicio();
            _movimientoServicio = new MovimientoServicio();
            _comprobanteServicio = new ComprobanteServicio();
            formaPagoServicio = new FormaPagoServicio();
            precioServicio = new PrecioServicio();
            FormatearGrilla(dgvFacturar);

            lblCtaCte.Visible = false;
            txtctacte.Visible = false;

            cargarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (articulos.Count > 0)
            {
                if (txtCLiente.Text == null)
                {
                    MessageBox.Show("Debe Seleccionar un un Cliente");
                    return;
                }
                var x = TipoPago.CtaCte;
                if (cmbTipoPago.Text.Equals("Efectivo"))
                {
                    x = TipoPago.Efectivo;
                }
                



                if (x == TipoPago.CtaCte && txtCLiente.Text == "Consumidor Final")
                {
                    MessageBox.Show("Debe seleccionar un cliente");
                    return;
                }




                if (x == TipoPago.CtaCte)
                {
                    if (decimal.Parse(txtctacte.Text) < nudTotal.Value)
                    {
                        MessageBox.Show("El Monto Supera La Disponibilidad en Cta Cte");
                        cmbTipoPago.SelectedItem = TipoPago.Efectivo;
                        lblCtaCte.Visible = false;
                        txtctacte.Visible = false;
                        return;
                    }
                }

                ComprobanteId =  _comprobanteKioskoServicio.Generar(GenerarComprobante());

                _comprobanteKioskoServicio.AgregarDetallesComprobante(DetalleComprobante());

                CajaIdAbierta = CajaServicio.ObtenerIdporUsuario(UsuarioLogueadoId.Value).Id;

                var NuevoDetalle = new DetalleCajaDto
                {
                    CajaId = CajaIdAbierta.Value,
                    Monto = nudTotal.Value,
                    TipoPago = x,


                };

                detalleCajaServicio.Insertar(NuevoDetalle);

                if ((TipoPago)cmbTipoPago.SelectedItem == TipoPago.Efectivo)
                {
                    CajaServicio.ActualizarMontoDelSistemaPorVenta(nudTotal.Value, CajaIdAbierta.Value);
                    formaPagoServicio.InsertarEfectivo(GenerarFormaPagoEfectivo());
                }
                else if((TipoPago)cmbTipoPago.SelectedItem == TipoPago.CtaCte)
                {
                    formaPagoServicio.InsertarCte(GenerarFormaPagoctacte());
                }

                _movimientoServicio.insertar(GenerarMovimientoDto());
              
                MessageBox.Show("Se Facturo Correctamente");
                Limpiar();
                
            }
            else
            {
                MessageBox.Show("no hay articulos cargados ");
            }
        }

        

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Enter == e.KeyChar)
            {
                if (txtCodigo.Text == string.Empty)
                {
                    var FromArticulo = new _00013_Articulo(true);
                    FromArticulo.ShowDialog();
                    if (_00013_Articulo.ArticuloSeleccionado != null)
                    {
                        txtProducto.Text = _00013_Articulo.ArticuloSeleccionado.Descripcion;
                        txtCodigo.Text = _00013_Articulo.ArticuloSeleccionado.Codigo;

                        var Precio =  precioServicio.ObtenerPorId (_00013_Articulo.ArticuloSeleccionado.Id).PrecioPublico;
                        txtPrecioUnitario.Text = Precio.ToString();
                        return;
                    }

                }
                if (!_articuloServicio.VerificarPorCodigo(txtCodigo.Text))
                {
                    MessageBox.Show("No exixte ningun producto con ese codigo ");
                    return;
                }

                var ArticuloAgregar = _articuloServicio.ObtenerventaKiosko(txtCodigo.Text , nudCantidad.Value);

                if (articulos.Count != 0 && articulos.Any(x=>x.ArticuloId == ArticuloAgregar.ArticuloId))
                {
                    foreach (var item in articulos)
                    {
                        if (item.ArticuloId == ArticuloAgregar.ArticuloId)
                        {
                            item.cantidad += ArticuloAgregar.cantidad;
                            item.SubTotal = item.cantidad * item.Precio;
                            Actualizargrilla(dgvFacturar, articulos);
                        }
                    }

                }
                else
                {
                    articulos.Add(ArticuloAgregar);
                    Actualizargrilla(dgvFacturar, articulos);
                }


                nudSubTotal.Value = articulos.Sum(x => x.SubTotal);
                nudTotal.Value = nudSubTotal.Value;

                nudTotal.Value = (nudSubTotal.Value - (nudSubTotal.Value * (nuddescuento.Value / 100)));

                txtCodigo.Clear();
            }
            else
            {
                
            }
           
        }

        void Actualizargrilla(DataGridView grilla , List<ArticuloKioscoDto> a )
        {
            grilla.DataSource = a.ToList();


        }

        public void FormatearGrilla(DataGridView grilla)
        {

            grilla.DataSource = articulos;
           

            for (int i = 0; i < grilla.ColumnCount; i++)
            {
                grilla.Columns[i].Visible = false;
            }




            grilla.Columns["CodigoBarra"].Visible = true;
            grilla.Columns["CodigoBarra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["CodigoBarra"].HeaderText = "Codigo de Barra";
            grilla.Columns["CodigoBarra"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["CodigoBarra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].Width = 200;
            grilla.Columns["Descripcion"].HeaderText = " Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grilla.Columns["Cantidad"].Visible = true;
            grilla.Columns["Cantidad"].Width = 100;
            grilla.Columns["Cantidad"].HeaderText = "Cantidad";
            grilla.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grilla.Columns["Precio"].Visible = true;
            grilla.Columns["Precio"].Width = 100;
            grilla.Columns["Precio"].HeaderText = @"Precio";
            grilla.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Precio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grilla.Columns["SubTotal"].Visible = true;
            grilla.Columns["SubTotal"].Width = 100;
            grilla.Columns["SubTotal"].HeaderText = "SubTotal";
            grilla.Columns["SubTotal"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;




        }

        void cargarDatos()
        {
            ClienteDto Cliente = clienteServicio.ObtenerCFinal();
            if (Cliente != null)
            {
                txtCLiente.Text = Cliente.ApyNom;
            }
           
           

            var TiposPago = new List<TipoPago>()
            {
                
                TipoPago.Efectivo,
                
                TipoPago.CtaCte,


            }.ToList();



            cmbTipoPago.DataSource = TiposPago;
            cmbTipoPago.DisplayMember = "TipoPago";


            var TiposComprobante = new List<TipoComprobante>()
            {
             TipoComprobante.X,
             TipoComprobante.A,
             TipoComprobante.B,
             TipoComprobante.C,

            }.ToList();

            cmbTipoFactura.DataSource = TiposComprobante;
            cmbTipoFactura.DisplayMember = "TipoComprobante";


        }

        private void FotoBuscar_Click(object sender, EventArgs e)
        {
           
        }


        long ClienteSeleccionado()
        {
            if (_00039_ReservaCliente.ClienteSeleccionado == null)
            {
                ClienteDto cliente = clienteServicio.ObtenerCFinal();
                if (cliente == null)
                {
                    MessageBox.Show("Debe Seleccionar un cliente");
                    return 0;
                }
                return cliente.Id;
            }
            else
            {
                return _00039_ReservaCliente.ClienteSeleccionado.Id;
            }

        }

        private void FotoBuscar_Click_1(object sender, EventArgs e)
        {
            var FClienta = new _00039_ReservaCliente();

            FClienta.ShowDialog();
            if (_00039_ReservaCliente.ClienteSeleccionado != null)
            {
                txtCLiente.Text = _00039_ReservaCliente.ClienteSeleccionado.ApyNom;

            }
        }

        private void nuddescuento_KeyUp(object sender, KeyEventArgs e)
        {
            nudTotal.Value = (nudSubTotal.Value - (nudSubTotal.Value * (nuddescuento.Value / 100)));
        }

        ComprobanteKioskoDto GenerarComprobante()
        {
            var clienteId = ClienteSeleccionado();


          
            var comprobante = new ComprobanteKioskoDto
            {
                ClienteId = clienteId,
                Descuento = nuddescuento.Value,
                Fecha = DateTime.Now,
                Numero = _comprobanteServicio.ObtenerProximoNumero(),
                SubTotal = nudSubTotal.Value,
                TipoComprobante = (TipoComprobante)cmbTipoFactura.SelectedItem,
                Total = nudTotal.Value,
                UsuarioId = UsuarioLogueadoId.Value,


            };

            return comprobante;

        }

        List<DetalleComprobanteKiosco> DetalleComprobante()
        {
            var Lista = new List<DetalleComprobanteKiosco>();
            foreach (var item in articulos)
            {
                var Detalles = new DetalleComprobanteKiosco
                {
                    ArticuloId = (int)item.ArticuloId,
                    Cantidad = item.cantidad,
                    CodigoProducto = item.Codigo,
                    ComprobanteId = ComprobanteId.Value,
                    DescripcionProducto = item.Descripcion,
                    PrecioUnitario = item.Precio,
                    Subtotal = item.SubTotal,

                };
                Lista.Add(Detalles);
            }


            return Lista;
        }


        void Limpiar()
        {
            articulos.Clear();
            Actualizargrilla(dgvFacturar, articulos);
            Limpiarcontroles(this);
            cargarDatos();
        }

       MovimientoDto GenerarMovimientoDto()
        {
            var Dto = new MovimientoDto
            {

                CajaId = CajaIdAbierta.Value,
                ComprobanteId = ComprobanteId.Value,
                UsuarioId = UsuarioLogueadoId.Value,
                Monto = nudTotal.Value,
                Descripcion = $"FA_{(TipoComprobante)cmbTipoFactura.SelectedItem}_{_comprobanteServicio.ObtenerProximoNumero()}_{DateTime.Now}",


            };

            return Dto;
        }

        FormaPagoDto GenerarFormaPagoctacte()
        {
            var clienteId = ClienteSeleccionado();

            var fPago = new FormaPagoDto
            {
               ComprobanteId = ComprobanteId.Value,
               Monto = nudTotal.Value,
                clienteId = clienteId,
                FormaPago = TipoFormaPago.CuentaCorriente,
            };

            return fPago;
        }
        private FormaPagoDto GenerarFormaPagoEfectivo()
        {
            var clienteId = ClienteSeleccionado();

            var fPago = new FormaPagoDto
            {
                ComprobanteId = ComprobanteId.Value,
                Monto = nudTotal.Value,
                clienteId = clienteId,
                FormaPago = TipoFormaPago.Efectivo,
            };

            return fPago;
        }
        private void cmbTipoPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((TipoPago)cmbTipoPago.SelectedItem == TipoPago.CtaCte )
            {
                if (txtCLiente.Text == null)
                {
                    var FormClienta = new _00039_ReservaCliente();

                    FormClienta.ShowDialog();
                }
              
                if (_00039_ReservaCliente.ClienteSeleccionado != null)
                {
                    txtCLiente.Text = _00039_ReservaCliente.ClienteSeleccionado.ApyNom;

                }
                var clienteId = ClienteSeleccionado();

                lblCtaCte.Visible = true;
                txtctacte.Visible = true;
                txtctacte.Text =clienteServicio.MontoDisponibleCtaCte(ClienteSeleccionado()).ToString();
                
            }
            else
            {

                lblCtaCte.Visible = false;
                txtctacte.Visible = false;
            }
        }

        private void _00043_VentaKiosko_Activated(object sender, EventArgs e)
        {
            if ((TipoPago)cmbTipoPago.SelectedItem == TipoPago.CtaCte)
            {
               

               
                if (_00039_ReservaCliente.ClienteSeleccionado != null)
                {
                    txtCLiente.Text = _00039_ReservaCliente.ClienteSeleccionado.ApyNom;

                }
                var clienteId = ClienteSeleccionado();

                lblCtaCte.Visible = true;
                txtctacte.Visible = true;
                txtctacte.Text = clienteServicio.MontoDisponibleCtaCte(ClienteSeleccionado()).ToString();

            }
            else
            {

                lblCtaCte.Visible = false;
                txtctacte.Visible = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           
        }

        private void _00043_VentaKiosko_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (txtCodigo.Text == string.Empty)
            {
                var FromArticulo = new _00013_Articulo(true);
                FromArticulo.ShowDialog();
                if (_00013_Articulo.ArticuloSeleccionado != null)
                {
                    txtProducto.Text = _00013_Articulo.ArticuloSeleccionado.Descripcion;
                    txtCodigo.Text = _00013_Articulo.ArticuloSeleccionado.Codigo;

                    var Precio = precioServicio.ObtenerPorId(_00013_Articulo.ArticuloSeleccionado.Id).PrecioPublico;
                    txtPrecioUnitario.Text = Precio.ToString();
                    return;
                }

            }
            if (!_articuloServicio.VerificarPorCodigo(txtCodigo.Text))
            {
                MessageBox.Show("No exixte ningun producto con ese codigo ");
                return;
            }

            var ArticuloAgregar = _articuloServicio.ObtenerventaKiosko(txtCodigo.Text, nudCantidad.Value);

            if (articulos.Count != 0 && articulos.Any(x => x.ArticuloId == ArticuloAgregar.ArticuloId))
            {
                foreach (var item in articulos)
                {
                    if (item.ArticuloId == ArticuloAgregar.ArticuloId)
                    {
                        item.cantidad += ArticuloAgregar.cantidad;
                        item.SubTotal = item.cantidad * item.Precio;
                        Actualizargrilla(dgvFacturar, articulos);
                    }
                }

            }
            else
            {
                articulos.Add(ArticuloAgregar);
                Actualizargrilla(dgvFacturar, articulos);
            }


            nudSubTotal.Value = articulos.Sum(x => x.SubTotal);
            nudTotal.Value = nudSubTotal.Value;

            nudTotal.Value = (nudSubTotal.Value - (nudSubTotal.Value * (nuddescuento.Value / 100)));

            txtCodigo.Clear();
        }

        private void dgvFacturar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvFacturar.CurrentRow != null)
            {
                var remover = dgvFacturar.CurrentRow.DataBoundItem;

                articulos.Remove((ArticuloKioscoDto)remover);
                Actualizargrilla(dgvFacturar, articulos);


            }
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

        private void nuddescuento_ValueChanged(object sender, EventArgs e)
        {
            nudTotal.Value = (nudSubTotal.Value - (nudSubTotal.Value * (nuddescuento.Value / 100)));
        }
    }
}
