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
using Xcom.Servicio.Core.CondicionIva;

namespace Presentacion.Core.CondicionIva
{
    public partial class _00032_CondicionIva : FormularioConsulta
    {
      

        protected readonly ICondicionIvaServicio condicionIvaServicio;

        public _00032_CondicionIva()
            : this(new CondicionIvaServicio())
        {
            InitializeComponent();

            btnEliminar.Visible = false;
            btnEliminar.Enabled = false;
        }

        public _00032_CondicionIva(ICondicionIvaServicio _condicionIvaServicio)
        {
            condicionIvaServicio = _condicionIvaServicio;

            ActualizarDatos(dgvGrilla, string.Empty);
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);



            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = "Condicion IVA";


        }

        public override void ActualizarDatos(DataGridView grilla, string CadenaBuscar)
        {
            grilla.DataSource = condicionIvaServicio.Obtener(CadenaBuscar);
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
            var fMarcaAbm = new _00033_CondicionIva_ABM(TipoOperacion.Nuevo);
            fMarcaAbm.ShowDialog();
            ActualizarSegunOperacion(fMarcaAbm.RealizoAlgunaOperacion);

        }

        public override void EjecutarModificar()
        {
            base.EjecutarModificar();
            if (!puedeEjecutarComando) return;

            base.EjecutarModificar();



            var fMarcaAbm = new _00033_CondicionIva_ABM(TipoOperacion.Modificar, EntidadId);
            fMarcaAbm.ShowDialog();

            ActualizarSegunOperacion(fMarcaAbm.RealizoAlgunaOperacion);

        }

       


    }
}

