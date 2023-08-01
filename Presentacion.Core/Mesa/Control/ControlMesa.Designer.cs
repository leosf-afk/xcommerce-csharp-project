namespace Presentacion.Core.Mesa.Control
{
    partial class ControlMesa
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlMesa));
            this.lblPrecio = new System.Windows.Forms.Label();
            this.menuCtrol = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAbrirMesa = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNumeroMesa = new System.Windows.Forms.Label();
            this.menuCtrol.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPrecio
            // 
            this.lblPrecio.BackColor = System.Drawing.Color.Transparent;
            this.lblPrecio.ContextMenuStrip = this.menuCtrol;
            this.lblPrecio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(0, 67);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(98, 31);
            this.lblPrecio.TabIndex = 1;
            this.lblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPrecio.DoubleClick += new System.EventHandler(this.lblNumeroMesa_DoubleClick);
            // 
            // menuCtrol
            // 
            this.menuCtrol.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuCtrol.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbrirMesa});
            this.menuCtrol.Name = "menuCtrol";
            this.menuCtrol.Size = new System.Drawing.Size(211, 56);
            // 
            // menuAbrirMesa
            // 
            this.menuAbrirMesa.Name = "menuAbrirMesa";
            this.menuAbrirMesa.Size = new System.Drawing.Size(210, 24);
            this.menuAbrirMesa.Text = "Abrir Mesa";
            this.menuAbrirMesa.Click += new System.EventHandler(this.menuAbrirMesa_Click);
            // 
            // lblNumeroMesa
            // 
            this.lblNumeroMesa.BackColor = System.Drawing.Color.Transparent;
            this.lblNumeroMesa.ContextMenuStrip = this.menuCtrol;
            this.lblNumeroMesa.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNumeroMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroMesa.ForeColor = System.Drawing.Color.Transparent;
            this.lblNumeroMesa.Location = new System.Drawing.Point(0, 0);
            this.lblNumeroMesa.Name = "lblNumeroMesa";
            this.lblNumeroMesa.Size = new System.Drawing.Size(98, 67);
            this.lblNumeroMesa.TabIndex = 0;
            this.lblNumeroMesa.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblNumeroMesa.DoubleClick += new System.EventHandler(this.lblNumeroMesa_DoubleClick);
            // 
            // ControlMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblNumeroMesa);
            this.DoubleBuffered = true;
            this.Name = "ControlMesa";
            this.Size = new System.Drawing.Size(98, 98);
            this.DoubleClick += new System.EventHandler(this.lblNumeroMesa_DoubleClick);
            this.menuCtrol.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblNumeroMesa;
        private System.Windows.Forms.ContextMenuStrip menuCtrol;
        private System.Windows.Forms.ToolStripMenuItem menuAbrirMesa;
        public System.Windows.Forms.Label lblPrecio;
    }
}
