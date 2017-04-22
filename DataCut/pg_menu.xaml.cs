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

namespace Datacut
{
    /// <summary>
    /// Interaction logic for pg_menu.xaml
    /// </summary>
    public partial class pg_menu : Page
    {
        public pg_menu()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CG.fm.Navigate(new pg_registros());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Cerrar session?", "DataCut", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                MainWindow.CG.fm.Navigate(new pg_login());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow.CG.fm.Navigate(new pg_ajustes());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //FM.Navigate(new pg_perfil(FM));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow.CG.fm.Navigate(new pg_registro_trabajos());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MainWindow.CG.fm.Navigate(new pg_registro_personal());
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MainWindow.CG.fm.Navigate(new pg_registro_productos());
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            MainWindow.CG.fm.Navigate(new pg_cortes());
        }
    }
}
