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
using System.Timers;


namespace DataCut
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ClasseGlobal CG = new ClasseGlobal();
        public MainWindow()
        {
            InitializeComponent();
            CG.fm = fm;
            ConeccionSQL SQL = new ConeccionSQL();
            if (SQL.Conectar())
            {
                CG.CM = SQL;
                fm.Navigate(new pg_login());
            }
            else
                fm.Navigate(new pg_error());
        }
       
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
