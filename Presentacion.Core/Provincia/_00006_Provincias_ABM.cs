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
using Xcom.Servicio.Core.Provincia;
using Xcom.Servicio.Core.Provincia.DTOs;

namespace Presentacion.Core.Provincia
{
    public partial class _00006_Provincias_ABM : FormularioABM
    {
        private readonly IProvinciaServicio _provinciaServicio;

        public _00006_Provincias_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
             : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _provinciaServicio = new ProvinciaServicio();

           

            AgregarControlesObligatorios(txtDescripcion, "Descripción");
            AsignarEventoEnterLeave(this);
            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {


            txtDescripcion.MaxLength = 250;
            // Asignando un Evento
            txtDescripcion.KeyPress += Validacion.NoSimbolos;
            txtDescripcion.KeyPress += Validacion.NoNumeros;

            txtDescripcion.Focus();
        }

        public override void CargarDatos(long? entidadId)
        {


            if (_tipoOperacion == TipoOperacion.Nuevo) return;

            else if (_tipoOperacion == TipoOperacion.Eliminar || _tipoOperacion == TipoOperacion.Modificar)
            {
                base.CargarDatos(entidadId);
                var provincia = _provinciaServicio.ObtenerPorId(entidadId.Value);
                if (provincia != null)
                {
                    txtDescripcion.Text = provincia.Descripcion;
                }
                else 
                {
                    MessageBox.Show("ocurrio un error al selectionar La Provincia");
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("ocurrio un error al selectionar La Provincia");
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

            if (_provinciaServicio.VerificarExistencia(txtDescripcion.Text, null))
            {
                MessageBox.Show($" Ya existe una provincia con el nombre {txtDescripcion.Text}");
                return false;

            }



            var NuevaProvincia = new ProvinciaDto
            {
                Descripcion = txtDescripcion.Text
                
            };

            _provinciaServicio.Insertar(NuevaProvincia);
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


            if (_provinciaServicio.VerificarExistencia(txtDescripcion.Text, _entidadId ))
            {
                MessageBox.Show($" Ya existe una provincia con el nombre {txtDescripcion.Text}");
                return false;

            }

            var ModificarProvincia = new ProvinciaDto
            {
                
                Descripcion = txtDescripcion.Text,
                Id = _entidadId.Value
                
            };

            _provinciaServicio.Modificar(ModificarProvincia);
            return true;
        }

        protected override bool EjecutarComandoEliminar()
        {
            if (_entidadId == null) return false;

            _provinciaServicio.Eliminar(_entidadId.Value);

            return true;
        }

    }
}
