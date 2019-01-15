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
    /// Interaction logic for AddLessonToTrainee.xaml
    /// </summary>
    public partial class AddLessonToTrainee : UserControl
    {
        public AddLessonToTrainee()
        {
            InitializeComponent();
            initializeData();
        }
        public void setTrainee(Trainee pTrainee)
        {
            trainee.SelectedValue = pTrainee;
            trainee.Text = pTrainee.ToString();
            trainee.IsEnabled = false;
            addLesson.Content = pTrainee.LessonsNumber;
        }
        public void setTrainees(List<Trainee> pTrainee)
        {
            trainee.ItemsSource = pTrainee;
            trainee.IsEnabled = true;
        }
        private void trainee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (trainee.SelectedIndex != -1)
            {
                Trainee t = (trainee.SelectedValue as Trainee);
                if (t != null)
                {
                    addLesson.Content = t.LessonsNumber;
                    if (trainee.SelectedIndex != -1)
                    {
                        addLesson.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        private void AddLesson_Click(object sender, RoutedEventArgs e)
        {
            BE.Trainee t = trainee.SelectionBoxItem as Trainee;
            if(t != null)
            {
                t.LessonsNumber += 1;
                factoryBL.FactoryBL.GetBL().UpdateTrainee(t);
                addLesson.Content = t.LessonsNumber;
            }
        }
        /// <summary>
        /// function that reset the element that may to change for update changes. for admin use.
        /// </summary>
        internal void initializeData()
        {
            int num = trainee.SelectedIndex;
            trainee.ItemsSource = factoryBL.FactoryBL.GetBL().GetAllTrainees();
            trainee.SelectedIndex = num;
        }
    }
}
