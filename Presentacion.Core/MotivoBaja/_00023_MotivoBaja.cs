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
using Xcom.Servicio.Core.MotivoBaja;
using Xcom.Servicio.Core.MotivoBaja.DTOs;

namespace Presentacion.Core.MotivoBaja
{
    public partial class _00023_MotivoBaja : FormularioConsulta
    {
       

        protected readonly IMotivoBajaServicio  motivoBajaServicio;

        public _00023_MotivoBaja()
            : this(new MotivoBajaServicio())
        {
            InitializeComponent();
        }

        public _00023_MotivoBaja(IMotivoBajaServicio _motivoBajaServicio)
        {
            motivoBajaServicio = _motivoBajaServicio;

            ActualizarDatos(dgvGrilla, string.Empty);
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);



            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = "Motivo De Baja";


        }

        public override void ActualizarDatos(DataGridView grilla, string CadenaBuscar)
        {
            grilla.DataSource = motivoBajaServicio.Obtener(CadenaBuscar);
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
            var fMarcaAbm = new _00024_MotivoBaja_ABM(TipoOperacion.Nuevo);
            fMarcaAbm.ShowDialog();
            ActualizarSegunOperacion(fMarcaAbm.RealizoAlgunaOperacion);

        }

        public override void EjecutarModificar()
        {
            base.EjecutarModificar();
            if (!puedeEjecutarComando) return;
           
                base.EjecutarModificar();



                var fMarcaAbm = new _00024_MotivoBaja_ABM(TipoOperacion.Modificar, EntidadId);
                fMarcaAbm.ShowDialog();

                ActualizarSegunOperacion(fMarcaAbm.RealizoAlgunaOperacion);
           
        }

        public override void EjecutarEliminar()

        {
            base.EjecutarEliminar();

            if (!puedeEjecutarComando) return;
            


                var fMarcaAbm = new _00024_MotivoBaja_ABM(TipoOperacion.Eliminar, EntidadId);

                fMarcaAbm.ShowDialog();

                ActualizarSegunOperacion(fMarcaAbm.RealizoAlgunaOperacion);
            }
            
              
            
        }


    }

