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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void login ( string sucursal, string usuario, string contraseña)
        {
            Conexion conexionbd = new Conexion();
            try
            {
                
                SqlCommand comando = new SqlCommand("select Empleados.IdSucursal, Empleados.Usuario, Empleados.ClaveAcceso , Permisos.Nombre from Empleados inner join Cargos on Empleados.IdCargo = Cargos.IdCargo inner join Permisos on Cargos.idPermiso = Permisos.IdPermiso Where Empleados.IdSucursal = @sucursal and Empleados.Usuario = @usuario and Empleados.ClaveAcceso = @pas ", conexionbd.abrirBD());
                comando.Parameters.AddWithValue("sucursal", sucursal);
                comando.Parameters.AddWithValue("usuario", usuario);
                comando.Parameters.AddWithValue("pas", contraseña);
                SqlDataAdapter sda = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if(dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][3].ToString() == "Administrador") {
                        MessageBox.Show("Bienvenido Administrador", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MenuAdmin admin1 = new MenuAdmin();
                        admin1.lbSucursalP.Text = lbSucursal.Text;
                        admin1.Show();
                    }
                    else if (dt.Rows[0][3].ToString() == "Cajero") {
                        MessageBox.Show("Bienvenido Cajero", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MenuCajero cajero1 = new MenuCajero();
                        cajero1.Show();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña Incorrecta", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conexionbd.cerrar();
            }
            
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            login(lbSucursal.Text , txtNombre.Text, txtcontraseña.Text);
            this.Close();

        }
    }
}
