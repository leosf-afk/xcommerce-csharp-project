namespace Presentacion.Core.FormaPago
{
    partial class _00042_FormaPagoSalon
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
            this.cmbTipoPago = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCLiente = new System.Windows.Forms.TextBox();
            this.FotoBuscar = new System.Windows.Forms.PictureBox();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.lblCtaCte = new System.Windows.Forms.Label();
            this.txtctacte = new System.Windows.Forms.TextBox();
            this.cmbTipoFactura = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FotoBuscar)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTipoPago
            // 
            this.cmbTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoPago.FormattingEnabled = true;
            this.cmbTipoPago.Location = new System.Drawing.Point(383, 18);
            this.cmbTipoPago.Name = "cmbTipoPago";
            this.cmbTipoPago.Size = new System.Drawing.Size(115, 30);
            this.cmbTipoPago.TabIndex = 0;
            this.cmbTipoPago.SelectionChangeCommitted += new System.EventHandler(this.cmbTipoPago_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(235, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Forma de Pago";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cliente";
            // 
            // txtCLiente
            // 
            this.txtCLiente.Enabled = false;
            this.txtCLiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCLiente.Location = new System.Drawing.Point(104, 81);
            this.txtCLiente.Name = "txtCLiente";
            this.txtCLiente.Size = new System.Drawing.Size(327, 28);
            this.txtCLiente.TabIndex = 4;
            // 
            // FotoBuscar
            // 
            this.FotoBuscar.BackColor = System.Drawing.Color.Transparent;
            this.FotoBuscar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FotoBuscar.Image = global::Presentacion.Core.Properties.Resources.Buscar;
            this.FotoBuscar.Location = new System.Drawing.Point(437, 64);
            this.FotoBuscar.Name = "FotoBuscar";
            this.FotoBuscar.Size = new System.Drawing.Size(48, 48);
            this.FotoBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FotoBuscar.TabIndex = 39;
            this.FotoBuscar.TabStop = false;
            this.FotoBuscar.Click += new System.EventHandler(this.FotoBuscar_Click);
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Enabled = false;
            this.txtTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPagar.Location = new System.Drawing.Point(157, 188);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.Size = new System.Drawing.Size(214, 30);
            this.txtTotalPagar.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 18);
            this.label3.TabIndex = 41;
            this.label3.Text = "Total a Pagar";
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(383, 186);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(95, 29);
            this.btnPagar.TabIndex = 42;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblCtaCte
            // 
            this.lblCtaCte.AutoSize = true;
            this.lblCtaCte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtaCte.Location = new System.Drawing.Point(26, 142);
            this.lblCtaCte.Name = "lblCtaCte";
            this.lblCtaCte.Size = new System.Drawing.Size(202, 18);
            this.lblCtaCte.TabIndex = 44;
            this.lblCtaCte.Text = "Monto Disponible Cta Cte";
            // 
            // txtctacte
            // 
            this.txtctacte.Enabled = false;
            this.txtctacte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtctacte.Location = new System.Drawing.Point(261, 134);
            this.txtctacte.Name = "txtctacte";
            this.txtctacte.Size = new System.Drawing.Size(119, 30);
            this.txtctacte.TabIndex = 43;
            // 
            // cmbTipoFactura
            // 
            this.cmbTipoFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoFactura.FormattingEnabled = true;
            this.cmbTipoFactura.Location = new System.Drawing.Point(168, 12);
            this.cmbTipoFactura.Name = "cmbTipoFactura";
            this.cmbTipoFactura.Size = new System.Drawing.Size(46, 30);
            this.cmbTipoFactura.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 18);
            this.label5.TabIndex = 46;
            this.label5.Text = "Tipo De Factura";
            // 
            // _00042_FormaPagoSalon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 234);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTipoFactura);
            this.Controls.Add(this.lblCtaCte);
            this.Controls.Add(this.txtctacte);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotalPagar);
            this.Controls.Add(this.FotoBuscar);
            this.Controls.Add(this.txtCLiente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTipoPago);
            this.Name = "_00042_FormaPagoSalon";
            this.Text = "Facturar Mesa ";
            this.Activated += new System.EventHandler(this._00042_FormaPagoSalon_Activated);
            this.Load += new System.EventHandler(this._00042_FormaPagoSalon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FotoBuscar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTipoPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCLiente;
        private System.Windows.Forms.PictureBox FotoBuscar;
        private System.Windows.Forms.TextBox txtTotalPagar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Label lblCtaCte;
        private System.Windows.Forms.TextBox txtctacte;
        private System.Windows.Forms.ComboBox cmbTipoFactura;
        private System.Windows.Forms.Label label5;
    }
}