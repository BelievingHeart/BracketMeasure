namespace DataBind.UI
{
    partial class FormRotationCenter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRotationCenter));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cogRecordDisplay1 = new Cognex.VisionPro.CogRecordDisplay();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label13 = new System.Windows.Forms.Label();
            this.txtRealY = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.txtRealX = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtAffineY = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.txtAffineX = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtResultRadius = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtResultY = new System.Windows.Forms.TextBox();
            this.txtResultX = new System.Windows.Forms.TextBox();
            this.btnFindCenter = new System.Windows.Forms.Button();
            this.btnGetRef3 = new System.Windows.Forms.Button();
            this.btnGetRef2 = new System.Windows.Forms.Button();
            this.btnGetRef1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 292F));
            this.tableLayoutPanel1.Controls.Add(this.cogRecordDisplay1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(879, 487);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cogRecordDisplay1
            // 
            this.cogRecordDisplay1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogRecordDisplay1.Location = new System.Drawing.Point(3, 3);
            this.cogRecordDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay1.Name = "cogRecordDisplay1";
            this.cogRecordDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay1.OcxState")));
            this.cogRecordDisplay1.Size = new System.Drawing.Size(581, 481);
            this.cogRecordDisplay1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.Label13);
            this.panel1.Controls.Add(this.txtRealY);
            this.panel1.Controls.Add(this.Label14);
            this.panel1.Controls.Add(this.txtRealX);
            this.panel1.Controls.Add(this.Label12);
            this.panel1.Controls.Add(this.Label10);
            this.panel1.Controls.Add(this.txtAffineY);
            this.panel1.Controls.Add(this.Label11);
            this.panel1.Controls.Add(this.txtAffineX);
            this.panel1.Controls.Add(this.btnTest);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Label9);
            this.panel1.Controls.Add(this.txtResultRadius);
            this.panel1.Controls.Add(this.Label7);
            this.panel1.Controls.Add(this.txtResultY);
            this.panel1.Controls.Add(this.txtResultX);
            this.panel1.Controls.Add(this.btnFindCenter);
            this.panel1.Controls.Add(this.btnGetRef3);
            this.panel1.Controls.Add(this.btnGetRef2);
            this.panel1.Controls.Add(this.btnGetRef1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(590, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 481);
            this.panel1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(10, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(264, 123);
            this.dataGridView1.TabIndex = 109;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "X";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Y";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(130, 382);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(11, 12);
            this.Label13.TabIndex = 108;
            this.Label13.Text = "Y";
            // 
            // txtRealY
            // 
            this.txtRealY.Location = new System.Drawing.Point(145, 379);
            this.txtRealY.Name = "txtRealY";
            this.txtRealY.ReadOnly = true;
            this.txtRealY.Size = new System.Drawing.Size(72, 21);
            this.txtRealY.TabIndex = 107;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(4, 382);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(35, 12);
            this.Label14.TabIndex = 106;
            this.Label14.Text = "实际X";
            // 
            // txtRealX
            // 
            this.txtRealX.Location = new System.Drawing.Point(45, 379);
            this.txtRealX.Name = "txtRealX";
            this.txtRealX.ReadOnly = true;
            this.txtRealX.Size = new System.Drawing.Size(72, 21);
            this.txtRealX.TabIndex = 105;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(123, 323);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(29, 12);
            this.Label12.TabIndex = 104;
            this.Label12.Text = "角度";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(130, 355);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(11, 12);
            this.Label10.TabIndex = 102;
            this.Label10.Text = "Y";
            // 
            // txtAffineY
            // 
            this.txtAffineY.Location = new System.Drawing.Point(145, 352);
            this.txtAffineY.Name = "txtAffineY";
            this.txtAffineY.ReadOnly = true;
            this.txtAffineY.Size = new System.Drawing.Size(72, 21);
            this.txtAffineY.TabIndex = 101;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(4, 355);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(35, 12);
            this.Label11.TabIndex = 100;
            this.Label11.Text = "理论X";
            // 
            // txtAffineX
            // 
            this.txtAffineX.Location = new System.Drawing.Point(45, 352);
            this.txtAffineX.Name = "txtAffineX";
            this.txtAffineX.ReadOnly = true;
            this.txtAffineX.Size = new System.Drawing.Size(72, 21);
            this.txtAffineX.TabIndex = 99;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(33, 312);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(84, 34);
            this.btnTest.TabIndex = 98;
            this.btnTest.Text = "测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(193, 436);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 36);
            this.btnSave.TabIndex = 97;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 96;
            this.label4.Text = "X";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(13, 277);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(29, 12);
            this.Label9.TabIndex = 95;
            this.Label9.Text = "半径";
            // 
            // txtResultRadius
            // 
            this.txtResultRadius.Location = new System.Drawing.Point(48, 274);
            this.txtResultRadius.Name = "txtResultRadius";
            this.txtResultRadius.ReadOnly = true;
            this.txtResultRadius.Size = new System.Drawing.Size(72, 21);
            this.txtResultRadius.TabIndex = 94;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(131, 250);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(11, 12);
            this.Label7.TabIndex = 93;
            this.Label7.Text = "Y";
            // 
            // txtResultY
            // 
            this.txtResultY.Location = new System.Drawing.Point(148, 247);
            this.txtResultY.Name = "txtResultY";
            this.txtResultY.ReadOnly = true;
            this.txtResultY.Size = new System.Drawing.Size(72, 21);
            this.txtResultY.TabIndex = 92;
            // 
            // txtResultX
            // 
            this.txtResultX.Location = new System.Drawing.Point(48, 247);
            this.txtResultX.Name = "txtResultX";
            this.txtResultX.ReadOnly = true;
            this.txtResultX.Size = new System.Drawing.Size(72, 21);
            this.txtResultX.TabIndex = 90;
            // 
            // btnFindCenter
            // 
            this.btnFindCenter.Location = new System.Drawing.Point(33, 210);
            this.btnFindCenter.Name = "btnFindCenter";
            this.btnFindCenter.Size = new System.Drawing.Size(107, 34);
            this.btnFindCenter.TabIndex = 89;
            this.btnFindCenter.Text = "计算旋转中心";
            this.btnFindCenter.UseVisualStyleBackColor = true;
            this.btnFindCenter.Click += new System.EventHandler(this.btnFindCenter_Click);
            // 
            // btnGetRef3
            // 
            this.btnGetRef3.Location = new System.Drawing.Point(190, 9);
            this.btnGetRef3.Name = "btnGetRef3";
            this.btnGetRef3.Size = new System.Drawing.Size(84, 34);
            this.btnGetRef3.TabIndex = 84;
            this.btnGetRef3.Text = "获取参照点3";
            this.btnGetRef3.UseVisualStyleBackColor = true;
            // 
            // btnGetRef2
            // 
            this.btnGetRef2.Location = new System.Drawing.Point(100, 9);
            this.btnGetRef2.Name = "btnGetRef2";
            this.btnGetRef2.Size = new System.Drawing.Size(84, 34);
            this.btnGetRef2.TabIndex = 79;
            this.btnGetRef2.Text = "获取参照点2";
            this.btnGetRef2.UseVisualStyleBackColor = true;
            // 
            // btnGetRef1
            // 
            this.btnGetRef1.Location = new System.Drawing.Point(10, 9);
            this.btnGetRef1.Name = "btnGetRef1";
            this.btnGetRef1.Size = new System.Drawing.Size(84, 34);
            this.btnGetRef1.TabIndex = 74;
            this.btnGetRef1.Text = "获取参照点1";
            this.btnGetRef1.UseVisualStyleBackColor = true;
            this.btnGetRef1.Click += new System.EventHandler(this.btnGetRef1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Location = new System.Drawing.Point(157, 321);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(63, 21);
            this.numericUpDown1.TabIndex = 110;
            // 
            // FormRotationCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 487);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormRotationCenter";
            this.Text = "FormRotationCenter";
            this.Load += new System.EventHandler(this.FormRotationCenter_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox txtResultRadius;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtResultY;
        internal System.Windows.Forms.TextBox txtResultX;
        internal System.Windows.Forms.Button btnFindCenter;
        internal System.Windows.Forms.Button btnGetRef3;
        internal System.Windows.Forms.Button btnGetRef2;
        internal System.Windows.Forms.Button btnGetRef1;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.TextBox txtRealY;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.TextBox txtRealX;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox txtAffineY;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.TextBox txtAffineX;
        internal System.Windows.Forms.Button btnTest;
        internal System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}