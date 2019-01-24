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
            if (id == "" || username == "" || password == "")
            {
                MainWindow.ErrorMessage("input box one or more empty");
                return;
            }
            Trainee trainee = bl.GetTraineeById(int.Parse(id));
            if(trainee == null)
            {
                MainWindow.ErrorMessage(string.Format("Trainee with id {0} not found.", id));
                clearTestsBox();
            }
            else
            {
                if (!bl.CreateUser(username, password, User.RoleTypes.Trainee, trainee, mail.Test))
                {
                    MainWindow.ErrorMessage(string.Format("Trainee with username {0} already exist.", username));
                    clearTestsBox();
                }
                else
                {
                    MainWindow.ErrorMessage("user created");
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            createTrainee.Visibility = Visibility.Visible;
            buttons.Visibility = Visibility.Hidden;
            addTraineeUsercontol.traineeAdded += AddTraineeUsercontol_traineeAdded;
            this.MinHeight += 50;
            this.Height += 50;
        }

        public static bool IsValidEmailAddress(string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }

        private void AddTraineeUsercontol_traineeAdded(object sender, EventArgs e)
        {
            createTrainee.Visibility = Visibility.Hidden;
            create1.Visibility = Visibility.Visible;
            this.MinHeight -= 30;
            this.MaxHeight -= 80;
            this.Height -= 30;
            MainWindow.ErrorMessage("the trainee created. you can register now as user");
        }

    }
}
