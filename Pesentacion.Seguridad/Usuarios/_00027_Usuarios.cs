using System;
using System.Windows.Forms;
using Presentacion.FormularioBase;
using Xcom.Servicio.Seguridad.Usuarios;
using Xcom.Servicio.Seguridad.Usuarios.DTOs;

namespace Pesentacion.Seguridad.Seguridad
{
    public partial class _00027_Usuarios : FormularioBase
    {

        protected readonly IUsuarioServicio usuarioServicio;

        protected object entidad;

        public _00027_Usuarios()
        {
            InitializeComponent();
            usuarioServicio = new UsuarioServicio();
            entidad = null;
            btnNuevo.Image = Presentacion.Constantes.Imagen.ImagenBotonNuevo;
            btnSalir.Image = Presentacion.Constantes.Imagen.ImagenBotonSalir;
            btnActualizar.Image = Presentacion.Constantes.Imagen.ImagenBotonActualizar;
            btnEliminar.Image = Presentacion.Constantes.Imagen.ImagenLogin;
            this.BackColor = Presentacion.Constantes.Color.ColorFondo;
            menuAccesoRapido.BackColor = Presentacion.Constantes.Color.ColorMenu2;
            
           
        }

        

        private void ActualizarDatos(string CadenaBuscar)
        {

            dgvGrilla.DataSource = usuarioServicio.Obtener(!string.IsNullOrEmpty( CadenaBuscar)
                ? CadenaBuscar : string.Empty);

            FormatearGrilla();

           
        }

        private void FormatearGrilla()
        {
            for (int i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                dgvGrilla.Columns[i].Visible = false;
            }



            dgvGrilla.Columns["ApyNom"].Visible = true;
            dgvGrilla.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["ApyNom"].HeaderText = "Apellido Y Nombre";
            dgvGrilla.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dgvGrilla.Columns["Nombre"].Visible = true;
            dgvGrilla.Columns["Nombre"].Width = 200;
            dgvGrilla.Columns["Nombre"].HeaderText = " Usuario";
            dgvGrilla.Columns["Nombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
           
            
            dgvGrilla.Columns["EstaBloqueadoStr"].Visible = true;
            dgvGrilla.Columns["EstaBloqueadoStr"].Width = 100;
            dgvGrilla.Columns["EstaBloqueadoStr"].HeaderText = @"Bloqueado";
            dgvGrilla.Columns["EstaBloqueadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["EstaBloqueadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void _00027_Usuarios_Load(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(txtBuscar.Text);
        }

        private void txtBuscar_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                ActualizarDatos(txtBuscar.Text);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                entidad = dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
            else
            {
                entidad = null;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (entidad == null) return;
           
            
            var usuarioSelecionado = ((UsuarioDto)entidad);


            if (usuarioSelecionado.Nombre.Equals("NO ASIGNADO"))
            {


                usuarioServicio.Crear(usuarioSelecionado.PersonaId, usuarioSelecionado.Apellidpersona, usuarioSelecionado.NombrePersona);
                ActualizarDatos(string.Empty);
            }
            else
            {
                MessageBox.Show($"El Empleado {usuarioSelecionado.NombrePersona} {usuarioSelecionado.Apellidpersona} ya tiene un usuario creado");
            }
        }


        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (entidad == null || ((UsuarioDto)entidad).Nombre == "NO ASIGNADO") return;


            var usuarioSelecionado = ((UsuarioDto)entidad);


            usuarioServicio.CambiarEstado(usuarioSelecionado.Nombre, !usuarioSelecionado.EstaBloqueado);

            var mensaje = usuarioSelecionado.EstaBloqueado
                ? "El usuario se Desbloqueo Correctamente"
                : "El Usuario se Bloqueo correctamente";
            MessageBox.Show(mensaje);
            ActualizarDatos(string.Empty);
              
            

         
        }
    }
}
