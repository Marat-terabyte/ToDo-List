using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ToDo_List.Views;

namespace ToDo_List.ViewModels
{
    class AddTaskVM
    {
        private ObservableCollection<Models.Task> _tasks;
        private DatabaseContext _databaseContext;
        private AddTask _window;

        public Models.Task Task { get; set; }
        public DateTime DateTimeNow { get; } 
        public RelayCommand AddTaskCommand { get; }

        public AddTaskVM(ObservableCollection<Models.Task> tasks, DatabaseContext databaseContext, AddTask window)
        {
            _tasks = tasks;
            _databaseContext = databaseContext;
            _window = window;

            Task = new Models.Task(_databaseContext);
            DateTimeNow = DateTime.Now;
            
            AddTaskCommand = new RelayCommand(o => AddTask());
        }

        public void AddTask()
        {
            if (!string.IsNullOrEmpty(Task.Title))
            {
                if (_tasks.Count > 0)
                    Task.Id = _tasks.Last().Id + 1;
                else
                    Task.Id = 1;

                _tasks.Add(Task);
                _databaseContext.AddTask(Task);
                _window.Close();
            }
        }
    }
}
