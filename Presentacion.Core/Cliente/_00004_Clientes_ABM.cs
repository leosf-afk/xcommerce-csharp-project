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
using Xcom.Servicio.Core.Cliente;
using Xcom.Servicio.Core.Cliente.Dtos;
using Xcom.Servicio.Core.Localidad;
using Xcom.Servicio.Core.Localidad.DTOs;
using Xcom.Servicio.Core.Provincia;
using Xcom.Servicio.Core.Provincia.DTOs;

namespace Presentacion.Core.Cliente
{
    public partial class _00004_Clientes_ABM : FormularioABM
    {
        protected readonly IClienteServicio clienteServicio;
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly ILocalidadServicio _localidadServicos;
      

        public _00004_Clientes_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
           : base(tipoOperacion , entidadId)
        {
            InitializeComponent();

            clienteServicio = new ClienteServicio();

            _provinciaServicio = new ProvinciaServicio();

            _localidadServicos = new LocalidadServicio();

           
                

            
            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(nudMaxCta, "MontoMaximoCtaCte");
            AgregarControlesObligatorios(txtApellido, "Apellido");
            AgregarControlesObligatorios(txtNombre, "Nombre");
            AgregarControlesObligatorios(txtdni, "DNI");
            AgregarControlesObligatorios(txtCUIL, "CUIL");
            AgregarControlesObligatorios(txtEmail, "E-Mail");
            AgregarControlesObligatorios(txtCalle, "Calle");
            AgregarControlesObligatorios(cmbLocalidad, "Localidad");
            AgregarControlesObligatorios(cmbProvincia, "Provincia");

            ckbEsVisible.Checked = true;
            Inicializador(entidadId);
        }

      


        private void cmbProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbProvincia.Items.Count > 0)
            {
                cmbLocalidad.Text = string.Empty;

                CargarComboBox(cmbLocalidad,
                    _localidadServicos.Obtener(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                    "Descripcion", "Id");
            }
        }



        public override void CargarDatos(long? entidadId)
        {
            if (_tipoOperacion == TipoOperacion.Nuevo) return;

            else if (_tipoOperacion == TipoOperacion.Eliminar || _tipoOperacion == TipoOperacion.Modificar)
            {

                base.CargarDatos(entidadId);
                var Cliente = clienteServicio.ObtenerPorId(entidadId.Value);
                if (Cliente != null)
                {    //asignar datos a los controles de los formularios
                    nudMaxCta.Maximum = 9999999;
                    nudMaxCta.Minimum = 0;

                    

                    nudMaxCta.Value = Cliente.MontoMaximoCtaCte;
                    txtApellido.Text = Cliente.Apellido;
                    txtNombre.Text = Cliente.Nombre;
                    txtdni.Text = Cliente.Dni;
                    txtTelefono.Text = Cliente.Telefono;
                    txtCelular.Text = Cliente.Celular;
                    txtEmail.Text = Cliente.EMail;
                    txtCUIL.Text = Cliente.Cuil;
                    dtpFechaNacimiento.Value = Cliente.FechaNacimiento;
                    //ckbEsVisible.Checked = Cliente.EsVisible;
                   


                    //datos de direccion
                    txtCalle.Text = Cliente.Calle;
                    txtNumero.Text = Cliente.Numero.ToString();
                    txtPiso.Text = Cliente.Piso;
                    txtDpto.Text = Cliente.Dpto;
                    txtLote.Text = Cliente.Lote;
                    txtManzana.Text = Cliente.Mza;
                    txtBarrio.Text = Cliente.Barrio;
                    txtCasa.Text = Cliente.Casa;
                    CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty),
                        "Descripcion", "Id");

                    cmbProvincia.SelectedItem = Cliente.ProvinciaId;

                    if (cmbProvincia.Items.Count > 0)
                    {
                        CargarComboBox(cmbLocalidad,
                            _localidadServicos.Obtener(Cliente.ProvinciaId, string.Empty),
                            "Descripcion", "Id");
                    }

                }
                else
                {
                    MessageBox.Show("ocurrio un error al seleccionar el Cliente", @"Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    this.Close();
                }


            }
            else
            {
                MessageBox.Show("ocurrio un error al seleccionar el Cliente", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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

             
                nudMaxCta.Maximum = 99999999;
                nudMaxCta.Minimum = 0;

                txtApellido.KeyPress += Presentacion.Helpers.Validacion.NoSimbolos;
                txtApellido.KeyPress += Presentacion.Helpers.Validacion.NoNumeros;
                txtApellido.MaxLength = 250;

                txtNombre.KeyPress += Presentacion.Helpers.Validacion.NoSimbolos;
                txtNombre.KeyPress += Presentacion.Helpers.Validacion.NoNumeros;
                txtNombre.MaxLength = 250;

                txtdni.KeyPress += Presentacion.Helpers.Validacion.NoSimbolos;
                txtdni.KeyPress += Presentacion.Helpers.Validacion.NoLetras;
                txtdni.MaxLength = 8;

                txtCUIL.KeyPress += Presentacion.Helpers.Validacion.NoSimbolos;
                txtCUIL.KeyPress += Presentacion.Helpers.Validacion.NoLetras;
                txtCUIL.MaxLength = 11;

                txtTelefono.KeyPress += Presentacion.Helpers.Validacion.NoSimbolos;
                txtTelefono.KeyPress += Presentacion.Helpers.Validacion.NoLetras;
                txtTelefono.MaxLength = 25;

                txtCelular.KeyPress += Presentacion.Helpers.Validacion.NoSimbolos;
                txtCelular.KeyPress += Presentacion.Helpers.Validacion.NoLetras;
                txtCelular.MaxLength = 25;

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

                txtLote.MaxLength =5;
                txtLote.KeyPress += Helpers.Validacion.NoSimbolos;

                txtManzana.MaxLength = 5;
                txtManzana.KeyPress += Helpers.Validacion.NoSimbolos;

                txtNumero.MaxLength = 10;
                txtNumero.KeyPress += Helpers.Validacion.NoSimbolos;
                txtNumero.KeyPress += Helpers.Validacion.NoLetras;


                ckbEsVisible.Checked = true;
              
                txtApellido.Focus();
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
           
            if (clienteServicio.VerificarExistencia(txtdni.Text , _entidadId ))
            {
                MessageBox.Show($"ya se encuentra en uso el mismo dni en otro cliente", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;

            }
            var NuevoCliente = new ClienteDto
            {
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                MontoMaximoCtaCte = nudMaxCta.Value,
                Dni = txtdni.Text,
                Barrio = txtBarrio.Text,
                Calle = txtCalle.Text,
                Casa = txtCasa.Text,
                Celular = txtCelular.Text,
                Cuil = txtCUIL.Text,
                Dpto = txtDpto.Text,
                EMail = txtEmail.Text,
                Mza = txtManzana.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                Lote = txtLote.Text,
                Numero = int.TryParse(txtNumero.Text, out var numero) ? numero : 0,
                Piso = txtPiso.Text,
                Telefono = txtTelefono.Text,
                LocalidadId = ((LocalidadDto)cmbLocalidad.SelectedItem).Id,
                EsVisible = ckbEsVisible.Checked,

              
                EstaEliminado = false,

            };
            clienteServicio.Insertar(NuevoCliente);
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
                       
            if (clienteServicio.VerificarExistencia(txtdni.Text, _entidadId ))
            {
                MessageBox.Show($"ya se encuentra en uso el mismo dni en otro cliente", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;

            }
            var ModificarCliente = new ClienteDto
            {
                Id = (long)_entidadId,
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                MontoMaximoCtaCte = nudMaxCta.Value,
                Dni = txtdni.Text,
                Barrio = txtBarrio.Text,
                Calle = txtCalle.Text,
                Casa = txtCasa.Text,
                Celular = txtCelular.Text,
                Cuil = txtCUIL.Text,
                Dpto = txtDpto.Text,
                EMail = txtEmail.Text,
                Mza = txtManzana.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                Lote = txtLote.Text,
                Numero = int.TryParse(txtNumero.Text, out var numero) ? numero : 0,
                Piso = txtPiso.Text,
                Telefono = txtTelefono.Text,
                LocalidadId = ((LocalidadDto)cmbLocalidad.SelectedItem).Id,
                ProvinciaId = ((ProvinciaDto)cmbProvincia.SelectedItem).Id,
                EstaEliminado = false,
                EsVisible = ckbEsVisible.Checked,
            };
            clienteServicio.Modificar(ModificarCliente);

            return true;
        }

        protected override bool EjecutarComandoEliminar()
        {
            if (_entidadId == null) return false;

            clienteServicio.Eliminar(_entidadId.Value);

            return true;


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

        private void btnNuevaProvincia_Click_1(object sender, EventArgs e)
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

        private void btnNuevoProvincia_Click(object sender, EventArgs e)
        {
            var formProvinciaAbm = new _00006_Provincias_ABM(TipoOperacion.Nuevo);
            formProvinciaAbm.ShowDialog();

            if (!formProvinciaAbm.RealizoAlgunaOperacion) return;

            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");

            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad,
                    _localidadServicos.Obtener(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                    "Descripcion", "Id");
            }


        }

        private void btnNuevaLocalidad_Click_1(object sender, EventArgs e)
        {

            var FormLocalidadaABM = new _00008_Localidad_ABM(TipoOperacion.Nuevo);
            FormLocalidadaABM.ShowDialog();


            if (!FormLocalidadaABM.RealizoAlgunaOperacion) return;

            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad,
                    _localidadServicos.Obtener(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                    "Descripcion", "Id");
            }
        }

      
    }
}
