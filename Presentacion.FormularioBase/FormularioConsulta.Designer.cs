namespace Presentacion.FormularioBase
{
    partial class FormularioConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioConsulta));
            this.menuAccesoRapido = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnModificar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.ImagenBuscar = new System.Windows.Forms.PictureBox();
            this.btnPagar = new System.Windows.Forms.Button();
            this.lblDeuda = new System.Windows.Forms.Label();
            this.txtDeuda = new System.Windows.Forms.TextBox();
            this.lblCondicion = new System.Windows.Forms.Label();
            this.cmbCondicion = new System.Windows.Forms.ComboBox();
            this.lblCtaPersona = new System.Windows.Forms.Label();
            this.btnPrueba = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.menuAccesoRapido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenBuscar)).BeginInit();
            this.SuspendLayout();
            // 
            // menuAccesoRapido
            // 
            this.menuAccesoRapido.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuAccesoRapido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnEliminar,
            this.btnModificar,
            this.btnSalir,
            this.toolStripSeparator1,
            this.btnActualizar,
            this.btnImprimir,
            this.btnPrueba});
            this.menuAccesoRapido.Location = new System.Drawing.Point(0, 0);
            this.menuAccesoRapido.Name = "menuAccesoRapido";
            this.menuAccesoRapido.Size = new System.Drawing.Size(1099, 67);
            this.menuAccesoRapido.TabIndex = 0;
            this.menuAccesoRapido.Text = "toolStrip1";
            this.menuAccesoRapido.DoubleClick += new System.EventHandler(this.dgvGrilla_DoubleClick);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(64, 64);
            this.btnNuevo.Text = " Nuevo ";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(67, 64);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(77, 64);
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(66, 64);
            this.btnSalir.Text = "   Salir   ";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 67);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(79, 64);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(70, 64);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1099, 10);
            this.panel1.TabIndex = 1;
            this.panel1.DoubleClick += new System.EventHandler(this.dgvGrilla_DoubleClick);
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGrilla.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Location = new System.Drawing.Point(9, 136);
            this.dgvGrilla.MultiSelect = false;
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.ReadOnly = true;
            this.dgvGrilla.RowTemplate.Height = 24;
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(1075, 446);
            this.dgvGrilla.TabIndex = 2;
            this.dgvGrilla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrilla_CellContentClick);
            this.dgvGrilla.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrilla_RowEnter);
            this.dgvGrilla.DoubleClick += new System.EventHandler(this.dgvGrilla_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtBuscar);
            this.panel2.Controls.Add(this.btnBuscar);
            this.panel2.Location = new System.Drawing.Point(719, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(368, 37);
            this.panel2.TabIndex = 3;
            this.panel2.DoubleClick += new System.EventHandler(this.dgvGrilla_DoubleClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Location = new System.Drawing.Point(71, 9);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(213, 22);
            this.txtBuscar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(290, 8);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 26);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // ImagenBuscar
            // 
            this.ImagenBuscar.BackColor = System.Drawing.Color.Transparent;
            this.ImagenBuscar.Location = new System.Drawing.Point(674, 93);
            this.ImagenBuscar.Name = "ImagenBuscar";
            this.ImagenBuscar.Size = new System.Drawing.Size(52, 42);
            this.ImagenBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagenBuscar.TabIndex = 4;
            this.ImagenBuscar.TabStop = false;
            this.ImagenBuscar.DoubleClick += new System.EventHandler(this.dgvGrilla_DoubleClick);
            // 
            // btnPagar
            // 
            this.btnPagar.Enabled = false;
            this.btnPagar.Location = new System.Drawing.Point(651, 93);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(75, 29);
            this.btnPagar.TabIndex = 12;
            this.btnPagar.Text = "pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Visible = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // lblDeuda
            // 
            this.lblDeuda.AutoSize = true;
            this.lblDeuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeuda.Location = new System.Drawing.Point(381, 97);
            this.lblDeuda.Name = "lblDeuda";
            this.lblDeuda.Size = new System.Drawing.Size(58, 20);
            this.lblDeuda.TabIndex = 13;
            this.lblDeuda.Text = "Deuda";
            this.lblDeuda.Visible = false;
            // 
            // txtDeuda
            // 
            this.txtDeuda.Enabled = false;
            this.txtDeuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeuda.Location = new System.Drawing.Point(451, 95);
            this.txtDeuda.Name = "txtDeuda";
            this.txtDeuda.Size = new System.Drawing.Size(100, 27);
            this.txtDeuda.TabIndex = 11;
            this.txtDeuda.Visible = false;
            // 
            // lblCondicion
            // 
            this.lblCondicion.AutoSize = true;
            this.lblCondicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondicion.Location = new System.Drawing.Point(35, 98);
            this.lblCondicion.Name = "lblCondicion";
            this.lblCondicion.Size = new System.Drawing.Size(83, 20);
            this.lblCondicion.TabIndex = 10;
            this.lblCondicion.Text = "Condicion";
            this.lblCondicion.Visible = false;
            // 
            // cmbCondicion
            // 
            this.cmbCondicion.Enabled = false;
            this.cmbCondicion.FormattingEnabled = true;
            this.cmbCondicion.Location = new System.Drawing.Point(133, 94);
            this.cmbCondicion.Name = "cmbCondicion";
            this.cmbCondicion.Size = new System.Drawing.Size(146, 24);
            this.cmbCondicion.TabIndex = 9;
            this.cmbCondicion.Visible = false;
            // 
            // lblCtaPersona
            // 
            this.lblCtaPersona.AutoSize = true;
            this.lblCtaPersona.BackColor = System.Drawing.Color.Transparent;
            this.lblCtaPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtaPersona.Location = new System.Drawing.Point(474, 9);
            this.lblCtaPersona.Name = "lblCtaPersona";
            this.lblCtaPersona.Size = new System.Drawing.Size(161, 32);
            this.lblCtaPersona.TabIndex = 14;
            this.lblCtaPersona.Text = "Cta Cte De:";
            this.lblCtaPersona.Visible = false;
            // 
            // btnPrueba
            // 
            this.btnPrueba.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrueba.Image = ((System.Drawing.Image)(resources.GetObject("btnPrueba.Image")));
            this.btnPrueba.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrueba.Name = "btnPrueba";
            this.btnPrueba.Size = new System.Drawing.Size(44, 64);
            this.btnPrueba.Text = "Prueba";
            this.btnPrueba.Visible = false;
            this.btnPrueba.Click += new System.EventHandler(this.btnPrueba_Click);
            // 
            // FormularioConsulta
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1099, 594);
            this.Controls.Add(this.lblCtaPersona);
            this.Controls.Add(this.txtDeuda);
            this.Controls.Add(this.lblDeuda);
            this.Controls.Add(this.lblCondicion);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.cmbCondicion);
            this.Controls.Add(this.ImagenBuscar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvGrilla);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuAccesoRapido);
            this.Name = "FormularioConsulta";
            this.Text = "Comprobantes de Cta Cte";
            this.Load += new System.EventHandler(this.FormularioConsulta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.menuAccesoRapido.ResumeLayout(false);
            this.menuAccesoRapido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenBuscar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menuAccesoRapido;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        protected System.Windows.Forms.DataGridView dgvGrilla;
        protected System.Windows.Forms.TextBox txtBuscar;
        protected System.Windows.Forms.ToolStripButton btnImprimir;
        protected System.Windows.Forms.ToolStripButton btnEliminar;
        protected System.Windows.Forms.ToolStripButton btnModificar;
        public System.Windows.Forms.ToolStripButton btnNuevo;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.PictureBox ImagenBuscar;
        public System.Windows.Forms.ToolStripButton btnActualizar;
        protected System.Windows.Forms.Button btnPagar;
        protected System.Windows.Forms.Label lblDeuda;
        protected System.Windows.Forms.TextBox txtDeuda;
        protected System.Windows.Forms.Label lblCondicion;
        protected System.Windows.Forms.ComboBox cmbCondicion;
        protected System.Windows.Forms.Label lblCtaPersona;
        protected System.Windows.Forms.ToolStripButton btnPrueba;
    }
}