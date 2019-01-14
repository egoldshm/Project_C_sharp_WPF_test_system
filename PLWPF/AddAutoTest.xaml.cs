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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddAutoTest.xaml
    /// </summary>
    public partial class AddAutoTest : UserControl
    {
        Ibl.IBL bl = factoryBL.FactoryBL.GetBL();
        public AddAutoTest()
        {
            InitializeComponent();
            traineeIdList.ItemsSource = bl.GetAllTrainees();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        /// <summary>
        /// Event when the click to create test click. try to create test.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Trainee trainee = new Trainee(traineeIdList.SelectionBoxItem as Trainee);
                DateTime dateTime = DateTime.Parse(dateOfTestDatePicker.Text);
                Address address = new Address(city.Text, int.Parse(building_number.Text), street.Text);
                Test test = bl.createTest(trainee.Id, address, dateTime);
                MessageBox.Show("added test");
                errorMessage.Content = $"Test number {test.TestNumber} created. In {test.DateOfTest} with Tester {test.TesterId}";
                errorMessage.Foreground = new SolidColorBrush(Colors.Green);
            }
            catch (Exception ex)
            {
                errorMessage.Content = ex.Message;
                errorMessage.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}