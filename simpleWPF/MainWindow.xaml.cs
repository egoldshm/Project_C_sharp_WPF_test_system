using BE;
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

        private void AddTraineeClick(object sender, RoutedEventArgs e)
        {
            InputDialogSample input = new InputDialogSample()
            bl.AddTrainee(new Trainee())
        }

        private void AddTesterClick(object sender, RoutedEventArgs e)
        {
        }

        private void AddTestClick(object sender, RoutedEventArgs e)
        {
        }
    }
}