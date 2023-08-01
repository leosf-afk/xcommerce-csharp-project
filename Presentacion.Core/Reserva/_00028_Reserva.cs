using Presentacion.FormularioBase;
using Presentacion.FormularioBase.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xcom.Servicio.Core.Cliente;
using Xcom.Servicio.Core.Mesa;
using Xcom.Servicio.Core.Reserva;
using Xcom.Servicio.Seguridad.Usuarios;

namespace Presentacion.Core.Reserva
{
    public partial class _00028_Reserva : FormularioConsulta
    {
       

        protected readonly IReservaServicio reservaServicio;
        protected readonly IMesaServicio mesaServicio;
        protected readonly IClienteServicio clienteServicio;
        protected readonly IUsuarioServicio usuarioServicio;

        public _00028_Reserva()
            : this(new Mesaservicio() )
        {
            InitializeComponent();

            btnEliminar.Visible = false;
            btnEliminar.Enabled = false;
        }

        public _00028_Reserva(IMesaServicio _mesaServicio)
        {
            mesaServicio = _mesaServicio;
            reservaServicio = new ReservaServicio();
            clienteServicio = new ClienteServicio();
            usuarioServicio = new UsuarioServicio();
            ActualizarDatos(dgvGrilla, string.Empty);
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["EstadoReserva"].Visible = true;
            grilla.Columns["EstadoReserva"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["EstadoReserva"].HeaderText = "Estado Reserva";

            grilla.Columns["Senia"].Visible = true;
            grilla.Columns["Senia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Senia"].HeaderText = "Seña";

            grilla.Columns["Fecha"].Visible = true;
            grilla.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Fecha"].HeaderText = "Fecha";

        }

        public override void ActualizarDatos(DataGridView grilla, string CadenaBuscar)
        {



            grilla.DataSource = reservaServicio.Obtener(CadenaBuscar) ;
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
            var FReservaABM = new _00029_Reserva_ABM(TipoOperacion.Nuevo);
            FReservaABM.ShowDialog();
            ActualizarSegunOperacion(FReservaABM.RealizoAlgunaOperacion);

        }

        public override void EjecutarModificar()
        {
          
            base.EjecutarModificar();
            if (!puedeEjecutarComando) return;
       
                base.EjecutarModificar();



                var FReservaABM = new _00029_Reserva_ABM(TipoOperacion.Modificar, EntidadId);
                FReservaABM.ShowDialog();

                ActualizarSegunOperacion(FReservaABM.RealizoAlgunaOperacion);
            
           
        }

        public override void EjecutarEliminar()

        {
            base.EjecutarEliminar();

            if (!puedeEjecutarComando) return;
          


                var FReservaABM = new _00029_Reserva_ABM(TipoOperacion.Eliminar, EntidadId);

                FReservaABM.ShowDialog();

          
        }

    }
}
