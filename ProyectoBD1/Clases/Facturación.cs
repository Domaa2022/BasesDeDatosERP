using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBD1.Clases
{
    public partial class Facturación : Form
    {
        public Facturación()
        {
            InitializeComponent();
            //groupBox1.Enabled = false;
            
            btnActualiza.Enabled = false;
            cbProveedor.Enabled = false;
            cantidad.Enabled = false;
            precioN.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cerrar la ventana Facturación?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
          
        }


        private void button3_Click_1(object sender, EventArgs e)
        {

            btnActualiza.Enabled = true;
            cbProveedor.Enabled = true;
            cantidad.Enabled = true;
            precioN.Enabled = true;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
