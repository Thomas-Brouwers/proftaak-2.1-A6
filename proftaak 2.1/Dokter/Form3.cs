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
    public partial class Form3 : Form
    {
        List<string> textboxHistory = new List<string>();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateText(textBox1.Text.ToString());
        }

        private void UpdateText(string text)
        {
            textboxHistory.Add(text);
            textBox2.Text = string.Join("\r\n", textboxHistory);
        }
        
    }
}
