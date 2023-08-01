using Presentacion.Core.Localidad;
using Presentacion.Core.Provincia;
using Presentacion.FormularioBase;
using Presentacion.FormularioBase.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;
using Xcom.Servicio.Core.Empleado;
using Xcom.Servicio.Core.Empleado.DTOs;
using Xcom.Servicio.Core.Localidad;
using Xcom.Servicio.Core.Localidad.DTOs;
using Xcom.Servicio.Core.Provincia;
using Xcom.Servicio.Core.Provincia.DTOs;
using Xcom.Servicio.Seguridad.Usuarios;
using static Presentacion.Helpers.ImagenDb;

namespace Presentacion.Core.Empleado
{
    public partial class _00002_ABM_Empleados : FormularioABM
    {
        private readonly IEmpleadoServicio _empleadoServicio;

        private readonly IProvinciaServicio _provinciaServicio;

        private readonly ILocalidadServicio _localidadServicos;

        protected readonly IUsuarioServicio usuarioServicio;
        
        //private object provinciaServicio;

        //public object _localidadServicios { get; private set; }

        public _00002_ABM_Empleados(TipoOperacion tipoOperacion, long? entidadId = null)
            :base(tipoOperacion , entidadId)
        {
            InitializeComponent();

            _empleadoServicio = new EmpleadoServicio();

            _provinciaServicio = new ProvinciaServicio();

            _localidadServicos = new LocalidadServicio();

            usuarioServicio = new UsuarioServicio();

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(nudLegajo, "Legajo");
            AgregarControlesObligatorios(txtApellido, "Apellido");
            AgregarControlesObligatorios(txtNombre, "Nombre");
            AgregarControlesObligatorios(txtdni, "DNI");
            AgregarControlesObligatorios(txtCUIL, "CUIL");
            AgregarControlesObligatorios(txtEmail, "E-Mail");
            AgregarControlesObligatorios(txtCalle, "Calle");
            AgregarControlesObligatorios(cmbLocalidad, "Localidad");
            AgregarControlesObligatorios(cmbProvincia, "Provincia");

            Inicializador(entidadId);
        }

        private void _00002_ABM_Empleados_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
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
                var empleado = _empleadoServicio.ObtenerPorId(entidadId.Value);
                if (empleado != null)
                {    //asignar datos a los controles de los formularios
                    nudLegajo.Maximum = 9999999;
                    nudLegajo.Minimum = 1;

                    nudLegajo.Value = empleado.Legajo;
                    txtApellido.Text = empleado.Apellido;
                    txtNombre.Text = empleado.Nombre;
                    txtdni.Text = empleado.Dni;
                    txtTelefono.Text = empleado.Telefono;
                    txtCelular.Text = empleado.Celular;
                    txtEmail.Text = empleado.EMail;
                    txtCUIL.Text = empleado.Cuil;
                    dtpFechaNacimiento.Value = empleado.FechaNacimiento;

                    pcbFoto.Image = Convertir_Bytes_Imagen(empleado.Foto);


                    //datos de direccion
                    txtCalle.Text = empleado.Calle;
                    txtNumero.Text = empleado.Numero.ToString();
                    txtPiso.Text = empleado.Piso;
                    txtDpto.Text = empleado.Dpto;
                    txtLote.Text = empleado.Lote;
                    txtManzana.Text = empleado.Mza;
                    txtBarrio.Text = empleado.Barrio;
                    txtCasa.Text = empleado.Casa;
                    CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty),
                        "Descripcion", "Id");



                    cmbProvincia.Text = _provinciaServicio.ObtenerPorId(_localidadServicos.obtenerPorId(_empleadoServicio.ObtenerPorId(_entidadId.Value).LocalidadId).ProvinciaId).Descripcion;



                    cmbProvincia.SelectedItem = empleado.ProvinciaId;

                    if (cmbProvincia.Items.Count > 0)
                    {
                        CargarComboBox(cmbLocalidad,
                            _localidadServicos.Obtener(empleado.ProvinciaId, string.Empty),
                            "Descripcion", "Id");

                        cmbLocalidad.Text = _localidadServicos.obtenerPorId(_empleadoServicio.ObtenerPorId(_entidadId.Value).LocalidadId).Descripcion;
                    }

                }
                else
                {
                    MessageBox.Show("ocurrio un error al seleccionar el Empleado");
                    this.Close();
                }


            }
            else
            {
                MessageBox.Show("ocurrio un error al seleccionar el Empleado");
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

                nudLegajo.Minimum = nudLegajo.Value = 1;
                nudLegajo.Maximum = 99999999;

                
                nudLegajo.Value = _empleadoServicio.ObtenerSiguienteNumeroLegajo();

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

                txtLote.MaxLength = 5;
                txtLote.KeyPress += Helpers.Validacion.NoSimbolos;

                txtManzana.MaxLength = 5;
                txtManzana.KeyPress += Helpers.Validacion.NoSimbolos;

                txtNumero.MaxLength = 10;
                txtNumero.KeyPress += Helpers.Validacion.NoSimbolos;
                txtNumero.KeyPress += Helpers.Validacion.NoLetras;



                pcbFoto.Image = Presentacion.Constantes.Imagen.ImagenBotonUsuario;
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

            if (_empleadoServicio.VerificarSiExisteLegajoNuevo((int)nudLegajo.Value ))
            {
                MessageBox.Show("ya existe un Empleado con ese numero de legajo");
                return false;
            }
            var nuevoEmpleado = new EmpleadoDto
            {
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                Legajo = (int)nudLegajo.Value,
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
                FechaIngreso = dtpFechaIngreso.Value,

                Foto = Convertir_Imagen_Bytes(pcbFoto.Image),
                EstaEliminado = false,

            };
            _empleadoServicio.Insertar(nuevoEmpleado);
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

           

            if (_empleadoServicio.VerificarSiExisteLegajo((int)nudLegajo.Value , _entidadId.Value ))
            {
                MessageBox.Show("ya existe un Empleado con ese numero de legajo");
                return false;
            }

            var ModificarEmpleado = new EmpleadoDto
            {
                Id = _entidadId.Value,
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                Legajo = (int)nudLegajo.Value,
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
                FechaIngreso = dtpFechaIngreso.Value,
                Foto = Convertir_Imagen_Bytes(pcbFoto.Image),
                EstaEliminado = false,

            };
            _empleadoServicio.Modificar(ModificarEmpleado);

            return true;
        }

        protected override bool EjecutarComandoEliminar()
        {
            if (_entidadId == null) return false;

            if (usuarioServicio.VerificarQueExista(_entidadId.Value))
            {

                usuarioServicio.CambiarEstado(usuarioServicio.Obtenernombre((_entidadId.Value)).Nombre, true);

            }
          

           
            _empleadoServicio.Eliminar(_entidadId.Value);

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
    }
}




