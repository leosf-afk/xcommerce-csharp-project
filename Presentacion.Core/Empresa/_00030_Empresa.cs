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
using Xcom.Servicio.Core.Empresa;

namespace Presentacion.Core.Empresa
{
    public partial class _00030_Empresa : FormularioConsulta
    {
        
      private readonly IEmpresaServicio  empresaServicio;

        public _00030_Empresa()
            : this(new EmpresaServicio())
        {
            InitializeComponent();

            btnEliminar.Enabled = false;
            btnEliminar.Visible = false;
        }


        public _00030_Empresa(IEmpresaServicio  _empresaServicio)
        {
            empresaServicio = _empresaServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["NombreFantasia"].Visible = true;
            grilla.Columns["NombreFantasia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["NombreFantasia"].HeaderText = "Nombre De Fantasia";
            grilla.Columns["NombreFantasia"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Cuit"].Visible = true;
            grilla.Columns["Cuit"].Width = 150;
            grilla.Columns["Cuit"].HeaderText = "Cuit";
            grilla.Columns["Cuit"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Telefono"].Visible = true;
            grilla.Columns["Telefono"].Width = 150;
            grilla.Columns["Telefono"].HeaderText = " Telefono";
            grilla.Columns["Telefono"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Mail"].Visible = true;
            grilla.Columns["Mail"].Width = 200;
            grilla.Columns["Mail"].HeaderText = "Mail";
            grilla.Columns["Mail"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

           

        }


        public override void ActualizarDatos(DataGridView grilla, string CadenaBuscar)
        {
            grilla.DataSource = empresaServicio.Obtener(CadenaBuscar);

        }


       

        public override void EjecutarModificar()
        {

            base.EjecutarModificar();
            if (!puedeEjecutarComando) return;
            




                var fEmpresaABM = new _00031_Empresa_ABM(TipoOperacion.Modificar, EntidadId);
                fEmpresaABM.ShowDialog();

                ActualizarSegunOperacion(fEmpresaABM.RealizoAlgunaOperacion);
               
            


        }


        public override void EjecutarNuevo()
        {
            var fEmpresaABM = new _00031_Empresa_ABM(TipoOperacion.Nuevo);
            fEmpresaABM.ShowDialog();
            ActualizarSegunOperacion(fEmpresaABM.RealizoAlgunaOperacion);

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
