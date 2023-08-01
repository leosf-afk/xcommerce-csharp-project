using Presentacion.Core.CondicionIva;
using Presentacion.Core.Localidad;
using Presentacion.Core.Provincia;
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
using Xcom.Servicio.Core.CondicionIva;
using Xcom.Servicio.Core.CondicionIva.DTOs;
using Xcom.Servicio.Core.Empresa;
using Xcom.Servicio.Core.Empresa.DTOs;
using Xcom.Servicio.Core.Localidad;
using Xcom.Servicio.Core.Localidad.DTOs;
using Xcom.Servicio.Core.Provincia;
using Xcom.Servicio.Core.Provincia.DTOs;
using static Presentacion.Helpers.ImagenDb;
namespace Presentacion.Core.Empresa
{
    public partial class _00031_Empresa_ABM : FormularioABM
    {

        protected readonly IEmpresaServicio empresaServicio;

        private readonly IProvinciaServicio _provinciaServicio;

        private readonly ILocalidadServicio _localidadServicos;

        protected readonly ICondicionIvaServicio condicionIvaServicio;
        
        //private object provinciaServicio;

        //public object _localidadServicios { get; private set; }

        public _00031_Empresa_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            empresaServicio = new EmpresaServicio();

            _provinciaServicio = new ProvinciaServicio();

            _localidadServicos = new LocalidadServicio();

            condicionIvaServicio = new CondicionIvaServicio();

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtNombreFantasia, "NombreFantasia");
            AgregarControlesObligatorios(txtRazonSocial, "RazonSocial");
            AgregarControlesObligatorios(txtSucursal, "Sucursal");
            AgregarControlesObligatorios(txtCUIT, "Cuit");
            AgregarControlesObligatorios(txtEmail, "Mail");
            AgregarControlesObligatorios(txtCalle, "Calle");
            AgregarControlesObligatorios(cmbLocalidad, "Localidad");
            AgregarControlesObligatorios(cmbProvincia, "Provincia");
            AgregarControlesObligatorios(cmbCondicionIva, "CondicionIva");

            Inicializador(entidadId);
        }

        public override void CargarDatos(long? entidadId)
        {
            if (_tipoOperacion == TipoOperacion.Nuevo) return;

            else if (_tipoOperacion == TipoOperacion.Eliminar || _tipoOperacion == TipoOperacion.Modificar)
            {

                base.CargarDatos(entidadId);
                var Empresa = empresaServicio.ObtenerPorId(entidadId.Value);
                if (Empresa != null)
                {    //asignar datos a los controles de los formularios
                   
                    txtNombreFantasia.Text = Empresa.NombreFantasia;
                    txtRazonSocial.Text = Empresa.RazonSocial;
                    txtSucursal.Text = Empresa.Sucursal;
                    txtTelefono.Text = Empresa.Telefono;
                  
                    txtEmail.Text = Empresa.Mail;
                    txtCUIT.Text = Empresa.Cuit;
                  

                    pcbFoto.Image = Convertir_Bytes_Imagen(Empresa.Logo);


                    //datos de direccion
                    txtCalle.Text = Empresa.Calle;
                    txtNumero.Text = Empresa.Numero.ToString();
                    txtPiso.Text = Empresa.Piso;
                    txtDpto.Text = Empresa.Dpto;
                    txtLote.Text = Empresa.Lote;
                    txtManzana.Text = Empresa.Mza;
                    txtBarrio.Text = Empresa.Barrio;
                    txtCasa.Text = Empresa.Casa;
                    CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty),
                        "Descripcion", "Id");



                    cmbProvincia.Text = _provinciaServicio.ObtenerPorId(_localidadServicos.obtenerPorId(empresaServicio.ObtenerPorId(_entidadId.Value).LocalidadId).ProvinciaId).Descripcion;



                    cmbProvincia.SelectedItem = Empresa.ProvinciaId;

                    if (cmbProvincia.Items.Count > 0)
                    {
                        CargarComboBox(cmbLocalidad,
                            _localidadServicos.Obtener(Empresa.ProvinciaId, string.Empty),
                            "Descripcion", "Id");

                        cmbLocalidad.Text = _localidadServicos.obtenerPorId(empresaServicio.ObtenerPorId(_entidadId.Value).LocalidadId).Descripcion;
                    }

                    CargarComboBox(cmbCondicionIva, condicionIvaServicio.Obtener(string.Empty),"Descripcion" , "Id");
                    cmbCondicionIva.Text = condicionIvaServicio.ObtenerPorId(empresaServicio.ObtenerPorId(entidadId.Value).CondicionIvaId).Descripcion;
                }
                else
                {
                    MessageBox.Show("ocurrio un error al seleccionar la Empresa");
                    this.Close();
                }


            }
            else
            {
                MessageBox.Show("ocurrio un error al seleccionar la Empresa");
                this.Close();
            }





        }

        public override void Inicializador(long? entidadId)
        {



            if (!entidadId.HasValue || _tipoOperacion == TipoOperacion.Modificar)
            {


                CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");


                if (cmbProvincia.Items.Count > 0)
                {
                    var provincia = (ProvinciaDto)cmbProvincia.Items[0];
                    cmbLocalidad.Text = string.Empty;
                    CargarComboBox(cmbLocalidad,
                        _localidadServicos.Obtener(provincia.Id, string.Empty),
                        "Descripcion", "Id");

                }

               
                txtNombreFantasia.KeyPress += Presentacion.Helpers.Validacion.NoSimbolos;
                txtNombreFantasia.KeyPress += Presentacion.Helpers.Validacion.NoNumeros;
                txtNombreFantasia.MaxLength = 250;

                txtRazonSocial.KeyPress += Presentacion.Helpers.Validacion.NoSimbolos;
        
                txtRazonSocial.MaxLength = 250;

                txtSucursal.KeyPress += Presentacion.Helpers.Validacion.NoSimbolos;
                
                txtSucursal.MaxLength = 10;

                txtCUIT.KeyPress += Presentacion.Helpers.Validacion.NoSimbolos;
                txtCUIT.KeyPress += Presentacion.Helpers.Validacion.NoLetras;
                txtCUIT.MaxLength = 11;

                txtTelefono.KeyPress += Presentacion.Helpers.Validacion.NoSimbolos;
                txtTelefono.KeyPress += Presentacion.Helpers.Validacion.NoLetras;
                txtTelefono.MaxLength = 25;

               

                txtEmail.MaxLength = 250;

                txtPiso.MaxLength = 2;
                txtPiso.KeyPress += Helpers.Validacion.NoLetras;
                txtPiso.KeyPress += Helpers.Validacion.NoSimbolos;

                txtBarrio.MaxLength = 250;
                txtBarrio.KeyPress += Helpers.Validacion.NoSimbolos;

                txtCalle.MaxLength = 400;
                txtCalle.KeyPress += Helpers.Validacion.NoSimbolos;

                txtCasa.MaxLength = 5;
                txtCasa.KeyPress += Helpers.Validacion.NoSimbolos;

                txtDpto.MaxLength = 2;
                txtDpto.KeyPress += Helpers.Validacion.NoSimbolos;

                txtLote.MaxLength = 5;
                txtLote.KeyPress += Helpers.Validacion.NoSimbolos;
                txtNumero.KeyPress += Helpers.Validacion.NoLetras;

                txtManzana.MaxLength = 5;
                txtManzana.KeyPress += Helpers.Validacion.NoSimbolos;

                txtNumero.MaxLength = 10;
                txtNumero.KeyPress += Helpers.Validacion.NoSimbolos;
                txtNumero.KeyPress += Helpers.Validacion.NoLetras;



                pcbFoto.Image = Presentacion.Constantes.Imagen.ImagenBotonUsuario;
                txtNombreFantasia.Focus();

                CargarComboBox(cmbCondicionIva, condicionIvaServicio.Obtener(string.Empty), "Descripcion", "Id");
               // cmbCondicionIva.Text = condicionIvaServicio.ObtenerPorId(empresaServicio.ObtenerPorId(entidadId.Value).CondicionIvaId).Descripcion;
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

            var NuevaEmpresa = new EmpresaDto
            {
                NombreFantasia = txtNombreFantasia.Text,
                RazonSocial = txtRazonSocial.Text,
               
                Sucursal = txtSucursal.Text,
                Barrio = txtBarrio.Text,
                Calle = txtCalle.Text,
                Casa = txtCasa.Text,
                CondicionIvaId = ((CondicionIvaDto)cmbCondicionIva.SelectedItem).Id,
                Cuit = txtCUIT.Text,
                Dpto = txtDpto.Text,
                Mail = txtEmail.Text,
                Mza = txtManzana.Text,
               
                Lote = txtLote.Text,
                Numero = int.TryParse(txtNumero.Text, out var numero) ? numero : 0,
                Piso = txtPiso.Text,
                Telefono = txtTelefono.Text,
                LocalidadId = ((LocalidadDto)cmbLocalidad.SelectedItem).Id,
               

                Logo = Convertir_Imagen_Bytes(pcbFoto.Image),
                
                
            };
            empresaServicio.Insertar(NuevaEmpresa);
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

            var ModificarEmpresa = new EmpresaDto
            {
                Id = _entidadId.Value,
                NombreFantasia = txtNombreFantasia.Text,
                RazonSocial = txtRazonSocial.Text,
                CondicionIvaId = ((CondicionIvaDto)cmbCondicionIva.SelectedItem).Id,
                Sucursal = txtSucursal.Text,
                Barrio = txtBarrio.Text,
                Calle = txtCalle.Text,
                Casa = txtCasa.Text,
               
                Cuit = txtCUIT.Text,
                Dpto = txtDpto.Text,
                Mail = txtEmail.Text,
                Mza = txtManzana.Text,
               
                Lote = txtLote.Text,
                Numero = int.TryParse(txtNumero.Text, out var numero) ? numero : 0,
                Piso = txtPiso.Text,
                Telefono = txtTelefono.Text,
                LocalidadId = ((LocalidadDto)cmbLocalidad.SelectedItem).Id,
              
                Logo = Convertir_Imagen_Bytes(pcbFoto.Image),
                

            };
            empresaServicio.Modificar(ModificarEmpresa);

            return true;
        }

        private void btnNuevaProvincia_Click(object sender, EventArgs e)
        {
            var fNuevaProvincia = new _00006_Provincias_ABM(TipoOperacion.Nuevo);
            fNuevaProvincia.ShowDialog();

            if (!fNuevaProvincia.RealizoAlgunaOperacion) return;

            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");

            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad,
                    _localidadServicos.Obtener(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                    "Descripcion", "Id");
            }
        }

        private void btnNuevaLocalidad_Click(object sender, EventArgs e)
        {
            var fNuevaLocalidad = new _00008_Localidad_ABM(TipoOperacion.Nuevo);
            fNuevaLocalidad.ShowDialog();

            if (!fNuevaLocalidad.RealizoAlgunaOperacion) return;

            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad,
                    _localidadServicos.Obtener(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                    "Descripcion", "Id");
            }
        }

        private void _00031_Empresa_ABM_Load(object sender, EventArgs e)
        {

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

        private void cmbProvincia_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            if (cmbProvincia.Items.Count > 0)
            {
                cmbLocalidad.Text = string.Empty;

                CargarComboBox(cmbLocalidad,
                    _localidadServicos.Obtener(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                    "Descripcion", "Id");



            }
        }

        private void btnCondicionIva_Click(object sender, EventArgs e)
        {
            var fCondicionIva = new _00033_CondicionIva_ABM(TipoOperacion.Nuevo);
            fCondicionIva.ShowDialog();

            if (!fCondicionIva.RealizoAlgunaOperacion) return;

            CargarComboBox(cmbCondicionIva, condicionIvaServicio.Obtener(string.Empty), "Descripcion", "Id");

           
        }
    }
}
