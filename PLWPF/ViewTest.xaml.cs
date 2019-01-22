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
                if(factoryBL.FactoryBL.GetBL().isTestFinished(test))
                {
                    resert();
                    foreach (object item in grid1.Children)
                    {
                        if (item is Label)
                            (item as Label).Visibility = Visibility.Visible;
                        if (item is CheckBox)
                            (item as CheckBox).Visibility = Visibility.Visible;
                    }
                    gridCriterions.Visibility = Visibility.Visible;
                    test.Criterions.Criterions.ForEach(criterion => { var label = new Label(); label.Content = string.Format("{0}: {1}", criterion.Name, criterion.Mode);
                    gridCriterions.Children.Add(label);
                    });
                }
                else
                {
                    InitializeComponent();
                }
                grid1.DataContext = test;

            }
        }
        private void resert()
        {
            /*foreach (var item in gridCriterions.Children)
            {
                gridCriterions.Children.Remove((UIElement)item);
            }*/
        }
    }
}
