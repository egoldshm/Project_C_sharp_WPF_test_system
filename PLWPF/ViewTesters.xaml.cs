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
        public ObservableCollection<Tester> toDisplay;

        public ViewTesters()
        {
            InitializeComponent();
            list.DataContext = toDisplay;
            initializeData();
        }

        public void initializeData()
        {
            testers = new ObservableCollection<Tester>(bl.GetAllTesters());
            toDisplay = testers;
        }
    }
}
