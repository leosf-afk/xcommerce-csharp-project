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
using Xcom.Servicio.Core.Localidad;
using Xcom.Servicio.Core.Localidad.DTOs;

namespace Presentacion.Core.Localidad
{
    public partial class _00007_Localidad : FormularioConsulta


    {
        protected readonly ILocalidadServicio localidadServicio;

        public _00007_Localidad()
            : this(new LocalidadServicio())
        {
            InitializeComponent();

        }


        public _00007_Localidad(ILocalidadServicio _localidadServicio)
        {
            localidadServicio = _localidadServicio;

        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = "Localidades";


            grilla.Columns["Provincia"].Visible = true;
            grilla.Columns["Provincia"].Width = 200;
            grilla.Columns["Provincia"].HeaderText = "Provincia";

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public override void ActualizarDatos(DataGridView grilla, string CadenaBuscar)
        {
            
            grilla.DataSource = localidadServicio.ObtenerLocalidades(CadenaBuscar);
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
            var FormLocalidadaABM = new _00008_Localidad_ABM(TipoOperacion.Nuevo);
            FormLocalidadaABM.ShowDialog();
            ActualizarSegunOperacion(FormLocalidadaABM.RealizoAlgunaOperacion);

        }

        public override void EjecutarModificar()
        {
           

            base.EjecutarModificar();

            if (puedeEjecutarComando)
            {
                if (!((LocalidadDto)EntidadSeleccionada).EstaEliminado)
                {

                    if (!puedeEjecutarComando) return;

                    var fEmpleadoAbm = new _00008_Localidad_ABM(TipoOperacion.Modificar, EntidadId);
                    fEmpleadoAbm.ShowDialog();

                    ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
                }
                else
                {
                    MessageBox.Show(@"La Localidad se encuetra Eliminada", @"Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

            }
        }

        public override void EjecutarEliminar()
        {
            base.EjecutarEliminar();
            if (!puedeEjecutarComando) return;
            if (!((LocalidadDto)EntidadSeleccionada).EstaEliminado)
            {
               

              

                var FLocalidadABM = new _00008_Localidad_ABM(TipoOperacion.Eliminar, EntidadId);

                FLocalidadABM.ShowDialog();

                ActualizarSegunOperacion(FLocalidadABM.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Localidad se encuetra Eliminada", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
