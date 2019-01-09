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
    /// Interaction logic for ViewTest.xaml
    /// </summary>
    public partial class ViewTest : UserControl
    {
        private Test test;
        public ViewTest()
        {
            InitializeComponent();
        }

        public Test Test {
            get => test;
            set
            {
                test = value;
                grid1.DataContext = test;
                if(factoryBL.FactoryBL.GetBL().isTestFinished(test))
                {

                }


            }
        }
    }
}
