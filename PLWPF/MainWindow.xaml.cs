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
using Ibl;
using BE;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl = factoryBL.FactoryBL.GetBL();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = this.UserName.Text;
            string InputPassword = this.password.Password;
            User user = bl.GetUser(username, InputPassword);
            if(user == null)
            {
                this.UserName.Text = "";
                password.Password = "";
                MessageBox.Show("user name of password invaild");
            }
            else
            {
                switch (user.role)
                {
                    case User.RoleTypes.Trainee:
                        //show trainee window
                        break;
                    case User.RoleTypes.Teacher:
                        //show teacher window
                        break;
                    case User.RoleTypes.Tester:
                        //show tester window
                        break;
                    case User.RoleTypes.School:
                        //show school window
                        break;
                    case User.RoleTypes.Admin:
                        //show admin window
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
