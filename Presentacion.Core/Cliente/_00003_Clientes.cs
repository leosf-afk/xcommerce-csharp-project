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
using Xcom.Servicio.Core.Empleado.DTOs;

namespace Presentacion.Core.Cliente
{
    public partial class _00003_Clientes : FormularioConsulta
    {
        protected readonly IClienteServicio clienteServicio;


        public _00003_Clientes()
           :  this(new ClienteServicio())
        {
            InitializeComponent();

            btnImprimir.Visible = true;
            btnImprimir.Enabled = true;
            btnImprimir.Text = "Ver Cta.Cte";
            btnImprimir.Image = Constantes.Imagen.ImagenOjo;


            btnPrueba.Visible = true;
            btnPrueba.Enabled = true;
            btnPrueba.Text = "Ver Efectivo";
            btnPrueba.Image = Constantes.Imagen.ImagenOjo;





        }

        public _00003_Clientes(ClienteServicio _clienteServicio )
        {

            clienteServicio = _clienteServicio;


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

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


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
                MessageBox.Show(@"El Cliente se encuentra Eliminado", @"Atención", MessageBoxButtons.OK,
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

        public override void EjecutarBotonImprimir()
        {

            var FCtaCte = new _00044_Cliente_Cta_Cte(EntidadId.Value);
            FCtaCte.ShowDialog();


           
        }

       


       public override void ejecutarBotonPrueba()
        {

             var FEfectivo = new _00045_Cliente_Efectivo(EntidadId.Value);
            FEfectivo.ShowDialog();
            

        }



    }
}
