namespace conversor_y_mas
{
    partial class Parcial
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
            this.btnconvertir = new System.Windows.Forms.Button();
            this.cmbde = new System.Windows.Forms.ComboBox();
            this.txtcantidad = new System.Windows.Forms.TextBox();
            this.cmba = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbopcion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblresultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnconvertir
            // 
            this.btnconvertir.Location = new System.Drawing.Point(169, 307);
            this.btnconvertir.Name = "btnconvertir";
            this.btnconvertir.Size = new System.Drawing.Size(106, 44);
            this.btnconvertir.TabIndex = 0;
            this.btnconvertir.Text = "Convertir";
            this.btnconvertir.UseVisualStyleBackColor = true;
            this.btnconvertir.Click += new System.EventHandler(this.btnconvertir_Click);
            // 
            // cmbde
            // 
            this.cmbde.FormattingEnabled = true;
            this.cmbde.Location = new System.Drawing.Point(169, 118);
            this.cmbde.Name = "cmbde";
            this.cmbde.Size = new System.Drawing.Size(121, 21);
            this.cmbde.TabIndex = 1;
            // 
            // txtcantidad
            // 
            this.txtcantidad.Location = new System.Drawing.Point(169, 173);
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(100, 20);
            this.txtcantidad.TabIndex = 2;
            // 
            // cmba
            // 
            this.cmba.FormattingEnabled = true;
            this.cmba.Location = new System.Drawing.Point(169, 218);
            this.cmba.Name = "cmba";
            this.cmba.Size = new System.Drawing.Size(121, 21);
            this.cmba.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "De:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cantidad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "A:";
            // 
            // cmbopcion
            // 
            this.cmbopcion.FormattingEnabled = true;
            this.cmbopcion.Location = new System.Drawing.Point(169, 62);
            this.cmbopcion.Name = "cmbopcion";
            this.cmbopcion.Size = new System.Drawing.Size(121, 21);
            this.cmbopcion.TabIndex = 7;
            this.cmbopcion.SelectedIndexChanged += new System.EventHandler(this.cmbopcion_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Opcion:";
            // 
            // lblresultado
            // 
            this.lblresultado.AutoSize = true;
            this.lblresultado.Location = new System.Drawing.Point(175, 268);
            this.lblresultado.Name = "lblresultado";
            this.lblresultado.Size = new System.Drawing.Size(13, 13);
            this.lblresultado.TabIndex = 9;
            this.lblresultado.Text = "?";
            // 
            // Parcial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 363);
            this.Controls.Add(this.lblresultado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbopcion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmba);
            this.Controls.Add(this.txtcantidad);
            this.Controls.Add(this.cmbde);
            this.Controls.Add(this.btnconvertir);
            this.Name = "Parcial";
            this.Text = "Parcial";
            this.Load += new System.EventHandler(this.Parcial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnconvertir;
        private System.Windows.Forms.ComboBox cmbde;
        private System.Windows.Forms.TextBox txtcantidad;
        private System.Windows.Forms.ComboBox cmba;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbopcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblresultado;
    }
}