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
using Xcom.Servicio.Core.Provincia;
using Xcom.Servicio.Core.Provincia.DTOs;

namespace Presentacion.Core.Provincia
{
    public partial class _00005_Provincias : FormularioConsulta
    {
        private readonly IProvinciaServicio _provinciaServicio;
        

        public _00005_Provincias()
          : this(new ProvinciaServicio())
        {
            InitializeComponent();
        }

        public _00005_Provincias(IProvinciaServicio provinciaServicio)
        {
            _provinciaServicio = provinciaServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

           

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = "Provincia";

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public override void ActualizarDatos(DataGridView grilla, string CadenaBuscar)
        {
            grilla.DataSource = _provinciaServicio.Obtener(CadenaBuscar);
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
            var formProvinciaAbm = new _00006_Provincias_ABM(TipoOperacion.Nuevo);
            formProvinciaAbm.ShowDialog();
            ActualizarSegunOperacion(formProvinciaAbm.RealizoAlgunaOperacion);

        }

        public override void EjecutarModificar()
        {
            base.EjecutarModificar();
            if (!puedeEjecutarComando) return;
            if (!((ProvinciaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

              

                var fEmpleadoAbm = new _00006_Provincias_ABM(TipoOperacion.Modificar, EntidadId);
                fEmpleadoAbm.ShowDialog();

                ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
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
            if (!((ProvinciaDto)EntidadSeleccionada).EstaEliminado)
            {
               

                var fEmpleadoAbm = new _00006_Provincias_ABM(TipoOperacion.Eliminar, EntidadId);

                fEmpleadoAbm.ShowDialog();

                ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Provincia Se Encuentra Eliminada.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void _00005_Provincias_Load(object sender, EventArgs e)
        {
          ActualizarDatos(dgvGrilla,string.Empty);
        }
    }
}
