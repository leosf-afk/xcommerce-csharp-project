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
using Xcom.Servicio.Core.MotivoReserva;
using Xcom.Servicio.Core.MotivoReserva.DTOs;

namespace Presentacion.Core.MotivoReserva
{
    public partial class _00035_MotivoReserva_ABM : FormularioABM
    {
        protected readonly IMotivoReservaServicio  motivoReservaServicio;


        public _00035_MotivoReserva_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            motivoReservaServicio = new MotivoReservaServicio();

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
                var MotivoBaja = motivoReservaServicio.ObtenerPorId(entidadId.Value);
                if (MotivoBaja != null)
                {
                    txtDescripcion.Text = MotivoBaja.Descripcion;
                }
                else
                {
                    MessageBox.Show("ocurrio un error al seleccionar el Motivo");
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("ocurrio un error al seleccionar e Motivo");
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

            var NuevoMotivoReserva = new MotivoReservaDto
            {
                Descripcion = txtDescripcion.Text

            };

            motivoReservaServicio.Insertar(NuevoMotivoReserva);
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
            var ModificarMotivo = new MotivoReservaDto
            {

                Descripcion = txtDescripcion.Text,
                Id = _entidadId.Value

            };

            motivoReservaServicio.Modificar(ModificarMotivo);
            return true;
        }

    }
}
