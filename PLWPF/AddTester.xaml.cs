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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddTester.xaml
    /// </summary>
    public partial class AddTester : UserControl
    {
        
        public AddTester()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    CheckBox checkBox = new CheckBox();
                    WorkHours.Children.Add(checkBox);
                    Grid.SetRow(checkBox, i);
                    Grid.SetColumn(checkBox, j);
                    checkBox.Margin = new Thickness(3);
                    checkBox.Name = "checkBox" + i + "_" + j;
                }
            }

        }

    }
}
