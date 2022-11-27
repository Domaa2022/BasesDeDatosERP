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
    public partial class Facturación : Form
    {
        public Facturación()
        {
            InitializeComponent();
            //groupBox1.Enabled = false;
            
            btnActualiza.Enabled = false;
            cbProveedor.Enabled = false;
            cantidad.Enabled = false;
            precioN.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cerrar la ventana Facturación?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
          
        }


        private void button3_Click_1(object sender, EventArgs e)
        {

            btnActualiza.Enabled = true;
            cbProveedor.Enabled = true;
            cantidad.Enabled = true;
            precioN.Enabled = true;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

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
            SqlCommand comando = new SqlCommand("select * from PuntosDeVentas where IdSucursal = "+label14su.Text+"", conexionbd.abrirBD());
            SqlDataReader sucursal = comando.ExecuteReader();
            while (sucursal.Read())
            {
                cbPuntoVenta.Items.Add(sucursal["NumeroPos"].ToString());
            
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

            }

            conexionbd.cerrar();

        }

        public void crearFacturaDefaul(int sucursal, int numeroFactura, int tipoDocumento, string POS,  string cliente)
        {
            Conexion conectarbd = new Conexion();
            SqlCommand comando = new SqlCommand("insert into NumeroFacturas values ("+sucursal+","+POS+","+tipoDocumento+","+numeroFactura+")", conectarbd.abrirBD());
            int cantidad = comando.ExecuteNonQuery();
            conectarbd.cerrar();
            if(cantidad == 2)
            {
                
                int facturaEnProceso ;
                int clienteEnProceso; 
                int EmpleadoEnProceso;
                string fechaFactura = dateFactura.Value.Month + "-" + dateFactura.Value.Day + "-" + dateFactura.Value.Year;
                // BUSCAR EL IDNUMEROFACTURA
                SqlCommand comando2 = new SqlCommand("select * from NumeroFacturas where NumeracionCorrelativa = "+numeroFactura+"", conectarbd.abrirBD());
                SqlDataReader dr = comando2.ExecuteReader();
                if (dr.Read())
                {
                    facturaEnProceso = Int32.Parse(dr["IdFactura"].ToString());
                    conectarbd.cerrar();

                    // BUSCAR EL ID Cliente
                    SqlCommand comando3 = new SqlCommand("select IdCliente from Clientes inner join Personas on Clientes.IdPersona = Personas.IdPersona where Personas.NumIdentidad = '" + cliente + "'", conectarbd.abrirBD());
                    SqlDataReader dr2 = comando3.ExecuteReader();
                    if (dr2.Read())
                    {
                        clienteEnProceso = Int32.Parse(dr2["IdCliente"].ToString());
                        conectarbd.cerrar();
                        //Buscar el idEmpleado
                        SqlCommand comando4 = new SqlCommand("select IdEmpleado from Empleados inner join Personas on Empleados.IdPersona = Personas.IdPersona where Empleados.Usuario = '" + UserEmpleado.Text + "'", conectarbd.abrirBD());
                        SqlDataReader dr3 = comando4.ExecuteReader();
                        if (dr3.Read())
                        {
                            EmpleadoEnProceso = Int32.Parse(dr3["IdEmpleado"].ToString());
                            conectarbd.cerrar();
                            //Crear factura 
                            if (cbMetodoPago.Text == "Credito")
                            {
                                SqlCommand comando5 = new SqlCommand("insert into Facturas values ("+facturaEnProceso+",'"+fechaFactura+"',"+EmpleadoEnProceso+","+clienteEnProceso+",NULL,NULL,NULL,NULL,NULL,1,"+label14su.Text+",NULL)", conectarbd.abrirBD());
                                int cantidad2 = comando5.ExecuteNonQuery();
                                if(cantidad2 == 1)
                                {
                                    MessageBox.Show("Factura creada con exito");
                                    conectarbd.cerrar();

                                }
                                else
                                {
                                    MessageBox.Show("No se pudo crear la factura creada");
                                    conectarbd.cerrar();
                                }
                            }
                            else
                            {
                                SqlCommand comando5 = new SqlCommand("insert into Facturas values (" + facturaEnProceso + ",'" + fechaFactura + "'," + EmpleadoEnProceso + "," + clienteEnProceso + ",NULL,NULL,NULL,NULL,NULL,2," + label14su.Text + ",NULL)", conectarbd.abrirBD());
                                int cantidad2 = comando5.ExecuteNonQuery();
                                if (cantidad2 == 1)
                                {
                                    MessageBox.Show("Factura creada con exito");
                                   
                                    conectarbd.cerrar();

                                }
                                else
                                {
                                    MessageBox.Show("No se pudo crear la factura creada");
                                    conectarbd.cerrar();
                                }
                            }
                            
                        }
                        
                        

                    }
                   
                    
                }
              

                

              

               

            }
            else
            {
                MessageBox.Show("no se creo");
            }

        }
        
        public void CrearDetalle()
        {
            //Crear Venta
            int idCliente;
            int idVenta;
            int idNumeroFactura;
            Conexion conectarbd = new Conexion();
            SqlCommand comando = new SqlCommand("select * from Clientes inner join Personas on Clientes.IdPersona= Personas.IdPersona where NumIdentidad = '" + txtIdCliente.Text + "'", conectarbd.abrirBD());
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.Read())
            {
                idCliente = Int32.Parse(dr["IdCliente"].ToString());
                conectarbd.cerrar();
                string fechaFactura = fechaVenta.Value.Year + "-" + fechaVenta.Value.Month + "-" + fechaVenta.Value.Day + " " + fechaVenta.Value.Hour+":"+fechaVenta.Value.Minute+":"+fechaVenta.Value.Second;
                SqlCommand comando2 = new SqlCommand("INSERT INTO Ventas VALUES ("+Int32.Parse(txtIdPro.Text)+","+idCliente+","+Int32.Parse(txtCantidad.Text)+",'"+fechaFactura+"')", conectarbd.abrirBD());
                int cantidad = comando2.ExecuteNonQuery();
                if(cantidad == 2)
                {
                    conectarbd.cerrar();
                    SqlCommand comando3 = new SqlCommand("select * from Ventas where Ventas.IdCliente = " + idCliente + " and Ventas.Fecha = '"+fechaFactura+"' ", conectarbd.abrirBD());
                    SqlDataReader dr2 = comando3.ExecuteReader();
                    if (dr2.Read())
                    {
                        idVenta = Int32.Parse(dr2["idVenta"].ToString());
                        conectarbd.cerrar();
                        SqlCommand comando4 = new SqlCommand("select * from Facturas inner join NumeroFacturas on Facturas.NumFactura = NumeroFacturas.IdFactura where NumeracionCorrelativa = '" + NumeroFact.Text + "'", conectarbd.abrirBD());
                        SqlDataReader dr3 = comando4.ExecuteReader();
                        if (dr3.Read())
                        {
                            idNumeroFactura = Int32.Parse(dr3["IdFactura"].ToString());
                            conectarbd.cerrar();
                            SqlCommand comando5 = new SqlCommand("insert into Detalles values ("+idNumeroFactura+","+idVenta+")", conectarbd.abrirBD());
                            int cantidad2 = comando5.ExecuteNonQuery();
                            if(cantidad2 == 1)
                            {
                                MessageBox.Show("Se ha creado el producto");
                                llenarGrid(idNumeroFactura);
                                detallesPrecios(idNumeroFactura);
                            }
                        }
                    }
                   
                }
            } 
        }

        private void Facturación_Load(object sender, EventArgs e)
        {
            sucursal.Text = label14su.Text;
            llenarNumeroFactura();
            llenarPuntosDeVenta();
            llenarDocumentoTipo();
            llenarMetodoDePago();
           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CrearDetalle();

        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            if (cbTipoDoc.Text == "Factura")
            {
                crearFacturaDefaul(Int32.Parse(label14su.Text), Int32.Parse(NumeroFact.Text), 1, cbPuntoVenta.Text, txtIdCliente.Text);
            }
        }

        private DataTable detalles(int idFactura)
        {
            Conexion conexionbd = new Conexion();
            try
            {

                SqlCommand comando = new SqlCommand("select  Cantidad, Marca, Modelo, Agno as Año, Precio from Detalles inner join Ventas on Detalles.IdVenta = Ventas.IdVenta inner join Productos on Productos.IdProducto = Ventas.IdProducto where Detalles.IdFactura = "+idFactura+" ", conexionbd.abrirBD());
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

        public void llenarGrid(int idFactura)
        {
            DataTable datos = detalles(idFactura);
            if (datos == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {

                dgvDetalles.DataSource = datos.DefaultView;
            }
        }

        public void detallesPrecios(int idFactura)
        {
            Conexion conectarbd = new Conexion();
            SqlCommand comando = new SqlCommand("select Facturas.IdFactura, SUM(Ventas.Cantidad * Productos.Precio)PrecioTotal from Facturas inner join Detalles on Facturas.IdFactura = Detalles.IdFactura inner join Ventas on Detalles.IdVenta = Ventas.IdVenta inner join Productos on Productos.IdProducto = Ventas.IdProducto where Facturas.IdFactura = "+idFactura+" group by Facturas.IdFactura", conectarbd.abrirBD());
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.Read())
            {
                lbSubtotal.Text = dr["PrecioTotal"].ToString();
                double subprecio = double.Parse(dr["PrecioTotal"].ToString());
                double impuest15 = subprecio * 0.15;
                Math.Round(impuest15, 2);
                double total = subprecio + impuest15;
                imp15.Text = impuest15.ToString();
                imp18.Text = "0.00";
                descuento.Text = "0.00";
                importe.Text = "0.00";
                totalCompra.Text = total.ToString();
                conectarbd.cerrar();

            }
          
        }

        public void finalizarFactura()
        {
            int idNumeroFactura;
            Conexion conectarbd = new Conexion();
            SqlCommand comando = new SqlCommand("select * from Facturas inner join NumeroFacturas on Facturas.NumFactura = NumeroFacturas.IdFactura where NumeracionCorrelativa = '" + NumeroFact.Text + "'", conectarbd.abrirBD());
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.Read())
            {
                idNumeroFactura = Int32.Parse(dr["IdFactura"].ToString());
                conectarbd.cerrar();
                SqlCommand comando2 = new SqlCommand("update Facturas set SubTotal = "+Math.Round(double.Parse(lbSubtotal.Text),2)+" , IsvQuince = " + Math.Round(double.Parse(imp15.Text), 2) + "  ,IsvDieciocho =  " + Math.Round(double.Parse(imp18.Text), 2) + "  , Descuentos =  " + Math.Round(double.Parse(descuento.Text), 2) + ", ImporteExonerado = " + Math.Round(double.Parse(importe.Text), 2) + " , TotalPagar = " + Math.Round(double.Parse(totalCompra.Text), 2) + " where Facturas.IdFactura =" + idNumeroFactura+"", conectarbd.abrirBD());
                int cantidad = comando2.ExecuteNonQuery();
                if(cantidad == 1)
                {
                    MessageBox.Show("Factura Completada");
                    llenarNumeroFactura();
                    eliminarRegistros();
                    
                }
            }
        }

        private void btnFinalizarCom_Click(object sender, EventArgs e)
        {
            finalizarFactura();
        }

        public void eliminarRegistros()
        {
            cbPuntoVenta.Text = "";
            cbTipoDoc.Text = "";
            txtIdCliente.Text = "";
            cbMetodoPago.Text = "";
            txtIdPro.Text = "";
            txtCantidad.Text = "";
            dgvDetalles.Columns.Clear();
        }
    }
}
