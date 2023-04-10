using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
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

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            try { this.DragMove(); }
            catch { }
        }
    }
}
