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
using MahApps.Metro.Controls;
using System.Data;

namespace Datacut
{
    /// <summary>
    /// Interaction logic for pg_registro_productos.xaml
    /// </summary>
    public partial class pg_registro_productos : Page
    {
        bool errors;
        string msg;
        public pg_registro_productos()
        {
            InitializeComponent();
            fly_add.IsOpen = false;
            fly_delete.IsOpen = false;
            fly_edit.IsOpen = false;
            refreshProducts();
        }

        private void refreshProducts()
        {
            try { products.ItemsSource = MainWindow.CG.CM.QueryOut("SELECT * FROM Productos").DefaultView; } catch { }
            if (products.Columns.Count > 0)
            {
                products.Columns[0].Visibility = Visibility.Hidden;
            }
        }

        private void clearAdd()
        {
            tbx_nombre.Text = "";
            tbx_precio.Text = "";
            fly_add.IsOpen = false;
        }

        private void clearEdit()
        {
            tbx_edit_nombre.Text = "";
            tbx_edit_precio.Text = "";
            fly_edit.IsOpen = false;
        }

        private void showFlyout(Flyout F)
        {
            fly_add.IsOpen = false;
            fly_delete.IsOpen = false;
            fly_edit.IsOpen = false;
            if (!F.IsOpen)
                F.IsOpen = true;
        }

        private void btn_producto_Click(object sender, RoutedEventArgs e)
        {
            showFlyout(fly_add);
        }

        private void bt_edit_Click(object sender, RoutedEventArgs e)
        {
            DataRowView tmp = (DataRowView)products.SelectedItem;
            if (products.SelectedItems.Count==1)
            {
                tbx_edit_nombre.Text = tmp[1].ToString();
                tbx_edit_precio.Text = tmp[2].ToString();
                showFlyout(fly_edit);
            }
               
        }

        private void bt_delete_Click(object sender, RoutedEventArgs e)
        {
           if(products.SelectedItems.Count>0)
            {
                var rows =  products.SelectedItems;
                string productos = " Eliminar productos: \n";
                foreach (DataRowView row in rows)
                {
                    productos += "* " + row[1].ToString() + "\n";
                }
                showFlyout(fly_delete);
                tbl_pegunta.Text = productos;
            }
           
        }

        private void bt_add_cancel_Click(object sender, RoutedEventArgs e)
        {
            clearAdd();
        }

        private void bt_add_ok_Click(object sender, RoutedEventArgs e)
        {
            float price=0;
            errors = false;
            if (tbx_precio.Text != "" && float.TryParse(tbx_precio.Text,out price ))
                tbx_precio.BorderBrush = Brushes.Green;
            else
            {
                tbx_precio.BorderBrush = Brushes.Red;
                errors = true;
            }

            if (tbx_nombre.Text != "")
                tbx_nombre.BorderBrush = Brushes.Green;
            else
            {
                tbx_nombre.BorderBrush = Brushes.Red;
                errors = true;
            }
            if (!errors)
            {
                MainWindow.CG.CM.QueryIn("INSERT INTO Productos (NombrePro,Precio) VALUES ('"+tbx_nombre.Text+"','"+price+"');");
                clearAdd();
                refreshProducts();
            }
        }

        private void bt_edit_cancel_Click(object sender, RoutedEventArgs e)
        {
            clearEdit();
        }

        private void bt_edit_ok_Click(object sender, RoutedEventArgs e)
        {
            float price = 0;
            errors = false;
            if (tbx_edit_precio.Text != "" && float.TryParse(tbx_edit_precio.Text, out price))
                tbx_edit_precio.BorderBrush = Brushes.Green;
            else
            {
                tbx_edit_precio.BorderBrush = Brushes.Red;
                errors = true;
            }

            if (tbx_edit_nombre.Text != "")
                tbx_edit_nombre.BorderBrush = Brushes.Green;
            else
            {
                tbx_edit_nombre.BorderBrush = Brushes.Red;
                errors = true;
            }
            if (!errors)
            {
                DataRowView tmp = (DataRowView)products.SelectedItem;
                MainWindow.CG.CM.QueryIn("UPDATE Productos SET NombrePro='" + tbx_edit_nombre.Text + "',Precio='" + price +"' WHERE ID_Producto="+tmp[0].ToString());
                clearEdit();
                refreshProducts();
            }
        }

        private void products_Loaded(object sender, RoutedEventArgs e)
        {
            if(products.Columns.Count>0)
            {
                products.Columns[0].Visibility = Visibility.Hidden;
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CG.fm.GoBack();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            bt_delete_Click(sender, e);
        }

        private void btn_no_Click(object sender, RoutedEventArgs e)
        {
            fly_delete.IsOpen = false;
        }

        private void btn_yes_Click(object sender, RoutedEventArgs e)
        {
            string ids = "(";
            var tmp = products.SelectedItems;
            foreach(DataRowView row in tmp)
            {
                ids += row[0] + ",";
            }
            ids = ids.Remove(ids.Length - 1) + ")";
            MainWindow.CG.CM.QueryIn("DELETE FROM Productos WHERE ID_Producto IN " + ids);
            refreshProducts();
            fly_delete.IsOpen = false;
        }

        private void products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fly_add.IsOpen = false;
            fly_delete.IsOpen = false;
            fly_edit.IsOpen = false;
        }
    }
}
