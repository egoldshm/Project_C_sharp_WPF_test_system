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
            inputId.ItemsSource = bl.GetAllTrainees().Select(trainee => trainee.Id);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string id = inputId.SelectionBoxItem.ToString();
            string username = inputUsername.Text;
            string password = inputPassword.Password;
            if (id == string.Empty || username == string.Empty || password == string.Empty || mail.Text == string.Empty)
            {
                messageError.Content = "input box one or more empty";
                return;
            }
            Trainee trainee = bl.GetTraineeById(int.Parse(id));
            if(trainee == null)
            {
                messageError.Content = $"Trainee with id {id} not found.";
                clearTestsBox();
            }
            else
            {
                if (!bl.CreateUser(username, password, User.RoleTypes.Trainee, trainee, mail.Text))
                {
                    messageError.Content = $"Trainee with username {username} already exist.";
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

        private void mail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsValidEmailAddress(mail.Text))
                createUser.IsEnabled = true;
            else
                createUser.IsEnabled = false;
        }
    }
}
