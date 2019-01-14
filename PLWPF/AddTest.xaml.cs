using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
//using Xceed.Wpf.Toolkit;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddTest.xaml
    /// </summary>
    public partial class AddTest : UserControl
    {
        Ibl.IBL bl = factoryBL.FactoryBL.GetBL();
        public AddTest()
        {
            InitializeComponent();
            traineeIdList.ItemsSource = bl.GetAllTrainees();
            testerIdList.ItemsSource = bl.GetAllTesters();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Trainee trainee = new Trainee(traineeIdList.SelectionBoxItem as Trainee);
                Tester tester = new Tester(testerIdList.SelectionBoxItem as Tester);
                MessageBoxResult answer = MessageBox.Show("Verify test scheduling", "are you sure you want to add a test for " + trainee.Id + " with " + tester.Id + "?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (MessageBoxResult.Yes == answer)
                {
                    bl.AddFutureTest(tester, trainee, (DateTime)dateOfTestDatePicker.SelectedDate, new Address(city.Text, int.Parse(building_number.Text), street.Text));
                    MessageBox.Show("added test");
                }
                else
                {
                    MessageBox.Show("canceled");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
