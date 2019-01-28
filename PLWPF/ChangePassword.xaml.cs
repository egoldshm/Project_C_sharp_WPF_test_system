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
using System.Windows.Shapes;
using BE;
namespace PLWPF
{
    /// <summary>
    /// Window of change password panal.
    /// </summary>
    public partial class ChangePassword : Window
    {

        /// <summary>
        /// constractor of window of change password.
        /// </summary>
        /// <param name="user">User that only for him you can change the password</param>
        public ChangePassword(User user = null)
        {
            InitializeComponent();
            if(user != null)
            {
                username.Text = user.Username;
                username.IsEnabled = false;
            }
        }

        /// <summary>
        /// Event that start when change-password button clicked. and try to change than
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = factoryBL.FactoryBL.GetBL().GetUser(username.Text, OldPassword.Password);
            if(user == null)
            {
                MainWindow.ErrorMessage("username or password is valid. try again!");
            }
            else if (NewPassword.Password != NewPassword2.Password)
                {
                MainWindow.ErrorMessage("Make sure you've entered the same password twice");
                }
            else
            {
                bool done = factoryBL.FactoryBL.GetBL().ChangePassword(user, OldPassword.Password, NewPassword.Password);
                if(done)
                {
                    MessageBox.Show("Password changed successfully.");
                    string message = "";
                    switch (user.role)
                    {
                        case User.RoleTypes.Trainee:
                            message = " teacher";
                            break;
                        case User.RoleTypes.Teacher:
                            message = " school administrator";
                            break;
                        case User.RoleTypes.Tester:
                        case User.RoleTypes.School:
                            message = " contact at the Driving system";
                            break;
                        case User.RoleTypes.Admin:
                            message = "self";
                            break;
                    }
                    MailSender.MailSender.sendMail(user.EmailAddress, user.Username, "Driving system - Password changed alert",
                        "If it wasn't you who changed tyhe password, please contact your" + message);
                    this.Close();
                }
                else
                {
                    MainWindow.ErrorMessage("Something happened. Failed to change password.");
                }
            }
        }
    }
}
