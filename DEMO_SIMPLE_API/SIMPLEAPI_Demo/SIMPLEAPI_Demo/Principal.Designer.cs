namespace SIMPLEAPI_Demo
{
    partial class Principal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.radioCertificacion = new System.Windows.Forms.RadioButton();
            this.radioProduccion = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Button3 = new System.Windows.Forms.Button();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.Button1 = new System.Windows.Forms.Button();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.Button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.GroupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15, 41, 15, 16);
            this.panel1.Size = new System.Drawing.Size(262, 618);
            this.panel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel7);
            this.groupBox4.Controls.Add(this.radioCertificacion);
            this.groupBox4.Controls.Add(this.radioProduccion);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(15, 298);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(232, 119);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Envío al SII";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.button6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(3, 79);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(5);
            this.panel7.Size = new System.Drawing.Size(226, 37);
            this.panel7.TabIndex = 16;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button6.Location = new System.Drawing.Point(5, 5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(216, 27);
            this.button6.TabIndex = 11;
            this.button6.Text = "Enviar a SII";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // radioCertificacion
            // 
            this.radioCertificacion.AutoSize = true;
            this.radioCertificacion.Location = new System.Drawing.Point(16, 25);
            this.radioCertificacion.Name = "radioCertificacion";
            this.radioCertificacion.Size = new System.Drawing.Size(90, 20);
            this.radioCertificacion.TabIndex = 14;
            this.radioCertificacion.Text = "Certificación";
            this.radioCertificacion.UseVisualStyleBackColor = true;
            // 
            // radioProduccion
            // 
            this.radioProduccion.AutoSize = true;
            this.radioProduccion.Checked = true;
            this.radioProduccion.Location = new System.Drawing.Point(16, 48);
            this.radioProduccion.Name = "radioProduccion";
            this.radioProduccion.Size = new System.Drawing.Size(86, 20);
            this.radioProduccion.TabIndex = 15;
            this.radioProduccion.TabStop = true;
            this.radioProduccion.Text = "Producción";
            this.radioProduccion.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel9);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(15, 226);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox1.Size = new System.Drawing.Size(232, 72);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Herramientas";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.button8);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(8, 21);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(5);
            this.panel9.Size = new System.Drawing.Size(216, 37);
            this.panel9.TabIndex = 13;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button8.Location = new System.Drawing.Point(5, 5);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(206, 27);
            this.button8.TabIndex = 11;
            this.button8.Text = "Opciones avanzadas";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.panel5);
            this.GroupBox3.Controls.Add(this.Panel2);
            this.GroupBox3.Controls.Add(this.Panel3);
            this.GroupBox3.Controls.Add(this.Panel4);
            this.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBox3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GroupBox3.Location = new System.Drawing.Point(15, 41);
            this.GroupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Padding = new System.Windows.Forms.Padding(8);
            this.GroupBox3.Size = new System.Drawing.Size(232, 185);
            this.GroupBox3.TabIndex = 24;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Preparando Envío";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(8, 132);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(5);
            this.panel5.Size = new System.Drawing.Size(216, 37);
            this.panel5.TabIndex = 14;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button4.Location = new System.Drawing.Point(5, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(206, 27);
            this.button4.TabIndex = 11;
            this.button4.Text = "Generar DTE NC";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.Button3);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(8, 95);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.Panel2.Size = new System.Drawing.Size(216, 37);
            this.Panel2.TabIndex = 11;
            // 
            // Button3
            // 
            this.Button3.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button3.FlatAppearance.BorderSize = 0;
            this.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Button3.Location = new System.Drawing.Point(5, 5);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(206, 27);
            this.Button3.TabIndex = 11;
            this.Button3.Text = "Generar DTE Boletas";
            this.Button3.UseVisualStyleBackColor = false;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.Button1);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Location = new System.Drawing.Point(8, 58);
            this.Panel3.Name = "Panel3";
            this.Panel3.Padding = new System.Windows.Forms.Padding(5);
            this.Panel3.Size = new System.Drawing.Size(216, 37);
            this.Panel3.TabIndex = 12;
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button1.FlatAppearance.BorderSize = 0;
            this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Button1.Location = new System.Drawing.Point(5, 5);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(206, 27);
            this.Button1.TabIndex = 11;
            this.Button1.Text = "Sobre de Envío Boletas";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Panel4
            // 
            this.Panel4.Controls.Add(this.Button2);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel4.Location = new System.Drawing.Point(8, 21);
            this.Panel4.Name = "Panel4";
            this.Panel4.Padding = new System.Windows.Forms.Padding(5);
            this.Panel4.Size = new System.Drawing.Size(216, 37);
            this.Panel4.TabIndex = 13;
            // 
            // Button2
            // 
            this.Button2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button2.FlatAppearance.BorderSize = 0;
            this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Button2.Location = new System.Drawing.Point(5, 5);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(206, 27);
            this.Button2.TabIndex = 11;
            this.Button2.Text = "Configuración";
            this.Button2.UseVisualStyleBackColor = false;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.button5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button5.Location = new System.Drawing.Point(15, 566);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(232, 36);
            this.button5.TabIndex = 27;
            this.button5.Text = "Sobre de Envío NCE";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(262, 618);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Button Button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        internal System.Windows.Forms.Panel panel5;
        internal System.Windows.Forms.Button button4;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Panel panel9;
        internal System.Windows.Forms.Button button8;
        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.Button button6;
        private System.Windows.Forms.RadioButton radioCertificacion;
        private System.Windows.Forms.RadioButton radioProduccion;
        internal System.Windows.Forms.Button button5;
    }
}