using Presentacion.FormularioBase;
using Presentacion.FormularioBase.Helpers;
using Presentacion.Helpers;
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
using Xcom.Servicio.Core.Mesa;
using Xcom.Servicio.Core.Mesa.DTOs;
using Xcom.Servicio.Core.Salon;
using Xcom.Servicio.Core.Salon.DTOs;

namespace Presentacion.Core.Mesa
{
    public partial class _00021_Mesa_ABM : FormularioABM
    {

        protected readonly IMesaServicio mesaServicio;
        protected readonly ISalonServicio salonServicio;


        public _00021_Mesa_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            mesaServicio = new Mesaservicio();
            salonServicio = new SalonServicio();

            
            AgregarControlesObligatorios(txtDescripcion, "Descripción");

            AgregarControlesObligatorios(cmbSalon, "Salon");

            AsignarEventoEnterLeave(this);

            Inicializador(entidadId);




            CargarComboBox(cmbSalon, salonServicio.Obtener(string.Empty), "Descripcion", "Id");

        }

        public override void Inicializador(long? entidadId)
        {


            txtDescripcion.MaxLength = 250;
            // Asignando un Evento
            nudNumero.Value = mesaServicio.ObtenerSiguienteNumeroMesa();

            txtDescripcion.KeyPress += Validacion.NoSimbolos;

            var x = new List<EstadoMesa>()
                    {
                        EstadoMesa.Cerrada,
                        EstadoMesa.Abierta,
                       
                        EstadoMesa.FueraServicio,
                        EstadoMesa.Reservada,

                    }.ToList();



            CmbEstado.DataSource = x;
            CmbEstado.DisplayMember = "EstadoMesa";


            if (_tipoOperacion == TipoOperacion.Nuevo)
            {
                CmbEstado.Text = EstadoMesa.Cerrada.ToString();
                CmbEstado.Enabled = false;
            }

            txtDescripcion.Focus();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (_tipoOperacion == TipoOperacion.Nuevo) return;

            else if (_tipoOperacion == TipoOperacion.Eliminar || _tipoOperacion == TipoOperacion.Modificar)
            {
                base.CargarDatos(entidadId);
                var Mesa = mesaServicio.ObtenerPorId(entidadId.Value);
                if (Mesa != null)
                {
                    nudNumero.Minimum = -1;
                    nudNumero.Maximum = 999999;

                    txtDescripcion.Text = Mesa.Descripcion;
                   
                    nudNumero.Value = Mesa.Numero;

                    var x = new List<EstadoMesa>()
                    {
                         EstadoMesa.Cerrada,
                        EstadoMesa.Abierta,
                       
                        EstadoMesa.FueraServicio,
                        EstadoMesa.Reservada,

                    }.ToList();

                   

                    CmbEstado.DataSource = x;
                    CmbEstado.DisplayMember = "EstadoMesa";
                    
                    var Estado = mesaServicio.ObtenerPorId(entidadId.Value);



                   
                    CmbEstado.Text = Estado.EstadoMesa.ToString();
                    CargarComboBox(cmbSalon, salonServicio.Obtener(string.Empty), "Descripcion", "Id");
                     cmbSalon.SelectedValue = Mesa.SalonId;
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

            var x = EstadoMesa.FueraServicio;
            if (CmbEstado.Text.Equals("Abierta"))
            {
                x = EstadoMesa.Abierta;
            }
            else if (CmbEstado.Text.Equals("Cerrada"))
            {
                x = EstadoMesa.Cerrada;
            }
            else if (CmbEstado.Text.Equals("Reservada"))
            {
                x = EstadoMesa.Reservada;
            }
            var NuevaMesa = new MesaDto
            {
                Descripcion = txtDescripcion.Text,
                Numero = (int)nudNumero.Value,
                SalonId = ((SalonDto)cmbSalon.SelectedItem).Id,

                EstaEliminado = false,
                EstadoMesa = x



            };

            
            if (!mesaServicio.VerificarExistencia(txtDescripcion.Text ,(int)nudNumero.Value , null))
            {
                mesaServicio.Insertar(NuevaMesa);
               
               
                return true;
            }
            else
            {
                MessageBox.Show($"Ya existe Una Mesa con el nombre : ( {txtDescripcion.Text} ) o el numero: {nudNumero.Value.ToString()} ");
                return false;
            }



        }

        protected override bool EjecutarComandoModificar()
        {
            

            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var x = EstadoMesa.FueraServicio;
            if (CmbEstado.Text.Equals("Abierta"))
            {
                x = EstadoMesa.Abierta;
            } else if (CmbEstado.Text.Equals("Cerrada"))
            {
                x = EstadoMesa.Cerrada;
            }
            else if (CmbEstado.Text.Equals("Reservada"))
            {
                x = EstadoMesa.Reservada;
            }

            var ModificarMesa = new MesaDto
            {
                Id = _entidadId.Value,
                Descripcion = txtDescripcion.Text,
                Numero = (int)nudNumero.Value,
                EstaEliminado = false,
                EstadoMesa = x,
                SalonId = ((SalonDto)cmbSalon.SelectedItem).Id

            };

            if (!mesaServicio.VerificarExistencia(txtDescripcion.Text ,(int) nudNumero.Value ,  _entidadId.Value))
            {
                mesaServicio.Modificar(ModificarMesa);
                return true;
            }
            else
            {
                MessageBox.Show($"Ya existe Una mesa con el nombre : ( {txtDescripcion.Text} ) o el numero: {nudNumero.Value.ToString()} ");
                return false;
            }

        }

        protected override bool EjecutarComandoEliminar()
        {
            if (_entidadId == null) { return false; }

            else
            {
                mesaServicio.Eliminar(_entidadId.Value);
                return true;
            };
        }
    }
    }
