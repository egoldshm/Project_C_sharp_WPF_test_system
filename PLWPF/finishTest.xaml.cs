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
using Ibl;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for finishTest.xaml
    /// </summary>
    public partial class finishTest : UserControl
    {
        IBL bl = factoryBL.FactoryBL.GetBL();
        public finishTest()
        {
            InitializeComponent();
            CriterionsOfTest criterionsOfTest = new CriterionsOfTest();
            foreach (var item in criterionsOfTest.Criterions)
            {
                var label = new Label();
                label.Content = item.Name;
                CheckBox checkBox = new CheckBox();
                checkBox.Content = item.Name;
                critrions.Children.Add(checkBox);
            }
            tests.ItemsSource = bl.GetAllTests(test => !bl.isTestFinished(test));
        }
        public List<Test> Tests { set => tests.ItemsSource = value; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool pass = (bool)PassTest.IsChecked;
                List<Criterion> newList = new List<Criterion>();
                CriterionsOfTest criterionsOfTest = new CriterionsOfTest();
                int id = (tests.SelectionBoxItem as Test).TestNumber;
                DateTime dateTime = (tests.SelectionBoxItem as Test).DateOfTest;
                //todo: fix the time part.
                string note = TesterNote.Text;
                foreach (var item in critrions.Children)
                {
                    if (item is CheckBox)
                    {
                        var checkBox = (item as CheckBox);
                        CriterionMode mode = CriterionMode.Fails;
                        if (checkBox.IsChecked == true)
                            mode = CriterionMode.passed;
                        newList.Add(new Criterion(checkBox.Content.ToString(), mode));
                    }
                }

                bl.FinishTest(id, new CriterionsOfTest(newList), pass, note);
                tests.ItemsSource = bl.GetAllTests(test => test.Criterions.Criterions.Any(c => c.Mode == CriterionMode.NotDetermined));
                TesterNote.Text = "";
                realDateOfTest.Text = "";
                PassTest.IsChecked = false;
            }
            catch (Exception ex)
            {
                MainWindow.ErrorMessage(ex.Message);
            }
        }

        internal void initializeData()
        {
            tests.ItemsSource = bl.GetAllTests(test => !bl.isTestFinished(test));
        }
        internal void initializeDataForTester(Tester tester)
        {
            tests.ItemsSource = bl.GetAllTests(test => !bl.isTestFinished(test) && test.TesterId == tester.Id);
        }
    }
}
