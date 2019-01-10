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
        List<Test> allTests;
        public ViewTests()
        {
            InitializeComponent();
        }

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
            for (int i = 0; i < 5; i++)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition();
                grid.ColumnDefinitions.Add(columnDefinition);
            }
            Button button = new Button();
            button.Content = "see Test";
            grid.Children.Add(button);
            Label labelNumber = new Label();
            labelNumber.Content = item.TestNumber;
            grid.Children.Add(labelNumber);
            Grid.SetColumn(labelNumber, 1);
            Label labelTraineeID = new Label();
            labelTraineeID.Content = item.TraineeId;
            grid.Children.Add(labelTraineeID);
            Grid.SetColumn(labelTraineeID, 2);
            Label labelTesterID = new Label();
            labelTesterID.Content = item.TesterId;
            grid.Children.Add(labelTesterID);
            Grid.SetColumn(labelTesterID, 3);
            Label LabelDone = new Label();
            LabelDone.Content = (factoryBL.FactoryBL.GetBL().isTestFinished(item) ? (item.Pass ? "pass" : "faild") : "not end yet");
            grid.Children.Add(LabelDone);
            Grid.SetColumn(LabelDone, 4);
            grid.Margin = new Thickness(0, 3, 0, 3);
            TestsView.Children.Add(grid);
        }

        private void clearOldTests()
        {
            System.Collections.IList list = TestsView.Children;
            for (int i = 0; i < list.Count; i++)
            {
                TestsView.Children.Remove((UIElement)list[i]);
            }
        }
    }
}
