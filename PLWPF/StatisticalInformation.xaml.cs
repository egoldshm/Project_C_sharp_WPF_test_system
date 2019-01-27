using BE;
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
    /// Interaction logic for StatisticalInformation.xaml
    /// </summary>
    public partial class StatisticalInformation : UserControl
    {
        public StatisticalInformation()
        {
            InitializeComponent();
        }


        private void trainee_Selected(object sender, RoutedEventArgs e)
        {
            buttonToDisplay.IsEnabled = true;
            items.ItemsSource = factoryBL.FactoryBL.GetBL().GetAllTrainees();
            buttonToDisplay.Content = "Select trainees to display";
        }
        private void tester_Selected(object sender, RoutedEventArgs e)
        {
            buttonToDisplay.IsEnabled = true;
            items.ItemsSource = factoryBL.FactoryBL.GetBL().GetAllTesters();
            buttonToDisplay.Content = "Select testers to display";
        }

        private void Items_ItemSelectionChanged(object sender,Xceed.Wpf.Toolkit.Primitives.ItemSelectionChangedEventArgs e)
        {
            buttonToDisplay.Content = "show information or change your selection";
            
        }
        
        private void ButtonToDisplay_Click(object sender, RoutedEventArgs e)
        {
            if(type.SelectedIndex == 0)//trainees
            {
                TraineeData.Visibility = Visibility.Visible;
                TesterData.Visibility = Visibility.Hidden;
                traineeInfo.Children.Clear();
                List<Trainee> list = new List<Trainee>(items.SelectedItems.Cast<Trainee>());
                //Add data about the trainees:
                list.ForEach(trainee =>
                {
                    Expander expander = new Expander();
                    expander.Header = trainee;
                    StackPanel stackPanel = new StackPanel();
                    addLabelToStackPanel(stackPanel, $"Name: {trainee.FirstName} {trainee.FamilyName}");
                    addLabelToStackPanel(stackPanel, $"Birthday: {trainee.Birthday}");
                    addLabelToStackPanel(stackPanel, $"Gander: {trainee.Gender}");
                    addLabelToStackPanel(stackPanel, $"Transmission Learned: {trainee.TransmissionLearned}");
                    addLabelToStackPanel(stackPanel, $"Type Car Learned: {trainee.TypeCarLearned}");
                    addLabelToStackPanel(stackPanel, $"Lesson number: {trainee.LessonsNumber}");
                    addLabelToStackPanel(stackPanel, $"school name: {trainee.SchoolName}");
                    addLabelToStackPanel(stackPanel, $"Teacher name: {trainee.TeacherName}");
                    addLabelToStackPanel(stackPanel, $"phone number: {trainee.PhoneNumber}");
                    addLabelToStackPanel(stackPanel, $"Address: {trainee.Address}");
                    expander.Content = stackPanel;
                    traineeInfo.Children.Add(expander);
                });
            }
            else if (type.SelectedIndex == 1)//testers
            {
                TraineeData.Visibility = Visibility.Hidden;
                TesterData.Visibility = Visibility.Visible;
                List<Tester> list = new List<Tester>(items.SelectedItems.Cast<Tester>());


            }
        }

        private static void addLabelToStackPanel(StackPanel stackPanel, string str)
        {
            Label label = new Label();
            label.Content = str;
            stackPanel.Children.Add(label);

        }
    }
}
