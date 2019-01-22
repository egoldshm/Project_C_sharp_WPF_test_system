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

        /// <summary>
        /// function that get a ID and return if is valid israeli number or not.
        /// Exception:
        ///     if the ID hasn't 9 digits
        /// </summary>
        /// <param name="id">israeli ID number</param>
        /// <returns>True: this ID is valid israeli ID. False: isn't </returns>
        private static bool CheckIfIDisValid(int id)
        {
            if (id.ToString().Length != 9)
                throw new Exception(string.Format("id {0} is invalid. because it has {1} digits and valid id has 9.", id, id.ToString().Length));
            int lessId = id / 10;
            int sum = 0;
            for (int i = 1; lessId > 0; i++)
            {
                int number1;
                number1 = (i % 2 + 1) * (lessId % 10);
                int number2 = number1 % 10 + number1 / 10;
                sum += number2;
                lessId /= 10;
            }
            int check_digit = (10 - sum % 10) % 10;
            return check_digit == id % 10;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool error = false;
                //if the id is invalid - label error and out.
                if(!CheckIfIDisValid(int.Parse(idTextBox.Text)))
                {
                    errorIdMessage.Visibility = Visibility.Visible;
                    error = true;
                }
                //if the phone number is invalid - label error and out.
                if (phoneNumberTextBox.Text.ToString().Length != 9)
                {
                    errorPhoneMessage.Visibility = Visibility.Visible;
                    error = true;
                }
                //if was problem.
                if(error)
                {
                    addTesterButton.Background = new SolidColorBrush(Colors.Red);
                    return;
                }
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
                clearAll();
            }
            catch (Exception ex)
            {
                errorMessage.Text = $"Error! {ex.Message}";
            }
        }
        private void clearAll()
        {
            tester = new Tester();
            grid1.DataContext = tester;
            city.Text = "";
            street.Text = "";
            building_number.Text = "";
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    WorkHours.Children.OfType<CheckBox>().Where(box => box.Name == "checkBox" + i + "_" + j).First().IsChecked = false;
                }
            }
        }

        /// <summary>
        /// event that remove error message for id number.
        /// </summary>
        private void idTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            errorIdMessage.Visibility = Visibility.Collapsed;
            errorPhoneMessage.Visibility = Visibility.Collapsed;
            addTesterButton.Background = new SolidColorBrush(Colors.White);
        }

        private void addTesterButton_MouseLeave(object sender, MouseEventArgs e)
        {
            MainWindow.doFunctionInFewSecond(() => { errorMessage.Text = ""; });
        }
    }
}
