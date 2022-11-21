using ProyectoBD1.Clases;
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

namespace ProyectoBD1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion conexionbd = new Conexion();
            SqlCommand comando = new SqlCommand("select IdSucursal from Sucursales", conexionbd.abrirBD());
            SqlDataReader sucursal = comando.ExecuteReader();
            while (sucursal.Read())
            {
                cbxSucursales.Items.Add(sucursal["IdSucursal"].ToString());
            }
          
            conexionbd.cerrar();

            
           

        }

        private void cbxSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("El estatus del combo es " + cbxSucursales.Text);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
           // this.Hide();
            Form2 FormularioInicioSesion = new Form2();
            FormularioInicioSesion.lbSucursal.Text = cbxSucursales.Text;
            FormularioInicioSesion.Show();
            
           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea salir de la aplicación?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
