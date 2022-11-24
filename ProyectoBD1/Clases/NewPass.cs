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
    public partial class NewPass : Form
    {
        public NewPass()
        {
            InitializeComponent();
           txtNuevaContraseña.Focus();
        }

        private void NewPass_Load(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nuevaContraseña(lbUsuarioNuevo.Text);
            
        }

        private void nuevaContraseña(string usuario)
        {
            Conexion conectarBd = new Conexion();
            try
            {
                SqlCommand comando = new SqlCommand("update Empleados set ClaveAcceso = ENCRYPTBYPASSPHRASE('password', '"+txtNuevaContraseña.Text+"') from Empleados where Empleados.Usuario = '"+usuario+"'", conectarBd.abrirBD());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    MessageBox.Show("Contraseña Actualizada");
                    this.Close();

                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la contraseña");
                    this.Close();
                }


            }catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }finally
            {
                conectarBd.cerrar();
            }
        }
    }
}
