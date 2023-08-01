using Presentacion.Core.Mesa.Control;
using Presentacion.Core.Reserva;
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
using Xcom.Servicio.Core.Cliente;
using Xcom.Servicio.Core.Cliente.Dtos;
using Xcom.Servicio.Core.Comprobante;
using Xcom.Servicio.Core.Comprobante.Comprobantes;
using Xcom.Servicio.Core.DetalleCaja;
using Xcom.Servicio.Core.DetalleCaja.DTOs;
using Xcom.Servicio.Core.FormaPago;
using Xcom.Servicio.Core.FormaPago.DTOs;
using Xcom.Servicio.Core.Mesa;
using Xcom.Servicio.Core.Movimiento;
using Xcom.Servicio.Core.Movimiento.DTOs;
using Xcom.Servicio.Seguridad.Usuarios;
using static Presentacion.Helpers.DatosParaReUtilizadar;
namespace Presentacion.Core.FormaPago
{
    public partial class _00042_FormaPagoSalon : FormularioBase.FormularioBase
    {
        protected readonly IClienteServicio clienteServicio;

        protected IComprobanteSalonServicio comprobanteSalonServivio;

        protected IMesaServicio mesaServicio;

        protected IUsuarioServicio UsuarioServicio;

        protected readonly IDetalleCajaServicio detalleCajaServicio;

        protected readonly ICajaServicio CajaServicio;

        protected readonly IMovimientoServicio _movimientoServicio;

        protected readonly IComprobanteServicio comprobanteServicio;

        protected readonly IFormaPagoServicio formaPagoServicio;

        decimal TotalPagar;

        decimal Subtotal;

        decimal Descuento;

        int Comensales;

        long ComprobanteId;

        long mesaId;

        public static bool Pagado;

        public _00042_FormaPagoSalon()

        {
            InitializeComponent();

        }
        public _00042_FormaPagoSalon(decimal Total, decimal _Subtotal, decimal _descuento, int _comensales, long _ComprobanteId, long mesaID)
            : this()
        {
            comprobanteSalonServivio = new ComprobanteSalonServicio();

            Subtotal = _Subtotal;
            Descuento = _descuento;
            TotalPagar = Total ;
            Comensales = _comensales;
            ComprobanteId = _ComprobanteId;
            clienteServicio = new ClienteServicio();
            detalleCajaServicio = new DetalleCajaServicio();
            mesaServicio = new Mesaservicio();
            UsuarioServicio = new UsuarioServicio();
            CajaServicio = new CajaServicio();
            _movimientoServicio = new MovimientoServicio();
            comprobanteServicio = new ComprobanteServicio();
            formaPagoServicio = new FormaPagoServicio();
            mesaId = mesaID;
            Pagado = false;
            this.BackColor = Presentacion.Constantes.Color.ColorFondo;
            cargarDatos();

            lblCtaCte.Visible = false;
            txtctacte.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = TipoPago.CtaCte;
            if (cmbTipoPago.Text.Equals("Efectivo"))
            {
                x = TipoPago.Efectivo;
            }
           



            if (txtTotalPagar.Text == string.Empty)
            {
                MessageBox.Show("Error no exixte ningun monto para cobrar");
            }
            else
            {

                if ((TipoPago)cmbTipoPago.SelectedItem == TipoPago.CtaCte)
                {
                    if (decimal.Parse(txtctacte.Text) < decimal.Parse(txtTotalPagar.Text))
                    {
                        MessageBox.Show("El Monto Supera La Disponibilidad en Cta Cte");
                        cmbTipoPago.SelectedItem = TipoPago.Efectivo;
                        lblCtaCte.Visible = false;
                        txtctacte.Visible = false;
                        return;
                    }
                }
                CajaIdAbierta = CajaServicio.ObtenerIdporUsuario(UsuarioLogueadoId.Value).Id;

                var NuevoDetalle = new DetalleCajaDto
                {
                    CajaId = CajaIdAbierta.Value,
                    Monto = decimal.Parse(txtTotalPagar.Text),
                    TipoPago = x,


                };

                detalleCajaServicio.Insertar(NuevoDetalle);



                comprobanteSalonServivio.CerrarCOmprobante(Comensales, Subtotal, Descuento, TotalPagar, ComprobanteId, ClienteSeleccionado(), comprobanteServicio.ObtenerProximoNumero());

                if ((TipoPago)cmbTipoPago.SelectedItem == TipoPago.Efectivo)
                {
                    CajaServicio.ActualizarMontoDelSistemaPorVenta(decimal.Parse(txtTotalPagar.Text), CajaIdAbierta.Value);
                    formaPagoServicio.InsertarEfectivo(GenerarFormaPagoEfectivo());

                }
                else if ((TipoPago)cmbTipoPago.SelectedItem == TipoPago.CtaCte)
                {
                    formaPagoServicio.InsertarCte(GenerarFormaPagoctacte());
                    if (decimal.Parse(txtctacte.Text) < decimal.Parse(txtTotalPagar.Text))
                    {
                        MessageBox.Show("El Monto Supera La Disponibilidad en Cta Cte");
                        cmbTipoPago.SelectedItem = TipoPago.Efectivo;
                        lblCtaCte.Visible = false;
                        txtctacte.Visible = false;
                        return;
                    }
                }

              
                mesaServicio.CerrarMesa(mesaId);

                _movimientoServicio.insertar(GenerarMovimientoDto());

                Pagado = true;
                MessageBox.Show(" Pago Realizado");


                this.Close();
                _00039_ReservaCliente.ClienteSeleccionado = null;



            }
        }

        private FormaPagoDto GenerarFormaPagoEfectivo()
        {
            var clienteId = ClienteSeleccionado();

            var vPago = new FormaPagoDto
            {
                ComprobanteId = ComprobanteId,
                Monto = decimal.Parse(txtTotalPagar.Text),
                clienteId = clienteId,
                FormaPago = TipoFormaPago.Efectivo,
            };

            return vPago;
        }

        void cargarDatos()
        {
            ClienteDto s = clienteServicio.ObtenerCFinal();

            txtTotalPagar.Text = decimal.Round(TotalPagar , 2 , MidpointRounding.AwayFromZero).ToString();
            txtCLiente.Text = s.ApyNom;

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
            var FClienta = new _00039_ReservaCliente();

            FClienta.ShowDialog();
            if (_00039_ReservaCliente.ClienteSeleccionado != null)
            {
                txtCLiente.Text = _00039_ReservaCliente.ClienteSeleccionado.ApyNom;

            }
        }


        long ClienteSeleccionado()
        {
            if (_00039_ReservaCliente.ClienteSeleccionado == null)
            {
                ClienteDto s = clienteServicio.ObtenerCFinal();
                return s.Id;
            }
            else
            {
                return _00039_ReservaCliente.ClienteSeleccionado.Id;
            }

        }

        MovimientoDto GenerarMovimientoDto()
        {
            var Dto = new MovimientoDto
            {

                CajaId = CajaIdAbierta.Value,
                ComprobanteId = ComprobanteId,
                UsuarioId = UsuarioLogueadoId.Value,
                Monto = decimal.Parse(txtTotalPagar.Text),
                Descripcion = $"FA_X_{comprobanteServicio.ObtenerProximoNumero()}_{DateTime.Now}",
                

            };

            return Dto;
        }

        private void _00042_FormaPagoSalon_Load(object sender, EventArgs e)
        {

        }

        private void cmbTipoPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((TipoPago)cmbTipoPago.SelectedItem == TipoPago.CtaCte)
            {
                if (txtCLiente.Text == "Consumidor Final")
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
                txtctacte.Text = clienteServicio.MontoDisponibleCtaCte(ClienteSeleccionado()).ToString();

            }
            else
            {

                lblCtaCte.Visible = false;
                txtctacte.Visible = false;
            }
        }

        FormaPagoDto GenerarFormaPagoctacte()
        {
            var clienteId = ClienteSeleccionado();

            var fPago = new FormaPagoDto
            {
                ComprobanteId = ComprobanteId,
                Monto = decimal.Parse(txtTotalPagar.Text),
                clienteId = clienteId,
                FormaPago = TipoFormaPago.CuentaCorriente,
            };

            return fPago;
        }

        private void _00042_FormaPagoSalon_Activated(object sender, EventArgs e)
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
    }
}
