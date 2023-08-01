using Presentacion.Core.BajaArticulo;
using Presentacion.Core.ListaPrecio;
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
using Xcom.Servicio.Core.Articulo;
using Xcom.Servicio.Core.Articulo.DTOs;
using Xcom.Servicio.Core.ListaPrecio;

namespace Presentacion.Core.Articulo
{
    public partial class _00013_Articulo : FormularioConsulta
    {
       

        private readonly IArticuloServicio articuloServicio;
        private readonly IListaPrecioServicio listaPrecioServicio;

        public static ArticuloDto ArticuloSeleccionado;

        bool grillaDobleClicks;

        public _00013_Articulo()
            : this(new ArticuloServicio() , new bool())
        {
            InitializeComponent();

            btnImprimir.Visible = true;
            btnImprimir.Enabled = true;
            btnImprimir.Text = "Dar De Baja";
            btnImprimir.Image = Presentacion.Constantes.Imagen.ImagenBotonBorrar;
            ArticuloSeleccionado = null;
            grillaDobleClicks = false;
        }


        public _00013_Articulo(bool Seleccionar)
            
        {
            articuloServicio = new ArticuloServicio();
            listaPrecioServicio = new ListaPrecioServicio();
            grillaDobleClicks = Seleccionar;
           
        }

        public _00013_Articulo(IArticuloServicio _articuloServicio , bool Seleccionar)
        {
            articuloServicio = _articuloServicio;
            listaPrecioServicio = new ListaPrecioServicio();
            grillaDobleClicks = Seleccionar;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = "Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            


            grilla.Columns["Codigo"].Visible = true;
            grilla.Columns["Codigo"].Width = 100;
            grilla.Columns["Codigo"].HeaderText = "Codigo";
            grilla.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grilla.Columns["Stock"].Visible = true;
            grilla.Columns["Stock"].Width = 100;
            grilla.Columns["Stock"].HeaderText = " Stock";
            grilla.Columns["Stock"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grilla.Columns["StockMinimo"].Visible = true;
            grilla.Columns["StockMinimo"].Width = 150;
            grilla.Columns["StockMinimo"].HeaderText = "StockMinimo";
            grilla.Columns["StockMinimo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["StockMinimo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }


        public override void ActualizarDatos(DataGridView grilla, string CadenaBuscar)
        {
            grilla.DataSource = articuloServicio.Obtener(CadenaBuscar);

        }


        public override void EjecutarEliminar()
        {
            base.EjecutarEliminar();
            if (!puedeEjecutarComando) return;
            if (!((ArticuloDto)EntidadSeleccionada).EstaEliminado)
            {




                var FArticuloAbm = new _00014_Articulo_ABM(TipoOperacion.Eliminar, EntidadId);

                FArticuloAbm.ShowDialog();

                ActualizarSegunOperacion(FArticuloAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Articulo se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }


        public override void EjecutarModificar()
        {

            base.EjecutarModificar();
            if (!puedeEjecutarComando) return;
            if (!((ArticuloDto)EntidadSeleccionada).EstaEliminado)
            {




                var FArticuloAbm = new _00014_Articulo_ABM(TipoOperacion.Modificar, EntidadId);
                FArticuloAbm.ShowDialog();

                ActualizarSegunOperacion(FArticuloAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Articulo se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }


        }


        public override void EjecutarNuevo()
        {
            if (!listaPrecioServicio.verificarExisteListaPrecio())
            {
                DialogResult result  = MessageBox.Show("Debe crear una lista de precios 'Basicos' antes de ingresar un Producto, ¿ Desea crearla ?","Atencion", MessageBoxButtons.OKCancel );
            

                if (result == DialogResult.OK)
                {
                    var FormListaPrecio = new _00015_ListaPrecios();
                    FormListaPrecio.ShowDialog();
                }

                return;
                
            }

            var FArticuloAbm = new _00014_Articulo_ABM(TipoOperacion.Nuevo);
            FArticuloAbm.ShowDialog();
            ActualizarSegunOperacion(FArticuloAbm.RealizoAlgunaOperacion);
           


        }


        private void ActualizarSegunOperacion(bool RealizoAlgunaOperacion)
        {
            if (RealizoAlgunaOperacion)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }


        public override void EjecutarBotonImprimir()
        {
            if (EntidadId == null)
            {
                return;
            }
            base.EjecutarBotonImprimir();
            var FormMotivoBaja = new _00026_BajaArticulo_ABM(TipoOperacion.Nuevo ,EntidadId );
            
            FormMotivoBaja.ShowDialog();
        }

        public override void grillaDobleClick()
        {
            if (grillaDobleClicks)
            {
                if (dgvGrilla.SelectedRows.Count == 1)
                {
                    ArticuloSeleccionado = ((ArticuloDto)dgvGrilla.CurrentRow.DataBoundItem);
                    this.Close();
                }
            }
        }

    }
}
