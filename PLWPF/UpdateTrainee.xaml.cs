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
    /// Interaction logic for UpdateTrainee.xaml
    /// </summary>
    public partial class UpdateTrainee: UserControl
    {

        public event EventHandler traineeUpdated;
        Trainee trainee;
        Ibl.IBL bl = factoryBL.FactoryBL.GetBL();
        public List<Trainee> allTrainees;
        public UpdateTrainee()
        {
            trainee = new Trainee();
            InitializeComponent();
            DataContext = trainee;
            genderComboBox.ItemsSource = Enum.GetValues(typeof(Gender));
            this.transmissionLearnedComboBox.ItemsSource = Enum.GetValues(typeof(TransmissionType));
            this.typeCarLearnedComboBox.ItemsSource = Enum.GetValues(typeof(CarType));
            this.idTextBox.ItemsSource = bl.GetAllTrainees().Select(_trainee => _trainee.Id); ;
        }
        public void setTrainees(List<Trainee> trainees)
        {
            this.idTextBox.ItemsSource = trainees;
        }
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
                if (oneOrMoreEmpty)
                {
                    MessageBox.Show(string.Format("you have a cells {0} is empty, fill all and try again", whoEmpty));
                    return;
                }
                trainee.Address = new Address(city.Text, int.Parse(building_number.Text), street_name.Text);
                bl.UpdateTrainee(trainee);
                trainee = new Trainee();
                DataContext = trainee;
                traineeUpdated?.Invoke(this, new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void IdTextBox_DropDownClosed(object sender, EventArgs e)
        {
            if (idTextBox.Text != string.Empty)
            {
                int id = int.Parse(idTextBox.Text);
                trainee = bl.GetTraineeById(id);
                if (trainee != null)
                {
                    DataContext = trainee;
                    street_name.Text = trainee.Address.street_name;
                    city.Text = trainee.Address.city;
                    building_number.Text = trainee.Address.building_number.ToString();
                }
            }
        }
    }
}
