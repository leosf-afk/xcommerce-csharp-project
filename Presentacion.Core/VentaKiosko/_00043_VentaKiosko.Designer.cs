namespace Presentacion.Core.VentaKiosko
{
    partial class _00043_VentaKiosko
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
            this.btnfacturar = new System.Windows.Forms.Button();
            this.nudTotal = new System.Windows.Forms.NumericUpDown();
            this.nuddescuento = new System.Windows.Forms.NumericUpDown();
            this.nudSubTotal = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.dgvFacturar = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTipoPago = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCLiente = new System.Windows.Forms.TextBox();
            this.FotoBuscar = new System.Windows.Forms.PictureBox();
            this.txtctacte = new System.Windows.Forms.TextBox();
            this.lblCtaCte = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTipoFactura = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuddescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FotoBuscar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnfacturar
            // 
            this.btnfacturar.Location = new System.Drawing.Point(16, 398);
            this.btnfacturar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnfacturar.Name = "btnfacturar";
            this.btnfacturar.Size = new System.Drawing.Size(102, 25);
            this.btnfacturar.TabIndex = 67;
            this.btnfacturar.Text = "Facturar";
            this.btnfacturar.UseVisualStyleBackColor = true;
            this.btnfacturar.Click += new System.EventHandler(this.button1_Click);
            // 
            // nudTotal
            // 
            this.nudTotal.DecimalPlaces = 2;
            this.nudTotal.Enabled = false;
            this.nudTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotal.Location = new System.Drawing.Point(608, 399);
            this.nudTotal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudTotal.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudTotal.Name = "nudTotal";
            this.nudTotal.Size = new System.Drawing.Size(86, 23);
            this.nudTotal.TabIndex = 66;
            // 
            // nuddescuento
            // 
            this.nuddescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuddescuento.Location = new System.Drawing.Point(608, 368);
            this.nuddescuento.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nuddescuento.Name = "nuddescuento";
            this.nuddescuento.Size = new System.Drawing.Size(86, 23);
            this.nuddescuento.TabIndex = 65;
            this.nuddescuento.ValueChanged += new System.EventHandler(this.nuddescuento_ValueChanged);
            this.nuddescuento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nuddescuento_KeyUp);
            // 
            // nudSubTotal
            // 
            this.nudSubTotal.DecimalPlaces = 2;
            this.nudSubTotal.Enabled = false;
            this.nudSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSubTotal.Location = new System.Drawing.Point(608, 334);
            this.nudSubTotal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudSubTotal.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudSubTotal.Name = "nudSubTotal";
            this.nudSubTotal.Size = new System.Drawing.Size(86, 23);
            this.nudSubTotal.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(575, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(472, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Precio Unitario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Descripcion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Codigo / Codigo de Barra";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(578, 34);
            this.nudCantidad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(55, 20);
            this.nudCantidad.TabIndex = 52;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.Location = new System.Drawing.Point(476, 33);
            this.txtPrecioUnitario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.ReadOnly = true;
            this.txtPrecioUnitario.Size = new System.Drawing.Size(98, 20);
            this.txtPrecioUnitario.TabIndex = 51;
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(153, 33);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(319, 20);
            this.txtProducto.TabIndex = 50;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(26, 33);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(124, 20);
            this.txtCodigo.TabIndex = 49;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // dgvFacturar
            // 
            this.dgvFacturar.AllowUserToAddRows = false;
            this.dgvFacturar.AllowUserToDeleteRows = false;
            this.dgvFacturar.BackgroundColor = System.Drawing.Color.White;
            this.dgvFacturar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturar.GridColor = System.Drawing.Color.DarkGray;
            this.dgvFacturar.Location = new System.Drawing.Point(22, 72);
            this.dgvFacturar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvFacturar.Name = "dgvFacturar";
            this.dgvFacturar.ReadOnly = true;
            this.dgvFacturar.RowTemplate.Height = 24;
            this.dgvFacturar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturar.Size = new System.Drawing.Size(673, 248);
            this.dgvFacturar.TabIndex = 48;
            this.dgvFacturar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvFacturar_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(540, 401);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 47;
            this.label7.Text = "TOTAL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(502, 372);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 17);
            this.label6.TabIndex = 46;
            this.label6.Text = "Descuento[%]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(524, 339);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 45;
            this.label5.Text = "Sub-Total";
            // 
            // cmbTipoPago
            // 
            this.cmbTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoPago.FormattingEnabled = true;
            this.cmbTipoPago.Location = new System.Drawing.Point(260, 327);
            this.cmbTipoPago.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbTipoPago.Name = "cmbTipoPago";
            this.cmbTipoPago.Size = new System.Drawing.Size(232, 25);
            this.cmbTipoPago.TabIndex = 68;
            this.cmbTipoPago.SelectionChangeCommitted += new System.EventHandler(this.cmbTipoPago_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(149, 330);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 15);
            this.label10.TabIndex = 69;
            this.label10.Text = "Forma de Pago";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(31, 373);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 70;
            this.label9.Text = "Cliente";
            // 
            // txtCLiente
            // 
            this.txtCLiente.Enabled = false;
            this.txtCLiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCLiente.Location = new System.Drawing.Point(91, 370);
            this.txtCLiente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCLiente.Name = "txtCLiente";
            this.txtCLiente.Size = new System.Drawing.Size(360, 24);
            this.txtCLiente.TabIndex = 71;
            // 
            // FotoBuscar
            // 
            this.FotoBuscar.BackColor = System.Drawing.Color.Transparent;
            this.FotoBuscar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FotoBuscar.Image = global::Presentacion.Core.Properties.Resources.Buscar;
            this.FotoBuscar.Location = new System.Drawing.Point(454, 357);
            this.FotoBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FotoBuscar.Name = "FotoBuscar";
            this.FotoBuscar.Size = new System.Drawing.Size(37, 40);
            this.FotoBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FotoBuscar.TabIndex = 72;
            this.FotoBuscar.TabStop = false;
            this.FotoBuscar.Click += new System.EventHandler(this.FotoBuscar_Click_1);
            // 
            // txtctacte
            // 
            this.txtctacte.Enabled = false;
            this.txtctacte.Location = new System.Drawing.Point(364, 405);
            this.txtctacte.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtctacte.Name = "txtctacte";
            this.txtctacte.Size = new System.Drawing.Size(61, 20);
            this.txtctacte.TabIndex = 73;
            // 
            // lblCtaCte
            // 
            this.lblCtaCte.AutoSize = true;
            this.lblCtaCte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtaCte.Location = new System.Drawing.Point(182, 406);
            this.lblCtaCte.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCtaCte.Name = "lblCtaCte";
            this.lblCtaCte.Size = new System.Drawing.Size(178, 15);
            this.lblCtaCte.TabIndex = 74;
            this.lblCtaCte.Text = "Monto Disponible Cta. Cte.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 334);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 15);
            this.label8.TabIndex = 75;
            this.label8.Text = "Factura";
            // 
            // cmbTipoFactura
            // 
            this.cmbTipoFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoFactura.FormattingEnabled = true;
            this.cmbTipoFactura.Location = new System.Drawing.Point(85, 331);
            this.cmbTipoFactura.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbTipoFactura.Name = "cmbTipoFactura";
            this.cmbTipoFactura.Size = new System.Drawing.Size(61, 23);
            this.cmbTipoFactura.TabIndex = 76;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(643, 30);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(52, 25);
            this.btnAgregar.TabIndex = 77;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click_1);
            // 
            // _00043_VentaKiosko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 434);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cmbTipoFactura);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblCtaCte);
            this.Controls.Add(this.txtctacte);
            this.Controls.Add(this.FotoBuscar);
            this.Controls.Add(this.txtCLiente);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbTipoPago);
            this.Controls.Add(this.btnfacturar);
            this.Controls.Add(this.nudTotal);
            this.Controls.Add(this.nuddescuento);
            this.Controls.Add(this.nudSubTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.txtPrecioUnitario);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.dgvFacturar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Name = "_00043_VentaKiosko";
            this.Text = "VentaKiosko";
            this.Activated += new System.EventHandler(this._00043_VentaKiosko_Activated);
            this.Load += new System.EventHandler(this._00043_VentaKiosko_Load);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuddescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FotoBuscar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnfacturar;
        private System.Windows.Forms.NumericUpDown nudTotal;
        private System.Windows.Forms.NumericUpDown nuddescuento;
        private System.Windows.Forms.NumericUpDown nudSubTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.DataGridView dgvFacturar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTipoPago;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCLiente;
        private System.Windows.Forms.PictureBox FotoBuscar;
        private System.Windows.Forms.TextBox txtctacte;
        private System.Windows.Forms.Label lblCtaCte;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTipoFactura;
        private System.Windows.Forms.Button btnAgregar;
    }
}