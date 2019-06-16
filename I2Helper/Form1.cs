using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MainAPP.UI;

namespace I2Helper
{
    public partial class Form1 : Form
    {
        private string _processName = "", _executablePath = "", _vppDir = "", _OMMDir = " ", _LogDir = "";
        private string _backupPath;
        private string _vppPath;
        private const string _executableProjectName = "MainAPP", _executableConfig = "Debug";

        public Form1()
        {
            InitializeComponent();

            InitProcessName();
            InitPaths();

            FormClosing += OnFormClosing;
            _notifyIcon.DoubleClick += NotifyIconOnDoubleClick;
            Move += Form1_SizeChanged;
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;

            e.Cancel = true;
            WindowState = FormWindowState.Minimized;
        }


        private void NotifyIconOnDoubleClick(object sender, EventArgs e)
        {
            Show();
        }

        private void InitPaths()
        {
            string executableScriptsDir = Path.Combine(GetSLNDir(), _executableProjectName);
            _vppDir = Path.Combine(Directory.GetParent(GetSLNDir()).FullName, "VPP");
            var buildDir = executableScriptsDir + "/bin/" + _executableConfig;
            _executablePath = buildDir + "/" + _processName + ".exe";
            _LogDir = Path.Combine(buildDir, "Log");
            _OMMDir = Path.Combine(buildDir, "data");
            _backupPath = Path.Combine(_vppDir, "Backup.vpp");
            _vppPath = Path.Combine(_vppDir, "Template.vpp");
        }

        private void
            InitProcessName()
        {
            var doc = new XmlDocument();
            string _XMLFile = GetExecutableProjectConfigFilePath();

            doc.Load(_XMLFile);

            foreach (XmlNode element in doc.DocumentElement)
            {
                if (element.Name == "PropertyGroup" && element.Attributes != null && element.Attributes.Count == 0)
                {
                    _processName = element["AssemblyName"].InnerText;
                }
            }
        }

        private string GetExecutableProjectConfigFilePath()
        {
            string executableScriptsDir = Path.Combine(GetSLNDir(), _executableProjectName);
            return executableScriptsDir + "/" + _executableProjectName + ".csproj";
        }

        private string
            GetSLNDir()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        }

        private void _timer_scanProcess_Tick(object sender, EventArgs e)
        {

            labelBackupInfo.Text = BackupInfo;

            if (MainApplicationIsRunning()) return;

            Process.Start(_executablePath);
        }

        public string BackupInfo
        {
            get
            {
                if (!File.Exists(_backupPath))
                {
                    labelBackupInfo.ForeColor = Color.Red;
                    return "暂无备份, 请及时备份";
                }

                var backupDate = File.GetLastWriteTime(_backupPath);
                labelBackupInfo.ForeColor = (DateTime.Now - backupDate).Days > 3 ? Color.Yellow : Color.Green;

                return "上次备份时间: " + backupDate.ToLocalTime();
            }
        }

        private bool MainApplicationIsRunning()
        {
            return Process.GetProcesses().Any(p => p.ProcessName.Equals(_processName));
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            var cursorNotInBar = Screen.GetWorkingArea(this).Contains(Cursor.Position);

            if (WindowState == FormWindowState.Minimized && cursorNotInBar)
            {
                ShowInTaskbar = false;
                _notifyIcon.Visible = true;
                Hide();

                _notifyIcon.ShowBalloonTip(1000, "程序已托管", "双击可再次展开", ToolTipIcon.Info);
            }
        }

        private void Backup(string src, string dst)
        {
            if (System.IO.File.Exists(dst)) System.IO.File.Delete(dst);
            System.IO.File.Copy(src, dst);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (VerificationBox.Show() != DialogResult.Yes) return;
            try
            {
                Backup(_vppPath, _backupPath);
                MessageBox.Show("操作成功");
            }
            catch (Exception exception)
            {
                MessageBox.Show("操作失败");
            }
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            if (VerificationBox.Show() != DialogResult.Yes) return;
            try
            {
                Backup(_backupPath, _vppPath);
                MessageBox.Show("操作成功");
            }
            catch (Exception exception)
            {
                MessageBox.Show("操作失败");
            }
        }

        private void btnOpenOMMDir_Click(object sender, EventArgs e)
        {
            if (VerificationBox.Show() != DialogResult.Yes) return;

            Process.Start(_OMMDir);
        }

        private void btnOpenLogDir_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(_LogDir)) Directory.CreateDirectory(_LogDir);
            Process.Start(_LogDir);

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var processes = Process.GetProcessesByName(_processName);
            foreach (var process in processes)
            {
                if (process.ProcessName == _processName)
                {
                    process.Kill();
                }
            }
            Application.Exit();
        }

        private void _notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}