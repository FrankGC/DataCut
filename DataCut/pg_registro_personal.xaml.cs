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
using MahApps.Metro.Controls;

namespace Datacut
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
            idpuesto.DisplayMemberPath = "Descripcion";
            idpuesto.SelectedValuePath = "ID_Puesto";
            DataTable tmp = MainWindow.CG.CM.QueryOut("SELECT * FROM Puestos");
            cmb_idpuesto.ItemsSource = tmp.DefaultView;
            idpuesto.ItemsSource = tmp.DefaultView;
            cmb_horario.DisplayMemberPath = "Horario";
            cmb_horario.SelectedValuePath = "ID_Horario";
            horario.DisplayMemberPath = "Horario";
            horario.SelectedValuePath = "ID_Horario";
            tmp = MainWindow.CG.CM.QueryOut("SELECT ID_Horario,CONVERT (VARCHAR(5), Hora_de_Entrada)+' - '+CONVERT(VARCHAR(5),Hora_de_Salida) AS Horario FROM Horarios");
            cmb_horario.ItemsSource = tmp.DefaultView;
            horario.ItemsSource = tmp.DefaultView;
            refresh();
            NV_personal.IsOpen = false;
            PR_personal.IsOpen = false;
        }

        private void refresh()
        {
            if (activos.IsChecked == false)
                try { datagrid_PR_list.ItemsSource = MainWindow.CG.CM.QueryOut("SELECT ID_Empleado,Personal.ID_Puesto,Personal.ID_Horario,Nombre,Apellidos,Puestos.Descripcion AS Puesto,(CONVERT(varchar(5),Hora_de_Entrada)+' - '+CONVERT(varchar(5),Hora_de_Salida)) AS Horario,Tel as Telefono,Domicilio,CURP,CONVERT(VARCHAR(10),FDN) AS FDN,CONVERT(VARCHAR(10),FDC) AS FDC FROM Personal,Horarios,Puestos WHERE Personal.ID_Horario = Horarios.ID_Horario AND Puestos.ID_Puesto=Personal.ID_Puesto AND Estado='Activo'").DefaultView; } catch { }
            else
                try { datagrid_PR_list.ItemsSource = MainWindow.CG.CM.QueryOut("SELECT ID_Empleado,Personal.ID_Puesto,Personal.ID_Horario,Nombre,Apellidos,Puestos.Descripcion AS Puesto,(CONVERT(varchar(5),Hora_de_Entrada)+' - '+CONVERT(varchar(5),Hora_de_Salida)) AS Horario,Tel as Telefono,Domicilio,CURP,CONVERT(VARCHAR(10),FDN) AS FDN,CONVERT(VARCHAR(10),FDC) AS FDC,Estado FROM Personal,Horarios,Puestos WHERE Personal.ID_Horario = Horarios.ID_Horario AND Puestos.ID_Puesto=Personal.ID_Puesto AND Estado='Inactivo'").DefaultView; } catch { }
            hide_columns();
        }

        private void hide_columns()
        {
            if (datagrid_PR_list.Columns.Count > 0)
            {
                datagrid_PR_list.Columns[0].Visibility = Visibility.Hidden;
                datagrid_PR_list.Columns[1].Visibility = Visibility.Hidden;
                datagrid_PR_list.Columns[2].Visibility = Visibility.Hidden;
            }
        }

        private void btn_personal_back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CG.fm.GoBack();
        }

        private void btn_cancelarregistro_personal_Click(object sender, RoutedEventArgs e)
        {
            clear();
            NV_personal.IsOpen = false;
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
            bool erros = false;
            if (tbx_nombre_personal.Text == "")
            {
                tbx_nombre_personal.BorderBrush = Brushes.Red;
                erros = true;
            }
            else
                tbx_nombre_personal.BorderBrush = Brushes.Green;
            if (tbx_apellidos_personal.Text == "")
            {
                tbx_apellidos_personal.BorderBrush = Brushes.Red;
                erros = true;
            }
            else
                tbx_apellidos_personal.BorderBrush = Brushes.Green;
            if (tbx_CURP_personal.Text == "")
            {
                tbx_CURP_personal.BorderBrush = Brushes.Red;
                erros = true;
            }
            else
                tbx_apellidos_personal.BorderBrush = Brushes.Green;
            if (tbx_Telefono_personal.Text == "")
            {
                tbx_Telefono_personal.BorderBrush = Brushes.Red;
                erros = true;
            }
            else
                tbx_Telefono_personal.BorderBrush = Brushes.Green;
            if (tbx_Domicilio_personal.Text == "")
            {
                tbx_Domicilio_personal.BorderBrush = Brushes.Red;
                erros = true;
            }
            else
                tbx_Domicilio_personal.BorderBrush = Brushes.Green;
            if (cmb_horario.SelectedIndex == -1)
            {
                erros = true;
                cmb_horario.BorderBrush = Brushes.Red;
            }
            else
                cmb_horario.BorderBrush = Brushes.Green;
            if (cmb_idpuesto.SelectedIndex == -1)
            {
                erros = true;
                cmb_idpuesto.BorderBrush = Brushes.Red;
            }
            else
                cmb_idpuesto.BorderBrush = Brushes.Green;
            if (!erros)
            {
                MainWindow.CG.CM.QueryIn("INSERT INTO Personal (Apellidos,Nombre,CURP,Tel,Domicilio,Estado,FDN,FDC, ID_Horario,ID_Puesto) VALUES ('" + tbx_apellidos_personal.Text + "','" + tbx_nombre_personal.Text + "','" + tbx_CURP_personal.Text + "','" + tbx_Telefono_personal.Text + "','" + tbx_Domicilio_personal.Text + "','Activo','" + DateTime.Today.ToShortDateString() + "','" + DateTime.Today.ToShortDateString() + "'," + cmb_horario.SelectedValue.ToString() + "," + cmb_idpuesto.SelectedValue.ToString() + ")");
                cmb_horario.SelectedIndex = -1;
                cmb_idpuesto.SelectedIndex = -1;
                NV_personal.IsOpen = false;
                clear();
                refresh();
            }
        }

        private void datagrid_PR_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PR_personal.IsOpen = false;
            NV_personal.IsOpen = false;
            personal.IsOpen = false;
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid_PR_list.SelectedItems.Count > 0)
            {
                listar_empleados();
                active_flyout(PR_personal);
            }
        }

        private void NV_empleado_Click(object sender, RoutedEventArgs e)
        {
            active_flyout(NV_personal);
        }

        string ids = "";
        private void listar_empleados()
        {
            ids = "(";
            var rows = datagrid_PR_list.SelectedItems;
            string empleados = " Eliminar: \n";
            foreach (DataRowView row in rows)
            {
                empleados += "* " + row["Apellidos"].ToString() + " " + row["Nombre"] + "\n";
                ids += row["ID_Empleado"].ToString() + ",";
            }
            ids = ids.Remove(ids.Length - 1) + ")";
            tbl_pegunta.Text = empleados;
        }

        private void ELI_empleado_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid_PR_list.SelectedItems.Count > 0)
            {
                listar_empleados();
                active_flyout(PR_personal);

            }
        }

        private void btn_yes_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CG.CM.QueryIn("DELETE FROM Personal WHERE ID_Empleado in "+ids);
            PR_personal.IsOpen = false;          
            refresh();
        }

        private void active_flyout(Flyout activa)
        {
            PR_personal.IsOpen = false;
            NV_personal.IsOpen = false;
            personal.IsOpen = false;
            if (activa.IsOpen != true)
                activa.IsOpen = true;
        }

        private void btn_no_Click(object sender, RoutedEventArgs e)
        {
            PR_personal.IsOpen = false;
            tbl_pegunta.Text = "";
        }

        private void datagrid_PR_list_Loaded(object sender, RoutedEventArgs e)
        {
            hide_columns();
        }

        private void activos_IsCheckedChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid_PR_list.SelectedItems.Count == 1)
            {
                DataRowView tmp = (DataRowView)datagrid_PR_list.SelectedItems[0];
                nombre.Text = tmp["Nombre"].ToString();
                apellidos.Text = tmp["Apellidos"].ToString();
                CURP.Text = tmp["CURP"].ToString();
                telefono.Text = tmp["Telefono"].ToString();
                domicilio.Text = tmp["Domicilio"].ToString();
                idpuesto.SelectedValue = (int)tmp["ID_Puesto"];
                horario.SelectedValue = (int)tmp["ID_Horario"];
                if (activos.IsChecked == true)
                    estado.SelectedIndex = 1;
                else
                    estado.SelectedIndex = 0;
                active_flyout(personal);
            }
        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            personal.IsOpen = false;
        }

        private void actualizar_Click(object sender, RoutedEventArgs e)
        {
            bool erros = false;
            if (nombre.Text == "")
            {
                nombre.BorderBrush = Brushes.Red;
                erros = true;
            }
            else
                nombre.BorderBrush = Brushes.Green;
            if (apellidos.Text == "")
            {
                apellidos.BorderBrush = Brushes.Red;
                erros = true;
            }
            else
                apellidos.BorderBrush = Brushes.Green;
            if (CURP.Text == "")
            {
                CURP.BorderBrush = Brushes.Red;
                erros = true;
            }
            else
                CURP.BorderBrush = Brushes.Green;
            if (telefono.Text == "")
            {
                telefono.BorderBrush = Brushes.Red;
                erros = true;
            }
            else
                telefono.BorderBrush = Brushes.Green;
            if (domicilio.Text == "")
            {
                domicilio.BorderBrush = Brushes.Red;
                erros = true;
            }
            else
                domicilio.BorderBrush = Brushes.Green;
            if (horario.SelectedIndex == -1)
            {
                erros = true;
                horario.BorderBrush = Brushes.Red;
            }
            else
                horario.BorderBrush = Brushes.Green;
            if (idpuesto.SelectedIndex == -1)
            {
                erros = true;
                idpuesto.BorderBrush = Brushes.Red;
            }
            else
                idpuesto.BorderBrush = Brushes.Green;
            if (!erros)
            {
                personal.IsOpen = false;
                DataRowView tmp = (DataRowView)datagrid_PR_list.SelectedItem;
                if(estado.SelectedIndex==0)
                MainWindow.CG.CM.QueryIn("UPDATE Personal  SET Apellidos=  '" + apellidos.Text + "' ,Nombre = '" + nombre.Text + "' ,CURP = '" + CURP.Text + "' ,Tel = '" + telefono.Text + "',Domicilio ='" + domicilio.Text + "',ID_Horario =" + horario.SelectedValue.ToString() + ",Estado = 'Activo',ID_Puesto= " + idpuesto.SelectedValue.ToString()+" WHERE ID_Empleado="+tmp["ID_Empleado"].ToString());
                else
                    MainWindow.CG.CM.QueryIn("UPDATE Personal  SET Apellidos=  '" + apellidos.Text + "' ,Nombre = '" + nombre.Text + "' ,CURP = '" + CURP.Text + "' ,Tel = '" + telefono.Text + "',Domicilio ='" + domicilio.Text + "',ID_Horario =" + horario.SelectedValue.ToString() + ",Estado = 'Inactivo',ID_Puesto= " + idpuesto.SelectedValue.ToString() + " WHERE ID_Empleado=" + tmp["ID_Empleado"].ToString());
                refresh();
            }

        }
    }
}
