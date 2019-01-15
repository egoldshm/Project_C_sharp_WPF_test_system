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
        
        private Trainee trainee;
        Ibl.IBL bl = factoryBL.FactoryBL.GetBL();
        public List<Trainee> allTrainees;

        public Trainee Trainee { get => trainee; set  { trainee = value;
                idTextBox.Text = trainee.Id.ToString();
                IdTextBox_DropDownClosed(this, new EventArgs()); } }

        public UpdateTrainee()
        {
            trainee = new Trainee();
            InitializeComponent();
            DataContext = Trainee;
            genderComboBox.ItemsSource = Enum.GetValues(typeof(Gender));
            this.transmissionLearnedComboBox.ItemsSource = Enum.GetValues(typeof(TransmissionType));
            this.typeCarLearnedComboBox.ItemsSource = Enum.GetValues(typeof(CarType));
            this.idTextBox.ItemsSource = bl.GetAllTrainees().Select(_trainee => _trainee.Id); ;
        }
        public void setTrainees(List<Trainee> trainees)
        {
            this.idTextBox.ItemsSource = trainees.Select(_trainee => _trainee.Id);
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
                    MainWindow.ErrorMessage(string.Format("you have a cells {0} is empty, fill all and try again", whoEmpty));
                    return;
                }
                Trainee.Address = new Address(street_name.Text, int.Parse(building_number.Text), city.Text);
                bl.UpdateTrainee(Trainee);
                trainee = new Trainee();
                DataContext = Trainee;
            }
            catch (Exception ex)
            {
                MainWindow.ErrorMessage(ex.Message);
            }
        }
        /// <summary>
        /// function that reset the element that may to change for update changes. for admin use.
        /// </summary>
        internal void initializeData()
        {
            int index = idTextBox.SelectedIndex;
            idTextBox.ItemsSource = bl.GetAllTrainees().Select(_trainee => _trainee.Id);
            idTextBox.SelectedIndex = index;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void IdTextBox_DropDownClosed(object sender, EventArgs e)
        {
            if (idTextBox.Text != string.Empty)
            {
                int id = int.Parse(idTextBox.Text);
                trainee = bl.GetTraineeById(id);
                if (Trainee != null)
                {
                    DataContext = Trainee;
                    street_name.Text = Trainee.Address.street_name;
                    city.Text = Trainee.Address.city;
                    building_number.Text = Trainee.Address.building_number.ToString();
                }
            }
        }
    }
}
