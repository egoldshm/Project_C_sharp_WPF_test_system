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
        Ibl.IBL bl = factoryBL.FactoryBL.GetBL();
        public StatisticalInformation()
        {
            InitializeComponent();
        }


        private void trainee_Selected(object sender, RoutedEventArgs e)
        {
            items.IsEnabled = true;
            items.ItemsSource = bl.GetAllTrainees();
            //buttonToDisplay.Text = "Select trainees to display";
        }
        private void tester_Selected(object sender, RoutedEventArgs e)
        {
            items.IsEnabled = true;
            items.ItemsSource = bl.GetAllTesters();
            //buttonToDisplay.Text = "Select testers to display";
        }

        private void Items_ItemSelectionChanged(object sender,Xceed.Wpf.Toolkit.Primitives.ItemSelectionChangedEventArgs e)
        {
            // buttonToDisplay.Text = "show information or change your selection";
            if (type.SelectedIndex == 0)//trainees
            {
                TraineeData.Visibility = Visibility.Visible;
                TesterData.Visibility = Visibility.Hidden;
                messageToSelect.Visibility = Visibility.Hidden;

                traineeInfo.Children.Clear();
                List<Trainee> list = new List<Trainee>(items.SelectedItems.Cast<Trainee>());
                if (list.Count == 0)
                {
                    TraineeData.Visibility = Visibility.Hidden;
                    messageToSelect.Visibility = Visibility.Visible;

                    return;
                }
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

                AverageAge.Content = list.Average(trainee => GetAgeByBirthday(trainee.Birthday));
                maxAge.Content = list.Max(trainee => GetAgeByBirthday(trainee.Birthday));
                MinAge.Content = list.Min(trainee => GetAgeByBirthday(trainee.Birthday));

                AverageLesson.Content = list.Average(trainee => trainee.LessonsNumber);
                maxLesson.Content = list.Max(trainee => trainee.LessonsNumber);
                MinLesson.Content = list.Min(trainee => trainee.LessonsNumber);
                totalLessons.Content = list.Sum(trainee => trainee.LessonsNumber);

                TotalTrainees.Content = list.Count;
                MaleNumber.Content = list.Count(trainee => trainee.Gender == Gender.Male);
                femaleNumber.Content = list.Count(trainee => trainee.Gender == Gender.Female);

                AutomaticCars.Content = list.Count(trainee => trainee.TransmissionLearned == TransmissionType.Automatic);
                ManualCars.Content = list.Count(trainee => trainee.TransmissionLearned == TransmissionType.Manual);

                Heavy_truckCars.Content = list.Count(trainee => trainee.TypeCarLearned == CarType.Heavy_truck);
                Medium_truckCars.Content = list.Count(trainee => trainee.TypeCarLearned == CarType.Medium_truck);
                Private_CarCars.Content = list.Count(trainee => trainee.TypeCarLearned == CarType.Private_Car);
                Two_wheeled_vehiclesCars.Content = list.Count(trainee => trainee.TypeCarLearned == CarType.Two_wheeled_vehicles);

                totalTests.Content = list.Sum(trainee => bl.GetTestsByTrainee(trainee).Count);
                totalGoodTests.Content = list.Sum(trainee => bl.GetTestsByTrainee(trainee).Where(test => bl.isTestFinished(test) && test.Pass).Count());
                totalBadTests.Content = list.Sum(trainee => bl.GetTestsByTrainee(trainee).Where(test => bl.isTestFinished(test) && !test.Pass).Count());
                totalDidntDone.Content = list.Sum(trainee => bl.GetTestsByTrainee(trainee).Where(test => !bl.isTestFinished(test)).Count());
            }
            else if (type.SelectedIndex == 1)//testers
            {
                TraineeData.Visibility = Visibility.Hidden;
                TesterData.Visibility = Visibility.Visible;
                messageToSelect.Visibility = Visibility.Hidden;
                List<Tester> list = new List<Tester>(items.SelectedItems.Cast<Tester>());
                testerInfo.Children.Clear();

                if (list.Count == 0)
                {
                    TesterData.Visibility = Visibility.Hidden;
                    messageToSelect.Visibility = Visibility.Visible;
                    return;
                }
                //Add data about the testers:
                list.ForEach(tester =>
                {
                    Expander expander = new Expander();
                    expander.Header = tester;
                    StackPanel stackPanel = new StackPanel();
                    addLabelToStackPanel(stackPanel, $"Name: {tester.FirstName} {tester.LastName}");
                    addLabelToStackPanel(stackPanel, $"Birthday: {tester.DateOfBirth}");
                    addLabelToStackPanel(stackPanel, $"Gander: {tester.Gender}");
                    addLabelToStackPanel(stackPanel, $"max distance: {tester.MaxDistance}");
                    addLabelToStackPanel(stackPanel, $"Type Car Learned: {tester.CarType}");
                    addLabelToStackPanel(stackPanel, $"Years Of Experience: {tester.YearsOfExperience}");
                    addLabelToStackPanel(stackPanel, $"Max Weekly Tests: {tester.MaxWeeklyTests}");
                    addLabelToStackPanel(stackPanel, $"phone number: {tester.PhoneNumber}");
                    addLabelToStackPanel(stackPanel, $"Address: {tester.Address}");
                    expander.Content = stackPanel;
                    testerInfo.Children.Add(expander);
                });

                AverageAgeTester.Content = list.Average(tester => GetAgeByBirthday(tester.DateOfBirth));
                maxAgeTester.Content = list.Max(tester => GetAgeByBirthday(tester.DateOfBirth));
                MinAgeTester.Content = list.Min(tester => GetAgeByBirthday(tester.DateOfBirth));

                YearsOfExperienceAvg.Content = list.Average(tester => tester.YearsOfExperience);
                YearsOfExperienceMax.Content = list.Max(tester => tester.YearsOfExperience);
                YearsOfExperienceMin.Content = list.Min(tester => tester.YearsOfExperience);

                MaxWeeklyAvg.Content = list.Average(tester => tester.MaxWeeklyTests);
                MaxWeeklyMax.Content = list.Max(tester => tester.MaxWeeklyTests);
                MaxWeeklyMin.Content = list.Min(tester => tester.MaxWeeklyTests);


                MaxDistanceAvg.Content = list.Average(tester => tester.MaxDistance);
                MaxDistanceMax.Content = list.Max(tester => tester.MaxDistance);
                MaxDistanceMin.Content = list.Min(tester => tester.MaxDistance);


                TotalTests.Content = list.Count;
                MaleNumberTester.Content = list.Count(trainee => trainee.Gender == Gender.Male);
                femaleNumberTester.Content = list.Count(trainee => trainee.Gender == Gender.Female);

                Heavy_truckCarsTester.Content = list.Count(tester => tester.CarType == CarType.Heavy_truck);
                Medium_truckCarsTester.Content = list.Count(tester => tester.CarType == CarType.Medium_truck);
                Private_CarCarsTester.Content = list.Count(tester => tester.CarType == CarType.Private_Car);
                Two_wheeled_vehiclesCarsTester.Content = list.Count(tester => tester.CarType == CarType.Two_wheeled_vehicles);

                totalTestsTester.Content = list.Sum(tester => bl.GetTestsByTesters(tester).Count);
                totalGoodTestsTester.Content = list.Sum(tester => bl.GetAllSuccessfullTestsByTester(tester).Count);
                totalBadTestsTester.Content = list.Sum(tester => bl.GetAllSuccessfullTestsByTester(tester,false).Count);
                totalDidntDoneTester.Content = list.Sum(tester => bl.GetTestsByTesters(tester).Where(test => !bl.isTestFinished(test)).Count()); ;

            }
        }
        /// <summary>
        /// function that get Birthday in DateTime type and return age of the men who born there.
        /// </summary>
        /// <param name="birthday">the Birthday of the humen. type: DateTime</param>
        /// <returns>age of the men (float) </returns>
        private static float GetAgeByBirthday(DateTime birthday)
        {
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int birthdayINT = int.Parse(birthday.ToString("yyyyMMdd"));
            float age = (now - birthdayINT) / 10000;
            return age;
        }

       

        private static void addLabelToStackPanel(StackPanel stackPanel, string str)
        {
            Label label = new Label();
            label.FontFamily = new FontFamily("Gisha");
            label.Foreground = new SolidColorBrush(Colors.DarkGray);
            label.Content = str;
            stackPanel.Children.Add(label);

        }
    }
}
