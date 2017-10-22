using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dokter
{
    public partial class LoginForm : Form
    {
        string username;
        string password;
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginBT_Click(object sender, EventArgs e)
        {
            if (UserTB.Text == "doctor" && PasswordTB.Text == "password")
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    DataForm form1 = new DataForm();
                    form1.Show();
                    this.Close();
                }
                else
                {
                    HistoryForm form4 = new HistoryForm();
                    form4.Show();
                    this.Close();
                }
            } else
            {
                MessageBox.Show("verkeerde username of wachtwoord ingevoerd");
            }
        }
    }
}
