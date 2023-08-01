using Presentacion.Core.Mesa.Control;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Xcom.Servicio.Core.Mesa;
using Xcom.Servicio.Core.Salon;

namespace Presentacion.Core.VentaSalon
{
    public partial class _00036_VentaSalon : FormularioBase.FormularioBase
    {

        protected readonly ISalonServicio salonServicio;

        protected readonly IMesaServicio mesaServicio;

        public _00036_VentaSalon()
        {
            InitializeComponent();

            salonServicio = new SalonServicio();
            mesaServicio = new Mesaservicio();

            MenuAccesoRapido.BackColor = Presentacion.Constantes.Color.ColorFondo;
            btnSalir.Image = Presentacion.Constantes.Imagen.ImagenBotonSalir;

        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void _00036_VentaSalon_Load(object sender, System.EventArgs e)
        {
            CrearControles();
        }

        private void CrearControles()
        {
            var contenedorPagina = new TabControl();

            var contadorTabIndex = 0;
            foreach (var salon in salonServicio.Obtener(string.Empty).Where(x => !x.EstaEliminado))
            {

                var ListaMesas = mesaServicio.Obtener(string.Empty).Where(x => x.SalonId == salon.Id);

                var flowPanel = new FlowLayoutPanel
                {

                    Name = $"flowPanel{salon.Id}",
                    BackColor = Color.LightBlue,
                    Dock = DockStyle.Fill,

                };

                foreach (var Mesa in ListaMesas.Where(x => !x.EstaEliminado))
                {
                    var CMesa = new ControlMesa
                    {
                        MesaId = Mesa.Id,
                        estado = Mesa.EstadoMesa,
                        NumeroMesa = Mesa.Numero,
                        PrecioConsumido = mesaServicio.CargarLabelprecio(Mesa.Id)
                      
                    };

                    flowPanel.Controls.Add(CMesa);

                }

                var pagina = new TabPage
                {
                    Location = new Point(4, 22),
                    Name = $"Pagina{salon.Id}",
                    Padding = new Padding(3),
                    Size = new Size(845, 357),
                    TabIndex = contadorTabIndex,
                    Text = $"{salon.Descripcion}",
                    UseVisualStyleBackColor = true

                };
                contenedorPagina.Controls.Add(pagina);
                contadorTabIndex++;
                pagina.Controls.Add(flowPanel);
            }


            contenedorPagina.Dock = DockStyle.Fill;
            contenedorPagina.Location = new Point(0, 66);
            contenedorPagina.Name = "contenedor";
            contenedorPagina.SelectedIndex = 0;
            contenedorPagina.Size = new Size(862, 383);
            contenedorPagina.TabIndex = 9;
            contenedorPagina.ResumeLayout(false);

            this.Controls.Add(contenedorPagina);
            this.Controls.SetChildIndex(contenedorPagina, 0);
            contenedorPagina.ResumeLayout(false);

        }

        private void _00036_VentaSalon_Activated(object sender, EventArgs e)
        {
            CrearControles();
           
        }



    }
}
