using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataBind.UI
{
    public partial class FormOffset : Form
    {
        public FormOffset()
        {
            InitializeComponent();
        }

        private void FormOffset_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Rows.Add(3);
            string[] titles = { "X", "Y", "R" };
            for (int i = 0; i < 3; i++)
            {
                this.dataGridView1.Rows[i].HeaderCell.Value = titles[i];
            }
            for (int i = 0; i < MyGlobal.offset.X.Length; i++)
            {
                this.dataGridView1.Rows[0].Cells[i].Value = MyGlobal.offset.X[i];
                this.dataGridView1.Rows[1].Cells[i].Value = MyGlobal.offset.Y[i];
                this.dataGridView1.Rows[2].Cells[i].Value = MyGlobal.offset.R[i];
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < MyGlobal.offset.X.Length; i++)
                {
                    MyGlobal.offset.X[i] = double.Parse(this.dataGridView1.Rows[0].Cells[i].Value.ToString());
                    MyGlobal.offset.Y[i] = double.Parse(this.dataGridView1.Rows[1].Cells[i].Value.ToString());
                    MyGlobal.offset.R[i] = double.Parse(this.dataGridView1.Rows[2].Cells[i].Value.ToString());
                }
                Misc.WriteXML(MyGlobal.offset, "Offset.xml");

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
    }
}
