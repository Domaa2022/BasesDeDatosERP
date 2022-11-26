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
    public partial class Facturación : Form
    {
        public Facturación()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            btnActualiza.Enabled = false;
            btnInserta.Enabled = false;
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

        private void proNuevo_CheckedChanged(object sender, EventArgs e)
        {
            //proNuevo.Checked= true;
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            btnInserta.Enabled = true;
        }

        private void proExiste_CheckedChanged(object sender, EventArgs e)
        {
            //proExiste.Checked = true;
            btnInserta.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            cantidad.Enabled = false;
            nuevoPrecio.Enabled = false;
            btnActualiza.Enabled = false;
        }
    }
}
