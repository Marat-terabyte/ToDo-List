using System;
using System.Collections.ObjectModel;
using ToDo_List.Views;

namespace ToDo_List.ViewModels
{
    internal class MainWindowVM
    {
        public RelayCommand OpenAddTaskWindowCommand { get; }
        public ObservableCollection<Models.Task> Tasks { get; set; }
        public DatabaseContext DbContext;

        public string DateTimeNow
        {
            get
            {
                return DateTime.Now.ToString("D");
            }
        }

        public MainWindowVM()
        {
            DbContext = new DatabaseContext();
            
            Tasks = DbContext.GetTasks();

            OpenAddTaskWindowCommand = new RelayCommand(o => OpenAddTaskWindow());
        }

        private void OpenAddTaskWindow() => new AddTask(Tasks, DbContext).Show();
    }
}
