using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramToolkit
{
    public partial class dialogresizecanvas : Form
    {
        public int lebar;
        public int tinggi;
        public dialogresizecanvas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            lebar = Convert.ToInt32( textBox1.Text.ToString());

            tinggi = Convert.ToInt32(textBox2.Text.ToString());
            this.Close();

        }
    }
}
