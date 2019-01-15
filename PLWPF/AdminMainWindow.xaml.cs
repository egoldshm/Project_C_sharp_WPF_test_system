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

        /// <summary>
        /// string that check if we change the tab item.
        /// </summary>
        string OldTab;

        public AdminMainWindow(User user)
        {
            if (user.role != User.RoleTypes.Admin)
            {
                throw new Exception("user isn't admin");
            }
            InitializeComponent();
            title.user = user;
            loginas.User = user;
            ViewTest.AllExistTests = bl.GetAllTests();
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
        /// <summary>
        /// event that check if the we change the Tab
        /// </summary>
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OldTab != tabControl.SelectedValue.ToString())
            {
                if (view.IsSelected)
                {
                    viewTestersUsercontrol.initializeData();
                    viewTraineeUserconrol.initializeData();
                    ViewTest.AllExistTests = bl.GetAllTests();
                }
                if (delete.IsSelected)
                {
                    deleteTester_uc.initializeData();
                    deleteTrainee_uc.initializeData();
                    deleteTest_uc.initializeData();
                }
                if (update.IsSelected)
                {
                    updateTrainee_uc.initializeData();
                    UpdateTester_uc.initializeData();
                    finishTest_uc.initializeData();
                    AddLessonToTrainee_uc.initializeData();
                }
                if (Add.IsSelected)
                {
                    AddLessonToTrainee_uc.initializeData();
                    AddTest_uc.initializeData();
                    AddAutoTest_uc.initializeData();
                }
                
                OldTab = tabControl.SelectedValue.ToString();
            }
        }
    }
}
