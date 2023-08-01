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
using Xcom.Servicio.Core.MotivoReserva;

namespace Presentacion.Core.MotivoReserva
{
    public partial class _00034_MotivoReserva : FormularioConsulta
    {
       

        protected readonly IMotivoReservaServicio  motivoReservaServicio;

        public _00034_MotivoReserva()
            : this(new MotivoReservaServicio())
        {
            InitializeComponent();
        }

        public _00034_MotivoReserva(IMotivoReservaServicio _motivoReservaServicio)
        {
            motivoReservaServicio = _motivoReservaServicio;

            ActualizarDatos(dgvGrilla, string.Empty);
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);



            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = "Descripcion";


        }

        public override void ActualizarDatos(DataGridView grilla, string CadenaBuscar)
        {
            grilla.DataSource = motivoReservaServicio.Obtener(CadenaBuscar);
        }

        private void ActualizarSegunOperacion(bool RealizoAlgunaOperacion)
        {
            if (RealizoAlgunaOperacion)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }

        public override void EjecutarNuevo()
        {
            var fMotivoReservaABM = new _00035_MotivoReserva_ABM(TipoOperacion.Nuevo);
            fMotivoReservaABM.ShowDialog();
            ActualizarSegunOperacion(fMotivoReservaABM.RealizoAlgunaOperacion);

        }

        public override void EjecutarModificar()
        {
            base.EjecutarModificar();
            if (!puedeEjecutarComando) return;

            base.EjecutarModificar();



            var fMotivoReservaABM = new _00035_MotivoReserva_ABM(TipoOperacion.Modificar, EntidadId);
            fMotivoReservaABM.ShowDialog();

            ActualizarSegunOperacion(fMotivoReservaABM.RealizoAlgunaOperacion);

        }

       


    }
}
