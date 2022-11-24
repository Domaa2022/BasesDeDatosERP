using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBD1.Clases
{
    public partial class NewPass : Form
    {
        public NewPass()
        {
            InitializeComponent();
           textBox1.Focus();
        }

        private void NewPass_Load(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
