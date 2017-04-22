using System;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Datacut
{
    class Coneccion_SqlServer
    {
        SqlCommand CM = new SqlCommand();
        public string conectar()
        {
            try
            {
                SqlConnection SGBD = new SqlConnection(@"Server=DESKTOP-PJ3N4LO\SQLEXPRESS; Database=Estetica;  Trusted_Connection=True");
                SGBD.Open();
                CM.Connection = SGBD;
                return "Conectado";
            }
            catch { return "Error en conectar"; }
        }
        public void QueryIn(SqlCommand CM, string s)
        {
            CM.CommandText = s;
            CM.ExecuteNonQuery();
        }
        public DataTable QueryOut(string s)
        {
            CM.CommandText = s;
            SqlDataAdapter Adaptador = new SqlDataAdapter(CM);
            DataTable tabla = new DataTable();
            Adaptador.Fill(tabla);
            return tabla;
        }
    }
}
