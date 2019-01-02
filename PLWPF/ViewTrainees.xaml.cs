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
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for ViewTrainees.xaml
    /// </summary>
    public partial class ViewTrainees : UserControl
    {
        IBL bl = factoryBL.FactoryBL.GetBL();
        public List<Trainee> trainees;
        public ViewTrainees()
        {
            InitializeComponent();
            trainees = new List<Trainee>(bl.GetAllTrainees());
            list.DataContext = trainees;

        }

        private void ViewLicenseOwners_Click(object sender, RoutedEventArgs e)
        {
            if(ShowNoLicense.IsChecked == true && ViewLicenseOwners.IsChecked == true)
            {
                trainees = bl.GetAllTrainees();
            }
            else if (ShowNoLicense.IsChecked == false && ViewLicenseOwners.IsChecked == true)
            {
                trainees = bl.GetAllTraineesByLicense(true);
            }
            else if(ShowNoLicense.IsChecked == true && ViewLicenseOwners.IsChecked == false)
            {
                trainees = bl.GetAllTraineesByLicense(false);
            }
            else
            {
                trainees = new List<Trainee>();
            }
            list.DataContext = trainees;
        }
    }
}
