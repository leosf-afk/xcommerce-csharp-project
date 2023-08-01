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
using Xcom.Servicio.Core.ListaPrecio;
using Xcom.Servicio.Core.ListaPrecio.DTOs;
using Xcom.Servicio.Core.Salon;
using Xcom.Servicio.Core.Salon.DTOs;

namespace Presentacion.Core.Salon
{
    public partial class _00018_Salon_ABM : FormularioABM
    {
       

        protected readonly ISalonServicio salonServicio;
        protected readonly IListaPrecioServicio listaPrecioServicio;

        public _00018_Salon_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            listaPrecioServicio = new ListaPrecioServicio();
           salonServicio  = new SalonServicio();
            AgregarControlesObligatorios(txtDescripcion, "Descripción");
            AgregarControlesObligatorios(cmbListaPrecios , "Lista de Precios");
            AsignarEventoEnterLeave(this);
            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {

              CargarComboBox(cmbListaPrecios , listaPrecioServicio.Obtener(String.Empty) , "Descripcion" , "Id");

            // Asignando un Evento
            txtDescripcion.KeyPress += Validacion.NoSimbolos;
           

            txtDescripcion.Focus();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (_tipoOperacion == TipoOperacion.Nuevo) return;

            else if (_tipoOperacion == TipoOperacion.Eliminar || _tipoOperacion == TipoOperacion.Modificar)
            {
                base.CargarDatos(entidadId);
                var Salon = salonServicio.ObtenerPorId(entidadId.Value);
                if (Salon != null)
                {
                    txtDescripcion.Text = Salon.Descripcion;
                    cmbListaPrecios.SelectedValue = salonServicio.ObtenerPorId(_entidadId.Value).ListaPrecioId;
                }
                else
                {
                    MessageBox.Show("ocurrio un error al selectionar El Salon");
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("ocurrio un error al selectionar El Salon");
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

            var NuevoSalon = new SalonDto
            {
                Descripcion = txtDescripcion.Text,
                ListaPrecioId = ((ListaPrecioDto)cmbListaPrecios.SelectedItem).Id
                   
            };

            if (!salonServicio.VerificarExistencia(txtDescripcion.Text , null))
            {
                salonServicio.Insertar(NuevoSalon);
                return true;
            }
            else
            {
                MessageBox.Show($"Ya existe Un salon con el nombre: ( {txtDescripcion.Text} ) " , "Atencion" );
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
            var ModificarSalon = new SalonDto
            {
                Id = _entidadId.Value,
                Descripcion = txtDescripcion.Text,
                ListaPrecioId = ((ListaPrecioDto)cmbListaPrecios.SelectedItem).Id,  

            };

            if (!salonServicio.VerificarExistencia(txtDescripcion.Text, _entidadId.Value))
            {
                salonServicio.Modificar(ModificarSalon);
                return true;
            }
            else
            {
                MessageBox.Show($"Ya existe Un salon con el nombre: ( {txtDescripcion.Text} ) ");
                return false;
            }
          
        }

        protected override bool EjecutarComandoEliminar()
        {
            if (_entidadId == null) { return false; }

            else
            {
                salonServicio.Eliminar(_entidadId.Value);
                return true;
            };

        }
    }
}
