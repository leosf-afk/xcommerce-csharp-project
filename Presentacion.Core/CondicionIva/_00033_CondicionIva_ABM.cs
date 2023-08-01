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
using Xcom.Servicio.Core.CondicionIva;
using Xcom.Servicio.Core.CondicionIva.DTOs;

namespace Presentacion.Core.CondicionIva
{
    public partial class _00033_CondicionIva_ABM : FormularioABM
    {
       

        protected readonly ICondicionIvaServicio condicionIvaServicio;


        public _00033_CondicionIva_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            condicionIvaServicio = new CondicionIvaServicio();

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
                var MotivoBaja = condicionIvaServicio.ObtenerPorId(entidadId.Value);
                if (MotivoBaja != null)
                {
                    txtDescripcion.Text = MotivoBaja.Descripcion;
                }
                else
                {
                    MessageBox.Show("ocurrio un error al seleccionar la Condicion IVA");
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("ocurrio un error al seleccionar la Condicion IVA");
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

            var NuevaCondicion = new CondicionIvaDto
            {
                Descripcion = txtDescripcion.Text

            };

            condicionIvaServicio.Insertar(NuevaCondicion);
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
            var ModificarCondicion = new CondicionIvaDto
            {

                Descripcion = txtDescripcion.Text,
                Id = _entidadId.Value

            };

            condicionIvaServicio.Modificar(ModificarCondicion);
            return true;
        }

       
    }
}
