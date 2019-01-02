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
using Ibl;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddTester.xaml
    /// </summary>
    public partial class AddTester : UserControl
    {
        Tester tester;
        IBL bl = factoryBL.FactoryBL.GetBL();
        public AddTester()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    CheckBox checkBox = new CheckBox();
                    WorkHours.Children.Add(checkBox);
                    Grid.SetRow(checkBox, i+1);
                    Grid.SetColumn(checkBox, j+1);
                    checkBox.Margin = new Thickness(3);
                    checkBox.Name = "checkBox" + i + "_" + j;
                    checkBox.HorizontalAlignment = HorizontalAlignment.Center;
                }
            }
            genderComboBox.ItemsSource = Enum.GetValues(typeof(Gender));
            this.carTypeComboBox.ItemsSource = Enum.GetValues(typeof(CarType));
            tester = new Tester();
            grid1.DataContext = tester;
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
                bool oneOrMoreEmpty = false;
                foreach (Control txtbxs in this.grid1.Children)
                {

                    if (txtbxs is TextBox)
                    {
                        var TBox = (TextBox)txtbxs;
                        if (TBox.Text == string.Empty)
                        {
                            TBox.Background = new SolidColorBrush(Colors.Red);
                            oneOrMoreEmpty = true;
                        }
                    }

                }
                if (oneOrMoreEmpty)
                {
                    MessageBox.Show("you have a cells empty, fill all and try again");
                    return;
                }
                Address address;
                address.building_number = int.Parse(building_number.Text);
                address.city = city.Text;
                address.street_name = street.Text;
                tester.Address = address;
                bl.AddTester(tester);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
