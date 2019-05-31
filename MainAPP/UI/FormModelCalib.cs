using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cognex.VisionPro;

namespace MainAPP.UI
{
    public partial class FormModelCalib : Form
    {
        public FormModelCalib()
        {
            InitializeComponent();
        }

        private void FormModelCalib_Load(object sender, EventArgs e)
        {
            //this.cogToolBlockEditV21.Subject = UVGlue.tbCalib ;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    UVGlue.SaveCalibVPP();
            //    MessageBox.Show("保存成功");
            //    Clipboard.Clear();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("保存失败");
            //}
        }
    }
}
