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
    /// user control of passwordbox. let you to generate new password and show/hide the password.
    /// </summary>
    public partial class myPasswordBox : UserControl
    {
        
      

        /// <summary>
        /// if the password now if hidden or not.
        /// </summary>
        bool hidePassword = true;

        /// <summary>
        /// Proprty the set if we want to access to generate the new password.
        /// </summary>
        public bool GenerateOpionIsShowed { get => generate.Visibility == Visibility.Visible; set { if (value) generate.Visibility = Visibility.Visible; else generate.Visibility = Visibility.Hidden; } }


        /// <summary>
        /// return the password.
        /// </summary>
        public string Password
        {
            get => inputPassword.Password; set
            {
                {
                    inputPassword.Password = value; inputPassword_Text.Text = value;
                }
            }
        }

        /// <summary>
        /// return the password.
        /// </summary>
        public string Test
        {
            get => inputPassword.Password;
            set
            {
                inputPassword.Password = value;
                inputPassword_Text.Text = value;
            }
        }

        /// <summary>
        /// constractor.
        /// </summary>
        public myPasswordBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// event that start when we change the Visibility of the password.
        /// </summary>
        private void Button_Click_show(object sender, RoutedEventArgs e)
        {
            if (hidePassword)
            {
                inputPassword.Visibility = Visibility.Hidden;
                inputPassword_Text.Visibility = Visibility.Visible;
                password_hidder.Content = "***";
                password_hidder.FontSize = 12;
                inputPassword_Text.Text = inputPassword.Password;
            }
            else
            {
                inputPassword.Visibility = Visibility.Visible;
                inputPassword_Text.Visibility = Visibility.Hidden;
                var image = new Image();
                image.Source = new BitmapImage(new Uri("photos/view.png", UriKind.Relative));
                password_hidder.Content = image; 
                inputPassword.Password = inputPassword_Text.Text;
            }
            hidePassword = !hidePassword;
        }

        /// <summary>
        /// generate the password.
        /// </summary>
        private void Button_Click_generate(object sender, RoutedEventArgs e)
        {
            string New_Password = BE.User.createNewPassword(BE.Configuration.LENGHT_OF_RAND_PASSWORD);
            inputPassword.Password = inputPassword_Text.Text = New_Password;
        }

     

        private void inputPassword_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            inputPassword.Password = inputPassword_Text.Text;

        }
    }
}
