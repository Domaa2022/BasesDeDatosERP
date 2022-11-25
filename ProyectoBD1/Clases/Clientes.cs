using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProyectoBD1.Clases
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cerrar la ventana Clientes?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void gpbxPersonal_Enter(object sender, EventArgs e)
        {

        }
        public static DataTable listarClientes()
        {
            Conexion conexionbd = new Conexion();
            try
            {

                SqlCommand comando = new SqlCommand("SELECT Clientes.IdCliente, Clientes.RTN , Personas.NumIdentidad as Identidad, Personas.Nombre1 as Nombre, Personas.Apellido1 as Apellido FROM Clientes INNER JOIN Personas ON Clientes.IdPersona = Personas.IdPersona ;", conexionbd.abrirBD());
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
        public void llenarGrid()
        {
            DataTable datos = listarClientes();
            if (datos == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {

                dgvClientes.DataSource = datos.DefaultView;
            }
        }


        public class Persona
        {
            public string identidad;
            public string nombre;
            public string nombre2;
            public string apellido;
            public string apellido2;
            public string rtn;
        


        }

        public static Persona consultar(string documento)
        {
            Conexion conexionbd = new Conexion();


            try
            {
                SqlCommand comando = new SqlCommand("SELECT Clientes.IdCliente, Clientes.RTN , Personas.NumIdentidad as Identidad, Personas.Nombre1 as Nombre, Personas.Apellido1 as Apellido FROM Clientes INNER JOIN Personas ON Clientes.IdPersona = Personas.IdPersona; " + documento + "'", conexionbd.abrirBD());
                SqlDataReader dr = comando.ExecuteReader();
                Persona pr = new Persona();
                if (dr.Read())
                {

                    pr.nombre = dr["Nombre"].ToString();
                    pr.nombre2 = dr["SegundoNombre"].ToString();
                    pr.apellido = dr["Apellido"].ToString();
                    pr.apellido2 = dr["SegundoApellido"].ToString();
                    pr.rtn = dr["RTN"].ToString();
              
                   

                    return pr;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                conexionbd.cerrar();
            }
        }

        bool consultado = false;



        
        private void crearCliente(string numPersona)
        {
            Conexion conectarbd = new Conexion();
            try
            {




                SqlCommand comando = new SqlCommand("INSERT INTO Clientes VALUES('" + numPersona + "','" + rtn.Text + "')", conectarbd.abrirBD());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    MessageBox.Show("Cliente Creado");
                    //eliminarRegistros();
                    llenarGrid();

                }
                else
                {
                    MessageBox.Show("No se pudo Crear el cliente");
                    //eliminarRegistros();
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

       /* private void crearNumeroCliente(string idCliente)
        {
            Conexion conectarbd = new Conexion();
            try
            {




                SqlCommand comando = new SqlCommand("INSERT INTO Telefonos VALUES('" + idCliente + "','" + telefono.Text + "')", conectarbd.abrirBD());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    //MessageBox.Show("Cliente Creado");
                    //eliminarRegistros();
                    llenarGrid();

                }
                else
                {
                    MessageBox.Show("No se pudo Crear el cliente");
                    //eliminarRegistros();
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
        */


        public bool crearPersona(Persona per)
        {
            Conexion conexionbd = new Conexion();
            try
            {
                SqlCommand comando = new SqlCommand("insert into Personas values ('" + per.identidad + "','" + per.nombre + "','" + per.nombre2 + "', '" + per.apellido + "', '" + per.apellido2 + "')", conexionbd.abrirBD());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                conexionbd.cerrar();
            }

        }

        private void idCliente(string identidad)
        {
            Conexion conectarbd = new Conexion();

            try
            {

                SqlCommand comando = new SqlCommand("select Personas.IdPersona from Personas where Personas.NumIdentidad = '" + identidad + "' ", conectarbd.abrirBD());
                comando.Parameters.AddWithValue("identidad", identidad);
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    string numPersona = dr["idPersona"].ToString();
                    crearCliente(numPersona);
                    
                }
                else
                {
                    MessageBox.Show("No existe el documento");
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


        private void insercionPersona()
        {
            try
            {
                Persona em = new Persona();
                em.identidad = txtDocumento1.Text;
                em.nombre = txtFirstName.Text;
                em.nombre2 = txtSecondName.Text;
                em.apellido = txtA.Text;
                em.apellido2 = txtA2.Text;
                if (crearPersona(em))
                {

                    idCliente(em.identidad);
                }
                else
                {
                    MessageBox.Show("Ya existe otro empleado con esta identidad");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Clientes_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                insercionPersona();
            }
            catch (Exception em)
            {
                MessageBox.Show(em.ToString());
            }
            finally
            {
                eliminarRegistros();
            }

        }


        private void eliminarRegistros()
        {
            txtDocumento1.Text = "";
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtA.Text = "";
            txtA2.Text = "";
            rtn.Text = "";
            txtDocumento1.Focus();
            //txtPass.Text = "";

        }
    }
}
