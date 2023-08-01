namespace Presentacion.Core.caja
{
    partial class _00040_Caja
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
            this.btnAbrirCerrarCaja = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.nudMontoApertura = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoApertura)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbrirCerrarCaja
            // 
            this.btnAbrirCerrarCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirCerrarCaja.ForeColor = System.Drawing.Color.White;
            this.btnAbrirCerrarCaja.Location = new System.Drawing.Point(41, 90);
            this.btnAbrirCerrarCaja.Name = "btnAbrirCerrarCaja";
            this.btnAbrirCerrarCaja.Size = new System.Drawing.Size(296, 43);
            this.btnAbrirCerrarCaja.TabIndex = 0;
            this.btnAbrirCerrarCaja.Text = "Abrir Caja";
            this.btnAbrirCerrarCaja.UseVisualStyleBackColor = true;
            this.btnAbrirCerrarCaja.Click += new System.EventHandler(this.btnAbrirCerrarCaja_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(5, 152);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(145, 17);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario Logugeado:  ";
            // 
            // nudMontoApertura
            // 
            this.nudMontoApertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMontoApertura.Location = new System.Drawing.Point(217, 41);
            this.nudMontoApertura.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudMontoApertura.Name = "nudMontoApertura";
            this.nudMontoApertura.Size = new System.Drawing.Size(120, 28);
            this.nudMontoApertura.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Monto Apertura";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(6, 9);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(128, 18);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Fecha Apertura:    ";
            // 
            // _00040_Caja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 180);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudMontoApertura);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnAbrirCerrarCaja);
            this.Name = "_00040_Caja";
            this.Text = "Caja";
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoApertura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbrirCerrarCaja;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.NumericUpDown nudMontoApertura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFecha;
    }
}