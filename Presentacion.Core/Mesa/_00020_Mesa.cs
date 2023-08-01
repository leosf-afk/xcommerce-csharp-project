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
using Xcom.Servicio.Core.Mesa;
using Xcom.Servicio.Core.Mesa.DTOs;

namespace Presentacion.Core.Mesa
{
    public partial class _00020_Mesa : FormularioConsulta
    {


        protected readonly IMesaServicio mesaServicio;

        public _00020_Mesa()
            : this(new Mesaservicio())
        {
            InitializeComponent();
        }

        public _00020_Mesa(IMesaServicio _mesaServicio )
        {
            mesaServicio = _mesaServicio;

            ActualizarDatos(dgvGrilla, string.Empty);
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Numero"].Visible = true;
            grilla.Columns["Numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Numero"].HeaderText = "Numero";

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = "Salon";

            grilla.Columns["EstadoMesa"].Visible = true;
            grilla.Columns["EstadoMesa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["EstadoMesa"].HeaderText = "Estado De Mesa";

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public override void ActualizarDatos(DataGridView grilla, string CadenaBuscar)
        {
            grilla.DataSource = mesaServicio.Obtener(CadenaBuscar);
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
            var FMesaABM = new _00021_Mesa_ABM(TipoOperacion.Nuevo);
            FMesaABM.ShowDialog();
            ActualizarSegunOperacion(FMesaABM.RealizoAlgunaOperacion);

        }

        public override void EjecutarModificar()
        {
            base.EjecutarModificar();
            if (!puedeEjecutarComando) return;
            if (!((MesaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();



                var FMesaABM = new _00021_Mesa_ABM(TipoOperacion.Modificar, EntidadId);
                FMesaABM.ShowDialog();

                ActualizarSegunOperacion(FMesaABM.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Mesa Se Encuentra Eliminada.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()

        {
            base.EjecutarEliminar();

            if (!puedeEjecutarComando) return;
            if (!((MesaDto)EntidadSeleccionada).EstaEliminado)
            {


                var FMesaABM = new _00021_Mesa_ABM(TipoOperacion.Eliminar, EntidadId);

                FMesaABM.ShowDialog();

                ActualizarSegunOperacion(FMesaABM.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Provincia Se Encuentra Eliminada.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
