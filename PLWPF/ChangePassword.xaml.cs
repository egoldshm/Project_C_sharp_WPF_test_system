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
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public ChangePassword(User user = null)
        {
            InitializeComponent();
            if(user != null)
            {
                username.Text = user.Username;
                username.IsEnabled = false;
            }
        }

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
                    MainWindow.ErrorMessage("Password changed successfully.");
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
