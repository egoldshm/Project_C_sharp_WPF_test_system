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
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for DeleteTrainee.xaml
    /// </summary>
    public partial class DeleteTrainee : UserControl
    {
        Ibl.IBL bl = factoryBL.FactoryBL.GetBL();
        public DeleteTrainee()
        {
            InitializeComponent();
            this.idlist.ItemsSource = bl.GetAllTrainees(trainee => bl.GetAllTests(test => test.TraineeId == trainee.Id).Count == 0);
        }
        /// <summary>
        /// function that reset the element that may to change for update changes. for admin use.
        /// </summary>
        public void initializeData()
        {
            var list= bl.GetAllTrainees(trainee => bl.GetAllTests(test => test.TraineeId == trainee.Id).Count == 0);
            //if (this.idlist.ItemsSource.ToString() != list.ToString())
            this.idlist.ItemsSource = list;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = (idlist.SelectionBoxItem as Trainee).Id;
                MessageBoxResult answer = MessageBox.Show("do you sure you want delete trainee " + id + "?", "Verify deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (answer == MessageBoxResult.Yes)
                {
                    bl.DeleteTrainee(id);
                    MessageBox.Show("deleted successfully");
                }
                else
                {
                    MessageBox.Show("deleted cancaled");

                }
            }
            catch(Exception ex)
            {
                MainWindow.ErrorMessage(ex.Message);
            }
            finally
            {
                initializeData();
                idlist.SelectedIndex = -1;
            }
        }
    }
}
