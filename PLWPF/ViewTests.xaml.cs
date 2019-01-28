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
    /// Interaction logic for ViewTests.xaml
    /// </summary>
    public partial class ViewTests : UserControl
    {
        List<Test> allExistTests;
        Ibl.IBL bl = factoryBL.FactoryBL.GetBL();
        List<Test> allTests;
        public ViewTests()
        {
            InitializeComponent();
            InitializeData();
        }

        public void InitializeData()
        {
            allExistTests = bl.GetAllTests();
            setTraineeExist = bl.GetAllTrainees();
            setTestersExist = bl.GetAllTesters();
        }
        public List<Tester> setTestersExist
        {
            set { List<Object> list = new List<Object>(value); list.Add("all"); tester.ItemsSource = list; tester.SelectedIndex = list.Count - 1; }
        }
        public List<Trainee> setTraineeExist
        {
            set { List<Object> list = new List<Object>(value); list.Add("all"); trainee.ItemsSource = list; trainee.SelectedIndex = list.Count - 1; }
        }

        public List<Test> AllTests { get => allTests;
            set
            {
                allTests = new List<Test>(value.Where(test =>
                {
                    bool right = true;
                    if (trainee.SelectedItem is Trainee)
                        right = right && test.TraineeId == (trainee.SelectedItem as Trainee).Id;
                    if (tester.SelectedItem is Tester)
                        right = right && test.TesterId == (tester.SelectedItem as Tester).Id;
                    if (unfinishedTests.IsChecked == false)
                        right = right && !(getStateOfTest(test) == "not end yet");
                    else if (unsuccessfulTests.IsChecked == false)
                        right = right && !(getStateOfTest(test) == "faild");
                    else if(successfulTests.IsChecked == false)
                        right = right && !(getStateOfTest(test) == "pass");
                    return right;
                }));
                clearOldTests();
                foreach (Test item in allTests)
                {
                    addTestToView(item);
                }

            }
        }

        public List<Test> AllExistTests { get => allExistTests; set { allExistTests = value; allTests = allExistTests; } }

        private void addTestToView(Test item)
        {
            Grid grid = new Grid();
            createColumnsToGrid(grid, 6);
            Button button = new Button();
            button.ContentStringFormat = "see Test";
            button.Content = item.TestNumber;
            button.HorizontalContentAlignment = HorizontalAlignment.Center;
            button.VerticalContentAlignment = VerticalAlignment.Center;
            button.Click += ButtonShowDetailsClick;
            grid.Children.Add(button);
            createNewLabelAndInsert(grid, 1, item.TestNumber.ToString());
            createNewLabelAndInsert(grid, 2, bl.GetTraineeById(item.TraineeId).ToString());
            createNewLabelAndInsert(grid, 3, bl.GetTesterById(item.TesterId).ToString());
            createNewLabelAndInsert(grid, 4, item.DateOfTest.ToString());
            createNewLabelAndInsert(grid, 5, getStateOfTest(item));
            grid.Margin = new Thickness(0, 3, 0, 3);
            TestsView.Children.Add(grid);
        }

        private string getStateOfTest(Test item)
        {
            return bl.isTestFinished(item) ? (item.Pass ? "pass" : "faild") : "not end yet";
        }

        private static void createColumnsToGrid(Grid grid, int num)
        {
            for (int i = 0; i < num; i++)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition();
                grid.ColumnDefinitions.Add(columnDefinition);
            }
        }

        private void ButtonShowDetailsClick(object sender, RoutedEventArgs e)
        {
            if(e.Source is Button)
            {
                Button button = e.Source as Button;
                int id;
                if(int.TryParse(button.Content.ToString(), out id))
                {
                    clickMenu.IsEnabled = false;
                    viewSingleTest.Test = bl.GetTestByNumber(id);
                    toolsOfDisplay.Visibility = Visibility.Hidden;
                    backButton.Visibility = Visibility.Visible;
                    viewSingleTest.Visibility = Visibility.Visible;
                    menu.Visibility = Visibility.Hidden;
                    TestsView.Visibility = Visibility.Hidden;
                }
            }
        }

        private static void createNewLabelAndInsert(Grid grid, int num, string str)
        {
            Label label = new Label();
            label.Content = str;
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
            grid.Children.Add(label);
            Grid.SetColumn(label, num);
        }

        private void clearOldTests()
        {
            System.Collections.IList list = TestsView.Children;
            for (int i = 0; i < list.Count; i++)
            {
                TestsView.Children.Remove((UIElement)list[i]);
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            clickMenu.IsEnabled = true;
            toolsOfDisplay.Visibility = Visibility.Visible;
            backButton.Visibility = Visibility.Hidden;
            viewSingleTest.Visibility = Visibility.Hidden;
            menu.Visibility = Visibility.Visible;
            TestsView.Visibility = Visibility.Visible;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(AllExistTests != null)
                AllTests = new List<Test>(AllExistTests);
        }

        private void SortByNumber(object sender, RoutedEventArgs e)
        {
            AllTests.Sort((test1, test2) => test1.TestNumber.CompareTo(test2.TestNumber));
        }

        private void SortByTraineName(object sender, RoutedEventArgs e)
        {
            AllTests.Sort((test1, test2) => bl.GetTraineeById(test1.TraineeId).FirstName.CompareTo(bl.GetTraineeById(test2.TraineeId).FirstName));
        }

        private void SortByTesterName(object sender, RoutedEventArgs e)
        {
            AllTests.Sort((test1, test2) => bl.GetTesterById(test1.TesterId).FirstName.CompareTo(bl.GetTesterById(test2.TesterId).FirstName));

        }

        private void SortByState(object sender, RoutedEventArgs e)
        {
            AllTests.Sort((test1, test2) => string.Compare(getStateOfTest(test2), getStateOfTest(test2)));
        }

        private void SortBydate(object sender, RoutedEventArgs e)
        {
            allTests.Sort((test1, test2) => DateTime.Compare(test1.DateOfTest, test2.DateOfTest));
        }

        private void SuccessfulTests_Checked(object sender, RoutedEventArgs e)
        {
            comboBox_SelectionChanged(sender, null);
        }
    }
}
