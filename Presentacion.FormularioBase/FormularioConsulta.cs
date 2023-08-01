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

namespace Presentacion.FormularioBase
{
    public partial class FormularioConsulta : FormularioBase
    {
        protected long? EntidadId;
        protected bool puedeEjecutarComando;
        protected object EntidadSeleccionada;


        public FormularioConsulta()
        {
            InitializeComponent();

            btnImprimir.Visible = false;
            //btnEfectivo.Visible = false;


            //Asignamos el evento
            txtBuscar.Enter += Control_Enter;

            txtBuscar.Leave += Control_Leave;

            //asignacion de imagenes a botones
            btnNuevo.Image = Constantes.Imagen.ImagenBotonNuevo;
            btnEliminar.Image = Constantes.Imagen.ImagenBotonBorrar;
            btnActualizar.Image = Constantes.Imagen.ImagenBotonActualizar;
            btnImprimir.Image = Constantes.Imagen.ImagenBotonImprimir;
            //btnEfectivo.Image = Constantes.Imagen.ImagenBotonImprimir;
            btnSalir.Image = Constantes.Imagen.ImagenBotonSalir;
            btnModificar.Image = Constantes.Imagen.ImagenBotonModificar;
            ImagenBuscar.Image = Constantes.Imagen.ImagenBusacar;
            // Asignar Colores
            BackColor = Constantes.Color.ColorFondo;
            menuAccesoRapido.BackColor = Constantes.Color.ColorMenu;
            btnNuevo.ForeColor = Constantes.Color.ColorLetraMenu;
            btnEliminar.ForeColor = Constantes.Color.ColorLetraMenu;
            btnActualizar.ForeColor = Constantes.Color.ColorLetraMenu; ;
            btnImprimir.ForeColor = Constantes.Color.ColorLetraMenu;
            //btnEfectivo.ForeColor = Constantes.Color.ColorLetraMenu;
            btnSalir.ForeColor = Constantes.Color.ColorLetraMenu;
            btnModificar.ForeColor = Constantes.Color.ColorLetraMenu;

            EntidadId = null;
            puedeEjecutarComando = false;
         

        }

        protected bool HayDatosCargados()
        {
            if (dgvGrilla.RowCount > 0)
            {
                return true;
            }
            else
            {
                EntidadId = null;
                return false;
            }

            
        }

        private void FormularioConsulta_Load(object sender, EventArgs e)
        {
            EjecutarLoadFormulario();
            FormatearGrilla(dgvGrilla );
        }

        public virtual void EjecutarLoadFormulario()
        {
            ActualizarDatos(dgvGrilla,string.Empty);
        }

        //=======================================================================//
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EjecutarNuevo();
         

        }

        public virtual void EjecutarNuevo()
        {
            
        }
        //=======================================================================//

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            puedeEjecutarComando = false;
            EjecutarEliminar();
           
        }

        public virtual void EjecutarEliminar()
        {
            if (HayDatosCargados())
            {
                if (!EntidadId.HasValue)
                {
                    MessageBox.Show(@"porfavor seleccione un registro.");
                    puedeEjecutarComando = false;
                    return;

                }
                else
                {
                    puedeEjecutarComando = true;
                }

            }
            else
            {
                MessageBox.Show(@"No hay datos cargados");
                return;
                
            }
        }



        //=======================================================================//
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(dgvGrilla, string.Empty);
        }

        public virtual void ActualizarDatos(DataGridView grilla, string CadenaBuscar)
        {
           
        }


        //=======================================================================//

        private void btnModificar_Click(object sender, EventArgs e)
        {


            puedeEjecutarComando = false;
            EjecutarModificar();
           
        }

        public virtual void EjecutarModificar()
        {
            if (HayDatosCargados())
            {
                if (!EntidadId.HasValue)
                {
                    MessageBox.Show(@"porfavor seleccione un registro.");
                    puedeEjecutarComando = false;
                    return;

                }
                else
                {
                    puedeEjecutarComando = true;
                }
              
            }
            else
            {
                MessageBox.Show(@"No hay datos cargados");
                return;
            }
        }



        //=======================================================================//

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //=======================================================================//

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(dgvGrilla ,txtBuscar.Text);
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            RowEnter(e);
        }

        public virtual void RowEnter(DataGridViewCellEventArgs e)
        {
            if (HayDatosCargados())
            {
                EntidadId = (long?)dgvGrilla["Id", e.RowIndex].Value;
                EntidadSeleccionada = dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
            else
            {
                EntidadId = null;
                EntidadSeleccionada = null;

            }
        }

        public virtual void FormatearGrilla(DataGridView grilla)
               {
                   for (int i = 0; i < grilla.ColumnCount; i++)
                   {
                       grilla.Columns[i].Visible = false;
                   }
               }

        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            EjecutarBotonImprimir();
        }

  
        public virtual void EjecutarBotonImprimir()
    {


    }

        private void dgvGrilla_DoubleClick(object sender, EventArgs e)
        {
            grillaDobleClick();
        }

        public virtual void grillaDobleClick()
        {
            
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            ejecutarPagarctacte();
        }

        public virtual void ejecutarPagarctacte()
        {
           
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            ejecutarBotonPrueba();
        }

        public virtual void ejecutarBotonPrueba()
        {

        }
    }
}
