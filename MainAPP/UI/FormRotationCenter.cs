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

namespace DataBind.UI
{
    public partial class FormRotationCenter : Form
    {
        CogToolBlock tempBlock;
        RotationCenter rotationCenter;
        string fileName;

        public FormRotationCenter()
        {
            InitializeComponent();
        }
        public void SetTitle(string title)
        {
            this.Text = title;
            switch (this.Text)
            {
                case "轴1-旋转中心":
                    tempBlock = MyGlobal.tbDown1;
                    rotationCenter = MyGlobal.rotationCenterDown1;
                    fileName = "rotationCenterDown1.xml";
                    break;
                case "轴2-旋转中心":
                    tempBlock = MyGlobal.tbDown1;
                    rotationCenter = MyGlobal.rotationCenterDown2;
                    fileName = "rotationCenterDown2.xml";
                    break;
                case "轴3-旋转中心":
                    tempBlock = MyGlobal.tbDown2;
                    rotationCenter = MyGlobal.rotationCenterDown3;
                    fileName = "rotationCenterDown3.xml";
                    break;
                case "轴4-旋转中心":
                    tempBlock = MyGlobal.tbDown2;
                    rotationCenter = MyGlobal.rotationCenterDown4;
                    fileName = "rotationCenterDown4.xml";
                    break;
                default:
                    return;
            }
        }

        private void FormRotationCenter_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Add(3);
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                this.dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }

            this.btnGetRef2.Click += btnGetRef1_Click;
            this.btnGetRef3.Click += btnGetRef1_Click;

            this.txtResultX.Text = rotationCenter.X.ToString();
            this.txtResultY.Text = rotationCenter.Y.ToString();
        }

        private void btnGetRef1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string strIndex = btn.Name.Substring(9);
            int index = int.Parse(strIndex);

            tempBlock.Run();
            this.cogRecordDisplay1.Record = tempBlock.CreateLastRunRecord().SubRecords["CogIPOneImageTool1.OutputImage"];
            if (CogToolResultConstants.Accept == tempBlock.RunStatus.Result)
            {
                double x = Math.Round((double)tempBlock.Outputs["X"].Value, 3);
                double y = Math.Round((double)tempBlock.Outputs["Y"].Value, 3);
                this.dataGridView1.Rows[index - 1].Cells[0].Value = x;
                this.dataGridView1.Rows[index - 1].Cells[1].Value = y;
            }
            else
            {
                MessageBox.Show("获取点失败");
            }
        }

        double circleX;
        double circleY;
        private void btnFindCenter_Click(object sender, EventArgs e)
        {
            try
            {
                CogFitCircleTool fitCircle = new CogFitCircleTool();
                fitCircle.InputImage = this.cogRecordDisplay1.Image;
                fitCircle.RunParams.NumPoints = 0;
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    double x = double.Parse(this.dataGridView1.Rows[i].Cells[0].Value.ToString());
                    double y = double.Parse(this.dataGridView1.Rows[i].Cells[1].Value.ToString());
                    fitCircle.RunParams.AddPoint(x, y);
                }
                fitCircle.Run();
                circleX = Math.Round(fitCircle.Result.GetCircle().CenterX, 3);
                circleY = Math.Round(fitCircle.Result.GetCircle().CenterY, 3);
                double circleRadius = Math.Round(fitCircle.Result.GetCircle().Radius, 3);
                fitCircle.Result.GetCircle().Color = CogColorConstants.Green;
                CogPointMarker ptr = new CogPointMarker();
                ptr.Color = CogColorConstants.Green;
                ptr.SetCenterRotationSize(circleX, circleY, 0, 60);
                this.cogRecordDisplay1.StaticGraphics.Add(fitCircle.Result.GetCircle(), "");
                this.cogRecordDisplay1.StaticGraphics.Add(ptr, "");

                txtResultX.Text = circleX.ToString("f3");
                txtResultY.Text = circleY.ToString("f3");
                txtResultRadius.Text = circleRadius.ToString("f3");
            }
            catch (Exception ex)
            {
                MessageBox.Show("计算旋转中心失败");
                txtResultX.Text = string.Empty;
                txtResultY.Text = string.Empty;
                txtResultRadius.Text = string.Empty;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                double x = double.Parse(this.dataGridView1.Rows[2].Cells[0].Value.ToString());
                double y = double.Parse(this.dataGridView1.Rows[2].Cells[1].Value.ToString());
                double Xafter = 0, Yafter = 0;
                Misc.GetRoratedCoordinator(circleX, circleY, (double)this.numericUpDown1.Value, x, y, ref Xafter, ref Yafter);
                //this.txtRealX.Text = x.ToString();
                //this.txtRealY.Text = y.ToString();
                this.txtAffineX.Text = Xafter.ToString();
                this.txtAffineY.Text = Yafter.ToString();
                tempBlock.Run();
                if (CogToolResultConstants.Accept == tempBlock.RunStatus.Result)
                {
                    x = Math.Round((double)tempBlock.Outputs["X"].Value, 3);
                    y = Math.Round((double)tempBlock.Outputs["Y"].Value, 3);
                    double r = Math.Round((double)tempBlock.Outputs["R"].Value, 3);
                    this.txtRealX.Text = x.ToString();
                    this.txtRealY.Text = y.ToString();
                    //this.txtAffineX.Text = Xafter.ToString();
                    //this.txtAffineY.Text = Yafter.ToString();
                }
                else
                {
                    MessageBox.Show("测试失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("测试失败");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.rotationCenter.X = double.Parse(this.txtResultX.Text);
                this.rotationCenter.Y = double.Parse(this.txtResultY.Text);
                Misc.WriteXML(this.rotationCenter, fileName);
                MessageBox.Show("保存成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败");
            }
        }

    }
}
