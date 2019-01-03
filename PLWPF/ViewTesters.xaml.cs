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
    /// Interaction logic for ViewTesters.xaml
    /// </summary>
    public partial class ViewTesters : UserControl
    {
        IBL bl = factoryBL.FactoryBL.GetBL();
        public List<Tester> testers;
        public List<Tester> toDisplay;

        public ViewTesters()
        {
            InitializeComponent();
            initializeData();
        }

        public void initializeData()
        {
            testers = bl.GetAllTesters();
            toDisplay = testers;
            list.DataContext = toDisplay;
        }
    }
}
