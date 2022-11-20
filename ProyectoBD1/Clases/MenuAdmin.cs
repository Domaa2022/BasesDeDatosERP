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
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
           /* Personal p1 = new Personal();
            p1.MdiParent = this;
            p1.Show();*/
        }

      

        private void btnPersonal_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            Personal p1 = new Personal();
            p1.MdiParent = this;
            p1.Show();
           
=======
            // for (int i = 1; i <= 6; i++)
            // Personal
            if (ValidaVentana("Personal") == false)
            {
                Personal p1 = new Personal();
                p1.MdiParent = this;
                p1.Show();
            }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.ActiveMdiChild.Close();
           // for ( int i=1; i<=6; i++)
            //{
            if(ValidaVentana("Inventario") == false)
            {
                Inventario i1 = new Inventario();
                i1.MdiParent = this;
                i1.Show();

            }


            //i1.Show();
            /*if (i==6)
            {
                i1.Show();
            }*/
            //}


            //this.ActiveMdiChild.Close();

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

        private void button6_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Está seguro que desea cerrar Sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidaVentana("Clientes") == false)
            {
                Clientes c1 = new Clientes();
                c1.MdiParent = this;
                c1.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ValidaVentana("Facturación") == false)
            {
                Facturación f1 = new Facturación();
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ValidaVentana("Proveedores") == false)
            {
                Proveedores p1 = new Proveedores();
                p1.MdiParent = this;
                p1.Show();
            }
>>>>>>> developer
        }
    }
}
