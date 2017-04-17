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

namespace DataCut
{
    /// <summary>
    /// Interaction logic for pg_registros.xaml
    /// </summary>
    public partial class pg_registros : Page
    {
        bool pg_trabajosRealizados = true;
        public string fecha;
        public pg_registros()
        {
            InitializeComponent();
            bt_registros_productos.Opacity = 0.3;
            fecha = DateTime.Today.ToShortDateString();
        }

        private void Page_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void tb_registros_tr_realizados_Click(object sender, RoutedEventArgs e)
        {
            if(pg_trabajosRealizados==false)
            {
                bt_registros_productos.Opacity = 0.3;
                bt_registros_tr_realizados.Opacity = 0.9;
                pg_trabajosRealizados = true;
                fm_registros.Navigate(new pg_TrabajosRealizados());
            }
        }

        private void tb_registros_productos_Click(object sender, RoutedEventArgs e)
        {
            if (pg_trabajosRealizados == true)
            {
                bt_registros_productos.Opacity = 0.9;
                bt_registros_tr_realizados.Opacity = 0.3;
                pg_trabajosRealizados = false;
                fm_registros.Navigate(new pg_ProductosVendidos());
            }
        }

        private void bt_registros_menu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt_registros_back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CG.fm.Navigate(new pg_menu());
        }
    }
}
