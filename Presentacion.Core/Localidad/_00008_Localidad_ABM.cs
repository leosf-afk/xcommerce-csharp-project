using Presentacion.Core.Provincia;
using Presentacion.FormularioBase;
using Presentacion.FormularioBase.Helpers;
using Presentacion.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xcom.Servicio.Core.Localidad;
using Xcom.Servicio.Core.Localidad.DTOs;
using Xcom.Servicio.Core.Provincia;
using Xcom.Servicio.Core.Provincia.DTOs;

namespace Presentacion.Core.Localidad
{
    public partial class _00008_Localidad_ABM : FormularioABM
    {
        protected readonly ILocalidadServicio localidadServicio;

        protected readonly IProvinciaServicio provinciaServicio;

      
       public _00008_Localidad_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
           : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            localidadServicio = new LocalidadServicio();
            provinciaServicio = new ProvinciaServicio();

            AsignarEventoEnterLeave(this);
           
          

            AgregarControlesObligatorios(txtDescripcion, "Descripción");

            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {


            CargarComboBox(cmbProvincias, provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");
          
                
            // Asignando un Evento
            txtDescripcion.KeyPress += Validacion.NoSimbolos;
            txtDescripcion.KeyPress += Validacion.NoNumeros;
            txtDescripcion.MaxLength = 250;
            txtDescripcion.Focus();
        }


        public override void CargarDatos(long? entidadId)
        {
            if (_tipoOperacion == TipoOperacion.Nuevo) return;

            else if (_tipoOperacion == TipoOperacion.Eliminar || _tipoOperacion == TipoOperacion.Modificar)
            {

            
                base.CargarDatos(entidadId);
                var Localidad = localidadServicio.obtenerPorId(entidadId.Value);
                if (Localidad != null)
                {
                    txtDescripcion.Text = Localidad.Descripcion;
                    cmbProvincias.Text = provinciaServicio.ObtenerPorId(localidadServicio.obtenerPorId(_entidadId).ProvinciaId).Descripcion;
                }
                else
                {
                    MessageBox.Show("ocurrio un error al seleccionar la Localidad");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("ocurrio un error al seleccionar La Localidad" , "Atencion");
                this.Close();
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
            if (localidadServicio.VerificarExistencia(txtDescripcion.Text, null, ((ProvinciaDto) cmbProvincias.SelectedItem).Id))
            {
                MessageBox.Show($" Ya existe una Localidad con el nombre {txtDescripcion.Text} en la provincia seleccionada" , "Atencion");
                return false;

            }


            var NuevaLocalidad = new LocalidadDto
            {

                Descripcion = txtDescripcion.Text,
             
                ProvinciaId = ((ProvinciaDto) cmbProvincias.SelectedItem).Id

        };

            localidadServicio.Insertar(NuevaLocalidad);
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
            if (localidadServicio.VerificarExistencia(txtDescripcion.Text, _entidadId , ((ProvinciaDto)cmbProvincias.SelectedItem).Id))
            {
                MessageBox.Show($" Ya existe una Loclidad con el nombre {txtDescripcion.Text} en la provincia seleccionada", "Atencion");
                return false;

            }

            var ModiFicarLocalidad = new LocalidadDto
            {
                
                Descripcion = txtDescripcion.Text,
               
                Id = _entidadId.Value,
                ProvinciaId = ((ProvinciaDto)cmbProvincias.SelectedItem).Id


            };

            localidadServicio.Modificar(ModiFicarLocalidad);
            return true;
        }

        protected override bool EjecutarComandoEliminar()
        {
            if (_entidadId == null) return false;

            localidadServicio.Eliminar(_entidadId.Value);

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fNuevaProvincia = new _00006_Provincias_ABM(TipoOperacion.Nuevo);
            fNuevaProvincia.ShowDialog();

            if (fNuevaProvincia.RealizoAlgunaOperacion)
            {
                CargarComboBox(cmbProvincias, provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");
            }
        }
    }
}
