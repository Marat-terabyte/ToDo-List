using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ToDo_List.ViewModels;

namespace ToDo_List.Views
{
    /// <summary>
    /// Логика взаимодействия для AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        public AddTask(ObservableCollection<Models.Task> tasks, DatabaseContext databaseContext)
        {
            InitializeComponent();
            DataContext = new AddTaskVM(tasks, databaseContext, this);
        }

        private void CloseWindow(object sender, RoutedEventArgs e) => this.Close();

        private void MoveWindow(object sender, MouseButtonEventArgs e) => this.DragMove();
    }
}
