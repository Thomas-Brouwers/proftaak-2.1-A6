using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clientside
{
    public partial class Login : Form
    {

        static void Main(string[] args)
        {
            Application.Run(new Login());
        }

        public Login()
        {
            InitializeComponent();
        }

        private void LoginBT_Click(object sender, EventArgs e)
        {
            if (UserTB.Text == "Lil" && PasswordTB.Text == "Dicky") {
                new Client();

            }
        }
    }
}
