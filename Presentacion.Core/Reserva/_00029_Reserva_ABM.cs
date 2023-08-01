using Presentacion.Core.Cliente;
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
using Xcom.Servicio.Core.Cliente;
using Xcom.Servicio.Core.Cliente.Dtos;
using Xcom.Servicio.Core.Mesa;
using Xcom.Servicio.Core.Mesa.DTOs;
using Xcom.Servicio.Core.MotivoReserva;
using Xcom.Servicio.Core.MotivoReserva.DTOs;
using Xcom.Servicio.Core.Reserva;
using Xcom.Servicio.Core.Reserva.DTOs;
using Xcom.Servicio.Core.Salon;
using Xcom.Servicio.Seguridad.Usuarios;
using Xcom.Servicio.Seguridad.Usuarios.DTOs;

namespace Presentacion.Core.Reserva
{
    public partial class _00029_Reserva_ABM : FormularioABM
    {
        protected readonly IReservaServicio reservaServicio;

        protected readonly IMesaServicio mesaServicio;

        protected readonly IClienteServicio clienteServicio;

        protected readonly IUsuarioServicio usuarioServicio;

        protected readonly IMotivoReservaServicio motivoReservaServicio;

      

        public _00029_Reserva_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();


            mesaServicio = new Mesaservicio();

            reservaServicio = new ReservaServicio();

            clienteServicio = new ClienteServicio();

            usuarioServicio = new UsuarioServicio();

            motivoReservaServicio = new MotivoReservaServicio();

            AgregarControlesObligatorios(cmbEstadoReserva, "Descripción");

            AgregarControlesObligatorios(txtNombreCliente, "Cliente");

            AgregarControlesObligatorios(cmbUsuario, "Usuario");

            AgregarControlesObligatorios(CmbMesa, "Mesa");

            AgregarControlesObligatorios(cmbMotivoReserva,"MotivoReserva");

            AsignarEventoEnterLeave(this);

            Inicializador(entidadId);
 
            
            CargarComboBox(CmbMesa, mesaServicio.ObtenerMesaEstado(string.Empty), "Descripcion", "Id");

            CargarComboBox(cmbUsuario,usuarioServicio.Obtener(string.Empty), "Nombre", "Id");

            CargarComboBox(cmbMotivoReserva, motivoReservaServicio.Obtener(string.Empty) , "Descripcion" , "Id" );

            var x = new List<EstadoReserva>()
                    {
                
                EstadoReserva.Confirmada,

                EstadoReserva.NoConfirmada,

                  EstadoReserva.Cancelada,

                    }.ToList();

            cmbEstadoReserva.DataSource = x;

        }

       
        public override void CargarDatos(long? entidadId)
        {
            if (_tipoOperacion == TipoOperacion.Nuevo) return;

            else if (_tipoOperacion == TipoOperacion.Eliminar || _tipoOperacion == TipoOperacion.Modificar)
            {
                base.CargarDatos(entidadId);

                var Reserva = reservaServicio.ObtenerPorId(entidadId.Value);

                if (Reserva != null)
                {

                    nudSenia.Minimum = -1;

                    nudSenia.Maximum = 999999;

                   
                    cmbEstadoReserva.SelectedItem = Reserva.EstadoReserva;

                    
                    CmbMesa.Text = (mesaServicio.ObtenerPorId(reservaServicio.ObtenerPorId(entidadId.Value).MesaId)).Descripcion;

                    cmbUsuario.Text = usuarioServicio.ObtenerPorId(reservaServicio.ObtenerPorId(entidadId.Value).UsuarioId).Nombre;

                    dtpFecha.Value = reservaServicio.ObtenerPorId(entidadId.Value).Fecha;

                    nudSenia.Value = reservaServicio.ObtenerPorId(entidadId.Value).Senia;

                    cmbMotivoReserva.Text = motivoReservaServicio.ObtenerPorId(reservaServicio.ObtenerPorId(entidadId.Value).MotivoReservaId).Descripcion;

                    txtNombreCliente.Text = clienteServicio.ObtenerPorId(Reserva.ClienteId).ApyNom;
                    



                }
                else
                {
                    MessageBox.Show("ocurrio un error al selectionar La Mesa");
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("ocurrio un error al selectionar la Mesa");
                this.Close();
            }




        }

        protected override bool EjecutarComandoNuevo()
        {

            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (reservaServicio.verificarFecha(dtpFecha.Value, ((MesaDto)CmbMesa.SelectedItem).Id))
            {

                MessageBox.Show("Ya existe una reservacion para esa fecha");
                return false;
            }


            var NuevaReseerva = new ReservaDto
            {
                ClienteId = _00039_ReservaCliente.ClienteSeleccionado.Id,

                UsuarioId = ((UsuarioDto)cmbUsuario.SelectedItem).Id,

                MesaId = ((MesaDto)CmbMesa.SelectedItem).Id,

                Senia = nudSenia.Value,

                EstadoReserva = (EstadoReserva)cmbEstadoReserva.SelectedIndex + 1 ,

                Fecha = dtpFecha.Value,

                MotivoReservaId = ((MotivoReservaDto)cmbMotivoReserva.SelectedItem).Id



            };
            
           var ModificarEstadoMesa  = new MesaDto
                {
                  Descripcion = mesaServicio.ObtenerPorId(NuevaReseerva.MesaId).Descripcion,
                   EstadoMesa = EstadoMesa.Reservada,
                   EstaEliminado =  mesaServicio.ObtenerPorId(NuevaReseerva.MesaId).EstaEliminado,
                   Numero =  mesaServicio.ObtenerPorId(NuevaReseerva.MesaId).Numero,
                   SalonId = mesaServicio.ObtenerPorId(NuevaReseerva.MesaId).SalonId,
                   Id = NuevaReseerva.MesaId,

           };

                reservaServicio.Insertar(NuevaReseerva);
            mesaServicio.Modificar(ModificarEstadoMesa);
                return true;
            }






        protected override bool EjecutarComandoModificar()
        {


            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
              
                    MessageBoxIcon.Error);

                     return false;
            }

            if (reservaServicio.verificarFecha(dtpFecha.Value, ((MesaDto)CmbMesa.SelectedItem).Id))
            {

                MessageBox.Show("Ya existe una reservacion para esa fecha");
                return false;
            }
            

            

            var ModificarReserva = new ReservaDto
            {
                Id =  _entidadId.Value,

                EstadoReserva = (EstadoReserva)cmbEstadoReserva.SelectedIndex +1 ,

                ClienteId = _00039_ReservaCliente.ClienteSeleccionado.Id,

                UsuarioId = ((UsuarioDto)cmbUsuario.SelectedItem).Id,

                MesaId = ((MesaDto)CmbMesa.SelectedItem).Id,

                Fecha = dtpFecha.Value,

                Senia = nudSenia.Value,

                MotivoReservaId = ((MotivoReservaDto)cmbMotivoReserva.SelectedItem).Id
                
            };

           
                reservaServicio.Modificar(ModificarReserva);
                return true;
            


        }

        private void _00029_Reserva_ABM_Load(object sender, EventArgs e)
        {

        }

       

        private void FotoBuscar_MouseEnter(object sender, EventArgs e)
        {
            FotoBuscar.BackColor = Constantes.Color.ColorMenu;
        }

        private void FotoBuscar_MouseLeave(object sender, EventArgs e)
        {
            FotoBuscar.BackColor = Constantes.Color.ColorFondo;
        }

        private void FotoBuscar_Click(object sender, EventArgs e)
        {
            var FClienta = new _00039_ReservaCliente();

            FClienta.ShowDialog();
            if (_00039_ReservaCliente.ClienteSeleccionado != null)
            {
                txtNombreCliente.Text = _00039_ReservaCliente.ClienteSeleccionado.ApyNom;

            }
        }

        public override void EjecutarLimpiar()
        {
            base.EjecutarLimpiar();
            _00039_ReservaCliente.ClienteSeleccionado = null;
        }
    }
}
