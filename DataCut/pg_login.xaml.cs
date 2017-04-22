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
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;
using MahApps.Metro.Controls;

namespace Datacut
{
    /// <summary>
    /// Interaction logic for pg_login.xaml
    /// </summary>
    public partial class pg_login : Page
    {
        int error_counter = 0;
        public pg_login()
        {
            InitializeComponent();
        }

        private void bt_login_iniciar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbx_login_username.Text != "" && pbx_login_password.Password != "")
                {
                    DataTable dt_temp = MainWindow.CG.CM.QueryOut(@"SELECT UserName,contraseña FROM Usuario WHERE UserName='" + tbx_login_username.Text + "'");
                    if (dt_temp.Rows.Count > 0)
                    {
                        if (tbx_login_username.Text == dt_temp.Rows[0][0].ToString() && pbx_login_password.Password == dt_temp.Rows[0][1].ToString())
                        {
                            MainWindow.CG.fm.Navigate(new pg_menu());
                        }
                        else
                        {
                            lb_login_error.Content = "Error  en usuario o contraseña";
                            error_counter++;
                        //    if (error_counter <= 3)
                        //    {
                        //        MailMessage mail = new MailMessage();
                        //        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                        //        mail.From = new MailAddress("datacutis@gmail.com");
                        //        mail.To.Add("galvan.cfj@gmail.com");
                        //        mail.Subject = "Intento de acceso no autorizado";
                        //        mail.Body = "Intento de acceso " + DateTime.Today.ToString("D");
                        //        // System.Net.Mail.Attachment attachment;
                        //        // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
                        //        // mail.Attachments.Add(attachment);
                        //        SmtpServer.Port = 587;
                        //        SmtpServer.Credentials = new System.Net.NetworkCredential("DataCutIS@gmail.com", "ingsoftware");
                        //        SmtpServer.EnableSsl = true;
                        //        SmtpServer.Send(mail);
                        //    }
                        }
                    }
                    else
                        lb_login_error.Content = "Error  en usuario o contraseña";
                }
                else
                    lb_login_error.Content = "Ingresa el usuario o contraseña";
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

        private void bt_login_salir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Seguro que quieres salir?", "Datacut", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
