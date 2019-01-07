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
    /// Interaction logic for myPasswordBox.xaml
    /// </summary>
    /// 
    public partial class myPasswordBox : UserControl
    {
        public event EventHandler Changed;
        private string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
        bool hidePassword = true;

        public string Password { get => inputPassword.Password; set => inputPassword.Password = inputPassword_Text.Text= value; }
        public string Test { get => inputPassword.Password; set => inputPassword.Password = inputPassword_Text.Text = value; }

        public myPasswordBox()
        {
            InitializeComponent();
        }
        private void Button_Click_show(object sender, RoutedEventArgs e)
        {
            if (hidePassword)
            {
                inputPassword.Visibility = Visibility.Hidden;
                inputPassword_Text.Visibility = Visibility.Visible;
                password_hidder.Content = "hide password";
                inputPassword_Text.Text = inputPassword.Password;
            }
            else
            {
                inputPassword.Visibility = Visibility.Visible;
                inputPassword_Text.Visibility = Visibility.Hidden;
                password_hidder.Content = "show password";
                inputPassword.Password = inputPassword_Text.Text;
            }
            hidePassword = !hidePassword;
        }


        private void Button_Click_generate(object sender, RoutedEventArgs e)
        {
            string New_Password = CreatePassword(8);
            inputPassword.Password = inputPassword_Text.Text = New_Password;
        }

    }
}
