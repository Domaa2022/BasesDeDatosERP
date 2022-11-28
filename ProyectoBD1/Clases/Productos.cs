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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
            txtBuscar.Focus();
        }

        public static DataTable listarProductos()
        {
            Conexion conexionbd = new Conexion();
            try
            {

                SqlCommand comando = new SqlCommand("select Productos.IdProducto, Productos.Marca, Productos.Modelo,Productos.Color,Productos.Agno,Productos.Precio,Productos.Estado , SUM(Inventarios.Existencias * TipoMovimientos.Factor) Cantidad from Productos inner join  Inventarios on Inventarios.IdProducto = Productos.IdProducto inner join TipoMovimientos on TipoMovimientos.IdTipo = Inventarios.IdTipo where Productos.Estado = 1 group by Productos.IdProducto, Productos.Marca, Productos.Modelo, Productos.Color, Productos.Agno, Productos.Precio, Productos.Estado ", conexionbd.abrirBD());
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

       

        public static DataTable listarProductosId(int id)
        {
            Conexion conexionbd = new Conexion();
            try
            {

                //int id;
                //id = Convert.ToInt32(txt.Text);
                SqlCommand comando = new SqlCommand("select Productos.IdProducto, Productos.Marca, Productos.Modelo,Productos.Color,Productos.Agno,Productos.Precio,Productos.Estado , SUM(Inventarios.Existencias * TipoMovimientos.Factor) Cantidad from Productos   inner join  Inventarios on Inventarios.IdProducto = Productos.IdProducto inner join TipoMovimientos on TipoMovimientos.IdTipo = Inventarios.IdTipo where Productos.Estado = 1 and Productos.IdProducto = " + id + " group by Productos.IdProducto, Productos.Marca, Productos.Modelo, Productos.Color, Productos.Agno, Productos.Precio, Productos.Estado", conexionbd.abrirBD());
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


        bool consulta = false;
        public void consultarProducto()
        {
            Conexion conectarbd = new Conexion();
            try
            {
                int id;
                id = Convert.ToInt32(txtBuscar.Text);
                SqlCommand comando = new SqlCommand("select Productos.IdProducto, Productos.Marca, Productos.Modelo,Productos.Color,Productos.Agno,Productos.Precio,Productos.Estado , SUM(Inventarios.Existencias * TipoMovimientos.Factor) Cantidad from Productos   inner join  Inventarios on Inventarios.IdProducto = Productos.IdProducto inner join TipoMovimientos on TipoMovimientos.IdTipo = Inventarios.IdTipo where Productos.Estado = 1 and Productos.IdProducto = " + id + " group by Productos.IdProducto, Productos.Marca, Productos.Modelo, Productos.Color, Productos.Agno, Productos.Precio, Productos.Estado ", conectarbd.abrirBD());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                   
                    consulta = true;
                }
                else
                {
                    MessageBox.Show("No se encontro el producto");
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

        public void llenarGridId()
        {
            DataTable datos2 = listarProductosId(Int32.Parse(txtBuscar.Text));


            if (datos2 == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {

                dgvProductos.DataSource = datos2.DefaultView;


            }
        }

        public static DataTable listarProductosMarca(string marca)
        {
            Conexion conexionbd = new Conexion();
            try
            {

                //int id;
                //id = Convert.ToInt32(txt.Text);
               
                SqlCommand comando = new SqlCommand("select Productos.IdProducto, Productos.Marca, Productos.Modelo,Productos.Color,Productos.Agno,Productos.Precio,Productos.Estado , SUM(Inventarios.Existencias * TipoMovimientos.Factor) Cantidad from Productos   inner join  Inventarios on Inventarios.IdProducto = Productos.IdProducto inner join TipoMovimientos on TipoMovimientos.IdTipo = Inventarios.IdTipo where Productos.Estado = 1 and Productos.Marca = '" + marca + "' group by Productos.IdProducto, Productos.Marca, Productos.Modelo, Productos.Color, Productos.Agno, Productos.Precio, Productos.Estado", conexionbd.abrirBD());
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

        public void llenarGridMarca()
        {
            DataTable datos3 = listarProductosMarca(txtBuscar.Text);


            if (datos3 == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {

                dgvProductos.DataSource = datos3.DefaultView;


            }
        }

        public static DataTable listarProductosYear(string year)
        {
            Conexion conexionbd = new Conexion();
            try
            {

                SqlCommand comando = new SqlCommand("select Productos.IdProducto, Productos.Marca, Productos.Modelo,Productos.Color,Productos.Agno,Productos.Precio,Productos.Estado , SUM(Inventarios.Existencias * TipoMovimientos.Factor) Cantidad from Productos   inner join  Inventarios on Inventarios.IdProducto = Productos.IdProducto inner join TipoMovimientos on TipoMovimientos.IdTipo = Inventarios.IdTipo where Productos.Estado = 1 and Productos.Agno = '" + year + "' group by Productos.IdProducto, Productos.Marca, Productos.Modelo, Productos.Color, Productos.Agno, Productos.Precio, Productos.Estado", conexionbd.abrirBD());
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

        public void llenarGridYear()
        {
            DataTable datos4 = listarProductosYear(txtBuscar.Text);


            if (datos4 == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {

                dgvProductos.DataSource = datos4.DefaultView;


            }
        }


        public void llenarGrid()
        {
            DataTable datos = listarProductos();
            if (datos == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {


                dgvProductos.DataSource = datos.DefaultView;
            }
        }

       


        private void label2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cerrar la ventana Productos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text=="")
            {
                MessageBox.Show("No puede dejar este campo vacio");
                txtBuscar.Focus();
            }
            else if (rbId.Checked)
            {


                llenarGridId();
                txtBuscar.Text = "";
                txtBuscar.Focus();


            }
            else if (rbPrecio.Checked)
            {
                llenarGridYear();
                txtBuscar.Text = "";
                txtBuscar.Focus();
            }
            else if (rbMarca.Checked)
            {
                llenarGridMarca();
                txtBuscar.Text = "";
                txtBuscar.Focus();
            }
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            llenarGrid();
            txtBuscar.Focus();
        }
    }
}
