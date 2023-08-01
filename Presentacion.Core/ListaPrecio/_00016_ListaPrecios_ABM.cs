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
using Xcom.Servicio.Core.Precio;
using Xcom.Servicio.Core.Precio.DTOs;

namespace Presentacion.Core.ListaPrecio
{
    public partial class _00016_ListaPrecios_ABM : FormularioABM
    {
       
        protected readonly IListaPrecioServicio listaPrecioServicio;
        protected readonly IPrecioServicio precioServicio;

        public _00016_ListaPrecios_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            listaPrecioServicio = new ListaPrecioServicio();

            precioServicio = new PrecioServicio();

            AgregarControlesObligatorios(txtDescripcion, "Descripción");
            AgregarControlesObligatorios(nudRentabilidad, "Rentabilidad");
            AsignarEventoEnterLeave(this);
            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {



            // Asignando un Evento
            txtDescripcion.KeyPress += Validacion.NoSimbolos;
            txtDescripcion.KeyPress += Validacion.NoNumeros;

            txtDescripcion.Focus();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (_tipoOperacion == TipoOperacion.Nuevo) return;

            else if (_tipoOperacion == TipoOperacion.Eliminar || _tipoOperacion == TipoOperacion.Modificar)
            {
                base.CargarDatos(entidadId);
                var ListaPrecio = listaPrecioServicio.ObtenerPorId(entidadId.Value);
                if (ListaPrecio != null)
                {
                    txtDescripcion.Text = ListaPrecio.Descripcion;
                    nudRentabilidad.Value = ListaPrecio.Rentabilidad;
                }
                else
                {
                    MessageBox.Show("ocurrio un error al selectionar El Rubro");
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("ocurrio un error al selectionar El rubro");
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

            var NuevaListaPrecio = new ListaPrecioDto
            {
                Descripcion = txtDescripcion.Text,
                Rentabilidad = nudRentabilidad.Value,
                EstaEliminado = false

            };

            listaPrecioServicio.Insertar(NuevaListaPrecio);

            
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
            var ModificarRubro = new ListaPrecioDto
            {
                Id = _entidadId.Value,
                Descripcion = txtDescripcion.Text,
                Rentabilidad = nudRentabilidad.Value,
                EstaEliminado = false


            };

            listaPrecioServicio.Modificar(ModificarRubro);
            return true;
        }

        protected override bool EjecutarComandoEliminar()
        {
            if (_entidadId == null) { return false; }

            else
            {
                listaPrecioServicio.Eliminar(_entidadId.Value);
                return true;
            };

        }

    }
}
