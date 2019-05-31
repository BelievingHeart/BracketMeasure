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
    public partial class FormPLC : Form
    {
        public FormPLC()
        {
            InitializeComponent();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                try
                {
                   B403GlueCheck.plc.WriteWORD(uint.Parse(this.txtAddressToWrite.Text), (short)(this.numericUpDown1.Value * 1000));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("操作失败");
                }
            }
            else
            {
                try
                {
                    B403GlueCheck.plc.WriteDWORD(uint.Parse(this.txtAddressToWrite.Text), (int)(this.numericUpDown1.Value * 1000));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("操作失败");
                }
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                short value = 0;
                try
                {
                    B403GlueCheck.plc.ReadWORD(uint.Parse(this.txtAddressToRead.Text), ref value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("操作失败");
                }
                this.txtResult.Text = (value / 1000.0).ToString();
            }
            else
            {
                int value = 0;
                try
                {
                    B403GlueCheck.plc.ReadDWORD(uint.Parse(this.txtAddressToRead.Text), ref value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("操作失败");
                }
                this.txtResult.Text = (value / 1000.0).ToString();
            }
        }

        private void FormPLC_Load(object sender, EventArgs e)
        {
            this.radioButton1.Checked = true;
        }
    }
}
