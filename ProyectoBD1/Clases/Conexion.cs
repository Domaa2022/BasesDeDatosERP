using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD1.Clases
{
    class Conexion
    {
        SqlConnection conectarBD; 
        public Conexion()
        {
            conectarBD = new SqlConnection("Data Source=localhost;Initial Catalog=BDP2; Integrated Security=True");
        }

        public SqlConnection abrirBD()
        {
            try
            {
                conectarBD.Open();
                return conectarBD;
            }catch (Exception ex)
            {
                return null;
            }

        }

        public void cerrar()
        {
            conectarBD.Close();
        }


    }
}
