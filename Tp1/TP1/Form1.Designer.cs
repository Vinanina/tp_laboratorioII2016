namespace TP1
{
    partial class calculadora
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNumero1 = new System.Windows.Forms.TextBox();
            this.txtNumero2 = new System.Windows.Forms.TextBox();
            this.cmbOperacion = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnOperar = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNumero1
            // 
            this.txtNumero1.Location = new System.Drawing.Point(23, 50);
            this.txtNumero1.Name = "txtNumero1";
            this.txtNumero1.Size = new System.Drawing.Size(71, 20);
            this.txtNumero1.TabIndex = 1;
            this.txtNumero1.TextChanged += new System.EventHandler(this.txtNumero1_TextChanged);
            // 
            // txtNumero2
            // 
            this.txtNumero2.Location = new System.Drawing.Point(190, 50);
            this.txtNumero2.Name = "txtNumero2";
            this.txtNumero2.Size = new System.Drawing.Size(67, 20);
            this.txtNumero2.TabIndex = 2;
            // 
            // cmbOperacion
            // 
            this.cmbOperacion.FormattingEnabled = true;
            this.cmbOperacion.Location = new System.Drawing.Point(117, 49);
            this.cmbOperacion.Name = "cmbOperacion";
            this.cmbOperacion.Size = new System.Drawing.Size(50, 21);
            this.cmbOperacion.TabIndex = 3;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.AccessibleName = "btnClean";
            this.btnLimpiar.Location = new System.Drawing.Point(49, 101);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "CC";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOperar
            // 
            this.btnOperar.Location = new System.Drawing.Point(152, 101);
            this.btnOperar.Name = "btnOperar";
            this.btnOperar.Size = new System.Drawing.Size(75, 23);
            this.btnOperar.TabIndex = 5;
            this.btnOperar.Text = "=";
            this.btnOperar.UseVisualStyleBackColor = true;
            this.btnOperar.Click += new System.EventHandler(this.btnOperar_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(20, 21);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 13);
            this.lblResultado.TabIndex = 6;
            // 
            // calculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 140);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnOperar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.cmbOperacion);
            this.Controls.Add(this.txtNumero2);
            this.Controls.Add(this.txtNumero1);
            this.Name = "calculadora";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.lblResultado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumero1;
        private System.Windows.Forms.TextBox txtNumero2;
        private System.Windows.Forms.ComboBox cmbOperacion;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnOperar;
        private System.Windows.Forms.Label lblResultado;
    }
}

