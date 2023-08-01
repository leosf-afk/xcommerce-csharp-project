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
using Xcom.Servicio.Core.Marca;
using Xcom.Servicio.Core.Marca.DTOs;

namespace Presentacion.Core.Marca
{
    public partial class _00009_Marcas : FormularioConsulta
    {
        protected readonly IMarcaServicio marcaServicio;

        public _00009_Marcas()
            : this(new MarcaServicio()) 
        {
            InitializeComponent();
        }

        public _00009_Marcas(IMarcaServicio _marcaServicio)
        {
            marcaServicio = _marcaServicio;

            ActualizarDatos(dgvGrilla , string.Empty);
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);



            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = "Marca";

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public override void ActualizarDatos(DataGridView grilla, string CadenaBuscar)
        {
            grilla.DataSource = marcaServicio.Obtener(CadenaBuscar);
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
            var fMarcaAbm = new _00010_Marcas_ABM(TipoOperacion.Nuevo);
            fMarcaAbm.ShowDialog();
            ActualizarSegunOperacion(fMarcaAbm.RealizoAlgunaOperacion);

        }

        public override void EjecutarModificar()
        {
            base.EjecutarModificar();
            if (!puedeEjecutarComando) return;
            if (!((MarcaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();



                var fMarcaAbm = new _00010_Marcas_ABM(TipoOperacion.Modificar, EntidadId);
                fMarcaAbm.ShowDialog();

                ActualizarSegunOperacion(fMarcaAbm.RealizoAlgunaOperacion);
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
            if (!((MarcaDto)EntidadSeleccionada).EstaEliminado)
            {


                var fMarcaAbm = new _00010_Marcas_ABM(TipoOperacion.Eliminar, EntidadId);

                fMarcaAbm.ShowDialog();

                ActualizarSegunOperacion(fMarcaAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Provincia Se Encuentra Eliminada.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        
           



        

    }
}
