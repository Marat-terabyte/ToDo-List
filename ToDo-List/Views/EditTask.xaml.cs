using System.Windows;
using System.Windows.Input;
using ToDo_List.ViewModels;

namespace ToDo_List.Views
{
    /// <summary>
    /// Логика взаимодействия для EditTask.xaml
    /// </summary>
    public partial class EditTask : Window
    {
        public EditTask(Models.Task task)
        {
            InitializeComponent();
            DataContext = new EditTaskVM(task);
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            try { DragMove(); }
            catch { }
        }

        private void CloseWindow(object sender, RoutedEventArgs e) => this.Close();
    }
}
