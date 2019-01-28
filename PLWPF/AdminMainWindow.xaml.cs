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
using SnakeWPF.View;
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
            AddSnakeGame();

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
            //if (OldTab != null && OldTab != tabControl.SelectedValue.ToString())
            //{
            //    if (view.IsSelected)
            //    {
            //        viewTestersUsercontrol.initializeData();
            //        viewTraineeUserconrol.initializeData();
            //        ViewTest.AllExistTests = bl.GetAllTests();
            //    }
            //    if (delete.IsSelected)
            //    {
            //        deleteTester_uc.initializeData();
            //        deleteTrainee_uc.initializeData();
            //        deleteTest_uc.initializeData();
            //    }
            //    if (update.IsSelected)
            //    {
            //        updateTrainee_uc.initializeData();
            //        UpdateTester_uc.initializeData();
            //        finishTest_uc.initializeData();
            //        AddLessonToTrainee_uc.initializeData();
            //    }
            //    if (Add.IsSelected)
            //    {
            //        AddLessonToTrainee_uc.initializeData();
            //        AddTest_uc.initializeData();
            //        AddAutoTest_uc.initializeData();
            //    }
                
            //    OldTab = tabControl.SelectedValue.ToString();
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartGameClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Play during your work request permissions of your employer, do you sure you have?", "Do you sure?", MessageBoxButton.YesNoCancel, MessageBoxImage.Asterisk);
            if (result == MessageBoxResult.Yes)
            {
                AddSnakeGame();
            }
            else if (result == MessageBoxResult.No)
            {
                MessageBox.Show("okey. bye!");
            }
        }

        private void AddSnakeGame()
        {
            SnakeView snakeView = new SnakeView();
            snakeView.Margin = new Thickness(15);
            snakeView.BorderBrush = new SolidColorBrush(Colors.DarkRed);
            snakeView.BorderThickness = new Thickness(15, 20, 15, 20);
            game.Content = snakeView;
        }

        private void Home_GotFocus(object sender, RoutedEventArgs e)
        {
            OldTab = "Home";
        }

        private void Add_GotFocus(object sender, RoutedEventArgs e)
        {
            if (OldTab != "Add")
            {
                AddLessonToTrainee_uc.initializeData();
                AddTest_uc.initializeData();
                AddAutoTest_uc.initializeData();
            }
            OldTab = "Add";
        }

        private void Delete_GotFocus(object sender, RoutedEventArgs e)
        {
            if (OldTab != "Delete")
            {
                deleteTester_uc.initializeData();
                deleteTrainee_uc.initializeData();
                deleteTest_uc.initializeData();
            }
            OldTab = "Delete";
        }

        private void Update_GotFocus(object sender, RoutedEventArgs e)
        {
            if (OldTab != "Update")
            {
                updateTrainee_uc.initializeData();
                UpdateTester_uc.initializeData();
                finishTest_uc.initializeData();
                AddLessonToTrainee_uc.initializeData();
            }
            OldTab = "Update";
        }

        private void View_GotFocus(object sender, RoutedEventArgs e)
        {
            if (OldTab != "View")
            {
                viewTestersUsercontrol.initializeData();
                viewTraineeUserconrol.initializeData();
                //ViewTest.AllExistTests = bl.GetAllTests();
                ViewTest.InitializeData();
            }
            OldTab = "View";
        }

        private void LoginAs_GotFocus(object sender, RoutedEventArgs e)
        {
            OldTab = "Login As";
        }

        private void Game_GotFocus(object sender, RoutedEventArgs e)
        {
            OldTab = "Game";
        }

        private void StatisticalTab_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
