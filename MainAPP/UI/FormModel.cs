using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;

namespace MainAPP.UI
{
    public partial class FormModel : Form
    {
        public FormModel()
        {
            InitializeComponent();
        }

        private void FormModel_Load(object sender, EventArgs e)
        {
            this.cogToolBlockEditV21.Subject = UVGlue.tbCheck;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UVGlue.SaveVPP();
                MessageBox.Show("保存成功");
                Clipboard.Clear();
            }
            catch
            {
                MessageBox.Show("保存失败");
            }
        }

        private void FormModel_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Hide();
            //e.Cancel = true;
        }
    }
}
