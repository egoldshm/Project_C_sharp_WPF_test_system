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
using System.Text.RegularExpressions;
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
            ToDisplay = trainees;
            list.DataContext = ToDisplay;

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// function that reset the element that may to change for update changes. for admin use.
        /// </summary>
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
            list.DataContext = ToDisplay;
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
                var help = new List<List<Trainee>>(from Group in bl.GetTraineesBySchoolName() where Group.Key == SearchBar.Text select Group.ToList());
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
                    trainees = new ObservableCollection<Trainee>(help[0]);
                }
            }
            else if (SearchTeacher.IsChecked == true)
            {
                var help = new List<List<Trainee>>(from Group in bl.GetTraineesByTeacher() where Group.Key == SearchBar.Text select Group.ToList());
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
                    trainees = new ObservableCollection<Trainee>(help[0]);
                }
            }
            ToDisplay = trainees;
            list.DataContext = ToDisplay;
            ViewLicenseOwners_Click(null, null);
        }

        private void sortByButton_Click(object sender, RoutedEventArgs e)
        {
            string value = sortByComboBox.SelectionBoxItem.ToString();
            List<Trainee> sortList = new List<Trainee>(ToDisplay);
            if (value == "first name")
                sortList.Sort((trainee1, trainee2) => string.Compare(trainee1.FirstName.ToLower(), trainee2.FirstName.ToLower()));
            if (value == "Family name")
                sortList.Sort((trainee1, trainee2) => string.Compare(trainee1.FamilyName.ToLower(), trainee2.FamilyName.ToLower()));
            if (value == "ID")
                sortList.Sort((trainee1, trainee2) => string.Compare(trainee1.Id.ToString(), trainee2.Id.ToString()));
            if (value == "Lesson numbers")
                sortList.Sort((trainee1, trainee2) => (trainee1.LessonsNumber).CompareTo(trainee2.LessonsNumber));
            ToDisplay = new ObservableCollection<Trainee>(sortList);
            list.DataContext = ToDisplay;

        }

        private void SearchID_Checked(object sender, RoutedEventArgs e)
        {
            if (SearchBar != null)
            {
                SearchBar.PreviewTextInput += NumberValidationTextBox;
            }
        }

        private void SearchID_Unchecked(object sender, RoutedEventArgs e)
        {
            if (SearchBar != null)
            {
                SearchBar.PreviewTextInput -= NumberValidationTextBox;
            }
        }
    }
}
