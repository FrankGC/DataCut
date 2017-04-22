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
    /// Interaction logic for pg_registro_trabajos.xaml
    /// </summary>
    public partial class pg_registro_trabajos : Page
    {
        public pg_registro_trabajos()
        {
            InitializeComponent();

            fly_add.IsOpen = false;
            fly_delete.IsOpen = false;
            fly_edit.IsOpen = false;
            refresJobs();
        }

        private void refresJobs()
        {
            try { jobs.ItemsSource = MainWindow.CG.CM.QueryOut("SELECT ID_Trabajo,Descripcion AS Trabajo ,Precio,Comision FROM Trabajo").DefaultView; } catch { }
            if (jobs.Columns.Count > 0)
            {
                jobs.Columns[0].Visibility = Visibility.Hidden;
            }
        }

        private void clearAdd()
        {
            tbx_nombre.Text = "";
            tbx_precio.Text = "";
            tbx_comision.Text = "";
            fly_add.IsOpen = false;
        }

        private void clearEdit()
        {
            tbx_edit_nombre.Text = "";
            tbx_edit_precio.Text = "";
            tbx_edit_comision.Text = "";
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

        private bool form()
        {
            float price = 0;
            float comision = 0;
            bool errors = false;

            if (tbx_precio.Text != "" && float.TryParse(tbx_precio.Text, out price))
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
            if (tbx_comision.Text != "" && float.TryParse(tbx_comision.Text, out comision))
                tbx_comision.BorderBrush = Brushes.Green;
            else
            {
                errors = true;
                tbx_comision.BorderBrush = Brushes.Red;
            }
            if (!errors)
                return true;
            else
                return false;
        }
        private bool form_edit()
        {
            float price = 0;
            float comision = 0;
            bool errors = false;

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
            if (tbx_edit_comision.Text != "" && float.TryParse(tbx_edit_comision.Text, out comision))
                tbx_edit_comision.BorderBrush = Brushes.Green;
            else
            {
                errors = true;
                tbx_edit_comision.BorderBrush = Brushes.Red;
            }
            if (!errors)
                return true;
            else
                return false;
        }

        private void bt_add_cancel_Click(object sender, RoutedEventArgs e)
        {
            clearAdd();
        }

        private void jobs_Loaded(object sender, RoutedEventArgs e)
        {
            if (jobs.Columns.Count > 0)
            {
                jobs.Columns[0].Visibility = Visibility.Hidden;
            }
        }

        private void jobs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fly_add.IsOpen = false;
            fly_delete.IsOpen = false;
            fly_edit.IsOpen = false;
        }

        private void bt_add_ok_Click(object sender, RoutedEventArgs e)
        {
            if (form())
            {
                MainWindow.CG.CM.QueryIn("INSERT INTO Trabajo (Descripcion,Precio,Comision) VALUES ('" + tbx_nombre.Text + "','" + tbx_precio.Text+"','" +tbx_comision.Text + "');");
                clearAdd();
                refresJobs();
            }
        }

        private void bt_edit_cancel_Click(object sender, RoutedEventArgs e)
        {
            clearEdit();
        }

        private void bt_edit_ok_Click(object sender, RoutedEventArgs e)
        {
            if (form_edit())
            {
                DataRowView tmp = (DataRowView)jobs.SelectedItem;
                MainWindow.CG.CM.QueryIn("UPDATE Trabajo SET Descripcion='" + tbx_edit_nombre.Text+ "',Precio='" + tbx_edit_precio.Text + "',Comision='" + tbx_edit_comision.Text + "' WHERE ID_Trabajo="+tmp[0].ToString());
                clearEdit();
                refresJobs();
            }
        }

        private void btn_no_Click(object sender, RoutedEventArgs e)
        {
            fly_delete.IsOpen = false;
        }

        private void btn_yes_Click(object sender, RoutedEventArgs e)
        {
            string ids = "(";
            var tmp = jobs.SelectedItems;
            foreach (DataRowView row in tmp)
            {
                ids += row[0] + ",";
            }
            ids = ids.Remove(ids.Length - 1) + ")";
            MainWindow.CG.CM.QueryIn("DELETE FROM Trabajo WHERE ID_Trabajo IN " + ids);
            refresJobs();
            fly_delete.IsOpen = false;
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            showFlyout(fly_add);
        }

        private void bt_edit_Click(object sender, RoutedEventArgs e)
        {
            DataRowView tmp = (DataRowView)jobs.SelectedItem;
            if(jobs.SelectedItems.Count==1)
            {
                tbx_edit_nombre.Text = tmp[1].ToString();
                tbx_edit_precio.Text = tmp[2].ToString();
                tbx_edit_comision.Text = tmp[3].ToString();
                showFlyout(fly_edit);
            }
        }

        private void bt_delete_Click(object sender, RoutedEventArgs e)
        {
            if (jobs.SelectedItems.Count > 0)
            {
                var rows = jobs.SelectedItems;
                string productos = " Eliminar trabajos: \n";
                foreach (DataRowView row in rows)
                {
                    productos += "* " + row[1].ToString() + "\n";
                }
                tbl_pegunta.Text = productos;
                showFlyout(fly_delete);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            bt_delete_Click(sender, e);
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CG.fm.GoBack();
        }
    }
}
