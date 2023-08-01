namespace Presentacion.Core.caja
{
    partial class _00041_CajaCerrar
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
            this.label3 = new System.Windows.Forms.Label();
            this.nudDiferencia = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudMontoSistema = new System.Windows.Forms.NumericUpDown();
            this.lblfechaCierre = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudMontoCierre = new System.Windows.Forms.NumericUpDown();
            this.LblUsuarioLogueado = new System.Windows.Forms.Label();
            this.btnCerrarCaja = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiferencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoSistema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoCierre)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Diferencia";
            // 
            // nudDiferencia
            // 
            this.nudDiferencia.Enabled = false;
            this.nudDiferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDiferencia.Location = new System.Drawing.Point(223, 98);
            this.nudDiferencia.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudDiferencia.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.nudDiferencia.Name = "nudDiferencia";
            this.nudDiferencia.Size = new System.Drawing.Size(120, 28);
            this.nudDiferencia.TabIndex = 17;
            this.nudDiferencia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudMontoCierre_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Monto Del Sistema";
            // 
            // nudMontoSistema
            // 
            this.nudMontoSistema.Enabled = false;
            this.nudMontoSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMontoSistema.Location = new System.Drawing.Point(223, 64);
            this.nudMontoSistema.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudMontoSistema.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.nudMontoSistema.Name = "nudMontoSistema";
            this.nudMontoSistema.Size = new System.Drawing.Size(120, 28);
            this.nudMontoSistema.TabIndex = 15;
            this.nudMontoSistema.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudMontoCierre_KeyUp);
            // 
            // lblfechaCierre
            // 
            this.lblfechaCierre.AutoSize = true;
            this.lblfechaCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfechaCierre.Location = new System.Drawing.Point(12, 9);
            this.lblfechaCierre.Name = "lblfechaCierre";
            this.lblfechaCierre.Size = new System.Drawing.Size(133, 18);
            this.lblfechaCierre.TabIndex = 14;
            this.lblfechaCierre.Text = "Fecha de Cierre:    ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Monto de Cierre";
            // 
            // nudMontoCierre
            // 
            this.nudMontoCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMontoCierre.Location = new System.Drawing.Point(223, 30);
            this.nudMontoCierre.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudMontoCierre.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.nudMontoCierre.Name = "nudMontoCierre";
            this.nudMontoCierre.Size = new System.Drawing.Size(120, 28);
            this.nudMontoCierre.TabIndex = 12;
            this.nudMontoCierre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudMontoCierre_KeyPress);
            this.nudMontoCierre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudMontoCierre_KeyUp);
            // 
            // LblUsuarioLogueado
            // 
            this.LblUsuarioLogueado.AutoSize = true;
            this.LblUsuarioLogueado.Location = new System.Drawing.Point(12, 191);
            this.LblUsuarioLogueado.Name = "LblUsuarioLogueado";
            this.LblUsuarioLogueado.Size = new System.Drawing.Size(145, 17);
            this.LblUsuarioLogueado.TabIndex = 11;
            this.LblUsuarioLogueado.Text = "Usuario Logugeado:  ";
            // 
            // btnCerrarCaja
            // 
            this.btnCerrarCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarCaja.ForeColor = System.Drawing.Color.White;
            this.btnCerrarCaja.Location = new System.Drawing.Point(47, 134);
            this.btnCerrarCaja.Name = "btnCerrarCaja";
            this.btnCerrarCaja.Size = new System.Drawing.Size(296, 43);
            this.btnCerrarCaja.TabIndex = 10;
            this.btnCerrarCaja.Text = "Cerrar Caja";
            this.btnCerrarCaja.UseVisualStyleBackColor = true;
            this.btnCerrarCaja.Click += new System.EventHandler(this.btnCerrarCaja_Click);
            // 
            // _00041_CajaCerrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 228);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudDiferencia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudMontoSistema);
            this.Controls.Add(this.lblfechaCierre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudMontoCierre);
            this.Controls.Add(this.LblUsuarioLogueado);
            this.Controls.Add(this.btnCerrarCaja);
            this.Name = "_00041_CajaCerrar";
            this.Text = "CajaCerrar";
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiferencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoSistema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoCierre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudDiferencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudMontoSistema;
        private System.Windows.Forms.Label lblfechaCierre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudMontoCierre;
        private System.Windows.Forms.Label LblUsuarioLogueado;
        private System.Windows.Forms.Button btnCerrarCaja;
    }
}