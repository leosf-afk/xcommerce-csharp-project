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
using Xcom.Servicio.Core.Rubro;
using Xcom.Servicio.Core.Rubro.DTOs;

namespace Presentacion.Core.Rubro
{
    public partial class _00011_Rubro : FormularioConsulta
    {
        

        protected readonly IRubroservicio rubroservicio;

        public _00011_Rubro()
            : this(new RubroServicio())
        {
            InitializeComponent();
        }

        public _00011_Rubro(IRubroservicio _rubroservicio)
        {
            rubroservicio = _rubroservicio;

            ActualizarDatos(dgvGrilla, string.Empty);
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);



            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = "Rubros";

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public override void ActualizarDatos(DataGridView grilla, string CadenaBuscar)
        {
            grilla.DataSource = rubroservicio.Obtener(CadenaBuscar);
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
            var FRubroABM = new _00012_Rubro_ABM(TipoOperacion.Nuevo);
            FRubroABM.ShowDialog();
            ActualizarSegunOperacion(FRubroABM.RealizoAlgunaOperacion);

        }

        public override void EjecutarModificar()
        {
            base.EjecutarModificar();
            if (!puedeEjecutarComando) return;
            if (!((RubroDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();



                var FRubroABM = new _00012_Rubro_ABM(TipoOperacion.Modificar, EntidadId);
                FRubroABM.ShowDialog();

                ActualizarSegunOperacion(FRubroABM.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Provincia Se Encuentra Eliminada.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()

        {
            base.EjecutarEliminar();

            if (!puedeEjecutarComando) return;
            if (!((RubroDto)EntidadSeleccionada).EstaEliminado)
            {


                var FRubroABM = new _00012_Rubro_ABM(TipoOperacion.Eliminar, EntidadId);

                FRubroABM.ShowDialog();

                ActualizarSegunOperacion(FRubroABM.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Provincia Se Encuentra Eliminada.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

    }
}
