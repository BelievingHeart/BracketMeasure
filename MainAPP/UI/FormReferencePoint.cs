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
    public partial class FormReferencePoint : Form
    {
        public FormReferencePoint()
        {
            InitializeComponent();
        }

        private void FormReferencePoint_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Rows.Add(3);
            string[] titles = { "X", "Y", "R" };
            for (int i = 0; i < 3; i++)
            {
                this.dataGridView1.Rows[i].HeaderCell.Value = titles[i];
            }
            for (int i = 0; i < MyGlobal.refJixin.X.Length; i++)
            {
                this.dataGridView1.Rows[0].Cells[i].Value = MyGlobal.refJixin.X[i];
                this.dataGridView1.Rows[1].Cells[i].Value = MyGlobal.refJixin.Y[i];
                this.dataGridView1.Rows[2].Cells[i].Value = MyGlobal.refJixin.R[i];
            }

            this.dataGridView2.Rows.Clear();
            this.dataGridView2.Rows.Add(3);
            //string[] titles = { "X", "Y", "R" };
            for (int i = 0; i < 3; i++)
            {
                this.dataGridView2.Rows[i].HeaderCell.Value = titles[i];
            }
            for (int i = 0; i < MyGlobal.refFanghupian.X.Length; i++)
            {
                this.dataGridView2.Rows[0].Cells[i].Value = MyGlobal.refFanghupian.X[i];
                this.dataGridView2.Rows[1].Cells[i].Value = MyGlobal.refFanghupian.Y[i];
                this.dataGridView2.Rows[2].Cells[i].Value = MyGlobal.refFanghupian.R[i];
            }

            // this.button2.Click += button1_Click;
            //this.button3.Click += button1_Click;
           // this.button4.Click += button1_Click;
           // this.button5.Click += button1_Click;
           // this.button6.Click += button1_Click;
           // this.button7.Click += button1_Click;
           // this.button8.Click += button1_Click;

           /// this.buttonF2.Click += buttonF1_Click;
           // this.buttonF3.Click += buttonF1_Click;
           // this.buttonF4.Click += buttonF1_Click;
           // this.buttonF5.Click += buttonF1_Click;
           // this.buttonF6.Click += buttonF1_Click;
           // this.buttonF7.Click += buttonF1_Click;
           // this.buttonF8.Click += buttonF1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string strIndex = btn.Name.Substring(6);
            int index = int.Parse(strIndex) - 1;

            MyGlobal.tbUp1.Run();
            if (CogToolResultConstants.Accept == MyGlobal.tbUp1.RunStatus.Result)
            {
                double x = Math.Round((double)MyGlobal.tbUp1.Outputs["X"].Value, 3);
                double y = Math.Round((double)MyGlobal.tbUp1.Outputs["Y"].Value, 3);
                double r = Math.Round((double)MyGlobal.tbUp1.Outputs["R"].Value, 3);
                this.dataGridView1.Rows[0].Cells[index].Value = x;
                this.dataGridView1.Rows[1].Cells[index].Value = y;
                this.dataGridView1.Rows[2].Cells[index].Value = r;
            }
            else
            {
                MessageBox.Show("获取点失败");
            }
        }

        private void buttonF1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string strIndex = btn.Name.Substring(7);
            int index = int.Parse(strIndex) - 1;

            //FormMain fm = (FormMain)this.Owner;
            //CogRecordDisplay[] disp = { fm.cogRecordDisplay1, fm.cogRecordDisplay2, fm.cogRecordDisplay3, fm.cogRecordDisplay4 };

            CogToolBlock tbTemp;
            if (index == 0 || index == 1 || index == 4 || index == 5)
                tbTemp = MyGlobal.tbDown1;
            else
                tbTemp = MyGlobal.tbDown2;

            tbTemp.Run();
            //disp[index].Record = tbTemp.CreateLastRunRecord().SubRecords["CogIPOneImageTool1.OutputImage"];
            if (CogToolResultConstants.Accept == tbTemp.RunStatus.Result)
            {
                double x = Math.Round((double)tbTemp.Outputs["X"].Value, 3);
                double y = Math.Round((double)tbTemp.Outputs["Y"].Value, 3);
                double r = Math.Round((double)tbTemp.Outputs["R"].Value, 3);
                this.dataGridView2.Rows[0].Cells[index].Value = x;
                this.dataGridView2.Rows[1].Cells[index].Value = y;
                this.dataGridView2.Rows[2].Cells[index].Value = r;
            }
            else
            {
                MessageBox.Show("获取点失败");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < MyGlobal.refJixin.X.Length; i++)
                {
                    MyGlobal.refJixin.X[i] = double.Parse(this.dataGridView1.Rows[0].Cells[i].Value.ToString());
                    MyGlobal.refJixin.Y[i] = double.Parse(this.dataGridView1.Rows[1].Cells[i].Value.ToString());
                    MyGlobal.refJixin.R[i] = double.Parse(this.dataGridView1.Rows[2].Cells[i].Value.ToString());
                }

                for (int i = 0; i < MyGlobal.refFanghupian.X.Length; i++)
                {
                    MyGlobal.refFanghupian.X[i] = double.Parse(this.dataGridView2.Rows[0].Cells[i].Value.ToString());
                    MyGlobal.refFanghupian.Y[i] = double.Parse(this.dataGridView2.Rows[1].Cells[i].Value.ToString());
                    MyGlobal.refFanghupian.R[i] = double.Parse(this.dataGridView2.Rows[2].Cells[i].Value.ToString());
                }

                Misc.WriteXML(MyGlobal.refJixin, "ReferenceJixin.xml");
                Misc.WriteXML(MyGlobal.refFanghupian, "ReferenceFanghupian.xml");

                MessageBox.Show("保存成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyGlobal.tbUp2.Run();
            if (CogToolResultConstants.Accept == MyGlobal.tbUp2.RunStatus.Result)
            {
                double x = Math.Round((double)MyGlobal.tbUp2.Outputs["X"].Value, 3);
                double y = Math.Round((double)MyGlobal.tbUp2.Outputs["Y"].Value, 3);
                double r = Math.Round((double)MyGlobal.tbUp2.Outputs["R"].Value, 3);
                this.dataGridView1.Rows[0].Cells[2].Value = x;
                this.dataGridView1.Rows[1].Cells[2].Value = y;
                this.dataGridView1.Rows[2].Cells[2].Value = r;
            }
            else
            {
                MessageBox.Show("获取点失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyGlobal.tbUp1.Run();
            if (CogToolResultConstants.Accept == MyGlobal.tbUp1.RunStatus.Result)
            {
                double x = Math.Round((double)MyGlobal.tbUp1.Outputs["X"].Value, 3);
                double y = Math.Round((double)MyGlobal.tbUp1.Outputs["Y"].Value, 3);
                double r = Math.Round((double)MyGlobal.tbUp1.Outputs["R"].Value, 3);
                this.dataGridView1.Rows[0].Cells[1].Value = x;
                this.dataGridView1.Rows[1].Cells[1].Value = y;
                this.dataGridView1.Rows[2].Cells[1].Value = r;
            }
            else
            {
                MessageBox.Show("获取点失败");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MyGlobal.tbUp2.Run();
            if (CogToolResultConstants.Accept == MyGlobal.tbUp2.RunStatus.Result)
            {
                double x = Math.Round((double)MyGlobal.tbUp2.Outputs["X"].Value, 3);
                double y = Math.Round((double)MyGlobal.tbUp2.Outputs["Y"].Value, 3);
                double r = Math.Round((double)MyGlobal.tbUp2.Outputs["R"].Value, 3);
                this.dataGridView1.Rows[0].Cells[3].Value = x;
                this.dataGridView1.Rows[1].Cells[3].Value = y;
                this.dataGridView1.Rows[2].Cells[3].Value = r;
            }
            else
            {
                MessageBox.Show("获取点失败");
            }
        }

        private void buttonF2_Click(object sender, EventArgs e)
        {
            CogToolBlock tbTemp = MyGlobal.tbDown1;
            tbTemp.Run();
            //disp[index].Record = tbTemp.CreateLastRunRecord().SubRecords["CogIPOneImageTool1.OutputImage"];
            if (CogToolResultConstants.Accept == tbTemp.RunStatus.Result)
            {
                double x = Math.Round((double)tbTemp.Outputs["X"].Value, 3);
                double y = Math.Round((double)tbTemp.Outputs["Y"].Value, 3);
                double r = Math.Round((double)tbTemp.Outputs["R"].Value, 3);
                this.dataGridView2.Rows[0].Cells[1].Value = x;
                this.dataGridView2.Rows[1].Cells[1].Value = y;
                this.dataGridView2.Rows[2].Cells[1].Value = r;
            }
            else
            {
                MessageBox.Show("获取点失败");
            }
        }

        private void buttonF3_Click(object sender, EventArgs e)
        {
            CogToolBlock tbTemp = MyGlobal.tbDown2;
            tbTemp.Run();
            //disp[index].Record = tbTemp.CreateLastRunRecord().SubRecords["CogIPOneImageTool1.OutputImage"];
            if (CogToolResultConstants.Accept == tbTemp.RunStatus.Result)
            {
                double x = Math.Round((double)tbTemp.Outputs["X"].Value, 3);
                double y = Math.Round((double)tbTemp.Outputs["Y"].Value, 3);
                double r = Math.Round((double)tbTemp.Outputs["R"].Value, 3);
                this.dataGridView2.Rows[0].Cells[2].Value = x;
                this.dataGridView2.Rows[1].Cells[2].Value = y;
                this.dataGridView2.Rows[2].Cells[2].Value = r;
            }
            else
            {
                MessageBox.Show("获取点失败");
            }
        }

        private void buttonF4_Click(object sender, EventArgs e)
        {
            CogToolBlock tbTemp = MyGlobal.tbDown2;
            tbTemp.Run();
            //disp[index].Record = tbTemp.CreateLastRunRecord().SubRecords["CogIPOneImageTool1.OutputImage"];
            if (CogToolResultConstants.Accept == tbTemp.RunStatus.Result)
            {
                double x = Math.Round((double)tbTemp.Outputs["X"].Value, 3);
                double y = Math.Round((double)tbTemp.Outputs["Y"].Value, 3);
                double r = Math.Round((double)tbTemp.Outputs["R"].Value, 3);
                this.dataGridView2.Rows[0].Cells[3].Value = x;
                this.dataGridView2.Rows[1].Cells[3].Value = y;
                this.dataGridView2.Rows[2].Cells[3].Value = r;
            }
            else
            {
                MessageBox.Show("获取点失败");
            }
        }

        private void buttonF5_Click(object sender, EventArgs e)
        {
            CogToolBlock tbTemp = MyGlobal.tbDown1;
            tbTemp.Run();
            //disp[index].Record = tbTemp.CreateLastRunRecord().SubRecords["CogIPOneImageTool1.OutputImage"];
            if (CogToolResultConstants.Accept == tbTemp.RunStatus.Result)
            {
                double x = Math.Round((double)tbTemp.Outputs["X"].Value, 3);
                double y = Math.Round((double)tbTemp.Outputs["Y"].Value, 3);
                double r = Math.Round((double)tbTemp.Outputs["R"].Value, 3);
                this.dataGridView2.Rows[0].Cells[4].Value = x;
                this.dataGridView2.Rows[1].Cells[4].Value = y;
                this.dataGridView2.Rows[2].Cells[4].Value = r;
            }
            else
            {
                MessageBox.Show("获取点失败");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MyGlobal.tbUp1.Run();
            if (CogToolResultConstants.Accept == MyGlobal.tbUp1.RunStatus.Result)
            {
                double x = Math.Round((double)MyGlobal.tbUp1.Outputs["X"].Value, 3);
                double y = Math.Round((double)MyGlobal.tbUp1.Outputs["Y"].Value, 3);
                double r = Math.Round((double)MyGlobal.tbUp1.Outputs["R"].Value, 3);
                this.dataGridView1.Rows[0].Cells[4].Value = x;
                this.dataGridView1.Rows[1].Cells[4].Value = y;
                this.dataGridView1.Rows[2].Cells[4].Value = r;
            }
            else
            {
                MessageBox.Show("获取点失败");
            }
        }

        private void buttonF6_Click(object sender, EventArgs e)
        {
            CogToolBlock tbTemp = MyGlobal.tbDown1;
            tbTemp.Run();
            //disp[index].Record = tbTemp.CreateLastRunRecord().SubRecords["CogIPOneImageTool1.OutputImage"];
            if (CogToolResultConstants.Accept == tbTemp.RunStatus.Result)
            {
                double x = Math.Round((double)tbTemp.Outputs["X"].Value, 3);
                double y = Math.Round((double)tbTemp.Outputs["Y"].Value, 3);
                double r = Math.Round((double)tbTemp.Outputs["R"].Value, 3);
                this.dataGridView2.Rows[0].Cells[5].Value = x;
                this.dataGridView2.Rows[1].Cells[5].Value = y;
                this.dataGridView2.Rows[2].Cells[5].Value = r;
            }
            else
            {
                MessageBox.Show("获取点失败");
            }
        }

        private void buttonF7_Click(object sender, EventArgs e)
        {
            CogToolBlock tbTemp = MyGlobal.tbDown2;
            tbTemp.Run();
            //disp[index].Record = tbTemp.CreateLastRunRecord().SubRecords["CogIPOneImageTool1.OutputImage"];
            if (CogToolResultConstants.Accept == tbTemp.RunStatus.Result)
            {
                double x = Math.Round((double)tbTemp.Outputs["X"].Value, 3);
                double y = Math.Round((double)tbTemp.Outputs["Y"].Value, 3);
                double r = Math.Round((double)tbTemp.Outputs["R"].Value, 3);
                this.dataGridView2.Rows[0].Cells[6].Value = x;
                this.dataGridView2.Rows[1].Cells[6].Value = y;
                this.dataGridView2.Rows[2].Cells[6].Value = r;
            }
            else
            {
                MessageBox.Show("获取点失败");
            }
        }

        private void buttonF8_Click(object sender, EventArgs e)
        {
            CogToolBlock tbTemp = MyGlobal.tbDown2;
            tbTemp.Run();
            //disp[index].Record = tbTemp.CreateLastRunRecord().SubRecords["CogIPOneImageTool1.OutputImage"];
            if (CogToolResultConstants.Accept == tbTemp.RunStatus.Result)
            {
                double x = Math.Round((double)tbTemp.Outputs["X"].Value, 3);
                double y = Math.Round((double)tbTemp.Outputs["Y"].Value, 3);
                double r = Math.Round((double)tbTemp.Outputs["R"].Value, 3);
                this.dataGridView2.Rows[0].Cells[7].Value = x;
                this.dataGridView2.Rows[1].Cells[7].Value = y;
                this.dataGridView2.Rows[2].Cells[7].Value = r;
            }
            else
            {
                MessageBox.Show("获取点失败");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MyGlobal.tbUp1.Run();
            if (CogToolResultConstants.Accept == MyGlobal.tbUp1.RunStatus.Result)
            {
                double x = Math.Round((double)MyGlobal.tbUp1.Outputs["X"].Value, 3);
                double y = Math.Round((double)MyGlobal.tbUp1.Outputs["Y"].Value, 3);
                double r = Math.Round((double)MyGlobal.tbUp1.Outputs["R"].Value, 3);
                this.dataGridView1.Rows[0].Cells[5].Value = x;
                this.dataGridView1.Rows[1].Cells[5].Value = y;
                this.dataGridView1.Rows[2].Cells[5].Value = r;
            }
            else
            {
                MessageBox.Show("获取点失败");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MyGlobal.tbUp2.Run();
            if (CogToolResultConstants.Accept == MyGlobal.tbUp2.RunStatus.Result)
            {
                double x = Math.Round((double)MyGlobal.tbUp2.Outputs["X"].Value, 3);
                double y = Math.Round((double)MyGlobal.tbUp2.Outputs["Y"].Value, 3);
                double r = Math.Round((double)MyGlobal.tbUp2.Outputs["R"].Value, 3);
                this.dataGridView1.Rows[0].Cells[6].Value = x;
                this.dataGridView1.Rows[1].Cells[6].Value = y;
                this.dataGridView1.Rows[2].Cells[6].Value = r;
            }
            else
            {
                MessageBox.Show("获取点失败");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MyGlobal.tbUp2.Run();
            if (CogToolResultConstants.Accept == MyGlobal.tbUp2.RunStatus.Result)
            {
                double x = Math.Round((double)MyGlobal.tbUp2.Outputs["X"].Value, 3);
                double y = Math.Round((double)MyGlobal.tbUp2.Outputs["Y"].Value, 3);
                double r = Math.Round((double)MyGlobal.tbUp2.Outputs["R"].Value, 3);
                this.dataGridView1.Rows[0].Cells[7].Value = x;
                this.dataGridView1.Rows[1].Cells[7].Value = y;
                this.dataGridView1.Rows[2].Cells[7].Value = r;
            }
            else
            {
                MessageBox.Show("获取点失败");
            }
        }

    }
}
