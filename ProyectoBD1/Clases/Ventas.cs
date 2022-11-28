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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cerrar la ventana Ventas?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public void llenarNumeroFactura()
        {
            Conexion conectarbd = new Conexion();
            SqlCommand comando = new SqlCommand("select FacturaActual from Empresas inner join RangoFacturas on Empresas.RangoFactura = RangoFacturas.IdRango", conectarbd.abrirBD());
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.Read())
            {
                int contador = Int32.Parse(dr["FacturaActual"].ToString());
                contador = contador + 1;
                NumeroFact.Text = contador.ToString();
                conectarbd.cerrar();

            }
            else
            {
                MessageBox.Show("Problemas");
            }
        }

        public void llenarPuntosDeVenta()
        {

            Conexion conexionbd = new Conexion();
            SqlCommand comando = new SqlCommand("select * from PuntosDeVentas where IdSucursal =" + label14su.Text + "", conexionbd.abrirBD());
            SqlDataReader sucursal = comando.ExecuteReader();
            while (sucursal.Read())
            {
                cbPuntoVenta.Items.Add(sucursal["NumeroPos"].ToString());
                cbPuntoVenta.SelectedIndex = 0;

            }

            conexionbd.cerrar();
        }

        public void llenarDocumentoTipo()
        {
            Conexion conexionbd = new Conexion();
            SqlCommand comando = new SqlCommand("select * from DocumentoTipos", conexionbd.abrirBD());
            SqlDataReader sucursal = comando.ExecuteReader();
            while (sucursal.Read())
            {
                cbTipoDoc.Items.Add(sucursal["Nombre"].ToString());
                cbTipoDoc.SelectedIndex = 0;

            }

            conexionbd.cerrar();
        }

        public void llenarMetodoDePago()
        {
            Conexion conexionbd = new Conexion();
            SqlCommand comando = new SqlCommand("select * from PagoMetodos", conexionbd.abrirBD());
            SqlDataReader sucursal = comando.ExecuteReader();
            while (sucursal.Read())
            {
                cbMetodoPago.Items.Add(sucursal["Nombre"].ToString());
                cbMetodoPago.SelectedIndex = 0;

            }

            conexionbd.cerrar();

        }

        public static DataTable consultaVenta(int idVenta)
        {
            Conexion conexionbd = new Conexion();
            try
            {

                SqlCommand comando = new SqlCommand("select Ventas.IdVenta, Productos.Modelo, Ventas.Cantidad, Ventas.Fecha from Ventas inner join Productos on Productos.IdProducto = Ventas.IdProducto where Ventas.IdVenta =" + idVenta + " ", conexionbd.abrirBD());
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

                SqlCommand comando = new SqlCommand("select Ventas.IdVenta, Productos.Modelo, Ventas.Cantidad,Productos.Precio, Ventas.Fecha from Ventas inner join Productos on Productos.IdProducto = Ventas.IdProducto ", conexionbd.abrirBD());
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

        private void Ventas_Load(object sender, EventArgs e)
        {
            sucursal.Text = label14su.Text;
            //label14su.Text = lbSucursalP.Text;
            llenarNumeroFactura();
            llenarDocumentoTipo();
            llenarMetodoDePago();
            llenarPuntosDeVenta();
            llenarGridVentas();



        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable datos3 = consultaVenta(Int32.Parse(txtVenta.Text));
            if (datos3 == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {

                dgvVentas.DataSource = datos3.DefaultView;
            }

            txtVenta.Text = "";
            txtVenta.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            llenarGridVentas();
        }
    }
}
