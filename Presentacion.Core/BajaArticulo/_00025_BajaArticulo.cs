using Presentacion.Core.Articulo;
using Presentacion.Core.MotivoBaja;
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
using Xcom.Servicio.Core.BajaArticulo;
using Xcom.Servicio.Core.BajaArticulo.DTOs;

namespace Presentacion.Core.BajaArticulo
{
    public partial class _00025_BajaArticulo : FormularioConsulta
    {
       

        protected readonly  IArticuloBajaServicio articuloBajaServicio;

        public _00025_BajaArticulo()
            : this(new ArticuloBajaServicio())
        {
            InitializeComponent();

            btnEliminar.Enabled = false;
            btnEliminar.Visible = false;
            btnModificar.Image = Constantes.Imagen.ImagenOjo;
            btnModificar.Text = "Ver";
        }

        public _00025_BajaArticulo(IArticuloBajaServicio _articuloBajaServicio)
        {
            articuloBajaServicio = _articuloBajaServicio;

            ActualizarDatos(dgvGrilla, string.Empty);
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);



            grilla.Columns["ArticuloDescripcion"].Visible = true;
            grilla.Columns["ArticuloDescripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["ArticuloDescripcion"].HeaderText = "Articulo";

            grilla.Columns["Cantidad"].Visible = true;
            grilla.Columns["Cantidad"].Width = 100;
            grilla.Columns["Cantidad"].HeaderText = @"Cantidad";
            grilla.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["MotivoBaja"].Visible = true;
            grilla.Columns["MotivoBaja"].Width = 150;
            grilla.Columns["MotivoBaja"].HeaderText = @"Motivo";
            grilla.Columns["MotivoBaja"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["MotivoBaja"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["FechaBaja"].Visible = true;
            grilla.Columns["FechaBaja"].Width = 150;
            grilla.Columns["FechaBaja"].HeaderText = @"Fecha";
            grilla.Columns["FechaBaja"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["FechaBaja"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public override void ActualizarDatos(DataGridView grilla, string CadenaBuscar)
        {
            grilla.DataSource = articuloBajaServicio.Obtener(CadenaBuscar);
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
            var FBajaArticulo = new _00013_Articulo();
            FBajaArticulo.ShowDialog();
         

        }

        public override void EjecutarModificar()
        {
            base.EjecutarModificar();
            if (!puedeEjecutarComando) return;
           
                base.EjecutarModificar();


            //MessageBox.Show(EntidadId.Value.ToString());
            var FBajaArticulo = new _00026_BajaArticulo_ABM(TipoOperacion.Modificar, EntidadId);
                FBajaArticulo.ShowDialog();

                ActualizarSegunOperacion(FBajaArticulo.RealizoAlgunaOperacion);
          
        }

        public override void EjecutarEliminar()

        {
            base.EjecutarEliminar();

            if (!puedeEjecutarComando) return;
           


                var FBajaArticulo = new _00026_BajaArticulo_ABM(TipoOperacion.Eliminar, EntidadId);

                FBajaArticulo.ShowDialog();

                ActualizarSegunOperacion(FBajaArticulo.RealizoAlgunaOperacion);
          
        }


    }
}
