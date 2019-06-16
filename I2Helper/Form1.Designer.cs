namespace I2Helper
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._timer_scanProcess = new System.Windows.Forms.Timer(this.components);
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnRecover = new System.Windows.Forms.Button();
            this.btnOpenOMMDir = new System.Windows.Forms.Button();
            this.btnOpenLogDir = new System.Windows.Forms.Button();
            this._notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelBackupInfo = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _timer_scanProcess
            // 
            this._timer_scanProcess.Enabled = true;
            this._timer_scanProcess.Interval = 5000;
            this._timer_scanProcess.Tick += new System.EventHandler(this._timer_scanProcess_Tick);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(44, 36);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(75, 23);
            this.btnBackup.TabIndex = 0;
            this.btnBackup.Text = "备份";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRecover
            // 
            this.btnRecover.Location = new System.Drawing.Point(157, 36);
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.Size = new System.Drawing.Size(75, 23);
            this.btnRecover.TabIndex = 1;
            this.btnRecover.Text = "还原";
            this.btnRecover.UseVisualStyleBackColor = true;
            this.btnRecover.Click += new System.EventHandler(this.btnRecover_Click);
            // 
            // btnOpenOMMDir
            // 
            this.btnOpenOMMDir.Location = new System.Drawing.Point(44, 149);
            this.btnOpenOMMDir.Name = "btnOpenOMMDir";
            this.btnOpenOMMDir.Size = new System.Drawing.Size(75, 23);
            this.btnOpenOMMDir.TabIndex = 2;
            this.btnOpenOMMDir.Text = "二次元数据";
            this.btnOpenOMMDir.UseVisualStyleBackColor = true;
            this.btnOpenOMMDir.Click += new System.EventHandler(this.btnOpenOMMDir_Click);
            // 
            // btnOpenLogDir
            // 
            this.btnOpenLogDir.Location = new System.Drawing.Point(157, 149);
            this.btnOpenLogDir.Name = "btnOpenLogDir";
            this.btnOpenLogDir.Size = new System.Drawing.Size(75, 23);
            this.btnOpenLogDir.TabIndex = 3;
            this.btnOpenLogDir.Text = "实测数据";
            this.btnOpenLogDir.UseVisualStyleBackColor = true;
            this.btnOpenLogDir.Click += new System.EventHandler(this.btnOpenLogDir_Click);
            // 
            // _notifyIcon
            // 
            this._notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this._notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this._notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("_notifyIcon.Icon")));
            this._notifyIcon.Text = "I2助手";
            this._notifyIcon.Visible = true;
            this._notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // labelBackupInfo
            // 
            this.labelBackupInfo.AutoSize = true;
            this.labelBackupInfo.Location = new System.Drawing.Point(44, 82);
            this.labelBackupInfo.Name = "labelBackupInfo";
            this.labelBackupInfo.Size = new System.Drawing.Size(0, 13);
            this.labelBackupInfo.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.labelBackupInfo);
            this.Controls.Add(this.btnOpenLogDir);
            this.Controls.Add(this.btnOpenOMMDir);
            this.Controls.Add(this.btnRecover);
            this.Controls.Add(this.btnBackup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form1";
            this.Text = "I2助手";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer _timer_scanProcess;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRecover;
        private System.Windows.Forms.Button btnOpenOMMDir;
        private System.Windows.Forms.Button btnOpenLogDir;
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Label labelBackupInfo;
    }
}

