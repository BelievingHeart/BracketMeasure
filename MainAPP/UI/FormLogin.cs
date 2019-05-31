using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainAPP.UI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtPassword.Text == "112233")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.txtPassword.Focus();
                this.txtPassword.SelectAll();
            }
        }
    }
}
