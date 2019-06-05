using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainAPP.UI
{
    public partial class VerificationBox : Form
    {
        private static VerificationBox _staticBox;
        private static DialogResult _staticResult;
        private static string _password = "XW123456";
        public VerificationBox()
        {
            InitializeComponent();
        }

        public new static DialogResult Show()
        {
            _staticBox = new VerificationBox();
            _staticBox.ShowDialog();
            return _staticResult;
        }


        private void textBox_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (Char) 13) return;

            if (PasswordMatched)
            {
                _staticResult = DialogResult.Yes;
                _staticBox.Close();
            }
            else
            {
                _staticResult = DialogResult.No;
                MessageBox.Show("密码错误");
            }
        }

        public bool PasswordMatched {
            get
            {
                return textBox_password.Text.Equals(_password, StringComparison.Ordinal);
            }
             }
    }
}
