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
            list.DataContext = ToDisplay;
            initializeData();
        }

        public void initializeData()
        {
            testers = new ObservableCollection<Tester>(bl.GetAllTesters());
            ToDisplay = testers;
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            if (SearchBar.Text == "")
            {
                testers = new ObservableCollection<Tester>(bl.GetAllTesters());
            }
            else if (CarTypeSearch.IsChecked == true)
            {
                testers = new ObservableCollection<Tester>();
                testers.Add(new Tester(bl.GetTesterById(int.Parse(SearchBar.Text))));
            }
            else if (AvailableTimeSearch.IsChecked == true)
            {
                
            }
            else if (InDistanceOfSearch.IsChecked == true)
            {
                testers = new ObservableCollection<Tester>();
                //testers.Add(new Tester(bl.GetTestersWhoLiveInDistanceOfX(int.Parse(SearchBar.Text))));
            }
            
            ToDisplay = testers;
            list.DataContext = ToDisplay;
        }

        private void AvailableTimeSearch_Checked(object sender, RoutedEventArgs e)
        {
            SearchBar.Visibility = Visibility.Hidden;
            DatePicker.Visibility = Visibility.Visible;
        }
    }
}
