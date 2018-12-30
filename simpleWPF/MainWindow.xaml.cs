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
            InputDialogSample inputId = new InputDialogSample("enter id");
            InputDialogSample inputFirstName = new InputDialogSample("enter first name");
            InputDialogSample inputLastName = new InputDialogSample("enter Last Name");
            InputDialogSample inputSchoolName = new InputDialogSample("enter school name");
            InputDialogSample inputTeacherName = new InputDialogSample("enter teacher name");
            InputDialogSample inputPhone = new InputDialogSample("enter phone number");


            bl.AddTrainee(new Trainee(inputId.Answer, inputFirstName.Answer, inputLastName.Answer, inputSchoolName.Answer, int.Parse(inputPhone.Answer));
        }

        private void AddTesterClick(object sender, RoutedEventArgs e)
        {
        }

        private void AddTestClick(object sender, RoutedEventArgs e)
        {
        }
    }
}