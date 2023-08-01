using Presentacion.FormularioBase.DTOs;
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
    public partial class FormularioBase : Form
    {
        private readonly List<ControlDto> _listaControlesObligatorios;

        public FormularioBase()
        {
            InitializeComponent();
            _listaControlesObligatorios = new List<ControlDto>();
        }

      

        protected void Control_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                ((TextBox)sender).BackColor = Presentacion.Constantes.Color.ColorControlSinFoco;
            }
            if (sender is NumericUpDown)
            {
                ((NumericUpDown)sender).BackColor = Presentacion.Constantes.Color.ColorControlSinFoco;
            }
        }

        protected void Control_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                ((TextBox)sender).BackColor = Presentacion.Constantes.Color.ColorControlFoco;
            }
            if (sender is NumericUpDown)
            {
                ((NumericUpDown)sender).BackColor = Presentacion.Constantes.Color.ColorControlFoco;
            }
        }

        protected void Desactivarcontroles(object obj)
        {

            if (obj is Form)
            {
                foreach (var controlForm in ((Form)obj).Controls)
                {
                    if (controlForm is TextBox)
                    {
                        ((TextBox)controlForm).Enabled = false;
                    }
                    if (controlForm is ComboBox)
                    {
                        ((ComboBox)controlForm).Enabled = false;
                    }
                    if (controlForm is NumericUpDown)
                    {
                        ((NumericUpDown)controlForm).Enabled = false;
                    }
                    if (controlForm is Button)
                    {
                        ((Button)controlForm).Enabled = false;
                    }
                    if (controlForm is DateTimePicker)
                    {
                        ((DateTimePicker)controlForm).Enabled = false;
                    }
                    if (controlForm is Panel)
                    {
                        Desactivarcontroles(controlForm);
                    }
                }
            }
            else
            {
                if (obj is Panel)
                {
                    foreach (var ControlPanel in ((Panel)obj).Controls)
                    {
                        if (ControlPanel is TextBox)
                        {
                            ((TextBox)ControlPanel).Enabled = false;
                        }
                        if (ControlPanel is ComboBox)
                        {
                            ((ComboBox)ControlPanel).Enabled = false;
                        }
                        if (ControlPanel is NumericUpDown)
                        {
                            ((NumericUpDown)ControlPanel).Enabled = false;
                        }
                        if (ControlPanel is Button)
                        {
                            ((Button)ControlPanel).Enabled = false;
                        }
                        if (ControlPanel is DateTimePicker)
                        {
                            ((DateTimePicker)ControlPanel).Enabled = false;
                        }
                        if (ControlPanel is Panel)
                        {
                            Desactivarcontroles(ControlPanel);
                        }
                    }
                }
            }
        }

        protected void Limpiarcontroles(object obj)
        {

            if (obj is Form)
            {
                foreach (var controlForm in ((Form)obj).Controls)
                {
                    if (controlForm is TextBox)
                    {
                        ((TextBox)controlForm).Clear();
                    }
                   

                    if (controlForm is ComboBox)
                    {
                      if (((ComboBox)controlForm).Items.Count > 0)
                      {
                         ((ComboBox)controlForm).SelectedIndex = 0;
                      }
                           
                    }


                    if (controlForm is DateTimePicker)
                        {
                            ((DateTimePicker)controlForm).Value = DateTime.Now;
                        }


                    
                    if (controlForm is NumericUpDown)
                    {
                        ((NumericUpDown)controlForm).Value = ((NumericUpDown)controlForm).Minimum;
                    }


                    if (controlForm is RichTextBox)
                    {
                        ((RichTextBox)controlForm).Clear();
                    }

                    if (controlForm is Panel)
                    {
                        Limpiarcontroles(controlForm);
                    }
                }
            }
            else
            {
                if (obj is Panel)
                {
                    foreach (var ControlPanel in ((Panel)obj).Controls)
                    {
                        if (ControlPanel is TextBox)
                        {
                            ((TextBox)ControlPanel).Clear();
                        }
                        if (ControlPanel is ComboBox)
                        {
                            if (((ComboBox)ControlPanel).Items.Count > 0)
                            {
                                ((ComboBox)ControlPanel).SelectedIndex = 0; ;
                            }
                           
                        }
                        if (ControlPanel is NumericUpDown)
                        {
                            ((NumericUpDown)ControlPanel).Value = ((NumericUpDown)ControlPanel).Minimum;
                        }
                        if (ControlPanel is DateTimePicker)
                        {
                            ((DateTimePicker)ControlPanel).Value = DateTime.Now;
                        }
                        if (ControlPanel is RichTextBox)
                        {
                            ((RichTextBox)ControlPanel).Clear();
                        }


                        if (ControlPanel is Panel)
                        {
                            Limpiarcontroles(ControlPanel);
                        }
                    }
                }
            }
        }

        protected void AsignarEventoEnterLeave (object obj)
        {

            if (obj is Form)
            {
                foreach (var controlForm in ((Form)obj).Controls)
                {
                    if (controlForm is TextBox)
                    {
                        ((TextBox)controlForm).Enter += Control_Enter;
                        ((TextBox)controlForm).Leave += Control_Leave;
                    }
                    
                    if (controlForm is NumericUpDown)
                    {
                        ((NumericUpDown)controlForm).Enter += Control_Enter;
                        ((NumericUpDown)controlForm).Leave += Control_Leave;
                    }
                  
                   
                    if (controlForm is Panel)
                    {
                       AsignarEventoEnterLeave(controlForm);
                    }
                }
            }
            else
            {
                if (obj is Panel)
                {
                    foreach (var ControlPanel in ((Panel)obj).Controls)
                    {
                        if (ControlPanel is TextBox)
                        {
                            ((TextBox)ControlPanel).Enter += Control_Enter;
                            ((TextBox)ControlPanel).Leave += Control_Leave;
                        }
                       
                        if (ControlPanel is NumericUpDown)
                        {
                            ((NumericUpDown)ControlPanel).Enter += Control_Enter;
                            ((NumericUpDown)ControlPanel).Leave += Control_Leave;
                        }
                       
                       
                        if (ControlPanel is Panel)
                        {
                            AsignarEventoEnterLeave(ControlPanel);
                        }
                    }
                }
            }
        }

        public virtual void CargarComboBox(ComboBox cmb, object datos, string PropiedadMostrar, 
            string propiedadDevolver)
        {
            cmb.DataSource = datos;
            cmb.DisplayMember = PropiedadMostrar;
            cmb.ValueMember = propiedadDevolver;

        }


        public virtual void AgregarControlesObligatorios(object control, string nombreControl)
        {
            _listaControlesObligatorios.Add(new ControlDto
            {
                Control = control,
                NombreControl = nombreControl
            });

            AsignarErrorProvider(control);
        }

        public virtual void AsignarErrorProvider(object control)
        {
            if (control is TextBox)
            {
                ((TextBox)control).Validated += Control_Validated;
            }

            if (control is RichTextBox)
            {
                ((RichTextBox)control).Validated += Control_Validated;
            }

            if (control is ComboBox)
            {
                ((ComboBox)control).Validated += Control_Validated;
            }
        }

        public virtual void Control_Validated(object sender, System.EventArgs e)
        {
            if (sender is TextBox)
            {
                error.SetError(((TextBox)sender),
                    !string.IsNullOrEmpty(((TextBox)sender).Text)
                        ? string.Empty
                        : $"El campo es Obligatorio.");
                return;
            }

            if (sender is RichTextBox)
            {
                error.SetError(((RichTextBox)sender),
                    !string.IsNullOrEmpty(((RichTextBox)sender).Text)
                        ? string.Empty
                        : $"El campo es Obligatorio.");

                return;
            }

            if (sender is NumericUpDown)
            {
                error.SetError(((NumericUpDown)sender),
                    !string.IsNullOrEmpty(((NumericUpDown)sender).Text)
                        ? string.Empty
                        : $"El campo es Obligatorio.");

                return;
            }

            if (sender is ComboBox)
            {
                error.SetError(((ComboBox)sender),
                    !string.IsNullOrEmpty(((ComboBox)sender).Text)
                        ? string.Empty
                        : $"El campo es Obligatorio.");
            }
        }

        public virtual bool VerificarDatosObligatorios()
        {
            foreach (var objeto in _listaControlesObligatorios)
            {
                switch (objeto.Control)
                {
                    case TextBox _:
                        if (string.IsNullOrEmpty(((TextBox)objeto.Control).Text)) return false;
                        break;
                    case RichTextBox _:
                        if (string.IsNullOrEmpty(((RichTextBox)objeto.Control).Text)) return false;
                        break;
                    case NumericUpDown _:
                        if (string.IsNullOrEmpty(((NumericUpDown)objeto.Control).Text)) return false;
                        break;
                    case ComboBox _:
                        if (((ComboBox)objeto.Control).Items.Count <= 0) return false;
                        break;
                }
            }

            return true;
        }

    }
}
