
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using System.Runtime.InteropServices;
using Lib_MeasurementUtilities;

namespace MainAPP.UI
{
    public partial class FormMain : Form
    {
        FormBlock _formBlock;


        // fields for summery
        private int _numSamples = 8;
        private List<Tuple<string, Color>> _legends = new List<Tuple<string, Color>>() {new Tuple<string, Color>(
            "工件4", Color.Blue), new Tuple<string, Color>("工件3", Color.DarkTurquoise), new Tuple<string, Color>("工件2", Color.Coral), new Tuple<string, Color>("工件1", Color.Black) };
        private List<double> _sigmas = new List<double>(){16.034, 16.034, 0.35, 0.35, 90.0};
        public ChartFormMarshaller _chartFormMarshaller;

        private List<Button> _chartFormButtons;
        private bool _reversed = true;


        // fields for rectifier
        private string standardFile = AppDomain.CurrentDomain.BaseDirectory + "/data/OMM_DATA.csv";
        private List<string> sampleKeys = new List<string>() { "TimeAdded", "X1", "X2", "Y1", "Y2", "Angle", "Result", "Order", "Space", "X1_pixel", "X2_pixel", "Y1_pixel", "Y2_pixel", "AngleUncalib" };
        private List<string> standardKeys = new List<string>() {"Index", "X1", "X2", "Y1", "Y2", "Angle" };
        private int numLines = 8;
        private FormRectify _formRectify = new FormRectify();

        public void ShowAndSaveMsg_Invoke(string msg)
        {
            Action fp = () =>
            {
                    if (listBox1.Items.Count > 300)
                    {
                        listBox1.Items.RemoveAt(0);
                    }
                    string formatStr =  "HH:mm:ss";
                    string longMsg = string.Format("[{0}]", DateTime.Now.ToString(formatStr)) + msg;
                    listBox1.Items.Add(longMsg);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;

                    //Misc.WriteLog(longMsg);

                };
            if (this.InvokeRequired)
            {
                this.Invoke(fp);
            }
            else
            {
                fp();
            }
        }

        // using console
//        [DllImport("kernel32.dll", SetLastError = true)]
//        [return: MarshalAs(UnmanagedType.Bool)]
//        static extern bool AllocConsole();

        public void ShowDog(bool isOK)
        {
            Action fp = () =>
                {
                        this.toolStripStatusLabel1.Text = "加密狗状态OK";
                };
            if (this.InvokeRequired)
            {
                this.Invoke(fp);
            }
            else
            {
                fp();
            }
        }



        public FormMain()
        {
            InitializeComponent();

        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            // Enable console
//            AllocConsole();
           // this.EnableControls(false);
            UVGlue.applicationIsRunning = true;
            UVGlue.resultsThatImagesSholdBeSaved = new List<string>(){UVGlue.resultNG, UVGlue.resultNoProduct};
   
            int a = IOC0640.ioc_board_init();
            if (a > 0)
            {
                ShowAndSaveMsg_Invoke("IO卡打开成功");
            }
            else
            {
                ShowAndSaveMsg_Invoke("IO卡打开失败");
            }
           
            UVGlue.threadListen = new Thread(UVGlue.Listen);
            UVGlue.threadListen.Start();
            UVGlue.threadExecute = new Thread(UVGlue.ListenPos1);
            UVGlue.threadExecute.Start();


            // store summery buttons to a list
            _chartFormButtons = new List<Button>
            {
                btnX1,
                btnX2,
                btnY1,
                btnY2,
                btnAngle
            };
            _chartFormMarshaller = new ChartFormMarshaller(this, _legends, _sigmas, _numSamples, _chartFormButtons, btnReset, _reversed);

        }


        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
            {
                UVGlue.JoinBackgroundThreads();
                UVGlue.cleanUp();
                return;
            }

            var closeDecision = MessageBox.Show("是否退出", "正在退出", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (closeDecision == DialogResult.Yes)
            {
                UVGlue.JoinBackgroundThreads();
                UVGlue.cleanUp();
            }
            else
            {
                e.Cancel = true;
            }
          
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            
            UVGlue.RunOnce();
        }
        private void 模板设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_formBlock == null) _formBlock = new FormBlock();
            _formBlock.Show(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowDog(true);
        }



        public void showCurrentIndex(int currentItemIndex)
        {
            BeginInvoke((MethodInvoker)(() => { label_currentIndex.Text = currentItemIndex.ToString();}));
        }

        private void checkBox_saveRawImages_CheckedChanged(object sender, EventArgs e)
        {
            var me = (CheckBox) sender;
            lock (UVGlue.mu_SaveAsScreenShot)
            {
                UVGlue.saveAsScreenShot = !me.Checked;
            }
        }

        private void btnLastImage_Click(object sender, EventArgs e)
        {
            lock (UVGlue.mu_recentNGImagePath)
            {
                if (File.Exists(UVGlue.recentNGIMagePath))
                {
                    Process.Start(UVGlue.recentNGIMagePath);
                }
            }
        }

        private void btnOpenImageDir_Click(object sender, EventArgs e)
        {
            string imageBaseDir = AppDomain.CurrentDomain.BaseDirectory + "Image";
            var imageDir_today = imageBaseDir + "\\" + DateTime.Now.ToString("MM-dd");
            if (!Directory.Exists(imageDir_today))
            {
                Directory.CreateDirectory(imageDir_today);
            }

            Process.Start(imageDir_today);

        }

        private void 相机校正ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(UVGlue.csvFile)) return;
            var sampleDataDict = Rectifier.parseCSV_reversed(UVGlue.csvFile, sampleKeys, numLines);
            var standardDataDict = Rectifier.parseCSV_reversed(standardFile, standardKeys, numLines);


            double multiplier = Rectifier.calcMultiplier(standardDataDict, sampleDataDict,
                new Tuple<string, string>("X1", "X1_pixel"), new Tuple<string, string>("X2", "X2_pixel"));

            Dictionary<string, List<double>> distsUnBiased = Rectifier.calDistsUnbiased(sampleDataDict, multiplier,
                new Tuple<string, string>("X1_pixel", "X1"), new Tuple<string, string>("X2_pixel", "X2")
                , new Tuple<string, string>("Y1_pixel", "Y1"), new Tuple<string, string>("Y2_pixel", "Y2")
            );

            distsUnBiased["Angle"] = sampleDataDict["AngleUncalib"];


            Dictionary<string, double> biases = Rectifier.calcAveragedDiff(standardDataDict, distsUnBiased);

            var dataSource = Rectifier.GenerateDataSource(multiplier, biases);

            _formRectify.dataGridView1.DataSource = dataSource;
            _formRectify.dataGridView1.Show(); 
            _formRectify.ShowDialog(this);
        }

      

        private void 数据比对ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(UVGlue.csvFile)) return;
            var standardDataDict = Rectifier.parseCSV_reversed(standardFile, standardKeys, numLines);
            var sampleDataDict = Rectifier.parseCSV_reversed(UVGlue.csvFile, sampleKeys, numLines);

            var diffs = Rectifier.calcDiffs(standardDataDict, sampleDataDict, "Index");
            var correlationFile = Rectifier.serializeDataDict(diffs, AppDomain.CurrentDomain.BaseDirectory + "/correlation");

            Process.Start(correlationFile);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var me = (Button)sender;
            me.Enabled = false;
        }

        private void checkBox_saveOKImages_CheckedChanged(object sender, EventArgs e)
        {
            var me = (CheckBox) sender;
            if (me.Checked)
            {
                lock (UVGlue.mu_resultsThatImagesShouldBeSaved)
                {
                    if (!UVGlue.resultsThatImagesSholdBeSaved.Contains(UVGlue.resultOK))
                    {
                        UVGlue.resultsThatImagesSholdBeSaved.Add(UVGlue.resultOK);
                    }
                }
            }
            else
            {
                lock (UVGlue.mu_resultsThatImagesShouldBeSaved)
                {
                    if (UVGlue.resultsThatImagesSholdBeSaved.Contains(UVGlue.resultOK))
                    {
                        UVGlue.resultsThatImagesSholdBeSaved.Remove(UVGlue.resultOK);
                    }
                }
            }
        }
    }//class
}//namespace