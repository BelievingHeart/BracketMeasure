namespace MainAPP.UI
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuIOCard = new System.Windows.Forms.ToolStripMenuItem();
            this.模板设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.相机校正ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据比对ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cogRecordDisplay1 = new Cognex.VisionPro.CogRecordDisplay();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox_saveOKImages = new System.Windows.Forms.CheckBox();
            this.checkBox_saveRawImages = new System.Windows.Forms.CheckBox();
            this.btnOpenImageDir = new System.Windows.Forms.Button();
            this.btnLastImage = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnX2 = new System.Windows.Forms.Button();
            this.label_currentIndex = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnY2 = new System.Windows.Forms.Button();
            this.btnAngle = new System.Windows.Forms.Button();
            this.btnX1 = new System.Windows.Forms.Button();
            this.btnY1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuIOCard,
            this.stationsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1709, 35);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuIOCard
            // 
            this.menuIOCard.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.模板设置ToolStripMenuItem});
            this.menuIOCard.Name = "menuIOCard";
            this.menuIOCard.Size = new System.Drawing.Size(80, 29);
            this.menuIOCard.Text = "参数(&P)";
            // 
            // 模板设置ToolStripMenuItem
            // 
            this.模板设置ToolStripMenuItem.Name = "模板设置ToolStripMenuItem";
            this.模板设置ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.模板设置ToolStripMenuItem.Text = "视觉模板";
            this.模板设置ToolStripMenuItem.Click += new System.EventHandler(this.模板设置ToolStripMenuItem_Click);
            // 
            // stationsToolStripMenuItem
            // 
            this.stationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.相机校正ToolStripMenuItem,
            this.数据比对ToolStripMenuItem});
            this.stationsToolStripMenuItem.Name = "stationsToolStripMenuItem";
            this.stationsToolStripMenuItem.Size = new System.Drawing.Size(84, 29);
            this.stationsToolStripMenuItem.Text = "操作(&O)";
            // 
            // 相机校正ToolStripMenuItem
            // 
            this.相机校正ToolStripMenuItem.Name = "相机校正ToolStripMenuItem";
            this.相机校正ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.相机校正ToolStripMenuItem.Text = "相机校正";
            this.相机校正ToolStripMenuItem.Click += new System.EventHandler(this.相机校正ToolStripMenuItem_Click);
            // 
            // 数据比对ToolStripMenuItem
            // 
            this.数据比对ToolStripMenuItem.Name = "数据比对ToolStripMenuItem";
            this.数据比对ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.数据比对ToolStripMenuItem.Text = "数据比对";
            this.数据比对ToolStripMenuItem.Click += new System.EventHandler(this.数据比对ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1252);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1709, 30);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(179, 25);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 35);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(1709, 1217);
            this.splitContainer1.SplitterDistance = 1427;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 18;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.cogRecordDisplay1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1217F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1427, 1217);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // cogRecordDisplay1
            // 
            this.cogRecordDisplay1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogRecordDisplay1.Location = new System.Drawing.Point(4, 5);
            this.cogRecordDisplay1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cogRecordDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay1.Name = "cogRecordDisplay1";
            this.cogRecordDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay1.OcxState")));
            this.cogRecordDisplay1.Size = new System.Drawing.Size(1419, 1207);
            this.cogRecordDisplay1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.listBox1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(276, 1217);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBox_saveOKImages);
            this.panel2.Controls.Add(this.checkBox_saveRawImages);
            this.panel2.Controls.Add(this.btnOpenImageDir);
            this.panel2.Controls.Add(this.btnLastImage);
            this.panel2.Controls.Add(this.btnRun);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 6);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 155);
            this.panel2.TabIndex = 1;
            // 
            // checkBox_saveOKImages
            // 
            this.checkBox_saveOKImages.AutoSize = true;
            this.checkBox_saveOKImages.Location = new System.Drawing.Point(141, 128);
            this.checkBox_saveOKImages.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox_saveOKImages.Name = "checkBox_saveOKImages";
            this.checkBox_saveOKImages.Size = new System.Drawing.Size(121, 24);
            this.checkBox_saveOKImages.TabIndex = 8;
            this.checkBox_saveOKImages.Text = "保存OK图片";
            this.checkBox_saveOKImages.UseVisualStyleBackColor = true;
            this.checkBox_saveOKImages.CheckedChanged += new System.EventHandler(this.checkBox_saveOKImages_CheckedChanged);
            // 
            // checkBox_saveRawImages
            // 
            this.checkBox_saveRawImages.AutoSize = true;
            this.checkBox_saveRawImages.Location = new System.Drawing.Point(141, 94);
            this.checkBox_saveRawImages.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox_saveRawImages.Name = "checkBox_saveRawImages";
            this.checkBox_saveRawImages.Size = new System.Drawing.Size(99, 24);
            this.checkBox_saveRawImages.TabIndex = 7;
            this.checkBox_saveRawImages.Text = "保存原图";
            this.checkBox_saveRawImages.UseVisualStyleBackColor = true;
            this.checkBox_saveRawImages.CheckedChanged += new System.EventHandler(this.checkBox_saveRawImages_CheckedChanged);
            // 
            // btnOpenImageDir
            // 
            this.btnOpenImageDir.Location = new System.Drawing.Point(176, 49);
            this.btnOpenImageDir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpenImageDir.Name = "btnOpenImageDir";
            this.btnOpenImageDir.Size = new System.Drawing.Size(112, 35);
            this.btnOpenImageDir.TabIndex = 6;
            this.btnOpenImageDir.Text = "图片路径";
            this.btnOpenImageDir.UseVisualStyleBackColor = true;
            this.btnOpenImageDir.Click += new System.EventHandler(this.btnOpenImageDir_Click);
            // 
            // btnLastImage
            // 
            this.btnLastImage.Location = new System.Drawing.Point(176, 5);
            this.btnLastImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLastImage.Name = "btnLastImage";
            this.btnLastImage.Size = new System.Drawing.Size(112, 35);
            this.btnLastImage.TabIndex = 5;
            this.btnLastImage.Text = "最近图片";
            this.btnLastImage.UseVisualStyleBackColor = true;
            this.btnLastImage.Click += new System.EventHandler(this.btnLastImage_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 5);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(156, 68);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "手动运行";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 107);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(106, 43);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "清空记录";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(5, 172);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(266, 873);
            this.listBox1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnX2);
            this.panel1.Controls.Add(this.label_currentIndex);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnY2);
            this.panel1.Controls.Add(this.btnAngle);
            this.panel1.Controls.Add(this.btnX1);
            this.panel1.Controls.Add(this.btnY1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 1056);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 155);
            this.panel1.TabIndex = 3;
            // 
            // btnX2
            // 
            this.btnX2.Location = new System.Drawing.Point(165, 100);
            this.btnX2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnX2.Name = "btnX2";
            this.btnX2.Size = new System.Drawing.Size(75, 35);
            this.btnX2.TabIndex = 7;
            this.btnX2.Text = "X2";
            this.btnX2.UseVisualStyleBackColor = true;
            // 
            // label_currentIndex
            // 
            this.label_currentIndex.AutoSize = true;
            this.label_currentIndex.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_currentIndex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label_currentIndex.Location = new System.Drawing.Point(140, 20);
            this.label_currentIndex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_currentIndex.Name = "label_currentIndex";
            this.label_currentIndex.Size = new System.Drawing.Size(51, 53);
            this.label_currentIndex.TabIndex = 6;
            this.label_currentIndex.Text = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "数据统计";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(240, 20);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(138, 52);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "重置统计";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnY2
            // 
            this.btnY2.Location = new System.Drawing.Point(315, 100);
            this.btnY2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnY2.Name = "btnY2";
            this.btnY2.Size = new System.Drawing.Size(75, 35);
            this.btnY2.TabIndex = 3;
            this.btnY2.Text = "Y2";
            this.btnY2.UseVisualStyleBackColor = true;
            // 
            // btnAngle
            // 
            this.btnAngle.Location = new System.Drawing.Point(15, 100);
            this.btnAngle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAngle.Name = "btnAngle";
            this.btnAngle.Size = new System.Drawing.Size(75, 35);
            this.btnAngle.TabIndex = 2;
            this.btnAngle.Text = "角度";
            this.btnAngle.UseVisualStyleBackColor = true;
            // 
            // btnX1
            // 
            this.btnX1.Location = new System.Drawing.Point(90, 100);
            this.btnX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnX1.Name = "btnX1";
            this.btnX1.Size = new System.Drawing.Size(75, 35);
            this.btnX1.TabIndex = 1;
            this.btnX1.Text = "X1";
            this.btnX1.UseVisualStyleBackColor = true;
            // 
            // btnY1
            // 
            this.btnY1.Location = new System.Drawing.Point(240, 100);
            this.btnY1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnY1.Name = "btnY1";
            this.btnY1.Size = new System.Drawing.Size(75, 35);
            this.btnY1.TabIndex = 0;
            this.btnY1.Text = "Y1";
            this.btnY1.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1709, 1282);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.Text = "主界面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuIOCard;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem stationsToolStripMenuItem;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ToolStripMenuItem 模板设置ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public Cognex.VisionPro.CogRecordDisplay cogRecordDisplay1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_currentIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnY2;
        private System.Windows.Forms.Button btnAngle;
        private System.Windows.Forms.Button btnX1;
        private System.Windows.Forms.Button btnY1;
        private System.Windows.Forms.CheckBox checkBox_saveRawImages;
        private System.Windows.Forms.Button btnOpenImageDir;
        private System.Windows.Forms.Button btnLastImage;
        private System.Windows.Forms.Button btnX2;
        private System.Windows.Forms.ToolStripMenuItem 相机校正ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据比对ToolStripMenuItem;
        public System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox checkBox_saveOKImages;
    }
}