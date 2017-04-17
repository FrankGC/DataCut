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
    /// Interaction logic for pg_registro_personal.xaml
    /// </summary>
    public partial class pg_registro_personal : Page
    {
        public pg_registro_personal()
        {
            InitializeComponent();
            cmb_idpuesto.DisplayMemberPath = "Descripcion";
            cmb_idpuesto.SelectedValuePath = "ID_Puesto";
            cmb_idpuesto.ItemsSource = MainWindow.CG.CM.QueryOut("SELECT * FROM Puestos").DefaultView;
            cmb_horario.DisplayMemberPath = "Horario";
            cmb_horario.SelectedValuePath = "ID_Horario";
            cmb_horario.ItemsSource = MainWindow.CG.CM.QueryOut("SELECT ID_Horario,CONVERT (VARCHAR(10), Hora_de_Entrada,8)+' -------- '+CONVERT (VARCHAR(10),Hora_de_Salida,8) AS Horario FROM Horarios").DefaultView;
            
            refresh();
        }

        private void refresh()
        {
            datagrid_PR_list.ItemsSource = MainWindow.CG.CM.QueryOut("SELECT ID_Empleado,Apellidos+' '+Nombre AS Personal FROM Personal WHERE Estado='Activo'").DefaultView;
        }

        private void btn_personal_back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CG.fm.GoBack();
        }

        private void btn_cancelarregistro_personal_Click(object sender, RoutedEventArgs e)
        {
            MenuItem_Click(sender, e);
        }

        private void clear()
        {
            tbx_apellidos_personal.Clear();
            tbx_CURP_personal.Clear();
            tbx_Domicilio_personal.Clear();
            tbx_nombre_personal.Clear();
            tbx_Telefono_personal.Clear();
        }

        private void btn_guardarregistro_personal_Click(object sender, RoutedEventArgs e)
        {
            if (tbx_apellidos_personal.Text!=""&&tbx_CURP_personal.Text!=""&&tbx_Domicilio_personal.Text!=""&&tbx_nombre_personal.Text!=""&&tbx_Telefono_personal.Text!="")
            {
                MainWindow.CG.CM.QueryIn("INSERT INTO Personal (Apellidos,Nombre,CURP,Tel,Domicilio,Estado,FDN,ID_Horario,ID_Puesto) VALUES ('"+tbx_apellidos_personal.Text+"','"+tbx_nombre_personal.Text+"','"+tbx_CURP_personal.Text+"','"+tbx_Telefono_personal.Text+"','"+tbx_Domicilio_personal.Text+"','Activo','"+DateTime.Today.Date+"',"+cmb_horario.SelectedValue.ToString()+","+cmb_idpuesto.SelectedValue.ToString()+")");
                cmb_horario.SelectedIndex = -1;
                cmb_idpuesto.SelectedIndex = -1;
                clear();
                refresh();
            }       
        }

        private void datagrid_PR_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var rows = datagrid_PR_list.SelectedItems;
            string empleados = "";
            foreach (DataRowView row in rows)
            {
                empleados += row["Personal"].ToString() + "\n";
            }
            if (MessageBox.Show("Quieres eliminar a: \n" + empleados, "DataCut", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (DataRowView ROW in rows)
                {
                    MainWindow.CG.CM.QueryIn("UPDATE Personal SET Estado = 'Inactivo', FDC='" + DateTime.Today.ToShortDateString() + "' WHERE ID_Empleado=" + ROW["ID_Empleado"].ToString());
                }
                refresh();
            }
        }
    }
}
