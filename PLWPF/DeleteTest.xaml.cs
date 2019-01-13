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
    /// Interaction logic for DeleteTester.xaml
    /// </summary>
    public partial class DeleteTest : UserControl
    {
        Ibl.IBL bl = factoryBL.FactoryBL.GetBL();
        public DeleteTest()
        {
            InitializeComponent();
            idlist.ItemsSource = bl.GetAllTests();
        }

        public void initializeData()
        {
            var list = bl.GetAllTests();
            if (list.ToString() != idlist.ItemsSource.ToString())
                this.idlist.ItemsSource = list;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = (idlist.SelectionBoxItem as Test).TestNumber;
                MessageBoxResult answer = MessageBox.Show("do you sure you want delete Test " + id + "?", "Verify deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (answer == MessageBoxResult.Yes)
                {
                    bl.DeleteTester(id);
                    MessageBox.Show("deleted successfully");
                    initializeData();
                }
                else
                {
                    MessageBox.Show("deleted cancaled");

                }
            }
            catch (Exception ex)
            {
                MainWindow.ErrorMessage(ex.Message);
            }
        }
    }
}
