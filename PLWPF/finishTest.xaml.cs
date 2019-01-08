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
    /// Interaction logic for finishTest.xaml
    /// </summary>
    public partial class finishTest : UserControl
    {
        bool pass;
        string note;
        IBL bl = factoryBL.FactoryBL.GetBL();
        public finishTest()
        {
            InitializeComponent();
            CriterionsOfTest criterionsOfTest = new CriterionsOfTest();
            foreach (var item in criterionsOfTest.Criterions)
            {
                var label = new Label();
                label.Content = item.Name;
                CheckBox checkBox = new CheckBox();
                checkBox.Name = item.Name.Replace(" ", "_");
                critrions.Children.Add(label);
                critrions.Children.Add(checkBox);
            }
            tests.ItemsSource = bl.GetAllTests();
        }
        public List<Test> Tests { set => tests.ItemsSource = value; }
        public bool Pass { get => pass; set => pass = value; }
        public string Note { get => note; set => note = value; }
    }
}
