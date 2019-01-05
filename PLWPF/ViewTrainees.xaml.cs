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
    /// Interaction logic for ViewTrainees.xaml
    /// </summary>
    public partial class ViewTrainees : UserControl
    {
        IBL bl = factoryBL.FactoryBL.GetBL();
        public ObservableCollection<Trainee> trainees;
        public ObservableCollection<Trainee> ToDisplay;
        public ViewTrainees()
        {
            InitializeComponent();
            trainees = new ObservableCollection<Trainee>(bl.GetAllTrainees());
            initializeData();

        }

        public void initializeData()
        {
            trainees = new ObservableCollection<Trainee>(bl.GetAllTrainees());
            ToDisplay = trainees;
            list.DataContext = ToDisplay;
        }

        private void ViewLicenseOwners_Click(object sender, RoutedEventArgs e)
        {
            if(ShowNoLicense.IsChecked == true && ViewLicenseOwners.IsChecked == true)
            {
                ToDisplay = trainees;
            }
            else if (ShowNoLicense.IsChecked == false && ViewLicenseOwners.IsChecked == true)
            {
                ToDisplay = new ObservableCollection<Trainee>(trainees.Where(tr => bl.GetAllTraineesByLicense(true).Any(tr2 => tr.Id == tr2.Id)));
            }
            else if(ShowNoLicense.IsChecked == true && ViewLicenseOwners.IsChecked == false)
            {
                ToDisplay = new ObservableCollection<Trainee>(trainees.Where(tr => bl.GetAllTraineesByLicense(false).Any(tr2 => tr.Id == tr2.Id)));
            }
            else
            {
                ToDisplay = new ObservableCollection<Trainee>();
            }
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            if (SearchBar.Text == "")
            {
                trainees = new ObservableCollection<Trainee>(bl.GetAllTrainees());
            }
            else if (SearchID.IsChecked == true)
            {
                trainees = new ObservableCollection<Trainee>();
                trainees.Add(new Trainee(bl.GetTraineeById(int.Parse(SearchBar.Text))));
            }
            else if (SearchName.IsChecked == true)
            {
                throw new NotImplementedException();
            }
            else if (SearchSchool.IsChecked == true)
            {
                var help = new ObservableCollection<ObservableCollection<Trainee>>(from Group in bl.GetTraineesBySchoolName() where Group.Key == SearchBar.Text select Group.ToList());
                if (help.Count > 1)
                {
                    throw new Exception(string.Format("More than one school is named {0}", SearchBar.Text));
                }
                if (help.Count == 0)
                {
                    trainees = new ObservableCollection<Trainee>();
                }
                else
                {
                    trainees = help[0];
                }
            }
            else if (SearchTeacher.IsChecked == true)
            {
                var help = new ObservableCollection<ObservableCollection<Trainee>>(from Group in bl.GetTraineesByTeacher() where Group.Key == SearchBar.Text select Group.ToList());
                if (help.Count > 1)
                {
                    throw new Exception(string.Format("More than one Teacher is named {0}", SearchBar.Text));
                }
                if (help.Count == 0)
                {
                    trainees = new ObservableCollection<Trainee>();
                }
                else
                {
                    trainees = help[0];
                }
            }

            ViewLicenseOwners_Click(null, null);
        }
    }
}
