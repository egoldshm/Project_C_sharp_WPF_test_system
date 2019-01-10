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
    public partial class AdminMainWindow : Window
    {
        IBL bl = factoryBL.FactoryBL.GetBL();
        public AdminMainWindow(User user)
        {
            if (user.role != User.RoleTypes.Admin)
            {
                throw new Exception("user isn't admin");
            }
            InitializeComponent();
            title.user = user;
            loginas.User = user;
            ViewTest.AllTests = bl.GetAllTests();
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

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(view.IsSelected)
            {
                viewTestersUsercontrol.initializeData();
                viewTraineeUserconrol.initializeData();
                ViewTest.AllTests = bl.GetAllTests();
            }
           if(delete.IsSelected)
            {
                deleteTester_uc.initializeData();
                deleteTrainee_uc.initializeData();
            }
        }

        private void AddTest_Loaded()
        {

        }

        private void AddTest_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
