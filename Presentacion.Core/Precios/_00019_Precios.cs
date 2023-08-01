using Presentacion.Core.Articulo;
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
using Xcom.Servicio.Core.Articulo;
using Xcom.Servicio.Core.ListaPrecio;
using Xcom.Servicio.Core.ListaPrecio.DTOs;
using Xcom.Servicio.Core.Precio;
using Xcom.Servicio.Core.Precio.DTOs;

namespace Presentacion.Core.Precios
{
    public partial class _00019_Precios : FormularioConsulta  
    {
        protected readonly IPrecioServicio precioServicio;

        protected readonly IArticuloServicio articuloServicio;

        protected readonly IListaPrecioServicio listaPrecioServicio;

        protected TipoOperacion _tipoOperacion;

        protected long? _entidadId;

        public bool RealizoAlgunaOperacion { get; set; }


        public _00019_Precios()
        {
            InitializeComponent();

            //asignacion imagenes

            listaPrecioServicio = new ListaPrecioServicio();

            articuloServicio = new ArticuloServicio();

            precioServicio = new PrecioServicio();
           
            this.BackColor = Constantes.Color.ColorFondo;
          
        }


        public _00019_Precios(TipoOperacion tipoOperacion, long? entidadId )
           : this()
        {
            _tipoOperacion = tipoOperacion;
            _entidadId = entidadId;
            RealizoAlgunaOperacion = false;
        
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);


            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Descripcion"].HeaderText = "Descripcion";

            dgvGrilla.Columns["PrecioCosto"].Visible = true;
            dgvGrilla.Columns["PrecioCosto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["PrecioCosto"].HeaderText = "Precio de costo";

            dgvGrilla.Columns["PrecioPublico"].Visible = true;
            dgvGrilla.Columns["PrecioPublico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["PrecioPublico"].HeaderText = "Precio Base";


            dgvGrilla.Columns["PrecioPublicoRentabilidad"].Visible = true;
            dgvGrilla.Columns["PrecioPublicoRentabilidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["PrecioPublicoRentabilidad"].HeaderText = "Precio con Rentabilidad";
        }

        public  void CargarDatos(long? entidadId)
        {
            var Rentabilidad = listaPrecioServicio.ObtenerPorId(_entidadId).Rentabilidad;

            var Precios = precioServicio.obtenerPrecios(txtBuscar.Text, Rentabilidad); 

            foreach (var item in Precios)
            {
                item.PrecioPublicoRentabilidad = decimal.Round(item.PrecioPublicoRentabilidad, 2, MidpointRounding.AwayFromZero);
            }

            dgvGrilla.DataSource = Precios;

            FormatearGrilla(dgvGrilla);

            this.Text = ($" {listaPrecioServicio.ObtenerPorId(_entidadId).Descripcion}");

        }


        private void _00019_Precios_Load(object sender, EventArgs e)
        {
            CargarDatos(EntidadId);
            ActualizarDatos(dgvGrilla , txtBuscar.Text);
        }


        public override void EjecutarModificar()
        {
            base.EjecutarModificar();
            if (EntidadId == null) return;
           
            var FArticuloAbm = new _00014_Articulo_ABM(TipoOperacion.Modificar, EntidadId);
            FArticuloAbm.ShowDialog();

            RealizoAlgunaOperacion = true;
            ActualizarSegunOperacion(RealizoAlgunaOperacion);
                            
        }

        public override void EjecutarEliminar()
        {
            base.EjecutarEliminar();
            if (EntidadId == null) return;


            var FArticuloAbm = new _00014_Articulo_ABM(TipoOperacion.Eliminar, EntidadId);
            FArticuloAbm.ShowDialog();

            RealizoAlgunaOperacion = true;
            ActualizarSegunOperacion(RealizoAlgunaOperacion);
        }

        public override void ActualizarDatos(DataGridView grilla, string CadenaBuscar)
        {         
            CargarDatos(EntidadId);
            FormatearGrilla(dgvGrilla);
        }

        public override void EjecutarNuevo()
        {
            var FArticuloAbm = new _00014_Articulo_ABM(TipoOperacion.Nuevo, EntidadId);
            FArticuloAbm.ShowDialog();

            RealizoAlgunaOperacion = true;
            ActualizarSegunOperacion(RealizoAlgunaOperacion);
        }

        private void ActualizarSegunOperacion(bool RealizoAlgunaOperacion)
        {
            if (RealizoAlgunaOperacion)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }

       

    }
}
