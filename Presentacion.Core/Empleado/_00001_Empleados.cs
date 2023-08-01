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
using Xcom.Servicio.Core.Empleado;
using Xcom.Servicio.Core.Empleado.DTOs;

namespace Presentacion.Core.Empleado
{
    public partial class _00001_Empleados : FormularioConsulta
    {
        private readonly IEmpleadoServicio _empleadoServicio;

        public static EmpleadoDto EmpleadoSeleccionado;

        bool grillaDobleClicks;

        public _00001_Empleados()
            : this(new EmpleadoServicio() , new bool())
        {
            InitializeComponent();

            grillaDobleClicks = false;
        }


        public _00001_Empleados(bool _grillaDobleClick)
        {
            _empleadoServicio = new EmpleadoServicio();
            grillaDobleClicks = _grillaDobleClick;
        }


        public _00001_Empleados(IEmpleadoServicio empleadoServicio , bool _grillaDobleClick)
        {
            _empleadoServicio = empleadoServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Legajo"].Visible = true;
            grilla.Columns["Legajo"].Width = 100;
            grilla.Columns["Legajo"].HeaderText = "Legajo";
            grilla.Columns["Legajo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["ApyNom"].Visible = true;
            grilla.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["ApyNom"].HeaderText = "Apellido Y Nombre";
            grilla.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Dni"].Visible = true;
            grilla.Columns["Dni"].Width = 100;
            grilla.Columns["Dni"].HeaderText = " DNI";
            grilla.Columns["Dni"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Celular"].Visible = true;
            grilla.Columns["Celular"].Width = 150;
            grilla.Columns["Celular"].HeaderText = "Celular";
            grilla.Columns["Celular"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }


        public override void ActualizarDatos(DataGridView grilla, string CadenaBuscar)
        {
            grilla.DataSource = _empleadoServicio.Obtener(CadenaBuscar);

        }


        public override void EjecutarEliminar()
        {
            base.EjecutarEliminar();
            if (!puedeEjecutarComando) return;
            if (!((EmpleadoDto)EntidadSeleccionada).EstaEliminado)
            {
               

               

                var fEmpleadoAbm = new _00002_ABM_Empleados(TipoOperacion.Eliminar, EntidadId);

                fEmpleadoAbm.ShowDialog();

                ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El empleado se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }


        public override void EjecutarModificar()
        {
          
            base.EjecutarModificar();
            if (!puedeEjecutarComando) return;
            if (!((EmpleadoDto)EntidadSeleccionada).EstaEliminado)
            {
              

              

                var fEmpleadoAbm = new _00002_ABM_Empleados(TipoOperacion.Modificar, EntidadId);
                fEmpleadoAbm.ShowDialog();

                ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El empleado se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

           
        }


        public override void EjecutarNuevo()
        {
            var fEmpleadoabm = new _00002_ABM_Empleados(TipoOperacion.Nuevo);
            fEmpleadoabm.ShowDialog();
            ActualizarSegunOperacion(fEmpleadoabm.RealizoAlgunaOperacion);

        }


        private void ActualizarSegunOperacion(bool RealizoAlgunaOperacion)
        {
            if (RealizoAlgunaOperacion)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }


        public override void grillaDobleClick()
        {
            if (grillaDobleClicks)
            {

                if (dgvGrilla.SelectedRows.Count == 1)
                {
                    EmpleadoSeleccionado = ((EmpleadoDto)dgvGrilla.CurrentRow.DataBoundItem);
                    this.Close();
                }
            }

          
        }

    }
}
