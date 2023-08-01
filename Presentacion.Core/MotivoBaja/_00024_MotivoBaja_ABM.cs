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
using Xcom.Servicio.Core.MotivoBaja;
using Xcom.Servicio.Core.MotivoBaja.DTOs;

namespace Presentacion.Core.MotivoBaja
{
    public partial class _00024_MotivoBaja_ABM : FormularioABM
    {
      

        protected readonly IMotivoBajaServicio  motivoBajaServicio;


        public _00024_MotivoBaja_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            motivoBajaServicio = new MotivoBajaServicio();

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
                var MotivoBaja = motivoBajaServicio.ObtenerPorId(entidadId.Value);
                if (MotivoBaja != null)
                {
                    txtDescripcion.Text = MotivoBaja.Descripcion;
                }
                else
                {
                    MessageBox.Show("ocurrio un error al selectionar el Motivo");
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("ocurrio un error al selectionar e Motivo");
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

            var NuevoMotivoBaja = new MotivoBajaDto
            {
                Descripcion = txtDescripcion.Text

            };

            motivoBajaServicio.Insertar(NuevoMotivoBaja);
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
            var ModificarMotivo = new MotivoBajaDto
            {

                Descripcion = txtDescripcion.Text,
                Id = _entidadId.Value

            };

            motivoBajaServicio.Modificar(ModificarMotivo);
            return true;
        }

       
    }
}
