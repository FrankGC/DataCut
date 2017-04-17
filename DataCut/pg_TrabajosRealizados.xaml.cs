using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for pg_TrabajosRealizados.xaml
    /// </summary>
    public partial class pg_TrabajosRealizados : Page
    {
        public pg_TrabajosRealizados()
        {
            InitializeComponent();
            
            cbx_TR_empleado.DisplayMemberPath = "Nombre";
            cbx_TR_empleado.SelectedValuePath = "ID_Empleado";
            cbx_TR_empleado.ItemsSource = MainWindow.CG.CM.QueryOut("SELECT Nombre,ID_Empleado FROM Personal").DefaultView;
            cbx_TR_trabajo.DisplayMemberPath = "Descripcion";
            cbx_TR_trabajo.SelectedValuePath = "ID_Trabajo";
            cbx_TR_trabajo.ItemsSource = MainWindow.CG.CM.QueryOut("SELECT Descripcion,ID_Trabajo FROM Trabajo").DefaultView;          
            refres_data();
        }

        private void refres_data()
        {
            datagrid_TR_list.ItemsSource = MainWindow.CG.CM.QueryOut("SELECT ID_TR,Trabajos_Realizados.ID_Empleado,Trabajos_Realizados.ID_Trabajo,Trabajo.Descripcion AS Trabajo, CAST(Apellidos AS varchar)+' '+Nombre AS 'Empleado',Hora,Fecha  FROM Trabajo,Trabajos_Realizados,Personal WHERE Trabajos_Realizados.ID_Empleado = Personal.ID_Empleado AND Trabajos_Realizados.ID_Trabajo = Trabajo.ID_Trabajo").DefaultView;
 
        }

        private void bt_TR_ok_Click(object sender, RoutedEventArgs e)
        {
            if(cbx_TR_empleado.SelectedIndex!=-1 && cbx_TR_trabajo.SelectedIndex!=-1)
            {
                MainWindow.CG.CM.QueryIn("INSERT INTO Trabajos_Realizados (Hora,Fecha,ID_Trabajo,ID_Empleado) VALUES ('" + DateTime.Now.ToString("hh:mm:ss") + "','" + DateTime.Today.ToString("d") + "'," + cbx_TR_trabajo.SelectedValue.ToString() + "," + cbx_TR_empleado.SelectedValue.ToString() + ");");
                cbx_TR_empleado.SelectedIndex = -1;
                cbx_TR_trabajo.SelectedIndex = -1;
                refres_data();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var table = datagrid_TR_list.SelectedItems;
            string trabajos = "";
            foreach (DataRowView row in table)
            {
                trabajos += "Id de trabajo ==> " + row["ID_TR"]+"  Trabajo ==> "+row["Trabajo"]+"\n";
            }
            if (MessageBox.Show("Seguro que quieres borrar los trabajos: \n\n"+trabajos,"DataCut",MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
                
                foreach (DataRowView ROW in table)
                {
                    MainWindow.CG.CM.QueryIn("DELETE FROM Trabajos_Realizados WHERE ID_TR=" + ROW["ID_TR"].ToString());
                }
                refres_data();
            }
        }

        private void bt_TR_eliminar_Click(object sender, RoutedEventArgs e)
        {
            MenuItem_Click(sender, e);
        }
    }
}
