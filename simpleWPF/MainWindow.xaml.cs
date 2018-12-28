using Ibl;
using System.Windows;

namespace simpleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static IBL bl = factoryBL.FactoryBL.GetBL();

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}