﻿namespace SIMPLEAPI_Demo
{
    partial class MuestraTimbre
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
            this.botonCargarDTE = new System.Windows.Forms.Button();
            this.pictureBoxTimbre = new System.Windows.Forms.PictureBox();
            this.botonValidar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTimbre)).BeginInit();
            this.SuspendLayout();
            // 
            // botonCargarDTE
            // 
            this.botonCargarDTE.Location = new System.Drawing.Point(240, 12);
            this.botonCargarDTE.Name = "botonCargarDTE";
            this.botonCargarDTE.Size = new System.Drawing.Size(75, 23);
            this.botonCargarDTE.TabIndex = 3;
            this.botonCargarDTE.Text = "Cargar DTE";
            this.botonCargarDTE.UseVisualStyleBackColor = true;
            this.botonCargarDTE.Click += new System.EventHandler(this.botonCargarDTE_Click);
            // 
            // pictureBoxTimbre
            // 
            this.pictureBoxTimbre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxTimbre.Location = new System.Drawing.Point(16, 58);
            this.pictureBoxTimbre.Name = "pictureBoxTimbre";
            this.pictureBoxTimbre.Size = new System.Drawing.Size(414, 170);
            this.pictureBoxTimbre.TabIndex = 2;
            this.pictureBoxTimbre.TabStop = false;
            // 
            // botonValidar
            // 
            this.botonValidar.Location = new System.Drawing.Point(321, 12);
            this.botonValidar.Name = "botonValidar";
            this.botonValidar.Size = new System.Drawing.Size(105, 23);
            this.botonValidar.TabIndex = 4;
            this.botonValidar.Text = "Validar Timbre";
            this.botonValidar.UseVisualStyleBackColor = true;
            this.botonValidar.Click += new System.EventHandler(this.botonValidar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MuestraTimbre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 254);
            this.Controls.Add(this.botonValidar);
            this.Controls.Add(this.botonCargarDTE);
            this.Controls.Add(this.pictureBoxTimbre);
            this.MaximizeBox = false;
            this.Name = "MuestraTimbre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Muestra de Timbre";
            this.Load += new System.EventHandler(this.MuestraTimbre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTimbre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonCargarDTE;
        private System.Windows.Forms.PictureBox pictureBoxTimbre;
        private System.Windows.Forms.Button botonValidar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}