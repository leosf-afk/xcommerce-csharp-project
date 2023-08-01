namespace Presentacion.Core.Empleado
{
    partial class _00044_Cliente_Cta_Cte
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.SetChildIndex(this.txtBuscar, 0);
            this.panel2.Controls.SetChildIndex(this.textBox1, 0);
            // 
            // btnPagar
            // 
           
            // 
            // cmbCondicion
            // 
            this.cmbCondicion.Size = new System.Drawing.Size(146, 24);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(268, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 7;
            // 
            // _00044_Cliente_Cta_Cte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 594);
            this.MaximumSize = new System.Drawing.Size(1117, 641);
            this.MinimumSize = new System.Drawing.Size(1117, 641);
            this.Name = "_00044_Cliente_Cta_Cte";
            this.Text = "Cliente_Cta_Cte";
            this.Load += new System.EventHandler(this._00044_Cliente_Cta_Cte_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
    }
}