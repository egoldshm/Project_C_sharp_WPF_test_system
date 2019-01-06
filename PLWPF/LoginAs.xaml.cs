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
using BE;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for LoginAs.xaml
    /// </summary>
    public partial class LoginAs : UserControl
    {
        Ibl.IBL bl = factoryBL.FactoryBL.GetBL();
        private User user;
        public LoginAs()
        {
            InitializeComponent();
            List<User.RoleTypes> list = new List<User.RoleTypes>((IEnumerable<User.RoleTypes>)Enum.GetValues(typeof(User.RoleTypes)));
            list.Remove(User.RoleTypes.Admin);
            role.ItemsSource = list;

        }
        private User.RoleTypes oldRole;
        public User User { get => user; set => user = value; }

  

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (role.SelectionBoxItem.ToString() == string.Empty || item.SelectionBoxItem.ToString() == string.Empty)
            {
                MessageBox.Show("Fill in all the cells and try again");
                return;
            }
            User.RoleTypes NewRole = (User.RoleTypes)role.SelectionBoxItem;
            Window window;
            switch (NewRole)
            {
                case User.RoleTypes.Trainee:
                    user.ConnectTo = new Trainee(item.SelectionBoxItem as Trainee);
                    window = new TraineeMainWindow(user);
                    window.Show();
                    break;
                case User.RoleTypes.Teacher:
                    user.ConnectTo = item.SelectionBoxItem.ToString();
                    break;
                case User.RoleTypes.Tester:
                    user.ConnectTo = new Tester(item.SelectionBoxItem as Tester);
                    window = new TesterMainWindow(user);
                    window.Show();
                    break;
                case User.RoleTypes.School:
                    user.ConnectTo = item.SelectionBoxItem.ToString();
                    break;
            }
        }

        private void Role_DropDownClosed(object sender, EventArgs e)
        {
            User.RoleTypes NewRole;
            if (role.SelectionBoxItem.ToString() != string.Empty && role.SelectionBoxItem is User.RoleTypes)
            {
                NewRole = (User.RoleTypes)role.SelectionBoxItem;
                if (NewRole == oldRole)
                    return;
                switch (NewRole)
                {
                    case User.RoleTypes.Trainee:
                        item.ItemsSource = bl.GetAllTrainees();
                        break;
                    case User.RoleTypes.Teacher:
                        item.ItemsSource = bl.GetTraineesByTeacher().Select(group => group.First().TeacherName);
                        break;
                    case User.RoleTypes.Tester:
                        item.ItemsSource = bl.GetAllTesters();
                        break;
                    case User.RoleTypes.School:
                        item.ItemsSource = bl.GetTraineesBySchoolName().Select(group => group.First().SchoolName);
                        break;
                }
                oldRole = NewRole;
            }

        }
    }
}