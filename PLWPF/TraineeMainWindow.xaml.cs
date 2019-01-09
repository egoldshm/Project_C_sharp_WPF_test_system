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
        Ibl.IBL bl = factoryBL.FactoryBL.GetBL();
        Trainee trainee;
        public TraineeMainWindow(User user)
        {
            InitializeComponent();
            if(user.role == User.RoleTypes.Admin)
            {
                trainee = user.ConnectTo as Trainee;
                title.user = user;
                if(trainee == null)
                {
                    throw new Exception("worng user sended to trainee");
                }
            }
            else if(user.role != User.RoleTypes.Trainee || !(user.ConnectTo is Trainee))
            {
                throw new Exception("worng user sended to trainee");
            }
            else
                trainee = new Trainee(user.ConnectTo as Trainee);
            
            details.DataContext = trainee;
            updateTrainee_uc.Trainee = trainee;
            updateTrainee_uc.idTextBox.IsEnabled = false;
            updateTrainee_uc.button.Click += updateTrainee_click;
            if (bl.GetAllTraineesByLicense(true).Exists(_trainee => _trainee.Id == trainee.Id))
            {
                testFuture.Content = "view the test you passed";
            }
            else
            {
                if (bl.GetTestsByTrainee(trainee).Count == 0 || bl.GetTestsByTrainee(trainee).Last().Criterions.Criterions.TrueForAll(criterion => criterion.Mode != CriterionMode.NotDetermined))
                {
                    testFuture.Header = "add test";
                }
                else
                {
                    testFuture.Header = "view test";
                }

            }
            title.user = user;
        }

        private void updateTrainee_click(object sender, RoutedEventArgs e)
        {
            trainee = bl.GetTraineeById(trainee.Id);
            details.DataContext = trainee;
            updateTrainee_uc.Trainee = trainee;
            MessageBox.Show("trainee updated successfully");
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
