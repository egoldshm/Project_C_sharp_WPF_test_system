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
    /// usercontrol for delete Tester
    /// </summary>
    public partial class DeleteTester : UserControl
    {
        Ibl.IBL bl = factoryBL.FactoryBL.GetBL();

        /// <summary>
        /// Constractor for the usercontrol. get all the testers who not registers to tests.
        /// </summary>
        public DeleteTester()
        {
            InitializeComponent();
            idlist.ItemsSource = bl.GetAllTesters(Tester => bl.GetAllTests(test => test.TesterId == Tester.Id).Count == 0);
        }


        /// <summary>
        /// function that reset the element that may to change for update changes. for admin use.
        /// </summary>
        public void initializeData()
        {
            var list = bl.GetAllTesters(Tester => bl.GetAllTests(test => test.TesterId == Tester.Id).Count == 0);
            if (list.ToString() != idlist.ItemsSource.ToString())
                this.idlist.ItemsSource = list;
        }

        /// <summary>
        /// Event that started when the button is clicked and try to delete the tester that selected.
        /// </summary>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = (idlist.SelectionBoxItem as Tester).Id;
                MessageBoxResult answer = MessageBox.Show("do you sure you want delete Tester " + id + "?", "Verify deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
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
