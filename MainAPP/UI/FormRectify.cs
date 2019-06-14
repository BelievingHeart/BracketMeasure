using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib_MeasurementUtilities;

namespace MainAPP.UI
{
    public partial class FormRectify : Form
    {
        public FormRectify()
        {
            InitializeComponent();
            FormClosing += OnFormClosing;
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            Hide();
        }

        private void btnApplyCalibration_Click(object sender, EventArgs e)
        {
            var userResult = MessageBox.Show("是否将参数应用到CCD软件?", "应用参数", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (userResult != DialogResult.Yes) return;

            if (VerificationBox.Show() != DialogResult.Yes) return;

            Rectifier.EditBlockInputParams((ObservableCollection<RectifiedParam>) dataGridView1.DataSource,
                new List<Tuple<string, string>>()
                {
                    new Tuple<string, string>("Y1", "Y1Offset"),
                    new Tuple<string, string>("Y2", "Y2Offset"),
                    new Tuple<string, string>("Angle", "AngleOffset"),
                    new Tuple<string, string>("m", "mX"),
                    new Tuple<string, string>("CircleX", "CircleXOffset"),
                    new Tuple<string, string>("CircleY", "CircleYOffset"),
                }, ref UVGlue._block);

            try
            {
                UVGlue.SaveVPP();
                MessageBox.Show("应用并保存成功");
            }
            catch
            {
                MessageBox.Show("保存失败");
            }
        }
    }
}
