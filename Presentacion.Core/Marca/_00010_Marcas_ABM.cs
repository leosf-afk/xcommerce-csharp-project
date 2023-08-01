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
using Xcom.Servicio.Core.Marca;
using Xcom.Servicio.Core.Marca.DTOs;

namespace Presentacion.Core.Marca
{
    public partial class _00010_Marcas_ABM : FormularioABM
    {
        protected readonly IMarcaServicio marcaServicio;


        public _00010_Marcas_ABM(TipoOperacion tipoOperacion , long? entidadId = null)
            :base(tipoOperacion,entidadId)
        {
            InitializeComponent();

            marcaServicio = new MarcaServicio();

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
                var Marca = marcaServicio.ObtenerPorId(entidadId.Value);
                if (Marca != null)
                {
                    txtDescripcion.Text = Marca.Descripcion;
                }
                else
                {
                    MessageBox.Show("ocurrio un error al selectionar La Marca");
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("ocurrio un error al selectionar La Marca");
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

            var NuevaMarca = new MarcaDto
            {
                Descripcion = txtDescripcion.Text

            };

            marcaServicio.Insertar(NuevaMarca);
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
            var ModificarProvincia = new MarcaDto
            {

                Descripcion = txtDescripcion.Text,
                Id = _entidadId.Value

            };

            marcaServicio.Modificar(ModificarProvincia);
            return true;
        }

        protected override bool EjecutarComandoEliminar()
        {
            if (_entidadId == null) return false;

            marcaServicio.Eliminar(_entidadId.Value);

            return true;
        }
    }
}
