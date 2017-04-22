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
    /// Interaction logic for pg_cortes.xaml
    /// </summary>
    public partial class pg_cortes : Page
    {
        public pg_cortes()
        {
            InitializeComponent();
            tp_inicio.SelectedDate = DateTime.Today.Date;
            tp_fin.SelectedDate = DateTime.Today.Date;
            refreshCortes();
            refreshVentas();
            Total();
            
        }

        private void Total()
        {
            if(lista_trabajos.Columns.Count>0 && lista_productos.Columns.Count>0)
            {
                float total_trabajos =0,total_comision=0,ventas=0;
                foreach (DataRowView row in lista_trabajos.ItemsSource)
                {
                    total_comision += float.Parse(row[2].ToString());
                    total_trabajos += float.Parse(row[3].ToString());
                }
                foreach (DataRowView row in lista_productos.ItemsSource)
                {
                    ventas += float.Parse(row[3].ToString());
                }
                t_trabajos.Text = "$ " + total_trabajos.ToString();
                t_comision.Text = "$" + total_comision.ToString();
                t_ventas.Text = "$" + ventas.ToString();
                t_ganancias.Text = "$" + (total_trabajos - total_comision + ventas).ToString();
            }
        }

        private void showFlyout(Flyout f)
        {
            fly_corte.IsOpen = false;
            fly_trabajos.IsOpen = false;
            if (!f.IsOpen)
                f.IsOpen = true;
        }

        private void refreshVentas()
        {
            try
            {
                DataTable tmp = MainWindow.CG.CM.QueryOut(" SELECT Ventas.ID_Producto,NombrePro AS Producto,SUM (Cantidad) AS Cantidad,SUM(Precio*Cantidad) AS Total FROM Ventas,Productos WHERE Ventas.ID_Producto=Productos.ID_Producto AND Fecha BETWEEN '" + tp_inicio.SelectedDate.Value.ToString("d") + "' AND '" + tp_fin.SelectedDate.Value.ToString("d") + "' GROUP BY Ventas.ID_Producto,NombrePro");
                lista_productos.ItemsSource = tmp.DefaultView;
                if (lista_productos.Columns.Count > 0)
                {
                    lista_productos.Columns[0].Visibility = Visibility.Hidden;
                    Total();
                }
                    
            }catch { }
        }

        private void refreshCortes()
        {
            try
            {
                DataTable tmp = MainWindow.CG.CM.QueryOut("SELECT Personal.ID_Empleado,(Apellidos+' '+Nombre),SUM(Comision)AS Comision,SUM(Precio) AS Total FROM Personal,Trabajo,Trabajos_Realizados WHERE Trabajos_Realizados.ID_Trabajo=Trabajo.ID_Trabajo AND Personal.ID_Empleado=Trabajos_Realizados.ID_Empleado AND Fecha BETWEEN '" + tp_inicio.SelectedDate.Value.ToString("d") + "' AND '" + tp_fin.SelectedDate.Value.ToString("d") + "' GROUP BY Personal.ID_Empleado,(Apellidos+' '+Nombre)");
                lista_trabajos.ItemsSource = tmp.DefaultView;
                if (lista_trabajos.Columns.Count > 0)
                {
                    lista_trabajos.Columns[0].Visibility = Visibility.Hidden;
                    Total();
                }
            
            }
            catch { }
        }

        private void bt_guardar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_corte_Click(object sender, RoutedEventArgs e)
        {
            showFlyout(fly_corte);
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CG.fm.GoBack();
        }

        private void bt_corte_ok_Click(object sender, RoutedEventArgs e)
        {
            refreshCortes();
            refreshVentas();
            fly_corte.IsOpen = false;
        }

        private void bt_corte_cancelar_Click(object sender, RoutedEventArgs e)
        {
            fly_corte.IsOpen = false;
        }

        private void lista_trabajos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lista_trabajos.SelectedItems.Count==1)
            {
                DataRowView row = (DataRowView)lista_trabajos.SelectedItem;
                lista.ItemsSource = MainWindow.CG.CM.QueryOut("SELECT Descripcion AS Trabajo, Precio FROM Personal, Trabajo, Trabajos_Realizados WHERE Trabajos_Realizados.ID_Trabajo = Trabajo.ID_Trabajo AND Personal.ID_Empleado = Trabajos_Realizados.ID_Empleado AND Personal.ID_Empleado=" + row[0] + "AND Fecha BETWEEN '" + tp_inicio.SelectedDate.Value.ToString("d") + "' AND '" + tp_fin.SelectedDate.Value.ToString("d") + "'").DefaultView;
                showFlyout(fly_trabajos);
                DataRowView r = (DataRowView)lista_trabajos.SelectedItem;
                lista_nombre.Text = row[1].ToString();
                lista_count.Text = "Trabajos realizados: " + (lista.Items.Count-1).ToString();
                lista_comision.Text = "Comision: " + row[2].ToString();
                lista_total.Text = "Total: " + row[3].ToString();

            }
            
        }

        private void lista_productos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

        private void lista_productos_Loaded(object sender, RoutedEventArgs e)
        {
            if (lista_productos.Columns.Count > 0)
            {
                lista_productos.Columns[0].Visibility = Visibility.Hidden;
                Total();
            }
               
        }

        private void lista_trabajos_Loaded(object sender, RoutedEventArgs e)
        {
            if (lista_trabajos.Columns.Count > 0)
            {
                lista_trabajos.Columns[0].Visibility = Visibility.Hidden;
            }
        }

        private void lista_Loaded(object sender, RoutedEventArgs e)
        {
            if(lista.Columns.Count>0)
            {
                lista.Columns[1].Visibility = Visibility.Hidden;
            }
        }
    }
}
