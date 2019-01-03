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
            this.idlist.ItemsSource = bl.GetAllTrainees();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = (idlist.SelectionBoxItem as Trainee).Id;
                MessageBoxResult answer = MessageBox.Show("Verify deletion", "do you sure you want delete " + id + "?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (answer == MessageBoxResult.Yes)
                {
                    bl.DeleteTrainee(id);
                    MessageBox.Show("deleted successfully");
                    this.idlist.ItemsSource = bl.GetAllTrainees();

                }
                else
                {
                    MessageBox.Show("deleted cancaled");

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
