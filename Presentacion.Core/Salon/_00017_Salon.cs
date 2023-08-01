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
using Xcom.Servicio.Core.Salon;
using Xcom.Servicio.Core.Salon.DTOs;

namespace Presentacion.Core.Salon
{
    public partial class _00017_Salon : FormularioConsulta
    {


        protected readonly ISalonServicio salonServicio;

        public _00017_Salon()
            : this(new SalonServicio())
        {
            InitializeComponent();
            btnImprimir.Text = "Ver Mesas";
            btnImprimir.Image = Presentacion.Constantes.Imagen.ImagenOjo;
            btnImprimir.Enabled = true;
            btnImprimir.Visible = true;
        }

        public _00017_Salon(ISalonServicio _salonservicio)
        {
            salonServicio = _salonservicio;

            ActualizarDatos(dgvGrilla, string.Empty);
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);



            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = "Salon";

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public override void ActualizarDatos(DataGridView grilla, string CadenaBuscar)
        {
            grilla.DataSource = salonServicio.Obtener(CadenaBuscar);
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
            var FSalonABM = new _00018_Salon_ABM(TipoOperacion.Nuevo);
            FSalonABM.ShowDialog();
            ActualizarSegunOperacion(FSalonABM.RealizoAlgunaOperacion);

        }

        public override void EjecutarModificar()
        {
            base.EjecutarModificar();
            if (!puedeEjecutarComando) return;
            if (!((SalonDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();



                var FSalonABM = new _00018_Salon_ABM(TipoOperacion.Modificar, EntidadId);
                FSalonABM.ShowDialog();

                ActualizarSegunOperacion(FSalonABM.RealizoAlgunaOperacion);
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
            if (!((SalonDto)EntidadSeleccionada).EstaEliminado)
            {


                var FSalonABM = new _00018_Salon_ABM(TipoOperacion.Eliminar, EntidadId);

                FSalonABM.ShowDialog();

                ActualizarSegunOperacion(FSalonABM.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Provincia Se Encuentra Eliminada.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarBotonImprimir()
        {
           

            var FMesasSalon = new _00022_MesasSalon(EntidadId);
            FMesasSalon.ShowDialog();
        }

    }
}
