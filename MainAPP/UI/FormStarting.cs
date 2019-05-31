
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;

namespace MainAPP.UI
{
    public partial class FormStarting : Form
    {
        public FormStarting()
        {
            InitializeComponent();
        }

        void AddItem(string info)
        {
            this.listBox1.Items.Add(info);
            this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
        }

        private void FormStarting_Load(object sender, System.EventArgs e)
        {
            this.Show();
            Thread thdbackground = new Thread(new ParameterizedThreadStart(backgroundprocess));
            thdbackground.Name = "启动窗体后台加载线程";
            thdbackground.Start(this);
        }

        void backgroundprocess(object param)
        {
            FormStarting fs = (FormStarting)param;
            Action<string> fpAddItem = AddItem;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string result;
         

            this.Invoke(fpAddItem, "加载视觉工具");
            try
            {
                UVGlue.LoadVPP();
                result = "成功";
                this.Invoke(fpAddItem, result);

                fs.DialogResult = DialogResult.OK;
                Action actClose = () => { fs.Close(); };
                fs.Invoke(actClose);
            }
            catch (Exception ex)
            {
                MessageBox.Show("视觉工具加载失败，请联系技术人员\r\n" + ex.Message);
                result = "失败";
                this.Invoke(fpAddItem, result);

                fs.DialogResult = DialogResult.Cancel ;
                Action actClose = () => { fs.Close(); };
                fs.Invoke(actClose);
            }

         
        }

    }//class
}//namespace