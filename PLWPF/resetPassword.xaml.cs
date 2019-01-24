using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for resetPassword.xaml
    /// </summary>
    public partial class ResetPassword : Window
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        public static bool IsValidEmailAddress(string s)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsValidEmailAddress(email.Text))
            {
                email.BorderBrush = null;
                createButton.IsEnabled = true;
            }
            else
            {
                email.BorderBrush = new SolidColorBrush(Colors.Red);
                email.BorderThickness = new Thickness(3);
                createButton.IsEnabled = false;
            }
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker backgroudworker = new BackgroundWorker();
            bool work = factoryBL.FactoryBL.GetBL().resetPassword(username.Text, email.Text);
            if(work)
            {
                message.Visibility = Visibility.Visible;
                message.Content = "new password sended to your email.";
                message.Foreground = new SolidColorBrush(Colors.Green);
                backgroudworker.DoWork += Backgroudworker_DoWork;
                backgroudworker.RunWorkerCompleted += Backgroudworker_RunWorkerCompleted;
                backgroudworker.RunWorkerAsync();
            }
            else
            {
                message.Visibility = Visibility.Visible;
                message.Content = "Error. Please check the information you entered.";

            }
        }

        private void Backgroudworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        private void Backgroudworker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    message.Content = $"new password sended to your email. closing in {10 - i} sec";
                }));
            }
        }
    }
}
