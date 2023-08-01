using Presentacion.Core.MotivoBaja;
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
using Xcom.Servicio.Core.Articulo;
using Xcom.Servicio.Core.Articulo.DTOs;
using Xcom.Servicio.Core.BajaArticulo;
using Xcom.Servicio.Core.BajaArticulo.DTOs;
using Xcom.Servicio.Core.MotivoBaja;
using Xcom.Servicio.Core.MotivoBaja.DTOs;
using static Presentacion.Helpers.ImagenDb;
namespace Presentacion.Core.BajaArticulo
{
    public partial class _00026_BajaArticulo_ABM : FormularioABM
    {
       

        protected readonly IArticuloBajaServicio articuloBajaServicio;

        protected readonly IMotivoBajaServicio motivoBajaServicio;

        protected readonly IArticuloServicio articuloServicio;

        public _00026_BajaArticulo_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _entidadId = entidadId;
            articuloBajaServicio = new ArticuloBajaServicio();
            motivoBajaServicio = new MotivoBajaServicio();
            articuloServicio = new ArticuloServicio();
            AgregarControlesObligatorios(txtDescripcion, "Descripción");
            AgregarControlesObligatorios(cmbMotivosBaja, "Cantidad");


            AsignarEventoEnterLeave(this);
            Inicializador(entidadId);
            CargarDatos(_entidadId);

            if (entidadId == null)
            {
                this.Close();
            }
        }

        public override void Inicializador(long? entidadId)
        {



            // Asignando un Evento
            txtDescripcion.KeyPress += Validacion.NoSimbolos;
            txtDescripcion.KeyPress += Validacion.NoNumeros;
            rtxtObservacion.KeyPress += Validacion.NoSimbolos;
            txtDescripcion.Focus();
        }

        public override void CargarDatos(long? _entidadId)
        {
            if (_tipoOperacion == TipoOperacion.Nuevo)
            {
                if (_entidadId == null)
                {
                    MessageBox.Show("No Hay Datos Cargados");
                    
                    return;
                }

                

                var Articulo = articuloServicio.ObtenerPorId(_entidadId.Value);
                txtDescripcion.Text = Articulo.Descripcion;

                pcbFoto.Image = Convertir_Bytes_Imagen(Articulo.Foto);


                CargarComboBox(cmbMotivosBaja,motivoBajaServicio.Obtener(string.Empty), "Descripcion" , "Id");

            }

            else if (_tipoOperacion == TipoOperacion.Eliminar || _tipoOperacion == TipoOperacion.Modificar)
            {
                base.CargarDatos(_entidadId);
                var ArticuloBaja = articuloBajaServicio.ObtenerPorId(_entidadId.Value);
                var Articulo = articuloServicio.ObtenerPorId(_entidadId.Value);
                if (ArticuloBaja != null)
                {
                    txtDescripcion.Text = ((ArticuloDto)articuloServicio.ObtenerPorId(ArticuloBaja.ArticuloId)).Descripcion;
                    nudCantidad.Value = ArticuloBaja.Cantidad;
                    rtxtObservacion.Text = ArticuloBaja.Observacion;
                    DtpFechaActualizado.Value = ArticuloBaja.FechaBaja;
                    CargarComboBox(cmbMotivosBaja, motivoBajaServicio.Obtener(string.Empty), "Descripcion", "Id");
                    cmbMotivosBaja.Text = motivoBajaServicio.ObtenerPorId(articuloBajaServicio.ObtenerPorId(_entidadId.Value).MotivoBajaId).Descripcion;

                    pcbFoto.Image = Convertir_Bytes_Imagen(articuloServicio.ObtenerPorId(articuloBajaServicio.ObtenerPorId(_entidadId.Value).ArticuloId).Foto);

                }
                else
                {
                    MessageBox.Show("ocurrio un error al seleccionar el Articulo");
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("ocurrio un error al seleccionar el Articulo");
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

            var NuevaBaja = new ArticuloBajaDto
            {
               
                ArticuloId = _entidadId.Value,
                Cantidad = nudCantidad.Value,
                FechaBaja = DateTime.Now,
                MotivoBajaId = ((MotivoBajaDto)cmbMotivosBaja.SelectedItem).Id,
                Observacion = rtxtObservacion.Text
               

            };

            articuloBajaServicio.Insertar(NuevaBaja);
            articuloBajaServicio.DescontarStock(_entidadId.Value,nudCantidad.Value);
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
            MessageBox.Show(_entidadId.Value.ToString());
            var ModificarBaja = new ArticuloBajaDto
            {
                
                Id = _entidadId.Value,
                ArticuloId = articuloBajaServicio.ObtenerPorId(_entidadId.Value).ArticuloId,
                Cantidad = nudCantidad.Value,
                FechaBaja = DateTime.Now,
                MotivoBajaId = ((MotivoBajaDto)cmbMotivosBaja.SelectedItem).Id,
                Observacion = rtxtObservacion.Text

            };

            articuloBajaServicio.Modificar(ModificarBaja);
            articuloBajaServicio.DescontarStock(_entidadId.Value,nudCantidad.Value);
            return true;
        }

        
        protected override bool EjecutarComandoEliminar()
        {
          
            return false;
        }

        public override void EjecutarLimpiar()
        {
            base.EjecutarLimpiar();
            CargarDatos(_entidadId);
        }

        private void btnNuevaMarca_Click(object sender, EventArgs e)
        {
            var FMotivoBaja = new _00024_MotivoBaja_ABM(TipoOperacion.Nuevo, _entidadId );
            FMotivoBaja.ShowDialog();
        }
    }
}
