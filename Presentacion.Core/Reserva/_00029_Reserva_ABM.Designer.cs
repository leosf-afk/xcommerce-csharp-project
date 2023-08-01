namespace Presentacion.Core.Reserva
{
    partial class _00029_Reserva_ABM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CmbMesa = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.nudSenia = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbMotivoReserva = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbEstadoReserva = new System.Windows.Forms.ComboBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.FotoBuscar = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSenia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FotoBuscar)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbMesa
            // 
            this.CmbMesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMesa.Location = new System.Drawing.Point(492, 81);
            this.CmbMesa.Name = "CmbMesa";
            this.CmbMesa.Size = new System.Drawing.Size(276, 28);
            this.CmbMesa.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(421, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 25);
            this.label4.TabIndex = 26;
            this.label4.Text = "Mesa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "Fecha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Estado de Reserva";
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsuario.Location = new System.Drawing.Point(499, 187);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(269, 28);
            this.cmbUsuario.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(407, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 25);
            this.label5.TabIndex = 28;
            this.label5.Text = "Usuario";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(131, 83);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(252, 22);
            this.dtpFecha.TabIndex = 30;
            // 
            // nudSenia
            // 
            this.nudSenia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSenia.Location = new System.Drawing.Point(648, 116);
            this.nudSenia.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudSenia.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSenia.Name = "nudSenia";
            this.nudSenia.Size = new System.Drawing.Size(120, 27);
            this.nudSenia.TabIndex = 31;
            this.nudSenia.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(579, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 25);
            this.label6.TabIndex = 32;
            this.label6.Text = "Seña";
            // 
            // cmbMotivoReserva
            // 
            this.cmbMotivoReserva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMotivoReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMotivoReserva.Location = new System.Drawing.Point(245, 153);
            this.cmbMotivoReserva.Name = "cmbMotivoReserva";
            this.cmbMotivoReserva.Size = new System.Drawing.Size(523, 28);
            this.cmbMotivoReserva.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(63, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 25);
            this.label7.TabIndex = 33;
            this.label7.Text = "Motivo Reserva";
            // 
            // cmbEstadoReserva
            // 
            this.cmbEstadoReserva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstadoReserva.Location = new System.Drawing.Point(245, 119);
            this.cmbEstadoReserva.Name = "cmbEstadoReserva";
            this.cmbEstadoReserva.Size = new System.Drawing.Size(302, 28);
            this.cmbEstadoReserva.TabIndex = 35;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Enabled = false;
            this.txtNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCliente.Location = new System.Drawing.Point(131, 221);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(637, 27);
            this.txtNombreCliente.TabIndex = 37;
            // 
            // FotoBuscar
            // 
            this.FotoBuscar.BackColor = System.Drawing.Color.PaleGreen;
            this.FotoBuscar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FotoBuscar.Image = global::Presentacion.Core.Properties.Resources.Buscar;
            this.FotoBuscar.Location = new System.Drawing.Point(53, 185);
            this.FotoBuscar.Name = "FotoBuscar";
            this.FotoBuscar.Size = new System.Drawing.Size(66, 63);
            this.FotoBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FotoBuscar.TabIndex = 38;
            this.FotoBuscar.TabStop = false;
            this.FotoBuscar.Click += new System.EventHandler(this.FotoBuscar_Click);
            this.FotoBuscar.MouseEnter += new System.EventHandler(this.FotoBuscar_MouseEnter);
            this.FotoBuscar.MouseLeave += new System.EventHandler(this.FotoBuscar_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(126, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 39;
            this.label3.Text = "Cliente";
            // 
            // _00029_Reserva_ABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 276);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FotoBuscar);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.cmbEstadoReserva);
            this.Controls.Add(this.cmbMotivoReserva);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudSenia);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.cmbUsuario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CmbMesa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "_00029_Reserva_ABM";
            this.Text = "Reserva_ABM";
            this.Load += new System.EventHandler(this._00029_Reserva_ABM_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.CmbMesa, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cmbUsuario, 0);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.nudSenia, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.cmbMotivoReserva, 0);
            this.Controls.SetChildIndex(this.cmbEstadoReserva, 0);
            this.Controls.SetChildIndex(this.txtNombreCliente, 0);
            this.Controls.SetChildIndex(this.FotoBuscar, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSenia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FotoBuscar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbMesa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.NumericUpDown nudSenia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbMotivoReserva;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbEstadoReserva;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.PictureBox FotoBuscar;
        private System.Windows.Forms.Label label3;
    }
}