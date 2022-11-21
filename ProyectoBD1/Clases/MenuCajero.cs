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
    public partial class MenuCajero : Form
    {
        public MenuCajero()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cerrar Sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        bool ValidaVentana(string nombreForm)
        {
            foreach (var form_hijo in this.MdiChildren)
            {
                if (form_hijo.Text == nombreForm)
                {
                    form_hijo.BringToFront();
                    return true;
                }
                return false;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ventas
            if (ValidaVentana("Ventas") == false)
            {
                Ventas v1 = new Ventas();
                v1.MdiParent = this;
                v1.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //productos
            if (ValidaVentana("Productos") == false)
            {
                Productos p1 = new Productos();
                p1.MdiParent = this;
                p1.Show();
            }

        }
    }
}
