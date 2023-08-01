namespace Presentacion.Core.VentaSalon
{
    partial class _00036_VentaSalon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00036_VentaSalon));
            this.lbltitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MenuAccesoRapido = new System.Windows.Forms.ToolStrip();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.MenuAccesoRapido.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbltitulo
            // 
            this.lbltitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.BackColor = System.Drawing.Color.Transparent;
            this.lbltitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbltitulo.Location = new System.Drawing.Point(306, 198);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(0, 38);
            this.lbltitulo.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 10);
            this.panel1.TabIndex = 5;
            // 
            // MenuAccesoRapido
            // 
            this.MenuAccesoRapido.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.MenuAccesoRapido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalir});
            this.MenuAccesoRapido.Location = new System.Drawing.Point(0, 0);
            this.MenuAccesoRapido.Name = "MenuAccesoRapido";
            this.MenuAccesoRapido.Size = new System.Drawing.Size(800, 62);
            this.MenuAccesoRapido.TabIndex = 4;
            this.MenuAccesoRapido.Text = "toolStrip1";
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(42, 59);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // _00036_VentaSalon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbltitulo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MenuAccesoRapido);
            this.Name = "_00036_VentaSalon";
            this.Text = "Salon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this._00036_VentaSalon_Activated);
            this.Load += new System.EventHandler(this._00036_VentaSalon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.MenuAccesoRapido.ResumeLayout(false);
            this.MenuAccesoRapido.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip MenuAccesoRapido;
        private System.Windows.Forms.ToolStripButton btnSalir;
    }
}