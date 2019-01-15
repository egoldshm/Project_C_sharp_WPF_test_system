using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ViewTesters.xaml
    /// </summary>
    public partial class ViewTesters : UserControl
    {
        IBL bl = factoryBL.FactoryBL.GetBL();
        public ObservableCollection<Tester> testers;
        public ObservableCollection<Tester> ToDisplay;

        public ViewTesters()
        {
            InitializeComponent();
            initializeData();
            list.DataContext = ToDisplay;
        }

        public void initializeData()
        {
            testers = new ObservableCollection<Tester>(bl.GetAllTesters());
            ToDisplay = testers;
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            if (CarTypeSearch.IsChecked == true)
            {
                testers = new ObservableCollection<Tester>();
                if (CarTypePicker.SelectedValue != null)
                {
                    foreach (var TesterGroup in bl.GetTestersByCarType())
                    {
                        if (TesterGroup.Key == (CarType)CarTypePicker.SelectedValue)
                        {
                            testers = new ObservableCollection<Tester>(TesterGroup.ToList());
                            break;
                        }
                    }
                }
            }
            else if (AvailableTimeSearch.IsChecked == true)
            {
                if (DatePicker.Text != null)
                {
                    testers = new ObservableCollection<Tester>(bl.GetTestersByAvailableTime(DateTime.Parse(DatePicker.Text)));
                }
                else
                {
                    testers = new ObservableCollection<Tester>();
                }
            }
            else if (InDistanceOfSearch.IsChecked == true)
            {
                testers = new ObservableCollection<Tester>();
                throw new NotImplementedException();
            }
            else if(IdSearch.IsChecked == true)
            {
                testers = new ObservableCollection<Tester>();
                if (IdBox.Text != "")
                {
                    testers.Add(bl.GetTesterById(int.Parse(IdBox.Text)));
                }
            }
            
            ToDisplay = testers;
            list.DataContext = ToDisplay;
        }
        
        private void ViewAllButton_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            initializeData();
            list.DataContext = ToDisplay;
        }

        private void CarTypeSearch_Checked(object sender, RoutedEventArgs e)
        {
            CarTypePicker.Visibility = Visibility.Visible;
            IdBox.Visibility = Visibility.Hidden;
            AddressGrid.Visibility = Visibility.Hidden;
            DatePicker.Visibility = Visibility.Hidden;
            //need to add the values to the combo box
        }

        private void AvailableTimeSearch_Checked(object sender, RoutedEventArgs e)
        {
            CarTypePicker.Visibility = Visibility.Hidden;
            IdBox.Visibility = Visibility.Hidden;
            AddressGrid.Visibility = Visibility.Hidden;
            DatePicker.Visibility = Visibility.Visible;
        }

        private void InDistanceOfSearch_Checked(object sender, RoutedEventArgs e)
        {
            CarTypePicker.Visibility = Visibility.Hidden;
            IdBox.Visibility = Visibility.Hidden;
            AddressGrid.Visibility = Visibility.Visible;
            DatePicker.Visibility = Visibility.Hidden;
        }

        private void IdSearch_Checked(object sender, RoutedEventArgs e)
        {
            CarTypePicker.Visibility = Visibility.Hidden;
            IdBox.Visibility = Visibility.Visible;
            AddressGrid.Visibility = Visibility.Hidden;
            DatePicker.Visibility = Visibility.Hidden;
        }

        private void AddressCity_GotFocus(object sender, RoutedEventArgs e)
        {
            if (AddressCity.Text == "City")
            {
                AddressCity.Text = "";
                AddressCity.Foreground = Brushes.Black;
            }

            if (AddressStreet.Text == "")
            {
                AddressStreet.Text = "Street";
                AddressStreet.Foreground = Brushes.Gray;
            }

            if (AddressNumber.Text == "")
            {
                AddressNumber.Text = "Number";
                AddressNumber.Foreground = Brushes.Gray;
            }
        }

        private void AddressStreet_GotFocus(object sender, RoutedEventArgs e)
        {
            if (AddressCity.Text == "")
            {
                AddressCity.Text = "City";
                AddressCity.Foreground = Brushes.Gray;
            }

            if (AddressStreet.Text == "Street")
            {
                AddressStreet.Text = "";
                AddressStreet.Foreground = Brushes.Black;
            }

            if (AddressNumber.Text == "")
            {
                AddressNumber.Text = "Number";
                AddressNumber.Foreground = Brushes.Gray;
            }
        }

        private void AddressNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            if (AddressCity.Text == "")
            {
                AddressCity.Text = "City";
                AddressCity.Foreground = Brushes.Gray;
            }

            if (AddressStreet.Text == "")
            {
                AddressStreet.Text = "Street";
                AddressStreet.Foreground = Brushes.Gray;
            }

            if (AddressNumber.Text == "Number")
            {
                AddressNumber.Text = "";
                AddressNumber.Foreground = Brushes.Black;
            }
        }
    }
}
