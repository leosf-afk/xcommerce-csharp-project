namespace Presentacion.Core.VentaSalon
{
    partial class _00037_ComprobanteMesa
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
            this.dgvFacturar = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMozo = new System.Windows.Forms.TextBox();
            this.txtMozoLegajo = new System.Windows.Forms.TextBox();
            this.btnMozo = new System.Windows.Forms.Button();
            this.nudComesales = new System.Windows.Forms.NumericUpDown();
            this.nudSubTotal = new System.Windows.Forms.NumericUpDown();
            this.nuddescuento = new System.Windows.Forms.NumericUpDown();
            this.nudTotal = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComesales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuddescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFacturar
            // 
            this.dgvFacturar.AllowUserToAddRows = false;
            this.dgvFacturar.AllowUserToDeleteRows = false;
            this.dgvFacturar.BackgroundColor = System.Drawing.Color.White;
            this.dgvFacturar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturar.GridColor = System.Drawing.Color.DarkGray;
            this.dgvFacturar.Location = new System.Drawing.Point(15, 119);
            this.dgvFacturar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvFacturar.Name = "dgvFacturar";
            this.dgvFacturar.ReadOnly = true;
            this.dgvFacturar.RowTemplate.Height = 24;
            this.dgvFacturar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturar.Size = new System.Drawing.Size(673, 248);
            this.dgvFacturar.TabIndex = 24;
            this.dgvFacturar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvFacturar_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(533, 447);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "TOTAL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(489, 416);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Descuento[%]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(517, 385);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Sub-Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(546, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(466, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Precio Unitario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Descripcion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Codigo / Codigo de Barra";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(626, 76);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(64, 23);
            this.btnAgregar.TabIndex = 29;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(548, 80);
            this.nudCantidad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(74, 20);
            this.nudCantidad.TabIndex = 28;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.Location = new System.Drawing.Point(469, 80);
            this.txtPrecioUnitario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.ReadOnly = true;
            this.txtPrecioUnitario.Size = new System.Drawing.Size(76, 20);
            this.txtPrecioUnitario.TabIndex = 27;
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(146, 80);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(319, 20);
            this.txtProducto.TabIndex = 26;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(19, 80);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(124, 20);
            this.txtCodigo.TabIndex = 25;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 384);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 17);
            this.label8.TabIndex = 37;
            this.label8.Text = "Comensales";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 17);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Mozo";
            // 
            // txtMozo
            // 
            this.txtMozo.Location = new System.Drawing.Point(102, 33);
            this.txtMozo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMozo.Name = "txtMozo";
            this.txtMozo.ReadOnly = true;
            this.txtMozo.Size = new System.Drawing.Size(521, 20);
            this.txtMozo.TabIndex = 35;
            // 
            // txtMozoLegajo
            // 
            this.txtMozoLegajo.Location = new System.Drawing.Point(19, 33);
            this.txtMozoLegajo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMozoLegajo.MaxLength = 10;
            this.txtMozoLegajo.Name = "txtMozoLegajo";
            this.txtMozoLegajo.Size = new System.Drawing.Size(80, 20);
            this.txtMozoLegajo.TabIndex = 34;
            this.txtMozoLegajo.TextChanged += new System.EventHandler(this.txtMozoLegajo_TextChanged);
            this.txtMozoLegajo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMozoLegajo_KeyPress_1);
            // 
            // btnMozo
            // 
            this.btnMozo.Location = new System.Drawing.Point(626, 31);
            this.btnMozo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMozo.Name = "btnMozo";
            this.btnMozo.Size = new System.Drawing.Size(62, 23);
            this.btnMozo.TabIndex = 38;
            this.btnMozo.Text = "Buscar";
            this.btnMozo.UseVisualStyleBackColor = true;
            this.btnMozo.Click += new System.EventHandler(this.btnMozo_Click);
            // 
            // nudComesales
            // 
            this.nudComesales.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudComesales.Location = new System.Drawing.Point(110, 379);
            this.nudComesales.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudComesales.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudComesales.Name = "nudComesales";
            this.nudComesales.Size = new System.Drawing.Size(56, 23);
            this.nudComesales.TabIndex = 39;
            this.nudComesales.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudSubTotal
            // 
            this.nudSubTotal.DecimalPlaces = 2;
            this.nudSubTotal.Enabled = false;
            this.nudSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSubTotal.Location = new System.Drawing.Point(602, 380);
            this.nudSubTotal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudSubTotal.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudSubTotal.Name = "nudSubTotal";
            this.nudSubTotal.Size = new System.Drawing.Size(86, 23);
            this.nudSubTotal.TabIndex = 40;
            // 
            // nuddescuento
            // 
            this.nuddescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuddescuento.Location = new System.Drawing.Point(602, 414);
            this.nuddescuento.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nuddescuento.Name = "nuddescuento";
            this.nuddescuento.Size = new System.Drawing.Size(86, 23);
            this.nuddescuento.TabIndex = 41;
            this.nuddescuento.ValueChanged += new System.EventHandler(this.nuddescuento_ValueChanged);
            this.nuddescuento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nuddescuento_KeyUp);
            // 
            // nudTotal
            // 
            this.nudTotal.DecimalPlaces = 2;
            this.nudTotal.Enabled = false;
            this.nudTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotal.Location = new System.Drawing.Point(602, 445);
            this.nudTotal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudTotal.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudTotal.Name = "nudTotal";
            this.nudTotal.Size = new System.Drawing.Size(86, 23);
            this.nudTotal.TabIndex = 42;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(698, 8);
            this.panel1.TabIndex = 43;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 444);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 25);
            this.button1.TabIndex = 44;
            this.button1.Text = "Cerrar Mesa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _00037_ComprobanteMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 486);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.nudTotal);
            this.Controls.Add(this.nuddescuento);
            this.Controls.Add(this.nudSubTotal);
            this.Controls.Add(this.nudComesales);
            this.Controls.Add(this.btnMozo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMozo);
            this.Controls.Add(this.txtMozoLegajo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.txtPrecioUnitario);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.dgvFacturar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.MaximumSize = new System.Drawing.Size(714, 525);
            this.MinimumSize = new System.Drawing.Size(714, 525);
            this.Name = "_00037_ComprobanteMesa";
            this.Text = "Venta";
            this.Load += new System.EventHandler(this._00037_ComprobanteMesa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComesales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuddescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFacturar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMozo;
        private System.Windows.Forms.TextBox txtMozoLegajo;
        private System.Windows.Forms.Button btnMozo;
        private System.Windows.Forms.NumericUpDown nudComesales;
        private System.Windows.Forms.NumericUpDown nudSubTotal;
        private System.Windows.Forms.NumericUpDown nuddescuento;
        private System.Windows.Forms.NumericUpDown nudTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}