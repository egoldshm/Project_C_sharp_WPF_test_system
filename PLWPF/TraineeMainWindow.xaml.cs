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
    /// Interaction logic for TraineeMainWindow.xaml
    /// </summary>
    public partial class TraineeMainWindow : Window
    {
        readonly Trainee trainee;
        public TraineeMainWindow(User user)
        {
            InitializeComponent();
            if(user.role != User.RoleTypes.Trainee || !(user.connectTo is Trainee))
            {
                throw new Exception("worng user sended to trainee");
            }
            trainee = new Trainee(user.connectTo as Trainee);
        }
    }
}
