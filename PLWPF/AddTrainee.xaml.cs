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
using System.Text.RegularExpressions;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddTrainee.xaml
    /// </summary>
    public partial class AddTrainee : UserControl
    {
        public event EventHandler traineeAdded;
        Trainee trainee;
        IBL bl = factoryBL.FactoryBL.GetBL();
        public AddTrainee()
        {
            trainee = new Trainee();
            InitializeComponent();
            DataContext = trainee;
            genderComboBox.ItemsSource = Enum.GetValues(typeof(Gender));
            this.transmissionLearnedComboBox.ItemsSource = Enum.GetValues(typeof(TransmissionType));
            this.typeCarLearnedComboBox.ItemsSource = Enum.GetValues(typeof(CarType));
        }
        /// <summary>
        /// event of create new trainee that happen when the button is click
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
                bool oneOrMoreEmpty = false;
                string whoEmpty = "";
                foreach (Control txtbxs in this.input.Children)
                {
                    
                    if (txtbxs is TextBox)
                    {
                        var TBox = (TextBox)txtbxs;
                        if (TBox.Text == string.Empty)
                        {
                            TBox.Background = new SolidColorBrush(Colors.Red);
                            oneOrMoreEmpty = true;
                            whoEmpty += TBox.Name + " ";
                        }
                    }

                }
                if(oneOrMoreEmpty)
                {
                    MainWindow.ErrorMessage(string.Format("you have a cells {0} is empty, fill all and try again", whoEmpty));
                    return;
                }
                trainee.Address = new Address(city.Text, int.Parse(building_number.Text), street_name.Text);
                bl.AddTrainee(trainee);
                traineeAdded?.Invoke(sender, new EventArgs());
                trainee = new Trainee();
                DataContext = trainee;
                city.Text = ""; building_number.Text = ""; street_name.Text = "";
            }
            catch(Exception ex)
            {
                MainWindow.ErrorMessage(ex.Message);
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
