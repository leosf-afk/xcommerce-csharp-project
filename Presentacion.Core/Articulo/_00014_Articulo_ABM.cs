using Presentacion.Core.Marca;
using Presentacion.Core.Rubro;
using Presentacion.FormularioBase;
using Presentacion.FormularioBase.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xcom.Servicio.Core.Articulo;
using Xcom.Servicio.Core.Articulo.DTOs;
using Xcom.Servicio.Core.Marca;
using Xcom.Servicio.Core.Marca.DTOs;
using Xcom.Servicio.Core.Precio;
using Xcom.Servicio.Core.Precio.DTOs;
using Xcom.Servicio.Core.Rubro;
using Xcom.Servicio.Core.Rubro.DTOs;
using static Presentacion.Helpers.ImagenDb;
namespace Presentacion.Core.Articulo
{
    public partial class _00014_Articulo_ABM : FormularioABM
    {
        protected readonly IArticuloServicio articuloServicio;

        protected readonly IRubroservicio rubroservicio;

        protected readonly IMarcaServicio marcaServicio;

        protected readonly IPrecioServicio precioServicio;

       

        public _00014_Articulo_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
           : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            articuloServicio = new ArticuloServicio();
            rubroservicio = new RubroServicio();
            marcaServicio = new MarcaServicio();
            precioServicio = new PrecioServicio();
          //  AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(nudLimiteVenta, "Limite de Venta");
            AgregarControlesObligatorios(txtcodigoBarra, "Codigo De Barra");
            AgregarControlesObligatorios(txtCodigo, "codigo");
            AgregarControlesObligatorios(txtDescripcion, "Descripcion");
            AgregarControlesObligatorios(nudStockMin, "StocK Minimo");
            AgregarControlesObligatorios(nudStockMax, "Stock Maximo");
            AgregarControlesObligatorios(nudStock, "stock");
            AgregarControlesObligatorios(cmbMarca, "Marca");
            AgregarControlesObligatorios(cmbRubro, "Rubro");

            Inicializador(entidadId);
            CargarDatos(entidadId);
            
        }











        public override void CargarDatos(long? entidadId)
        {
            if (_tipoOperacion == TipoOperacion.Nuevo) return;

            else if (_tipoOperacion == TipoOperacion.Eliminar || _tipoOperacion == TipoOperacion.Modificar)
            {
                if (entidadId == null)
                {
                    return;
                }

                base.CargarDatos(entidadId);
                var Articulo = articuloServicio.ObtenerPorId(entidadId.Value);
                var PrecioId = precioServicio.obtenerId(entidadId.Value);
                var Precio = precioServicio.ObtenerPorId(PrecioId);
                if (Articulo != null && Precio != null)
                {    //asignar datos a los controles de los formularios
                    nudStock.Maximum = 9999999;
                    nudStock.Minimum = -99999999;

                    nudStockMax.Maximum = 9999999;
                    nudStockMax.Minimum = 1;

                    nudStockMin.Maximum = 9999999;
                    nudStockMin.Minimum = 1;

                    nudLimiteVenta.Maximum = 9999999;
                    nudLimiteVenta.Minimum = 1;

                   
                    txtcodigoBarra.Text = Articulo.CodigoBarra;
                    txtCodigo.Text = Articulo.Codigo;
                    txtAbreviatura.Text = Articulo.Abreviatura;
                    txtDescripcion.Text = Articulo.Descripcion;
                    txtDetalle.Text = Articulo.Detalle;
                    nudLimiteVenta.Value = Articulo.LimiteVenta;
                    nudStock.Value = Articulo.Stock;
                    nudStockMax.Value = Articulo.StockMaximo;
                    nudStockMin.Value = Articulo.StockMinimo;
                    if (Articulo.ActivarLimiteVenta)
                    {
                        ActivarLimite.Checked = true;
                    }
                    else
                    {
                        ActivarLimite.Checked = false;
                    }
                    if (Articulo.PermitirStockNegativo)
                    {
                        PermitirStockNeg.Checked = true;
                    }
                    else
                    {
                        PermitirStockNeg.Checked = false;
                    }

                    if (Precio.ActivarHoraVenta)
                    {
                        chkActivarHoraVenta.Checked = true;
                    }
                    else
                    {
                        chkActivarHoraVenta.Checked = false;
                    }
                   
                    ckbDescontarStock.Checked = Articulo.DescuentoStock;
                    chkEstaDescontinuado.Checked = Articulo.EstaDescontinuado;
                    CargarComboBox(cmbRubro, rubroservicio.Obtener(string.Empty),
                       "Descripcion", "Id");

                    CargarComboBox(cmbMarca, marcaServicio.Obtener(string.Empty),
                       "Descripcion", "Id");

                    cmbMarca.SelectedValue = Articulo.MarcaId;

                    cmbRubro.SelectedValue = Articulo.RubroId;
                 
                    pcbFoto.Image = Convertir_Bytes_Imagen(Articulo.Foto);

                    nudPrecioCosto.Value = Precio.PrecioCosto;
                    nudPrecioPublico.Value = Precio.PrecioPublico;
                    dtpHoraVenta.Value = Precio.HoraVenta;
                    DtpFechaActualizado.Value = Precio.FechaActualizacion;

                }
                else
                {
                    MessageBox.Show("ocurrio un error al seleccionar el Articulo");
                    this.Close();
                }


            }
            else
            {
                MessageBox.Show("ocurrio un error al seleccionar el Articulo");
                this.Close();
            }





        }

        public override void Inicializador(long? entidadId)
        {



            if (!entidadId.HasValue || _tipoOperacion == TipoOperacion.Modificar || _tipoOperacion == TipoOperacion.Nuevo)
            {


                CargarComboBox(cmbRubro, rubroservicio.Obtener(string.Empty),
                   "Descripcion", "Id");

                CargarComboBox(cmbMarca, marcaServicio.Obtener(string.Empty),
                   "Descripcion", "Id");

             

                nudLimiteVenta.Maximum = 99999;
                nudLimiteVenta.Minimum = 1;

                nudPrecioCosto.Maximum = 99999999;
                nudPrecioCosto.Minimum = 1;

                nudPrecioPublico.Maximum = 9999999;
                nudPrecioPublico.Minimum = 1;

                nudStock.Maximum = 9999999;
                nudStock.Minimum = 1;

                nudStockMax.Maximum = 9999999;
                nudStockMax.Minimum = 1;

                nudStockMin.Maximum = 9999999;
                nudStockMin.Minimum = 1;

                nudLimiteVenta.Maximum = 9999999;
                nudLimiteVenta.Minimum = 1;


                txtcodigoBarra.KeyPress += Presentacion.Helpers.Validacion.NoSimbolos;
                txtcodigoBarra.KeyPress += Presentacion.Helpers.Validacion.NoLetras;
                txtcodigoBarra.MaxLength = 100;

                txtCodigo.KeyPress += Presentacion.Helpers.Validacion.NoSimbolos;
                txtCodigo.KeyPress += Presentacion.Helpers.Validacion.NoLetras;
                txtCodigo.MaxLength = 100;

                txtAbreviatura.KeyPress += Presentacion.Helpers.Validacion.NoSimbolos;
                
                txtAbreviatura.MaxLength = 20;

                txtDescripcion.KeyPress += Presentacion.Helpers.Validacion.NoSimbolos;
                
                txtDescripcion.MaxLength = 400;

                txtDetalle.KeyPress += Presentacion.Helpers.Validacion.NoSimbolos;
                
                txtDetalle.MaxLength = 400;


               

               pcbFoto.Image = Presentacion.Constantes.Imagen.ImagenBotonUsuario;
                txtcodigoBarra.Focus();
            }

        }


        public override void btnEjecutar_Click(object sender, EventArgs e)
        {
            base.btnEjecutar_Click(sender, e);
            if (_tipoOperacion == FormularioBase.Helpers.TipoOperacion.Nuevo)
            {
                Inicializador(_entidadId);
            }

        }



        protected override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (articuloServicio.VerificarExistencia(txtDescripcion.Text, null , txtCodigo.Text,txtcodigoBarra.Text))
            {
                MessageBox.Show($" Ya existe un producto con esa Descripcion, Codigo , o Codigo de barra {txtDescripcion.Text}");
                
                
                return false;
            }
            
            
            
            var NuevoArtuculo = new ArticuloDto
            {
                Codigo = txtCodigo.Text,
                CodigoBarra = txtcodigoBarra.Text,
                Descripcion = txtDescripcion.Text,
                Detalle = txtDetalle.Text,
                Abreviatura = txtAbreviatura.Text,
                Stock = nudStock.Value,
                StockMaximo = nudStockMax.Value,
                StockMinimo = nudStockMin.Value,
                LimiteVenta = nudLimiteVenta.Value,
                ActivarLimiteVenta = ActivarLimite.Checked,
                PermitirStockNegativo = PermitirStockNeg.Checked,
                RubroId = ((RubroDto)cmbRubro.SelectedItem).Id,
                MarcaId = ((MarcaDto)cmbMarca.SelectedItem).Id,
                EstaDescontinuado = chkEstaDescontinuado.Checked,
                DescuentoStock = chkEstaDescontinuado.Checked,
                Foto = Convertir_Imagen_Bytes(pcbFoto.Image),
                EstaEliminado = false,


            };
           

            var NuevoPrecio = new PrecioDto
            {


                PrecioCosto = nudPrecioCosto.Value,
                PrecioPublico = nudPrecioPublico.Value,
                FechaActualizacion = DateTime.Now,
                ListaPrecioId = 1,
                ArticuloId = (int)articuloServicio.Insertar(NuevoArtuculo) ,
                ActivarHoraVenta = chkActivarHoraVenta.Checked,
                HoraVenta = dtpHoraVenta.Value

            };

            precioServicio.Insertar(NuevoPrecio);
            return true;



        }

        protected override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (articuloServicio.VerificarExistencia(txtDescripcion.Text, _entidadId, txtCodigo.Text, txtcodigoBarra.Text))
            {
                MessageBox.Show($" Ya existe un producto con esa Descripcion, Codigo , o Codigo de barra {txtDescripcion.Text}");
                return false;

            }

            var ModificarArticulo = new ArticuloDto
            {
                Id = _entidadId.Value,
                Codigo = txtCodigo.Text,
                CodigoBarra = txtcodigoBarra.Text,
                Descripcion = txtDescripcion.Text,
                Detalle = txtDetalle.Text,
                Abreviatura = txtAbreviatura.Text,
                Stock = nudStock.Value,
                StockMaximo = nudStockMax.Value,
                StockMinimo = nudStockMin.Value,
                LimiteVenta = nudLimiteVenta.Value,
                ActivarLimiteVenta = ActivarLimite.Checked,
                PermitirStockNegativo = PermitirStockNeg.Checked,
                RubroId = ((RubroDto)cmbRubro.SelectedItem).Id,
                MarcaId = ((MarcaDto)cmbMarca.SelectedItem).Id,
                EstaDescontinuado = chkEstaDescontinuado.Checked,
                DescuentoStock = ckbDescontarStock.Checked,
                Foto = Convertir_Imagen_Bytes(pcbFoto.Image),
                EstaEliminado = false,
            };
            articuloServicio.Modificar(ModificarArticulo);
            var NuevoPrecio = new PrecioDto
            {
                PrecioCosto = nudPrecioCosto.Value,
                PrecioPublico = nudPrecioPublico.Value,
                FechaActualizacion = DateTime.Now,
                ListaPrecioId = 1,
                ArticuloId = (int)_entidadId,
                ActivarHoraVenta = chkActivarHoraVenta.Checked,
                HoraVenta = dtpHoraVenta.Value,
                Id = precioServicio.obtenerId(_entidadId)
                
            };

            precioServicio.Modificar(NuevoPrecio);

            return true;
        }

        protected override bool EjecutarComandoEliminar()
        {
            if (_entidadId == null) return false;

            articuloServicio.Eliminar(_entidadId.Value);

            return true;


        }

        private void btnAgregarImagen_Click_1(object sender, EventArgs e)
        {
            if (Archivo.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(Archivo.FileName))
                {
                    pcbFoto.Image = Image.FromFile(Archivo.FileName);
                }
                else
                {
                    pcbFoto.Image = Presentacion.Constantes.Imagen.ImagenBotonUsuario;
                }
            }
            else
            {
                pcbFoto.Image = Presentacion.Constantes.Imagen.ImagenBotonUsuario;
                

            }
        }

        private void _00014_Articulo_ABM_Load(object sender, EventArgs e)
        {
           
                
              
        }

        private void btnNuevaMarca_Click(object sender, EventArgs e)
        {
          
            var fMarcasABM = new _00010_Marcas_ABM (TipoOperacion.Nuevo);
            fMarcasABM.ShowDialog();

            CargarComboBox(cmbMarca, marcaServicio.Obtener(string.Empty),
               "Descripcion", "Id");

        }

        private void btnNuevoRubro_Click(object sender, EventArgs e)
        {
            var fRubroABM = new _00012_Rubro_ABM(TipoOperacion.Nuevo);
            fRubroABM.ShowDialog();

            CargarComboBox(cmbRubro, rubroservicio.Obtener(string.Empty),
               "Descripcion", "Id");
        }

        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }

        private void chkActivarHoraVenta_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkActivarHoraVenta.Checked)
            {
                dtpHoraVenta.Enabled = false;
            }
            else
            {
                dtpHoraVenta.Enabled = true;
            }
        }

        private void ActivarLimite_CheckedChanged(object sender, EventArgs e)
        {
            if (!ActivarLimite.Checked)
            {
                nudLimiteVenta.Enabled = false;
            }
            else
            {
                nudLimiteVenta.Enabled = true;
            }
        }
    }
}
