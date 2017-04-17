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
    /// Interaction logic for pg_registro_trabajos.xaml
    /// </summary>
    public partial class pg_registro_trabajos : Page
    {
        public pg_registro_trabajos()
        {
            InitializeComponent();
            refresh();
        }
        private void clear()
        {
            tbx_comision_trabajos.Clear();
            tbx_nombre_trabajo.Clear();
            tbx_precio_trabajos.Clear();
        }
        private void refresh()
        {
            datagrid_TR_list.ItemsSource = MainWindow.CG.CM.QueryOut("SELECT * FROM Trabajo").DefaultView;
        }

        private void btn_cancelarregistro_trabajos_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void btn_personal_back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CG.fm.GoBack();
        }

        private void btn_guardarregistro_trabajos_Click(object sender, RoutedEventArgs e)
        {
            double precio=0;
            try {  precio = int.Parse(tbx_precio_trabajos.Text); } catch { }
            if(tbx_comision_trabajos.Text!=""&& tbx_nombre_trabajo.Text!="" && tbx_precio_trabajos.Text!="")
            {
                MainWindow.CG.CM.QueryIn("INSERT INTO Trabajo (Descripcion,Costo,Comision) VALUES ('" + tbx_nombre_trabajo.Text + "'," + precio + "," + tbx_comision_trabajos.Text + ")");
                refresh();
                clear();
            }
            
        }
    }
}
