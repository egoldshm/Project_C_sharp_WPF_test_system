using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddAutoTest.xaml
    /// </summary>
    public partial class AddAutoTest : UserControl
    {
        struct ForTest
        {
            public Trainee Trainee;
            public Tester Tester;
            public DateTime DateTime;
            public Address Address;
        }
        struct BackgroundResult
        {
            public Exception Exception;
            public object Result;
        }
        private BackgroundWorker GetDistanceThread;
        private Ibl.IBL bl = factoryBL.FactoryBL.GetBL();

        public AddAutoTest()
        {
            InitializeComponent();
            GetDistanceThread = new BackgroundWorker();
            GetDistanceThread.DoWork += GetDistanceThread_DoWork;
            GetDistanceThread.RunWorkerCompleted += GetDistanceThread_RunWorkerCompleted;
            initializeData();
        }

        private void GetDistanceThread_DoWork(object sender, DoWorkEventArgs e)
        {
            Test test = new Test();
            BackgroundResult Result;
            try
            {
                ForTest? arg = e.Argument as ForTest?;
                test = bl.createTest(arg.Value.Trainee.Id, arg.Value.Address, arg.Value.DateTime);
            }
            catch (Exception ex)
            {
                Result.Exception = ex;
                Result.Result = "Didn't add test";
                e.Result = Result;
            }
            Result.Result = "added test";
            Result.Exception = new Exception( $"Test number {test.TestNumber} created. In {test.DateOfTest} with Tester {test.TesterId}");
            e.Result = Result;
        }

        private void GetDistanceThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundResult? Result = e.Result as BackgroundResult?;
            MessageBox.Show(Result.Value.Result as string);
            errorMessage.Content = Result.Value.Exception.Message;
            errorMessage.Foreground = new SolidColorBrush(Colors.Red);
        }

        /// <summary>
        /// function that set list of trainees that will be aviable in the list. for teacher and school use.
        /// </summary>
        /// <param name="trainees">the list of the trainees that will be aviable</param>
        public void setTrainees(List<Trainee> trainees)
        {
            traineeIdList.ItemsSource = trainees;
        }

        /// <summary>
        /// set single trainee that will be able to set set for himself only. for Trainee use.
        /// </summary>
        /// <param name="trainee">the trainee that will be use alone.</param>
        public void setTrainee(Trainee trainee)
        {
            traineeIdList.SelectedValue = trainee;
            traineeIdList.Text = trainee.ToString();
            traineeIdList.IsEnabled = false;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Event when the click to create test click. try to create test.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ForTest arg = new ForTest();
                arg.Trainee = new Trainee(traineeIdList.SelectionBoxItem as Trainee);
                arg.DateTime = DateTime.Parse(dateOfTestDatePicker.Text);
                arg.Address = new Address(city.Text, int.Parse(building_number.Text), street.Text);
                
                GetDistanceThread.RunWorkerAsync(arg);
            }
            catch (Exception ex)
            {
                errorMessage.Content = ex.Message;
                errorMessage.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        /// <summary>
        /// function that reset the element that may to change for update changes. for admin use.
        /// </summary>
        internal void initializeData()
        {
            traineeIdList.ItemsSource = bl.GetAllTrainees();
        }
    }
}