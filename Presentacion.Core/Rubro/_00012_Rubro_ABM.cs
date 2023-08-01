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
using Xcom.Servicio.Core.Rubro;
using Xcom.Servicio.Core.Rubro.DTOs;

namespace Presentacion.Core.Rubro
{
    public partial class _00012_Rubro_ABM : FormularioABM
    {
        protected readonly IRubroservicio rubroservicio;


        public _00012_Rubro_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            rubroservicio = new RubroServicio();
            AgregarControlesObligatorios(txtDescripcion, "Descripción");
            AsignarEventoEnterLeave(this);
            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {



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
                var  Rubro = rubroservicio.ObtenerPorId(entidadId.Value);
                if (Rubro != null)
                {
                    txtDescripcion.Text = Rubro.Descripcion;
                }
                else
                {
                    MessageBox.Show("ocurrio un error al selectionar El Rubro");
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("ocurrio un error al selectionar El rubro");
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

            var NuevoRubro = new RubroDto
            {
                Descripcion = txtDescripcion.Text

            };

            rubroservicio.Insertar(NuevoRubro);
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
            var ModificarRubro = new RubroDto
            {
                Id = _entidadId.Value,
                Descripcion = txtDescripcion.Text,
               

            };

            rubroservicio.Modificar(ModificarRubro);
            return true;
        }

        protected override bool EjecutarComandoEliminar()
        {
            if (_entidadId == null) { return false; }

            else{
                rubroservicio.Eliminar(_entidadId.Value);
                return true;
            };
           
        }
    }
}
