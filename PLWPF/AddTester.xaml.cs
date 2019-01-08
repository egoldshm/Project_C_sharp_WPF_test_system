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
                    Grid.SetRow(checkBox, i+1);
                    Grid.SetColumn(checkBox, j+1);
                    checkBox.Margin = new Thickness(3);
                    checkBox.Name = "checkBox" + i + "_" + j;
                    checkBox.HorizontalAlignment = HorizontalAlignment.Center;
                    WorkHours.Children.Add(checkBox);

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
                foreach (UIElement txtbxs in this.grid1.Children)
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
                    MainWindow.ErrorMessage("you have a cells empty, fill all and try again");
                    return;
                }
                tester.Address = new Address(street.Text, int.Parse(building_number.Text), city.Text);
                tester.WorkDays = new bool[5, 6];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                         tester.WorkDays[i, j] = WorkHours.Children.OfType<CheckBox>().Where(box => box.Name == "checkBox" + i + "_" + j).Select(box => (bool)box.IsChecked).First();
                    }
                }
                bl.AddTester(tester);
                tester = new Tester();
                grid1.DataContext = tester;
            }
            catch (Exception ex)
            {
                MainWindow.ErrorMessage(ex.Message);
            }
        }
    }
}
