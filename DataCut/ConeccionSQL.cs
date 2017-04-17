using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows;
using System.IO;

namespace DataCut
{
    public  class ConeccionSQL
    {
        public SqlCommand CM = new SqlCommand();
        public bool Conectar(string [] server)
        {
            try
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DataCut");
                File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DataCut" + @"\config.txt",server);
                SqlConnection SGBD = new SqlConnection(server[0]);
                SGBD.Open();
                CM.Connection = SGBD;
                return true;
            }
            catch (Exception ex) {  return false; }
        }
        public bool Conectar()
        {
            try
            {
                string[] lines = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DataCut" + @"\config.txt");               
                SqlConnection SGBD = new SqlConnection(lines[0]);
                SGBD.Open();
                CM.Connection = SGBD;
                return true;
            }
            catch { return false; }
        }
        public void QueryIn(string s)
        {
            try
            {
                CM.CommandText = s;
                CM.ExecuteNonQuery();
            }
            catch (Exception)
            {

                MessageBox.Show("Error en la base de datos");
            }       
        }
        public DataTable QueryOut(string s)
        {
            try
            {
                CM.CommandText = s;
                SqlDataAdapter Adaptador = new SqlDataAdapter(CM);
                DataTable tabla = new DataTable();
                Adaptador.Fill(tabla);
                return tabla;
            }
            catch { MessageBox.Show("Error en la base de datos"); return null; }
        }
    }
}
