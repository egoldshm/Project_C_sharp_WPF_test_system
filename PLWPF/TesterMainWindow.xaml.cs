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
using System.Windows.Shapes;
using BE;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for TesterMainWindow.xaml
    /// </summary>
    public partial class TesterMainWindow : Window
    {
        public User User;
        Tester tester;
        public TesterMainWindow(User user1)
        {
            InitializeComponent();
            User = user1;
            if(!(User.role == User.RoleTypes.Tester && User.ConnectTo is Tester))
            {
                throw new Exception("User valid");
            }
            tester = User.ConnectTo as Tester;
            title.user = User;
        }
    }
}
