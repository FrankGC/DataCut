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
using System.Data;

namespace DataCut
{
    /// <summary>
    /// Interaction logic for pg_ProductosVendidos.xaml
    /// </summary>
    public partial class pg_ProductosVendidos : Page
    {
        public pg_ProductosVendidos()
        {
            InitializeComponent();
            refresh();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            string venta = "";
            var table = datagrid_TR_list.SelectedItems;
            foreach (DataRowView row in table)
            {
                venta += "Id de venta ==> " + row["ID_Ventas"] + "  Producto ==> " + row["NombrePro"] + "  Cantidad ==> " + row["Cantidad"] + "\n";
            }
            if (MessageBox.Show("Seguro que quieres borara las ventas: \n\n"+venta, "DataCut", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {             
                foreach (DataRowView ROW in table)
                {
                    MainWindow.CG.CM.QueryIn("DELETE FROM Ventas WHERE ID_Ventas=" + ROW["ID_Ventas"].ToString());
                }
                refresh();
            }
        }

        private void refresh()
        {
            cbx_PV_productos.DisplayMemberPath = "NombrePro";
            cbx_PV_productos.SelectedValuePath = "ID_Producto";
            cbx_PV_productos.ItemsSource = MainWindow.CG.CM.QueryOut("SELECT NombrePro,ID_Producto FROM Productos").DefaultView;
            datagrid_TR_list.ItemsSource = MainWindow.CG.CM.QueryOut("SELECT ID_Ventas, Productos.ID_Producto, NombrePro, Cantidad, Fecha, Hora FROM Ventas, Productos WHERE Productos.ID_Producto = Ventas.ID_Producto AND Fecha ='"+ DateTime.Today.ToString("d") + "'").DefaultView;
            if (datagrid_TR_list.Columns.Count>0)
            {
                datagrid_TR_list.Columns[0].Visibility = Visibility.Hidden;
                datagrid_TR_list.Columns[1].Visibility = Visibility.Hidden;
            }     
        }

        private void bt_PV_ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int cantidad = int.Parse(cbx_PV_cantidad.Text);
                if(cbx_PV_productos.SelectedIndex!=-1 &&cbx_PV_cantidad.Text!="")
                {
                    MainWindow.CG.CM.QueryIn("INSERT INTO Ventas (ID_Producto,Fecha,Hora,Cantidad) VALUES (" + cbx_PV_productos.SelectedValue+ ",'" + DateTime.Today.Date.ToShortDateString() + "','" + DateTime.Now.TimeOfDay +"'," + cantidad + ")");
                    cbx_PV_productos.SelectedIndex = -1;
                    cbx_PV_cantidad.Text = "";
                    refresh();
                }
                
            } catch { }
        }

        private void bt_PV_eliminar_Click(object sender, RoutedEventArgs e)
        {
            MenuItem_Click(sender, e);
        }
    }
}
