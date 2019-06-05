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
    public partial class FormBlock : Form
    {
        public FormBlock()
        {
            InitializeComponent();
        }

        private void FormModel_Load(object sender, EventArgs e)
        {
            this.cogToolBlockEditV21.Subject = UVGlue._block;
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
            if (e.CloseReason != CloseReason.UserClosing) return;

            var userResult = MessageBox.Show("是否保存修改", "关闭模板窗口", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (userResult == DialogResult.Yes)
            {
                try
                {
                    UVGlue.SaveVPP();
                    MessageBox.Show("保存成功");
                }
                catch
                {
                    MessageBox.Show("保存失败");
                }
            }

            e.Cancel = true;
            Hide();
        }
    }
}
