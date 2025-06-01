namespace SIMPLEAPI_Demo.Vista
{
    partial class generarDTE_NCE
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtTermino = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInicio = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grilla1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.netoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docreferenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ventasFandaDataSet = new SIMPLEAPI_Demo.VentasFandaDataSet();
            this.panel4 = new System.Windows.Forms.Panel();
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lbBruto = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbIVA = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbNeto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nCTableAdapter = new SIMPLEAPI_Demo.VentasFandaDataSetTableAdapters.NCTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventasFandaDataSet)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nCBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1382, 932);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.kryptonGroupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.panel1.Size = new System.Drawing.Size(1374, 178);
            this.panel1.TabIndex = 0;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroupBox1.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlCustom1;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(15, 15);
            this.kryptonGroupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonButton1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtTermino);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label2);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtInicio);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label1);
            this.kryptonGroupBox1.Panel.Padding = new System.Windows.Forms.Padding(20, 30, 20, 22);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(1344, 148);
            this.kryptonGroupBox1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonGroupBox1.StateCommon.Border.Rounding = 10;
            this.kryptonGroupBox1.TabIndex = 0;
            this.kryptonGroupBox1.Values.Heading = "Filtro de búsqueda";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.kryptonButton1.Location = new System.Drawing.Point(1191, 30);
            this.kryptonButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(125, 57);
            this.kryptonButton1.TabIndex = 3;
            this.kryptonButton1.Values.Text = "Buscar";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // txtTermino
            // 
            this.txtTermino.CalendarTodayDate = new System.DateTime(2022, 9, 14, 0, 0, 0, 0);
            this.txtTermino.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTermino.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtTermino.Location = new System.Drawing.Point(456, 30);
            this.txtTermino.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTermino.Name = "txtTermino";
            this.txtTermino.Size = new System.Drawing.Size(266, 57);
            this.txtTermino.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(350, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(15, 7, 7, 0);
            this.label2.Size = new System.Drawing.Size(106, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Término";
            // 
            // txtInicio
            // 
            this.txtInicio.CalendarTodayDate = new System.DateTime(2022, 9, 14, 0, 0, 0, 0);
            this.txtInicio.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtInicio.Location = new System.Drawing.Point(84, 30);
            this.txtInicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.Size = new System.Drawing.Size(266, 57);
            this.txtInicio.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 7, 7, 0);
            this.label1.Size = new System.Drawing.Size(64, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inicio";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 190);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1374, 738);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1374, 738);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grilla1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.panel3.Size = new System.Drawing.Size(1366, 582);
            this.panel3.TabIndex = 0;
            // 
            // grilla1
            // 
            this.grilla1.AllowUserToAddRows = false;
            this.grilla1.AllowUserToDeleteRows = false;
            this.grilla1.AutoGenerateColumns = false;
            this.grilla1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.fechaDataGridViewTextBoxColumn,
            this.folioDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.netoDataGridViewTextBoxColumn,
            this.iVADataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.docreferenciaDataGridViewTextBoxColumn});
            this.grilla1.DataSource = this.nCBindingSource1;
            this.grilla1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grilla1.Location = new System.Drawing.Point(15, 15);
            this.grilla1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grilla1.Name = "grilla1";
            this.grilla1.ReadOnly = true;
            this.grilla1.RowHeadersWidth = 51;
            this.grilla1.RowTemplate.Height = 24;
            this.grilla1.Size = new System.Drawing.Size(1336, 552);
            this.grilla1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "id";
            this.idDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idDataGridViewTextBoxColumn1.Width = 125;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "fecha";
            this.fechaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn.Width = 125;
            // 
            // folioDataGridViewTextBoxColumn
            // 
            this.folioDataGridViewTextBoxColumn.DataPropertyName = "Folio";
            this.folioDataGridViewTextBoxColumn.HeaderText = "Folio";
            this.folioDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.folioDataGridViewTextBoxColumn.Name = "folioDataGridViewTextBoxColumn";
            this.folioDataGridViewTextBoxColumn.ReadOnly = true;
            this.folioDataGridViewTextBoxColumn.Width = 125;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Sala de Venta";
            this.nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreDataGridViewTextBoxColumn.Width = 125;
            // 
            // netoDataGridViewTextBoxColumn
            // 
            this.netoDataGridViewTextBoxColumn.DataPropertyName = "Neto";
            this.netoDataGridViewTextBoxColumn.HeaderText = "Neto";
            this.netoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.netoDataGridViewTextBoxColumn.Name = "netoDataGridViewTextBoxColumn";
            this.netoDataGridViewTextBoxColumn.ReadOnly = true;
            this.netoDataGridViewTextBoxColumn.Width = 125;
            // 
            // iVADataGridViewTextBoxColumn
            // 
            this.iVADataGridViewTextBoxColumn.DataPropertyName = "IVA";
            this.iVADataGridViewTextBoxColumn.HeaderText = "IVA";
            this.iVADataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iVADataGridViewTextBoxColumn.Name = "iVADataGridViewTextBoxColumn";
            this.iVADataGridViewTextBoxColumn.ReadOnly = true;
            this.iVADataGridViewTextBoxColumn.Width = 125;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalDataGridViewTextBoxColumn.Width = 125;
            // 
            // docreferenciaDataGridViewTextBoxColumn
            // 
            this.docreferenciaDataGridViewTextBoxColumn.DataPropertyName = "doc_referencia";
            this.docreferenciaDataGridViewTextBoxColumn.HeaderText = "doc_referencia";
            this.docreferenciaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.docreferenciaDataGridViewTextBoxColumn.Name = "docreferenciaDataGridViewTextBoxColumn";
            this.docreferenciaDataGridViewTextBoxColumn.ReadOnly = true;
            this.docreferenciaDataGridViewTextBoxColumn.Width = 125;
            // 
            // nCBindingSource1
            // 
            this.nCBindingSource1.DataMember = "NC";
            this.nCBindingSource1.DataSource = this.ventasFandaDataSet;
            // 
            // ventasFandaDataSet
            // 
            this.ventasFandaDataSet.DataSetName = "VentasFandaDataSet";
            this.ventasFandaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.kryptonButton2);
            this.panel4.Controls.Add(this.lbBruto);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.lbIVA);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.lbNeto);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(4, 594);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.panel4.Size = new System.Drawing.Size(1366, 140);
            this.panel4.TabIndex = 1;
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.kryptonButton2.Location = new System.Drawing.Point(1056, 15);
            this.kryptonButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(295, 110);
            this.kryptonButton2.TabIndex = 7;
            this.kryptonButton2.Values.Text = "Generar DTE";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // lbBruto
            // 
            this.lbBruto.AutoSize = true;
            this.lbBruto.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbBruto.Location = new System.Drawing.Point(275, 15);
            this.lbBruto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbBruto.Name = "lbBruto";
            this.lbBruto.Padding = new System.Windows.Forms.Padding(0, 30, 7, 0);
            this.lbBruto.Size = new System.Drawing.Size(30, 55);
            this.lbBruto.TabIndex = 6;
            this.lbBruto.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(204, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 30, 7, 0);
            this.label6.Size = new System.Drawing.Size(71, 55);
            this.label6.TabIndex = 5;
            this.label6.Text = "Bruto:";
            // 
            // lbIVA
            // 
            this.lbIVA.AutoSize = true;
            this.lbIVA.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbIVA.Location = new System.Drawing.Point(174, 15);
            this.lbIVA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbIVA.Name = "lbIVA";
            this.lbIVA.Padding = new System.Windows.Forms.Padding(0, 30, 7, 0);
            this.lbIVA.Size = new System.Drawing.Size(30, 55);
            this.lbIVA.TabIndex = 4;
            this.lbIVA.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(116, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 30, 7, 0);
            this.label5.Size = new System.Drawing.Size(58, 55);
            this.label5.TabIndex = 3;
            this.label5.Text = "IVA:";
            // 
            // lbNeto
            // 
            this.lbNeto.AutoSize = true;
            this.lbNeto.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbNeto.Location = new System.Drawing.Point(86, 15);
            this.lbNeto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNeto.Name = "lbNeto";
            this.lbNeto.Padding = new System.Windows.Forms.Padding(0, 30, 7, 0);
            this.lbNeto.Size = new System.Drawing.Size(30, 55);
            this.lbNeto.TabIndex = 2;
            this.lbNeto.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(15, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 30, 7, 0);
            this.label3.Size = new System.Drawing.Size(71, 55);
            this.label3.TabIndex = 1;
            this.label3.Text = "Neto: ";
            // 
            // nCBindingSource
            // 
            this.nCBindingSource.DataMember = "NC";
            this.nCBindingSource.DataSource = this.ventasFandaDataSet;
            // 
            // nCTableAdapter
            // 
            this.nCTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // generarDTE_NCE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 932);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "generarDTE_NCE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generación de archivos XML para envío a SII";
            this.Load += new System.EventHandler(this.generarDTE_NCE_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grilla1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventasFandaDataSet)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nCBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker txtTermino;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker txtInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView grilla1;
        private System.Windows.Forms.Panel panel4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
        private System.Windows.Forms.Label lbBruto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbIVA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbNeto;
        private System.Windows.Forms.Label label3;
        private VentasFandaDataSet ventasFandaDataSet;
        private System.Windows.Forms.BindingSource nCBindingSource;
        private VentasFandaDataSetTableAdapters.NCTableAdapter nCTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn folioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn netoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iVADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docreferenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource nCBindingSource1;
    }
}