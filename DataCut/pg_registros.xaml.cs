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
    /// Interaction logic for pg_TrabajosRealizados.xaml
    /// </summary>
    public partial class pg_registros : Page
    {
        bool errors = false;
        string ids = "";
        public pg_registros()
        {
            InitializeComponent();
            producto.IsOpen = false;
            trabajo.IsOpen = false;
            borrar.IsOpen = false;
            cbx_productos.SelectedValuePath = "ID_Producto";
            cbx_productos.DisplayMemberPath = "NombrePro";
            try { cbx_productos.ItemsSource = MainWindow.CG.CM.QueryOut("SELECT ID_Producto,NombrePro FROM Productos").DefaultView; } catch { }
            cbx_trabajos.SelectedValuePath = "ID_Trabajo";
            cbx_trabajos.DisplayMemberPath = "Trabajo";
            try { cbx_trabajos.ItemsSource = MainWindow.CG.CM.QueryOut("SELECT ID_Trabajo,Descripcion AS Trabajo FROM Trabajo").DefaultView; } catch { }
            cbx_personal.SelectedValuePath = "ID_Empleado";
            cbx_personal.DisplayMemberPath = "Nombre";
            try { cbx_personal.ItemsSource = MainWindow.CG.CM.QueryOut("SELECT ID_Empleado,(Apellidos+' '+Nombre) AS Nombre FROM Personal").DefaultView; } catch { }
            refreshProductos();
            refreshTrabajos();
        }

        private void refreshProductos()
        {
            try { registros_productos.ItemsSource = MainWindow.CG.CM.QueryOut("SELECT ID_Ventas,NombrePro AS Producto,Hora,Cantidad FROM Ventas,Productos WHERE Ventas.ID_Producto=Productos.ID_Producto AND Fecha='" + DateTime.Today.ToShortDateString() + "'").DefaultView; } catch { }
            if (registros_productos.Columns.Count > 0)
            {
                registros_productos.Columns[0].Visibility = Visibility.Hidden;
            }
        }

        private void refreshTrabajos()
        {
            try { registros_trabajos.ItemsSource = MainWindow.CG.CM.QueryOut("SELECT ID_TR,(Apellidos+' '+Nombre) AS Personal,Descripcion AS Trabajo,Hora FROM Personal,Trabajo,Trabajos_Realizados WHERE Trabajos_Realizados.ID_Trabajo=Trabajo.ID_Trabajo AND Personal.ID_Empleado=Trabajos_Realizados.ID_Empleado AND Fecha='" + DateTime.Today.ToShortDateString() + "'").DefaultView; } catch { }
            if (registros_trabajos.Columns.Count > 0)
            {
                registros_trabajos.Columns[0].Visibility = Visibility.Hidden;
            }
        }

        private void showflyout(Flyout f)
        {
            producto.IsOpen = false;
            trabajo.IsOpen = false;
            borrar.IsOpen = false;
            if (!f.IsOpen)
                f.IsOpen = true;
        }


        private void productoClear()
        {
            productos_cantidad.Value = 0;
            cbx_productos.SelectedIndex = -1;
            producto.IsOpen = false;
        }

        private void trabajoClear()
        {
            cbx_personal.SelectedIndex = -1;
            cbx_trabajos.SelectedIndex = -1;
            trabajo.IsOpen = false;
        }

        private void producto_vendido_Click(object sender, RoutedEventArgs e)
        {
            showflyout(producto);
        }

        private void trabajo_realizado_Click(object sender, RoutedEventArgs e)
        {
            showflyout(trabajo);
        }

        private void btn_personal_back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CG.fm.GoBack();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            eliminar_registro_Click(sender, e);
        }

        private void eliminar_registro_Click(object sender, RoutedEventArgs e)
        {
            if(registros_productos.SelectedItems.Count>0 || registros_trabajos.SelectedItems.Count>0)
            {
                showflyout(borrar);
                string msg = "Eliminar registros: \n";
                ids = "(";
                if (registros_productos.SelectedItems.Count > 0)
                {
                    var ROWS = registros_productos.SelectedItems;
                    foreach(DataRowView row in ROWS)
                    {
                        msg += "* " + row["Producto"].ToString() + " --> " + row["Cantidad"].ToString()+"\n";
                        ids += row[0].ToString() + ",";
                    }
                    ids = ids.Remove(ids.Length - 1)+")";
                    tbl_borrar.Text = msg;
                }
                else if (registros_trabajos.SelectedItems.Count > 0)
                {
                    var ROWS = registros_trabajos.SelectedItems;
                    foreach (DataRowView row in ROWS)
                    {
                        msg += "* " + row["Personal"].ToString() + " --> " + row["Trabajo"].ToString() + "\n";
                        ids += row[0].ToString() + ",";
                    }
                    ids = ids.Remove(ids.Length - 1) + ")";
                    tbl_borrar.Text = msg;
                }
            }
        }

        private void registros_trabajos_Loaded(object sender, RoutedEventArgs e)
        {
            if (registros_trabajos.Columns.Count > 0)
            {
                registros_trabajos.Columns[0].Visibility = Visibility.Hidden;
            }
        }

        private void registros_productos_Loaded(object sender, RoutedEventArgs e)
        {
            if(registros_productos.Columns.Count>0)
            {
                registros_productos.Columns[0].Visibility = Visibility.Hidden;
            }
        }

        private void producto_no_Click(object sender, RoutedEventArgs e)
        {
            productoClear();
        }

        private void producto_yes_Click(object sender, RoutedEventArgs e)
        {
            errors = false;
            if(cbx_productos.SelectedIndex==-1)
            {
                errors = true;
                cbx_productos.BorderBrush = Brushes.Red;
            }
            else
                cbx_productos.BorderBrush = Brushes.Green;
            if (productos_cantidad.Value<=0)
            {
                errors = true;
                productos_cantidad.BorderBrush = Brushes.Red;
            }
            else
                productos_cantidad.BorderBrush = Brushes.Green;
            if(!errors)
            {
                MainWindow.CG.CM.QueryIn("INSERT INTO Ventas  (ID_Producto,Fecha,Hora,Cantidad) VALUES ("+cbx_productos.SelectedValue+",'"+ DateTime.Today.ToShortDateString()+ "','"+DateTime.Now.ToShortTimeString()+"',"+productos_cantidad.Value+");");
                productoClear();
                refreshProductos();
            }
        }

        private void borrar_no_Click(object sender, RoutedEventArgs e)
        {
            borrar.IsOpen = false;
        }

        private void borrar_yes_Click(object sender, RoutedEventArgs e)
        {
            
            if (registros_productos.SelectedItems.Count > 0)
            {
                MainWindow.CG.CM.QueryIn("DELETE FROM Ventas WHERE ID_Ventas IN"+ids);
                borrar.IsOpen = false;
                refreshProductos();
            }
            else
            {
                MainWindow.CG.CM.QueryIn("DELETE FROM Trabajos_Realizados WHERE ID_TR IN" + ids);
                borrar.IsOpen = false;
                refreshTrabajos();
            }
        }

        private void trabajo_ok_Click(object sender, RoutedEventArgs e)
        {
            errors = false;
            if (cbx_personal.SelectedIndex == -1)
            {
                errors = true;
                cbx_personal.BorderBrush = Brushes.Red;
            }
            else
                cbx_personal.BorderBrush = Brushes.Green;
            if (cbx_trabajos.SelectedIndex == -1)
            {
                errors = true;
                cbx_trabajos.BorderBrush = Brushes.Red;
            }
            else
                cbx_trabajos.BorderBrush = Brushes.Green;
            if(!errors)
            {
                MainWindow.CG.CM.QueryIn("INSERT INTO Trabajos_Realizados (Hora,Fecha,ID_Trabajo,ID_Empleado) VALUES ('" + DateTime.Now.ToShortTimeString() + "','" + DateTime.Today.ToShortDateString()+ "'," + cbx_trabajos.SelectedValue + "," + cbx_personal.SelectedValue + ");");
                trabajo.IsOpen=false;
                trabajoClear();
                refreshTrabajos();
            }
        }

        private void trabajo_cancel_Click(object sender, RoutedEventArgs e)
        {
            trabajo.IsOpen = false;
            trabajoClear();
        }

        private void registros_productos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            registros_trabajos.UnselectAll();
            producto.IsOpen = false;
            trabajo.IsOpen = false;
            borrar.IsOpen = false;
        }

        private void registros_trabajos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            registros_productos.UnselectAll();
            producto.IsOpen = false;
            trabajo.IsOpen = false;
            borrar.IsOpen = false;
        }
    }
}
