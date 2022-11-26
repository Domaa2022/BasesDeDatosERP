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
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cerrar la ventana Inventario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void gpbxPersonal_Enter(object sender, EventArgs e)
        {

        }

    // LLENAR GRID
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

        public static DataTable listarVentas()
        {
            Conexion conexionbd = new Conexion();
            try
            {

                SqlCommand comando = new SqlCommand("select Ventas.IdVenta, Productos.Modelo, Ventas.Cantidad, Ventas.Fecha, Ventas.CostoTotal from Ventas inner join Productos on Productos.IdProducto = Ventas.IdProducto ", conexionbd.abrirBD());
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

        public static DataTable listarCompras()
        {
            Conexion conexionbd = new Conexion();
            try
            {

                SqlCommand comando = new SqlCommand("select Compras.IdCompra , Productos.Modelo, Compras.Cantidad, Compras.Fecha, Compras.CostoTotal from Compras inner join Productos on Productos.IdProducto = Compras.IdProducto ", conexionbd.abrirBD());
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


        public void llenarGridCompras()
        {
            DataTable datos = listarCompras();
            if (datos == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {


                dgvCompras.DataSource = datos.DefaultView;
            }
        }
        public void llenarGridVentas()
        {
            DataTable datos = listarVentas();
            if (datos == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {


                dgvVentas.DataSource = datos.DefaultView;
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
                

                dtgInventario.DataSource = datos.DefaultView;
            }
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            llenarGrid();
            llenarGridVentas();
            llenarGridCompras();
            cantidadcompras();
            cantidadVentas();
        }

        // REGISTRAR PRODUCTOS

        public void crearProducto(int IdProducto, string marca, string modelo, string color, string año, int precio)
        {
            Conexion conectarbd = new Conexion();

            try
            {
                SqlCommand comando = new SqlCommand("insert into Productos values ("+IdProducto+",'"+marca+"','"+modelo+"','"+color+"','"+año+"',"+precio+", 1 )", conectarbd.abrirBD());
                int cantidad = comando.ExecuteNonQuery();

                if(cantidad == 1)
                {
                    MessageBox.Show("Producto Registrado");
                    eliminarRegistros();
                    llenarGrid();

                }
                else
                {
                    MessageBox.Show("No se pudo crear el producto");
                }

            }catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conectarbd.cerrar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crearProducto(Int32.Parse(txtCodigoInventario.Text), txtMarca.Text, txtModelo.Text, txtColor.Text, txtAño.Text, Int32.Parse(txtPrecio.Text));

        }


        // Consultar Producto
        bool consulta = false;
        public void consultarProducto(int IdProducto)
        {
            Conexion conectarbd = new Conexion();
            try
            {
                SqlCommand comando = new SqlCommand("select * from Productos where Productos.IdProducto = " + IdProducto + " ", conectarbd.abrirBD());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    txtCodigoInventario.Text = dr["IdProducto"].ToString();
                    txtMarca.Text = dr["Marca"].ToString();
                    txtModelo.Text = dr["Modelo"].ToString();
                    txtColor.Text = dr["Color"].ToString();
                    txtAño.Text = dr["Agno"].ToString();
                    txtPrecio.Text = dr["Precio"].ToString();
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
            }finally
            {
                conectarbd.cerrar();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            consultarProducto(Int32.Parse(txtCodigoBuscar.Text));
        }

        //ELiminar registros 
        public void eliminarRegistros()
        {
            txtCodigoInventario.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtColor.Text = "";
            txtAño.Text = "";
            txtPrecio.Text = "";
        }

        // Actualizar Producto

        public void actualizarProducto(int idProducto, float Precio)
        {
            Conexion conectarbd = new Conexion();
            try
            {
                SqlCommand comando = new SqlCommand("update Productos set Precio = "+Precio+"  from Productos where Productos.IdProducto = "+ idProducto + "  ", conectarbd.abrirBD());
                int cantidad = comando.ExecuteNonQuery();
                if(cantidad == 1)
                {
                    MessageBox.Show("Producto actualizado");
                    eliminarRegistros();
                    llenarGrid();
                    consulta = false;
                }
                else
                {
                    MessageBox.Show("No se a podido actualizar el producto");
                }

            }catch( Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conectarbd.cerrar();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(consulta == false)
            {
                MessageBox.Show("Debe consultar primero");
            }
            else
            {
                actualizarProducto(Int32.Parse(txtCodigoBuscar.Text), float.Parse(txtPrecio.Text));
            }
        }


        // Eliminar producto 
        public void eliminarProducto( int IdProducto)
        {
            Conexion conectarbd = new Conexion();
            try
            {
                SqlCommand comando = new SqlCommand("update Productos set Estado = 0 from Productos where Productos.IdProducto = " + IdProducto + " ", conectarbd.abrirBD());
                int cantidad = comando.ExecuteNonQuery();

                if ( cantidad == 1)
                {
                    MessageBox.Show("producto eliminado");
                    eliminarRegistros();
                    llenarGrid();
                    consulta = false;
                }
                else
                {
                    MessageBox.Show("El producto que quiere elimnar no esta disponible");
                }

            }catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conectarbd.cerrar();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (consulta == false)
            {
                MessageBox.Show("Debe consultar primero");
            }
            else
            {
                eliminarProducto(Int32.Parse(txtCodigoBuscar.Text));
            }
        }


        // CANTIDADES DE COMPRA Y VENTA

        public void cantidadcompras()
        {
            Conexion conectarbd = new Conexion();
            try
            {
                SqlCommand comando = new SqlCommand("SELECT count(IdCompra) as Compras FROM Compras", conectarbd.abrirBD());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    label15.Text = dr["Compras"].ToString();

                }
                else
                {
                    MessageBox.Show("No funciona");
                }


            }
            catch ( Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conectarbd.cerrar();
            }
        }
        public void cantidadVentas()
        {
            Conexion conectarbd = new Conexion();
            try
            {
                SqlCommand comando = new SqlCommand("SELECT count(IdVenta) as Ventas FROM Ventas", conectarbd.abrirBD());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    label17.Text = dr["Ventas"].ToString();

                }
                else
                {
                    MessageBox.Show("No funciona");
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


        // CONSULTA COMPRA 

        public static DataTable consultaCompra(int idCompra)
        {
            Conexion conectarbd = new Conexion();
            try
            {
                SqlCommand comando = new SqlCommand("select Compras.IdCompra , Productos.Modelo, Compras.Cantidad, Compras.Fecha, Compras.CostoTotal from Compras inner join Productos on Productos.IdProducto = Compras.IdProducto where Compras.IdCompra = "+idCompra+"", conectarbd.abrirBD());
                SqlDataReader dr = comando.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                return dt;

            }
            catch(Exception e)
            {
                return null;
            }
            finally
            {
                conectarbd.cerrar();
            }

        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            DataTable datos = consultaCompra(Int32.Parse(txtCompra.Text));
            if (datos == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {


                dgvCompras.DataSource = datos.DefaultView;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable datos = listarCompras();
            if (datos == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {


                dgvCompras.DataSource = datos.DefaultView;
            }
        }

        //CONSULTA VENTA
        public static DataTable consultaVenta(int idVenta)
        {
            Conexion conexionbd = new Conexion();
            try
            {

                SqlCommand comando = new SqlCommand("select Ventas.IdVenta, Productos.Modelo, Ventas.Cantidad, Ventas.Fecha, Ventas.CostoTotal from Ventas inner join Productos on Productos.IdProducto = Ventas.IdProducto where Ventas.IdVenta = "+idVenta+" ", conexionbd.abrirBD());
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

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable datos = consultaVenta(Int32.Parse(txtVenta.Text));
            if (datos == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {

                dgvVentas.DataSource = datos.DefaultView;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataTable datos = listarVentas();
            if (datos == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {


                dgvVentas.DataSource = datos.DefaultView;
            }
        }
    }
}
