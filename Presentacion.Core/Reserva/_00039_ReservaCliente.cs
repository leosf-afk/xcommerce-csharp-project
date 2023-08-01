using Presentacion.Core.Cliente;
using Presentacion.Core.Comprobante;
using Presentacion.Core.Empleado;
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
using Xcom.Servicio.Core.Cliente;
using Xcom.Servicio.Core.Cliente.Dtos;
using Xcom.Servicio.Core.FormaPago.DTOs;

namespace Presentacion.Core.Reserva
{
    public partial class _00039_ReservaCliente : FormularioConsulta
    {
      
        
        protected readonly IClienteServicio clienteServicio;

        public static ClienteDto ClienteSeleccionado;

        public _00039_ReservaCliente()
           : this(new ClienteServicio())
        {
            InitializeComponent();


        }

        public _00039_ReservaCliente(ClienteServicio _clienteServicio)
        {

            clienteServicio = _clienteServicio;
            ClienteSeleccionado = null;
            btnImprimir.Visible = true;
            btnImprimir.Enabled = true;
            btnImprimir.Image = Constantes.Imagen.ImagenOjo;
            btnImprimir.Text = "Ver Cta Cte";
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);


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

            grilla.Columns["MontoMaximoCtaCte"].Visible = true;
            grilla.Columns["MontoMaximoCtaCte"].Width = 100;
            grilla.Columns["MontoMaximoCtaCte"].HeaderText = @"Cta Cte";
            grilla.Columns["MontoMaximoCtaCte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["MontoMaximoCtaCte"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }


        public override void ActualizarDatos(DataGridView grilla, string CadenaBuscar)
        {
            

            grilla.DataSource = clienteServicio.ObtenerCliente(CadenaBuscar);

        }


        public override void EjecutarEliminar()
        {
            base.EjecutarEliminar();
            if (!puedeEjecutarComando) return;

            if (!((ClienteDto)EntidadSeleccionada).EstaEliminado)
            {



                var FormClienteABM = new _00004_Clientes_ABM(TipoOperacion.Eliminar, EntidadId);

                FormClienteABM.ShowDialog();

                ActualizarSegunOperacion(FormClienteABM.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Cliente se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }


        public override void EjecutarModificar()
        {
            base.EjecutarModificar();

            if (!puedeEjecutarComando) return;
            if (!((ClienteDto)EntidadSeleccionada).EstaEliminado)
            {


                if (!puedeEjecutarComando) return;

                var FormClienteABM = new _00004_Clientes_ABM(TipoOperacion.Modificar, EntidadId);
                FormClienteABM.ShowDialog();

                ActualizarSegunOperacion(FormClienteABM.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Cliente se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }


        }


        public override void EjecutarNuevo()
        {
            var FormClienteABM = new _00004_Clientes_ABM(TipoOperacion.Nuevo);
            FormClienteABM.ShowDialog();
            ActualizarSegunOperacion(FormClienteABM.RealizoAlgunaOperacion);

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
            if (dgvGrilla.SelectedRows.Count > 0)
            {
                ClienteSeleccionado = ((ClienteDto)dgvGrilla.CurrentRow.DataBoundItem);
                this.Close();
            }
        }


        public override void EjecutarBotonImprimir()
        {
            var FCtaCte = new _00044_Cliente_Cta_Cte(EntidadId.Value);
            FCtaCte.ShowDialog();
        }

    }
}
