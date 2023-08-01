using Presentacion.Constantes;
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
    public partial class FormularioABM : FormularioBase
    {

        protected TipoOperacion _tipoOperacion;

        protected long? _entidadId;

        public bool RealizoAlgunaOperacion { get; set; }


        public FormularioABM()
        {
            InitializeComponent();

            //asignacion imagenes
            btnSalir.Image = Imagen.ImagenBotonSalir;
            this.BackColor = Constantes.Color.ColorFondo;
            MenuAccesoRapido.BackColor = Constantes.Color.ColorMenu2;

        }


        public FormularioABM(TipoOperacion tipoOperacion, long? entidadId)
           : this()
        {
            _tipoOperacion = tipoOperacion;
            _entidadId = entidadId;
            RealizoAlgunaOperacion = false;

            CambiarImagenTextoBotones(tipoOperacion);
        }


        private void FormularioABM_Load(object sender, EventArgs e)
        {
            if (_tipoOperacion == TipoOperacion.Eliminar
                || _tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(_entidadId);

            }
            if (_tipoOperacion == TipoOperacion.Eliminar)
            {
                Desactivarcontroles(this);

            }


        }

        private void CambiarImagenTextoBotones(TipoOperacion tipoOperacion)
        {
            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                btnEjecutar.Image = Constantes.Imagen.ImagenBotonBorrar;
                btnEjecutar.Text = "Eliminar";
                btnLimpiar.Visible = false;
                btnLimpiar.Enabled = false;
                lbltitulo.Text = "   Eliminar";
                lbltitulo.BackColor = Constantes.Color.ColorMenu;
            }
            else
            {
                btnEjecutar.Image = Constantes.Imagen.ImagenBotonGuardar;
                btnLimpiar.Image = Imagen.ImagenBotonBorrar;
                btnEjecutar.Text = "  Guardar";

                if (tipoOperacion == TipoOperacion.Modificar)
                {
                    lbltitulo.Text = "  Modificar";
                    lbltitulo.BackColor = Constantes.Color.ColorMenu;
                }
                else
                {
                    lbltitulo.Text = "     Nuevo";
                    lbltitulo.BackColor = Constantes.Color.ColorMenu;
                }
            }
        }

        public virtual void CargarDatos(long? entidadId)
        {


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            EjecutarLimpiar();



        }


        public virtual void EjecutarLimpiar()
            
            
            {

            if (MessageBox.Show(@"Esta seguro de Limpiar los Datos", @"Atención", MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Limpiarcontroles(this);
            }

        }

        public virtual void Inicializador(long? entidadId)
        {
           

        }

        public  virtual void btnEjecutar_Click(object sender, EventArgs e)
        {
            EjecutarComando();
        }

        protected  virtual void EjecutarComando()
        {
            switch (_tipoOperacion)
            {
                case TipoOperacion.Nuevo:
                    if (EjecutarComandoNuevo())
                    {
                        MessageBox.Show("Los Datos Se Guardaron Correctamente.", "Atencion", MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
                        Limpiarcontroles(this);
                        RealizoAlgunaOperacion = true;
                      
                    }
                    break;
                case TipoOperacion.Eliminar:
                    if (EjecutarComandoEliminar())
                    {
                        MessageBox.Show("Los Datos Se Eliminaron Correctamente,", "Atencion", MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
                        this.Close();
                        RealizoAlgunaOperacion = true;
                       
                    }
                    break;
                case TipoOperacion.Modificar:
                    if (EjecutarComandoModificar())
                    {
                        MessageBox.Show("Los Datos Se Modificaron Correctamente.", "Atencion", MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
                        this.Close();
                        RealizoAlgunaOperacion = true;
                       
                    }
                  
                    break;
               
                default:
                  break;
            }
        }

       protected virtual  bool EjecutarComandoModificar()
        {
            return false;

        }

        protected virtual bool EjecutarComandoEliminar()
        {
            return false;

        }

        protected virtual bool  EjecutarComandoNuevo()
        {
            return false;

        }
    }
}
