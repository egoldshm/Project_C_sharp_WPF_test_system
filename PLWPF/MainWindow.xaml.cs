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
using Ibl;
using BE;
using System.ComponentModel;
using System.Threading;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl = factoryBL.FactoryBL.GetBL();
        public MainWindow()
        {
            InitializeComponent();
        }
        public static void ErrorMessage(string message)
        {
            MessageBox.Show(message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = this.UserName.Text;
            string InputPassword = this.password.Password;
            User user = bl.GetUser(username, InputPassword);
            if(user == null)
            {
                this.UserName.Text = "";
                password.Password = "";
                errorMessage.Visibility = Visibility.Visible;
            }
            else
            {
                switch (user.role)
                {
                    case User.RoleTypes.Trainee:
                        TraineeMainWindow windowTrainee = new TraineeMainWindow(user);
                        windowTrainee.Show();
                        Close();
                        break;
                    case User.RoleTypes.Teacher:
                        MessageBox.Show("לא מומש עדיין");
                        break;
                    case User.RoleTypes.Tester:
                        TesterMainWindow window = new TesterMainWindow(user);
                        window.Show();
                        Close();
                        break;
                    case User.RoleTypes.School:
                        MessageBox.Show("לא מומש עדיין");
                        break;
                    case User.RoleTypes.Admin:
                        AdminMainWindow windowAdmin = new AdminMainWindow(user);
                        windowAdmin.Show();
                        Close();
                        break;
                    default:
                        break;
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.UserName.Text = "";
            password.Password = "";
            MessageBox.Show("You log out.");

        }

        private void Button_Click_CreateNewTraineeUser(object sender, RoutedEventArgs e)
        {
            newAccount.IsEnabled = false;
            CreatNewTraineeUser window = new CreatNewTraineeUser();
            window.Show();
            window.Closed += Window_Closed1;
        }

        private void Window_Closed1(object sender, EventArgs e)
        {
            newAccount.IsEnabled = true;
        }

        /// <summary>
        /// function that get Action and start it in delay of few second
        /// </summary>
        /// <param name="action">the action to do</param>
        internal static void doFunctionInFewSecond(Action action)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync(action);
        }

        private static void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            (e.Result as Action)();
        }

        private static void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(10000);
            e.Result = e.Argument;
        }
    }
}
