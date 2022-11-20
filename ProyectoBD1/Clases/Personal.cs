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
                dtEmpleados.DataSource = datos.DefaultView;
            }
        }


        private void Personal_Load_1(object sender, EventArgs e)
        {
            llenarGrid();
        }

        public class Persona
        {
            public string identidad;
            public string nombre;
            public string apellido;
            public string contrato;
            public string cargo;

        }

        public static Persona consultar(string documento)
        {
            Conexion conexionbd = new Conexion();


            try
            {
                SqlCommand comando = new SqlCommand("Select Empleados.IdEmpleado,Personas.NumIdentidad as Identidad ,Personas.Nombre1 as Nombre, Personas.Apellido1 as Apellido , TipoContratos.NombreContrato as Contrato, Permisos.Nombre as Cargo from Empleados inner join Personas on Empleados.IdPersona = Personas.IdPersona inner join TipoContratos on Empleados.IdContrato = TipoContratos.IdContrato inner join Cargos on empleados.IdCargo = cargos.IdCargo inner join Permisos on cargos.IdPermiso = Permisos.IdPermiso where Personas.NumIdentidad = @documento", conexionbd.abrirBD());
                comando.Parameters.AddWithValue("documento", documento);
                SqlDataReader dr = comando.ExecuteReader();
                Persona pr = new Persona();
                if (dr.Read())
                {
                    pr.identidad = dr["Identidad"].ToString();
                    pr.nombre = dr["Nombre"].ToString();
                    pr.apellido = dr["Apellido"].ToString();
                    pr.contrato = dr["Contrato"].ToString();
                    pr.cargo = dr["Cargo"].ToString();

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtIdentidad.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un documento");
            }
            else
            {
                Persona pr = consultar(txtIdentidad.Text);
                if (pr == null)
                {
                    MessageBox.Show("No existe el empleado con identidad" + txtIdentidad.Text);
                }
                else
                {
                    txtNombre.Text = pr.nombre;
                    txtApellido.Text = pr.apellido;
                    txtContrato.Text = pr.contrato;
                    txtCargo.Text = pr.cargo;

                }
            }
        }
    }
}
