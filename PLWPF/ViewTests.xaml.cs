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
        Ibl.IBL bl = factoryBL.FactoryBL.GetBL();
        List<Test> allTests;
        public ViewTests()
        {
            InitializeComponent();
            trainee.ItemsSource = bl.GetAllTrainees();
            tester.ItemsSource = bl.GetAllTesters();
        }
        public List<Tester> setTestersExits { set => tester.ItemsSource = value; }
        public List<Trainee> setTraineeExits { set => trainee.ItemsSource = value; }

        public List<Test> AllTests { get => allTests;
            set
            {
                allTests = value;
                clearOldTests();
                foreach (Test item in allTests)
                {
                    addTestToView(item);
                }

            }
        }

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
            createNewLabelAndInsert(grid, 5, bl.isTestFinished(item) ? (item.Pass ? "pass" : "faild") : "not end yet");
            grid.Margin = new Thickness(0, 3, 0, 3);
            TestsView.Children.Add(grid);
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
            toolsOfDisplay.Visibility = Visibility.Visible;
            backButton.Visibility = Visibility.Hidden;
            viewSingleTest.Visibility = Visibility.Hidden;
            menu.Visibility = Visibility.Visible;
            TestsView.Visibility = Visibility.Visible;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            allTests = bl.GetAllTests(test =>
            {
                bool right = true;
                if (trainee.SelectionBoxItem is Trainee)
                    right = right && test.TraineeId == (trainee.SelectionBoxItem as Trainee).Id;
                if (tester.SelectionBoxItem is Tester)
                    right = right && test.TesterId == (tester.SelectionBoxItem as Tester).Id;
                return right;
            });
        }
    }
}
