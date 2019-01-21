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
using BE;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    /// 
    
    public partial class AddUser : UserControl
    {
        User.RoleTypes? role = null;
        Ibl.IBL bl = factoryBL.FactoryBL.GetBL();
        public AddUser()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(role == null)
            {
                MainWindow.ErrorMessage("choose role");
                return;
            }
            try
            {
                bool empty = false;
                if (adminRadio.IsChecked == false && items.SelectionBoxItem.ToString() == string.Empty)
                {
                    empty = true;
                }
                if (Username.Text == string.Empty)
                {
                    empty = true;
                    Username.Background = new SolidColorBrush(Colors.Red);
                }
                if (password.Password == string.Empty)
                {
                    empty = true;
                    password.Background = new SolidColorBrush(Colors.Red);
                }
                if (empty)
                    MainWindow.ErrorMessage("one or more from the nessery box empty");
                else
                {
                    bl.CreateUser(Username.Text, password.Password, (User.RoleTypes)role, items.SelectionBoxItem);
                    Username.Text = string.Empty;
                    password.Password = string.Empty;
                    MessageBox.Show("successe", "new user created successfully",MessageBoxButton.OK,MessageBoxImage.Information);
                }
            }
            catch(Exception ex)
            {
                MainWindow.ErrorMessage(ex.Message);
            }
        }

        private void TraineeRadio_Checked(object sender, RoutedEventArgs e)
        {
            role = User.RoleTypes.Trainee;
            showComobox();
            items.ItemsSource = bl.GetAllTrainees();
            chooseType.Content = "choose trainee:";
        }

        private void showComobox()
        {
            items.Visibility = Visibility.Visible;
            chooseType.Visibility = Visibility.Visible;
        }

        private void AdminRadio_Checked(object sender, RoutedEventArgs e)
        {
            role = User.RoleTypes.Admin;
            items.Visibility = Visibility.Hidden;
            chooseType.Visibility = Visibility.Hidden;
        }

        private void TesterRadion_Checked(object sender, RoutedEventArgs e)
        {
            role = User.RoleTypes.Tester;
            showComobox();
            items.ItemsSource = bl.GetAllTesters();
            chooseType.Content = "choose tester:";
        }

        private void TeacherRadion_Checked(object sender, RoutedEventArgs e)
        {
            role = User.RoleTypes.Teacher;
            showComobox();
            items.ItemsSource = bl.GetTraineesByTeacher().Select((group) => group.First().TeacherName);
            chooseType.Content = "choose teacher:";
        }

        private void SchoolRadion_Checked(object sender, RoutedEventArgs e)
        {
            role = User.RoleTypes.School;
            showComobox();
            items.ItemsSource = bl.GetTraineesBySchoolName().Select((group) => group.First().SchoolName);
            chooseType.Content = "choose school name:";
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            Username.Background = null;
        }

        private void Password_PasswordChanged_1(object sender, EventArgs e)
        {
            password.Background = null;
        }
    }
}
