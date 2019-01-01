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
using Ibl;
using System.Text.RegularExpressions;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for CreatNewTraineeUser.xaml
    /// </summary>
    public partial class CreatNewTraineeUser : Window
    {
        IBL bl = factoryBL.FactoryBL.GetBL();
        public CreatNewTraineeUser()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            buttons.Visibility = Visibility.Collapsed;
            create1.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string id = inputId.Text;
            string username = inputUsername.Text;
            string password = inputPassword.Password;
            Trainee trainee = bl.GetTraineeById(int.Parse(id));
            if(trainee == null)
            {
                MessageBox.Show(string.Format("Trainee with id {0} not found.", id));
                clearTestsBox();
            }
            else
            {
                if (!bl.CreateUser(username, password, User.RoleTypes.Trainee, trainee))
                {
                    MessageBox.Show(string.Format("Trainee with username {0} already exist.", username));
                    clearTestsBox();
                }
                else
                {
                    MessageBox.Show("user created");
                    this.Close();
                }
            }
        }

        private void clearTestsBox()
        {
            inputUsername.Text = "";
            inputPassword.Password = "";
            inputId.Text = "";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
