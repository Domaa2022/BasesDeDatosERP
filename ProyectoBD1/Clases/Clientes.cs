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
            telefono.Enabled = false;
            correo.Enabled = false;
           // insertar.Enabled = false;
            //eliminar.Enabled = false;
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
        //CONSULTA MOSTRAR TELEFONOS Y CORREOS

        public static DataTable listarContacto()
        {
            Conexion conexionbd = new Conexion();
            try
            {

                SqlCommand comando = new SqlCommand("SELECT  * FROM Telefonos;", conexionbd.abrirBD());
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

        public static DataTable listarCorreos()
        {
            Conexion conexionbd = new Conexion();
            try
            {

                SqlCommand comando = new SqlCommand("SELECT  * FROM ElectronicoCorreos;", conexionbd.abrirBD());
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
        /// <summary>
        //LLENAR DATA GRID DE TELEFONOS Y CORREO
        /// </summary>
        public void llenarGridContacto()
        {
            DataTable datos = listarCorreos();
            DataTable datos2 = listarContacto();
     
            if (datos == null || datos2 == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {

                dgvcorreo.DataSource = datos.DefaultView;
                dtgtelefono.DataSource = datos2.DefaultView;
        
            }
        }

        public void llenarGridTel()
        {
           
            DataTable datos3 = buscarCliente(textBox1.Text);
            if (datos3 == null )
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {

                dtgtelefono.DataSource = datos3.DefaultView;
            }
        }

        public void llenarGridCorreo()
        {

            DataTable datos3 = buscarCliente2(textBox1.Text);
            if (datos3 == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {

                dgvcorreo.DataSource = datos3.DefaultView;
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
                SqlCommand comando = new SqlCommand("SELECT Clientes.IdCliente, Clientes.RTN , Personas.NumIdentidad as Identidad,  Personas.Nombre1 as Nombre,Personas.Nombre2 as SegundoNombre,Personas.Apellido1 as Apellido,Personas.Apellido2 as SegundoApellido FROM Clientes INNER JOIN Personas ON Clientes.IdPersona = Personas.IdPersona where Personas.NumIdentidad= '" + documento + "' ", conexionbd.abrirBD());
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

        public  static DataTable buscarCliente(string id)
        {
            Conexion conexionbd = new Conexion();
            try
            {

                SqlCommand comando = new SqlCommand("Select * from Telefonos where IdCliente = '" + id + "';", conexionbd.abrirBD());
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

        public static DataTable buscarCliente2(string id)
        {
            Conexion conexionbd = new Conexion();
            try
            {

                SqlCommand comando = new SqlCommand("Select * from ElectronicoCorreos where IdCliente = '" + id + "';", conexionbd.abrirBD());
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
        private void InsertarTel(string id, string telefono)
        {
            Conexion conectarbd = new Conexion();
            try
            {

                SqlCommand comando = new SqlCommand("INSERT INTO Telefonos VALUES(" + id + ",'" + telefono + "')", conectarbd.abrirBD());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    MessageBox.Show("Telefono Agregado");
                    //eliminarRegistros();
                    llenarGrid();

                }
                else
                {
                    MessageBox.Show("No se pudo Crear el telefono");
                   // eliminarRegistros();
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


        private void InsertarCorreo(string id, string correo)
        {
            Conexion conectarbd = new Conexion();
            try
            {

                SqlCommand comando = new SqlCommand("INSERT INTO ElectronicoCorreos VALUES(" + id + ",'" + correo + "')", conectarbd.abrirBD());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    MessageBox.Show("Correo Agregado");
                    //eliminarRegistros();
                    llenarGrid();

                }
                else
                {
                    MessageBox.Show("No se pudo Crear el correo");
                    // eliminarRegistros();
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

        private void eliminarTelefono(string numero)
        {
            Conexion conectarbd = new Conexion();
            try
            {
                SqlCommand comando = new SqlCommand("Delete  from Telefonos where NumeroTelefono = '" + numero + "';", conectarbd.abrirBD());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    MessageBox.Show("Numero Elimando");
                    eliminarRegistros();
                    llenarGrid();

                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Numero");
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

        private void eliminarCorreo(string correo)
        {
            Conexion conectarbd = new Conexion();
            try
            {
                SqlCommand comando = new SqlCommand("Delete  from ElectronicoCorreos where Correo = '" + correo + "';", conectarbd.abrirBD());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    MessageBox.Show("Correo Elimando");
                    eliminarRegistros();
                    llenarGrid();

                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el correo");
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


        private void eliminarCliente(string correo)
        {
            Conexion conectarbd = new Conexion();
            try
            {
                SqlCommand comando = new SqlCommand("Delete  from Clientes where Correo = '" + correo + "';", conectarbd.abrirBD());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    MessageBox.Show("Correo Elimando");
                    eliminarRegistros();
                    llenarGrid();

                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el correo");
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

        private void actualizarCliente(string id,string rtn)
        {
            Conexion conectarbd = new Conexion();

            try
            {
                
                SqlCommand comando = new SqlCommand("update Clientes set RTN ='" + rtn + "' from Clientes inner join Personas on Clientes.IdPersona = Personas.IdPersona where Personas.NumIdentidad = '" + id + "'", conectarbd.abrirBD());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    MessageBox.Show("Cliente actualizado correctamente");
                    llenarGrid();
                    eliminarRegistros();
                    consultado = false;
                }
                else
                {
                    MessageBox.Show("No se encontro el cliente");
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
        private void Clientes_Load(object sender, EventArgs e)
        {
            llenarGrid();
            llenarGridContacto();
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
            

        }

      

        private void button2_Click(object sender, EventArgs e)
        {
             if (correo.Text == "" && telefono.Text == "")
            {
                MessageBox.Show("Debe llenar al menos un  campo");
                
            }
            else if (correo.Text != "" && telefono.Text!= "")
            {
      
                InsertarCorreo(textBox1.Text, correo.Text);
                InsertarTel(textBox1.Text, telefono.Text);
                llenarGridContacto();
                
            }else if(correo.Text == "")
            {
                InsertarTel(textBox1.Text, telefono.Text);
                llenarGridContacto();
                
            }else if (telefono.Text =="")
            {
                InsertarCorreo(textBox1.Text, correo.Text);
                llenarGridContacto();
                
            }
            textBox1.Text = "";
            telefono.Text = "";
            correo.Text = "";
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        

        

            if(textBox1.Text != "")
            {
                llenarGridTel();
                llenarGridCorreo();
                telefono.Enabled = true;
                correo.Enabled = true;
                
            }else
            {
                MessageBox.Show("No puede dejar este campo vacio");
                textBox1.Focus();
            }


          


        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            if (correo.Text == "" && telefono.Text == "")
            {
                MessageBox.Show("Debe llenar al menos un  campo");
              
            }
            else if (correo.Text != "" && telefono.Text != "")
            {

                eliminarCorreo( correo.Text);
                eliminarTelefono( telefono.Text);
                llenarGridContacto();
               
            }
            else if (correo.Text == "")
            {
                eliminarTelefono( telefono.Text);
                llenarGridContacto();

            }
            else if (telefono.Text == "")
            {
                eliminarCorreo(correo.Text);
                llenarGridContacto();
               
            }
            textBox1.Text = "";
            telefono.Text = "";
            correo.Text = "";
            textBox1.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizarCliente(txtDocumento1.Text, rtn.Text);
        }

        private void btnconsultar_Click(object sender, EventArgs e)
        {
            Persona pr = consultar(txtDocumento1.Text);
            if (pr == null)
            {
                MessageBox.Show("No existe el cliente con documento: " + txtDocumento1.Text);
                consultado = false;
            }
            else
            {
                //txtDocumento1.Text = pr.identidad;
                txtFirstName.Text = pr.nombre;
                txtSecondName.Text = pr.nombre2;
                txtA.Text = pr.apellido;
                txtA2.Text = pr.apellido2;
                rtn.Text = pr.rtn;

                consultado = true;

            }
        }
    }
}
