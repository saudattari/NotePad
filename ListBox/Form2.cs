using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListBox
{
    public partial class Form2 : Form
    {
        public string s;
        public Form2()
        {
            InitializeComponent();
        }
        public string Display2()
        {
                return s;
        }
        private void button1_Click(object sender, EventArgs e)
        {
             s = textBox1.Text.ToString();
            this.Hide();
        }
    }
}
