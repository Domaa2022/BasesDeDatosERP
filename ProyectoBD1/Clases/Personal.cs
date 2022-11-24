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
    public partial class Personal : Form
    {
        public Personal()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cerrar la ventana Personal?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }


        //LLENAR GRID
        public static DataTable listarEmpleados()
        {
            Conexion conexionbd = new Conexion();
            try
            {

                SqlCommand comando = new SqlCommand("Select Empleados.IdEmpleado,Personas.NumIdentidad as Identidad ,Personas.Nombre1 as Nombre, Personas.Apellido1 as Apellido , TipoContratos.NombreContrato as Contrato, Permisos.Nombre as Cargo from Empleados inner join Personas on Empleados.IdPersona = Personas.IdPersona inner join TipoContratos on Empleados.IdContrato = TipoContratos.IdContrato inner join Cargos on empleados.IdCargo = cargos.IdCargo inner join Permisos on cargos.IdPermiso = Permisos.IdPermiso", conexionbd.abrirBD());
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
            DataTable datos = listarEmpleados();
            if (datos == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {
                
                dgvEmpleado.DataSource = datos.DefaultView;
            }
        }


        //INICIO DE PERSONAL
        private void Personal_Load_1(object sender, EventArgs e)
        {
            llenarGrid();
            llenarcargo();
            llenarContrato();

            
        }

        // CONSULTA DE EMPLEADOS Y CREACION DE MODELO DE PERSONA
        public class Persona
        {
            public string identidad;
            public string nombre;
            public string nombre2;
            public string apellido;
            public string apellido2;
            public string contrato;
            public string cargo;
            public string usuario;
            public string contraseña;
            public string fechaInicio;
            public string fechaFinalizacion;


        }

        public static Persona consultar(string documento)
        {
            Conexion conexionbd = new Conexion();


            try
            {
                SqlCommand comando = new SqlCommand("select Empleados.InicioContrato as FechaInicio , Empleados.FinalizaContrato as FechaFinalizacion,  Personas.Nombre1 as Nombre,Personas.Nombre2 as SegundoNombre,Personas.Apellido1 as Apellido,Personas.Apellido2 as SegundoApellido,Permisos.Nombre as Cargo,TipoContratos.NombreContrato,Empleados.Usuario as Usuario,Empleados.ClaveAcceso as Contraseña, Personas.NumIdentidad as Identidad from Empleados inner join Personas on Empleados.IdPersona = Personas.IdPersona inner join Cargos on Empleados.IdCargo = Cargos.IdCargo inner join Permisos on Cargos.IdPermiso = Permisos.IdPermiso inner join Contratos on Empleados.IdContrato = Contratos.IdContrato inner join TipoContratos on Contratos.IdTipoContrato = TipoContratos.IdContrato where Personas.NumIdentidad = '" + documento+"'", conexionbd.abrirBD());
                SqlDataReader dr = comando.ExecuteReader();
                Persona pr = new Persona();
                if (dr.Read())
                {
                    
                    pr.nombre = dr["Nombre"].ToString();
                    pr.nombre2 = dr["SegundoNombre"].ToString();
                    pr.apellido = dr["Apellido"].ToString();
                    pr.apellido2 = dr["SegundoApellido"].ToString();
                    pr.contrato = dr["NombreContrato"].ToString();
                    pr.cargo = dr["Cargo"].ToString();
                    pr.usuario = dr["Usuario"].ToString();
                    pr.contraseña = dr["Contraseña"].ToString();
                    pr.fechaInicio = dr["FechaInicio"].ToString();
                    pr.fechaFinalizacion = dr["FechaFinalizacion"].ToString();

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

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            Persona pr = consultar(txtDocumento1.Text);
            if (pr == null)
            {
                MessageBox.Show("No existe el empleado con documento: " + txtDocumento1.Text);
                consultado = false;
            }
            else
            {
                txtFirstName.Text = pr.nombre;
                txtSecondName.Text = pr.nombre2;
                txtA.Text = pr.apellido;
                txtA2.Text = pr.apellido2;
                cbCargo.Text = pr.cargo;
                cbContrato.Text = pr.contrato;
                txtUser.Text = pr.usuario;
                
                FechaInicio.Text = pr.fechaInicio;
                FechaFinalizacion.Text = pr.fechaFinalizacion;
                consultado = true;

            }

        }



        // LLENAR DROWNLIST DE  CARGO

        public void llenarcargo()
        {
            Conexion conexionbd = new Conexion();
            SqlCommand comando = new SqlCommand("select Cargos.idCargo, Permisos.IdPermiso, Permisos.Nombre from Cargos inner join Permisos on Cargos.IdPermiso = Permisos.IdPermiso", conexionbd.abrirBD());
            SqlDataReader cargo = comando.ExecuteReader();
            while (cargo.Read())
            {
                cbCargo.Items.Add(cargo["Nombre"].ToString());
            }
            conexionbd.cerrar();
        }



        // LLENAR DROWNLIST DE CONTRATOS
      
        public void llenarContrato()
        {
            Conexion conexionbd = new Conexion();
            SqlCommand comando = new SqlCommand("select *, Contratos.IdContrato, TipoContratos.NombreContrato from Contratos inner join TipoContratos on Contratos.IdTipoContrato = TipoContratos.IdContrato", conexionbd.abrirBD());
            SqlDataReader contrato = comando.ExecuteReader();
            while (contrato.Read())
            {
                cbContrato.Items.Add(contrato["NombreContrato"].ToString());
                
            }
            conexionbd.cerrar();
        }

        // CREACION DE EMPLEADOS

        public bool crearPersona(Persona per)
        {
            Conexion conexionbd = new Conexion();
            try
            {
                SqlCommand comando = new SqlCommand("insert into Personas values ('" + per.identidad + "','" + per.nombre + "','" + per.nombre2 + "', '" + per.apellido + "', '" + per.apellido2 + "')", conexionbd.abrirBD());
                int cantidad = comando.ExecuteNonQuery();
                if( cantidad == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }catch( Exception e)
            {
                return false;
            }
            finally
            {
                conexionbd.cerrar();
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

                    idEmpleado(em.identidad);
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

        private void idEmpleado(string identidad)
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
                    crearEmpleado(numPersona);
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

        private void crearEmpleado(string numPersona)
        {
            string fecha = FechaInicio.Value.Month + "-" + FechaInicio.Value.Day + "-" + FechaInicio.Value.Year;
            string fechaF = FechaFinalizacion.Value.Month + "-" + FechaFinalizacion.Value.Day + "-" + FechaFinalizacion.Value.Year;
            Conexion conectarbd = new Conexion();
            if (cbCargo.Text == "Administrador")
            {
                if (cbContrato.Text == "Permanente")
                {
                    try
                    {

                        


                        SqlCommand comando = new SqlCommand("exec RegistrarUsuario " + numPersona + ",1," + lbSucursal1.Text + ", 1 ,'" + txtUser.Text + "','1234',1,'" + fechaF + "','" + fechaF + "'", conectarbd.abrirBD());
                        int cantidad = comando.ExecuteNonQuery();
                        if (cantidad == 1)
                        {
                            MessageBox.Show("Empleado Creado");
                            eliminarRegistros();
                            llenarGrid();

                        }
                        else
                        {
                            MessageBox.Show("No se pudo Crear el empleado");
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
                else
                {
                    try
                    {


                        SqlCommand comando = new SqlCommand("exec RegistrarUsuario " + numPersona + ",1," + lbSucursal1.Text + ", 2 ,'" + txtUser.Text + "','1234',1,'" + fechaF + "','" + fechaF + "'", conectarbd.abrirBD());
                        int cantidad = comando.ExecuteNonQuery();
                        if (cantidad == 1)
                        {
                            MessageBox.Show("Empleado Creado");
                            llenarGrid();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Crear el empleado");
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
            }
            else
            {
                if (cbContrato.Text == "Permanente")
                {
                    try
                    {
                        SqlCommand comando = new SqlCommand("exec RegistrarUsuario " + numPersona + ",2," + lbSucursal1.Text + ", 1 ,'" + txtUser.Text + "','1234',1,'" + fechaF + "','" + fechaF + "'", conectarbd.abrirBD());
                        int cantidad = comando.ExecuteNonQuery();
                        if (cantidad == 1)
                        {
                            MessageBox.Show("Empleado Creado");
                            llenarGrid();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Crear el empleado");
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
                else
                {
                    try
                    {
                        SqlCommand comando = new SqlCommand("exec RegistrarUsuario " + numPersona + ",2," + lbSucursal1.Text + ", 2 ,'" + txtUser.Text + "','1234',1,'" + fechaF + "','" + fechaF + "'", conectarbd.abrirBD());
                        int cantidad = comando.ExecuteNonQuery();
                        if (cantidad == 1)
                        {
                            MessageBox.Show("Empleado Creado");
                            llenarGrid();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Crear el empleado");
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

            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                insercionPersona();
            }catch(Exception em)
            {
                MessageBox.Show(em.ToString());
            }
            finally
            {
                eliminarRegistros();
            }
            
            
        }


       //ELIMINACION DE EMPLEADO

        private void eliminarEmpleado(string numIdentidad)
        {
            Conexion conectarbd = new Conexion();
            

            try
            {
                SqlCommand comando = new SqlCommand("update Empleados set Estado = 0 from Empleados inner join Personas on Empleados.IdPersona = Personas.IdPersona where Personas.NumIdentidad = '"+numIdentidad+"'", conectarbd.abrirBD());
                int cantidad = comando.ExecuteNonQuery();
                if(cantidad == 1)
                {
                    MessageBox.Show("Empleado eliminado correctamente");
                    llenarGrid();
                    eliminarRegistros();
                }
                else
                {
                    MessageBox.Show("Identidad no encontrada");
                    eliminarRegistros();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarEmpleado(txtDocumento1.Text);
        }


       // ACTUALIZACION DE EMPLEADO

        
        private void actualizarEmpleado (string documento, string usuario, int cargo, int contrato)
        {
            Conexion conectarbd = new Conexion();

            try
            {
                string fecha = FechaInicio.Value.Month + "-" + FechaInicio.Value.Day + "-" + FechaInicio.Value.Year;
                string fechaF = FechaFinalizacion.Value.Month + "-" + FechaFinalizacion.Value.Day + "-" + FechaFinalizacion.Value.Year;
                SqlCommand comando = new SqlCommand("update Empleados set IdCargo = "+cargo+", IdContrato = "+contrato+" , Usuario = '"+usuario+"' ,  InicioContrato = '"+fecha+"', FinalizaContrato = '"+fechaF+"' from Empleados inner join Personas on Empleados.IdPersona = Personas.IdPersona where Personas.NumIdentidad = '"+documento+"'", conectarbd.abrirBD());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    MessageBox.Show("Empleado actualizado correctamente");
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if( consultado == false)
            {
                MessageBox.Show("debe consultar antes de actualizar");
            }
            else
            {
                if(cbCargo.Text == "Administrador")
                {
                    if(cbContrato.Text == "Permanente")
                    {
                        actualizarEmpleado(txtDocumento1.Text, txtUser.Text, 1, 1);
                    }
                    else
                    {
                        actualizarEmpleado(txtDocumento1.Text, txtUser.Text, 1, 2);
                    }
                }
                else
                {
                    if (cbContrato.Text == "Permanente")
                    {
                        actualizarEmpleado(txtDocumento1.Text, txtUser.Text,2,1);
                    }
                    else
                    {
                        actualizarEmpleado(txtDocumento1.Text, txtUser.Text, 2, 2);
                    }
                }
            }
        }

        //ELIMINACION DE REGISTROS TIPEADOS
        private void eliminarRegistros()
        {
            txtDocumento1.Text = "";
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtA.Text = "";
            txtA2.Text = "";
            txtUser.Text = "";
            //txtPass.Text = "";
            cbCargo.Text = "";
            cbContrato.Text = "";
        }
    }
}
