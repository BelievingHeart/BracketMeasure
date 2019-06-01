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

namespace I2Helper
{
    public partial class Form1 : Form
    {
        private string _processName = "", _executablePath = "";
        private const string _executableProjectName = "MainAPP", _executableConfig = "Debug";

        public Form1()
        {
            InitializeComponent();

            // Hide the form
            WindowState = FormWindowState.Minimized;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            ShowInTaskbar = false;
            ControlBox = false;

            InitProcessName();
            InitExecutablePath();

        }

        private void InitExecutablePath()
        {
            string executableScriptsDir = getExecutableScriptsDir();
            _executablePath = executableScriptsDir + "/bin/" + _executableConfig + "/" + _processName + ".exe";

        }

        private void InitProcessName()
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
            string executableScriptsDir = getExecutableScriptsDir();
            return executableScriptsDir + "/" + _executableProjectName + ".csproj";
        }

        private string getExecutableScriptsDir()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "/" +
                _executableProjectName;
        }

        private void _timer_scanProcess_Tick(object sender, EventArgs e)
        {
            if (MainApplicationIsRunning()) return;

            Process.Start(_executablePath);
        }

        private bool MainApplicationIsRunning()
        {
            return Process.GetProcesses().Any(p => p.ProcessName.Contains(_processName));
        }
    }
}
