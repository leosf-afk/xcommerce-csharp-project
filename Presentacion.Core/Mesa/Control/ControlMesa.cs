using Presentacion.Core.FormaPago;
using Presentacion.Core.VentaSalon;
using System;
using System.Drawing;
using System.Windows.Forms;
using Xcom.AccesoDatos;
using Xcom.Servicio.Core.Comprobante;
using static Presentacion.Helpers.DatosParaReUtilizadar;

namespace Presentacion.Core.Mesa.Control
{
    public partial class ControlMesa : UserControl
    {

        protected int numeroMesa;

        private long _mesaId;

        private long? ComprobanteId;

        public long MesaId


        {
           set => _mesaId = value;
        }

        public int NumeroMesa
        {

            set
            {
                numeroMesa = value;
                lblNumeroMesa.Text = value.ToString();
            }
        }


        
        public decimal PrecioConsumido
        {
            set => lblPrecio.Text = value.ToString("C");
           
        }

        private EstadoMesa _estadoMesa;

        public  EstadoMesa estado
        {
           
            set
            {
                menuAbrirMesa.Visible = false;
               
               
                _estadoMesa = value;
                switch (value)
                {
                    case EstadoMesa.Cerrada:
                        this.BackColor = Color.OrangeRed;
                        menuAbrirMesa.Visible = true;
                        this.BackgroundImage = Presentacion.Constantes.Imagen.MesaCerrada;
                        break;
                    case EstadoMesa.Abierta:
                        this.BackColor = Color.LawnGreen;
                       
                        this.BackgroundImage = Presentacion.Constantes.Imagen.ImagenMesa;
                        break;
                    case EstadoMesa.FueraServicio:
                        this.BackColor = Color.LightGray;
                        this.BackgroundImage = Presentacion.Constantes.Imagen.MesafueraServicio;
                        break;
                    case EstadoMesa.Reservada:
                        this.BackColor = Color.MediumPurple;
                        lblNumeroMesa.ForeColor = Color.Black;
                        lblPrecio.ForeColor = Color.Black;
                        this.BackgroundImage = Presentacion.Constantes.Imagen.MesaReservada;
                        menuAbrirMesa.Visible = true;
                        break;
                    default:
                        this.BackColor = Color.White;
                        break;
                }
            }
        }

        protected readonly IComprobanteSalonServicio _comprobanteSalonServicio;

        public ControlMesa()
            : this(new ComprobanteSalonServicio())
        {
            InitializeComponent();
            ComprobanteId = null;
        }

        public ControlMesa(IComprobanteSalonServicio comprobanteSalonServicio)
        {
            _comprobanteSalonServicio = comprobanteSalonServicio;
        }

        private void menuAbrirMesa_Click(object sender, EventArgs e)
        {
            if (_estadoMesa == EstadoMesa.Cerrada || _estadoMesa == EstadoMesa.Reservada)
            {

                ComprobanteId =   _comprobanteSalonServicio.Generar(_mesaId, UsuarioLogueadoId.Value , 1);

                    estado = EstadoMesa.Abierta;

                

                var fComprobanteVenta = new _00037_ComprobanteMesa(_mesaId ,numeroMesa );

                fComprobanteVenta.ShowDialog();
                
            }
            else
            {

                var fComprobanteVenta = new _00037_ComprobanteMesa(_mesaId, numeroMesa);

                fComprobanteVenta.ShowDialog();
            }
        }

      
        private void lblNumeroMesa_DoubleClick(object sender, EventArgs e)
        {
            if (_estadoMesa == EstadoMesa.Abierta)
            {
               
              
                var fComprobanteVenta = new _00037_ComprobanteMesa(_mesaId, numeroMesa );

                fComprobanteVenta.ShowDialog();

                
            }
        }

       
    }
}
