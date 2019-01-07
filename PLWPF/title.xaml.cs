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
    /// Interaction logic for title.xaml
    /// </summary>
    public partial class title : UserControl
    {
        Ibl.IBL bl = factoryBL.FactoryBL.GetBL();
        User _user;
        public title()
        {
            InitializeComponent();
        }

        public User user { get => _user; set 
                { _user = value;
                role.Content = user.role.ToString().ToLower();
                switch (user.role)
                {
                    case User.RoleTypes.Trainee:
                        var trainee = (user.ConnectTo as Trainee);
                        welcomeMessage.Content = trainee.FirstName + " " + trainee.FamilyName;
                        if (bl.GetAllTraineesByLicense(true).Exists(_trainee => _trainee.Id == trainee.Id))
                        {
                            LicenseLable.Content = "you have License!";
                            LicenseLable.Foreground = new SolidColorBrush(Colors.Green);
                        }
                        break;
                    case User.RoleTypes.Teacher:
                    case User.RoleTypes.School:
                        welcomeMessage.Content = user.ConnectTo as string;
                        break;
                    case User.RoleTypes.Tester:
                        welcomeMessage.Content = (user.ConnectTo as Tester).FirstName + " " + (user.ConnectTo as Tester).LastName;
                        break;
                    case User.RoleTypes.Admin:
                        welcomeMessage.Content = user.Username;
                        if(user.ConnectTo != null)
                        {
                            if (user.ConnectTo is Trainee)
                                role.Content = role.Content + " As Trainee";
                            if (user.ConnectTo is Tester)
                                role.Content = role.Content + " As Tester";
                            if (user.ConnectTo is string && bl.GetAllTrainees().Any(t => t.SchoolName == user.ConnectTo.ToString()))
                                role.Content = role.Content + " As School";
                            if (user.ConnectTo is string && bl.GetAllTrainees().Any(t => t.TeacherName == user.ConnectTo.ToString()))
                                role.Content = role.Content + " As Teacher";
                        }
                        break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            MainWindow window = new MainWindow();
            window.Show();
            parentWindow.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(user);
            changePassword.ShowDialog();
        }
    }
}