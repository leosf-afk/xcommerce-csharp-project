using Presentacion.Core.Mesa;
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
using Xcom.Servicio.Core.Salon;
using Xcom.Servicio.Core.Salon.DTOs;

namespace Presentacion.Core.Salon
{
    public partial class _00022_MesasSalon : FormularioConsulta
    {
       

        protected readonly IMesaServicio mesaServicio;
        protected readonly ISalonServicio salonServicio;
        protected long? _entidadId;
        protected TipoOperacion _tipoOperacion;
        public bool RealizoAlgunaOperacion { get; set; }

        public _00022_MesasSalon(TipoOperacion tipoOperacion)
            
        {
            InitializeComponent();
            

            ActualizarDatos(dgvGrilla , string.Empty);

          
        }

        public _00022_MesasSalon( long? entidadId)
        {
            _entidadId = entidadId;
            mesaServicio = new Mesaservicio();
            salonServicio = new SalonServicio();
            ActualizarDatos(dgvGrilla, string.Empty);
        }

     

        public override void FormatearGrilla(DataGridView grilla)
        {
           

          

            base.FormatearGrilla(grilla);
            

            grilla.Columns["NombreMesa"].Visible = true;
            grilla.Columns["NombreMesa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["NombreMesa"].HeaderText = "Descripcion";

            grilla.Columns["NumeroMesa"].Visible = true;
            grilla.Columns["NumeroMesa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["NumeroMesa"].HeaderText = "Numero de Mesa";

            grilla.Columns["EstadoMesa"].Visible = true;
            grilla.Columns["EstadoMesa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["EstadoMesa"].HeaderText = "Estado De Mesa";

            //grilla.Columns["EstaEliminadoStr"].Visible = true;
            //grilla.Columns["EstaEliminadoStr"].Width = 100;
            //grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            //grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public override void ActualizarDatos(DataGridView grilla, string CadenaBuscar)
        {
            
             
            grilla.DataSource = salonServicio.ObtenerMesas(_entidadId, CadenaBuscar);

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
            if (!((MesasSalonDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();



                var FMesaABM = new _00021_Mesa_ABM(TipoOperacion.Modificar, EntidadId);
                FMesaABM.ShowDialog();

                ActualizarSegunOperacion(FMesaABM.RealizoAlgunaOperacion);
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
            if (!((MesasSalonDto)EntidadSeleccionada).EstaEliminado)
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

        private void _00022_MesasSalon_Load(object sender, EventArgs e)
        {
            ActualizarDatos(dgvGrilla, string.Empty);
           this.Text = ($"{salonServicio.ObtenerPorId(_entidadId.Value).Descripcion}");

        }
    }
}
