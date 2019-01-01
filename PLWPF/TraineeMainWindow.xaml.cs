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
using Ibl;
using BE;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for TraineeMainWindow.xaml
    /// </summary>
    public partial class TraineeMainWindow : Window
    {
        readonly Trainee trainee;
        public TraineeMainWindow(User user, IBL bl)
        {
            InitializeComponent();
            if(user.role != User.RoleTypes.Trainee || !(user.ConnectTo is Trainee))
            {
                throw new Exception("worng user sended to trainee");
            }
            trainee = new Trainee(user.ConnectTo as Trainee);
            details.DataContext = trainee;
            if (bl.GetAllTraineesByLicense(true).Exists(_trainee => _trainee.Id == trainee.Id))
            {
                testFuture.Content = "view the test you passed";
                LicenseLable.Content = "you have License!";
                testFuture.Click += viewTestYouPassed;
                LicenseLable.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                if (bl.GetTestsByTrainee(trainee).Count == 0 || bl.GetTestsByTrainee(trainee).Last().Criterions.Criterions.TrueForAll(criterion => criterion.Mode != CriterionMode.NotDetermined))
                {
                    testFuture.Content = "add test";
                    testFuture.Click += addTestToTrainee;
                }
                else
                {
                    testFuture.Content = "view test";
                    testFuture.Click += viewTest;
                }

            }
            welcomeMessage.Content = "Welcome " + trainee.FirstName + " " + trainee.FamilyName;
        }

        private void viewTest(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void viewTestYouPassed(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void addTestToTrainee(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
