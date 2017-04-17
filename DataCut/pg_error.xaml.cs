using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using Microsoft.Win32;

namespace DataCut
{
    /// <summary>
    /// Interaction logic for pg_error.xaml
    /// </summary>
    public partial class pg_error : Page
    {
        string myServer = Environment.MachineName;
        public pg_error()
        {
            InitializeComponent();
            get_instans();
        }

        private void get_instans()
        {
            RegistryView rv = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, rv))
            {
                RegistryKey rk = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (rk == null) return;

                foreach (var v in rk.GetValueNames())
                {
                    cbx_instancia.Items.Add(myServer + "\\" + v);
                }
            }
        }

        private void get_databases()
        {
            if(cbx_instancia.SelectedIndex!=-1)
            {
                string [] conectionString = { @"Server=" + cbx_instancia.SelectedItem.ToString() + ";Trusted_Connection=True; Connection Timeout=10;" };
                ConeccionSQL tempc = new ConeccionSQL();
                tempc.Conectar(conectionString);
                MainWindow.CG.CM = tempc;
                DataTable tempDatatable = MainWindow.CG.CM.QueryOut("SELECT * FROM sys.databases");
                foreach (DataRow item in tempDatatable.Rows)
                    cbx_basededatos.Items.Add(item[0]);
            }                  
        }

        private void bt_guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(cbx_instancia.SelectedIndex!=-1 && cbx_basededatos.SelectedIndex!=-1)
                {
                    string [] conectionString = { @"Server=" + cbx_instancia.SelectedItem.ToString() + "; Database=" + cbx_basededatos.SelectedItem.ToString() + ";  Trusted_Connection=True; Connection Timeout=10;" };
                    if (MainWindow.CG.CM.Conectar(conectionString))
                    {
                        MainWindow.CG.fm.Navigate(new pg_login());
                    }
                }
            }
            catch { }
        }

        private void cbx_instancia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            get_databases();
        }
    }
}
