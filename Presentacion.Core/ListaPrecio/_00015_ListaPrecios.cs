using Presentacion.Core.Precios;
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
using Xcom.AccesoDatos;
using Xcom.Servicio.Core.ListaPrecio;
using Xcom.Servicio.Core.ListaPrecio.DTOs;

namespace Presentacion.Core.ListaPrecio
{
    public partial class _00015_ListaPrecios : FormularioConsulta
    {
       

        protected readonly IListaPrecioServicio listaPrecio;

        public _00015_ListaPrecios()
            : this(new ListaPrecioServicio())
        {
            InitializeComponent();
        }

        public _00015_ListaPrecios(IListaPrecioServicio _listaPrecio )
        {
            listaPrecio = _listaPrecio;
            btnImprimir.Visible = true;
            btnImprimir.Enabled = true;
            btnImprimir.Text = "  Ver Lista ";
            btnImprimir.Image = Presentacion.Constantes.Imagen.ImagenOjo;

            ActualizarDatos(dgvGrilla, string.Empty);
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);



            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = "Descripcion";


            grilla.Columns["REntabilidad"].Visible = true;
            grilla.Columns["REntabilidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["REntabilidad"].HeaderText = "Porcentaje De Rentabilidad ";

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public override void ActualizarDatos(DataGridView grilla, string CadenaBuscar)
        {
            EntidadId = null;
            grilla.DataSource = listaPrecio.Obtener(CadenaBuscar);
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
            var FRubroABM = new _00016_ListaPrecios_ABM(TipoOperacion.Nuevo);
            FRubroABM.ShowDialog();
            ActualizarSegunOperacion(FRubroABM.RealizoAlgunaOperacion);

        }

        public override void EjecutarModificar()
        {
            base.EjecutarModificar();
            if (!puedeEjecutarComando) return;
            if (!((ListaPrecioDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();



                var FListaPrecio = new _00016_ListaPrecios_ABM(TipoOperacion.Modificar, EntidadId);
                FListaPrecio.ShowDialog();

                ActualizarSegunOperacion(FListaPrecio.RealizoAlgunaOperacion);
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
            if (!((ListaPrecioDto)EntidadSeleccionada).EstaEliminado)
            {


                var FListaPrecio = new _00016_ListaPrecios_ABM(TipoOperacion.Eliminar, EntidadId);

                FListaPrecio.ShowDialog();

                ActualizarSegunOperacion(FListaPrecio.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Provincia Se Encuentra Eliminada.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

     
        public override void EjecutarBotonImprimir()
        {

            if (EntidadId == null)
            {
                MessageBox.Show("No hay datos cargados");
                return;
            } 

            base.EjecutarBotonImprimir();

            var prueba = new _00019_Precios(TipoOperacion.Modificar, EntidadId);
            prueba.ShowDialog();

        }

    }
}
