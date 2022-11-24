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
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cerrar la ventana Proveedores?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }


        // LLENAR PROVEEDORES

        public static DataTable listarProveedores()
        {
            Conexion conexionbd = new Conexion();
            try
            {

                SqlCommand comando = new SqlCommand("select * from Proveedores", conexionbd.abrirBD());
                SqlDataReader dr = comando.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                return dt;

            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                conexionbd.cerrar();

            }


        }

        //LLENAR GRID PROVEEDORES

        public void llenarGrid()
        {
            DataTable datos = listarProveedores();
            if (datos == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {

                dgvProveedores.DataSource = datos.DefaultView;
            }
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        // CREACION DE PROVEEDORES
        private void crearProveedor(int codigo, string nombreProveedor, string numero, string dirrecion)
        {
            Conexion conectarbd = new Conexion();
            try {

                SqlCommand comando = new SqlCommand("INSERT INTO Proveedores VALUES(" + codigo + ",'" + nombreProveedor + "','" + numero + "', '" + dirrecion + "', 1)", conectarbd.abrirBD());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    MessageBox.Show("Proveedor Creado");
                    eliminarRegistros();
                    llenarGrid();

                }
                else
                {
                    MessageBox.Show("No se pudo Crear el Proveedor");
                    eliminarRegistros();
                }



            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conectarbd.cerrar();
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            crearProveedor(Int32.Parse(txtCodigo.Text), txtNombreProveedor.Text, txtTelefonoProveedor.Text, txtDireccionProveedor.Text);
        }

        // ELIMINAR PROVEEDORES
        private void eliminarProveedores(int numero)
        {
            Conexion conectarbd = new Conexion();
            try
            {
                SqlCommand comando = new SqlCommand("update Proveedores set Estado = 0 from Proveedores where Proveedores.IdProveedor =" + numero + "", conectarbd.abrirBD());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    MessageBox.Show("Proveedor Elimando");
                    eliminarRegistros();
                    llenarGrid();

                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Proveedor");
                    eliminarRegistros();
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conectarbd.cerrar();
            }
        }


        //CONSULTAR PROVEEDOR 
        bool consultado = false;
        private void consultarProveedor(int numero)
        {
            Conexion conectarbd = new Conexion();
            try
            {
                SqlCommand comando = new SqlCommand("select * from Proveedores where Proveedores.IdProveedor ="+ numero +" ", conectarbd.abrirBD());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {

                    txtCodigo.Text = dr["IdProveedor"].ToString();
                    txtNombreProveedor.Text = dr["Nombre"].ToString();
                    txtTelefonoProveedor.Text = dr["Telefono"].ToString();
                    txtDireccionProveedor.Text = dr["Direccion"].ToString();
                    consultado = true;                 
                }
                else
                {
                    MessageBox.Show("Proveedor no encontrado");
                    consultado = false;
                }

            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conectarbd.cerrar();
            }
        }
        

        // EDITAR PROVEEDOR 

        private void  updateProveedor(int numero, string telefono , string direccion)
        {
            Conexion conectarbd = new Conexion();
            try
            {
                SqlCommand comando = new SqlCommand("update Proveedores set  Telefono = '"+telefono+"' , Direccion = '"+direccion+"'  from Proveedores where Proveedores.IdProveedor ="+numero+"", conectarbd.abrirBD());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    MessageBox.Show("Proveedor actualizado correctamente");
                    llenarGrid();
                    eliminarRegistros();
                    consultado = false;
                }
                else
                {
                    MessageBox.Show("No se encontro el empleado");
                    eliminarRegistros();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conectarbd.cerrar();
            }
        }

        //ELIMINAR REGISTROS TIPEADOS POR EL USUARIO 
        private void eliminarRegistros()
        {
            txtCodigo.Text = "";
            txtNombreProveedor.Text = "";
            txtDireccionProveedor.Text = "";
            txtTelefonoProveedor.Text = "";
        }

        //ELIMINAR PROVEEDORES CLICK
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarProveedores(Int32.Parse(txtCodigo.Text));
        }


        //ConsultarProveedor CLick
        private void button2_Click(object sender, EventArgs e)
        {
            consultarProveedor(Int32.Parse(txtCodigo.Text));
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if( consultado == false)
            {
                MessageBox.Show("Debe consultar primero");
            }
            else
            {
                updateProveedor(Int32.Parse(txtCodigo.Text), txtTelefonoProveedor.Text, txtDireccionProveedor.Text);
            }
        }
    }
}
