using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToDo_List.Views;

namespace ToDo_List.Models
{
    public class Task : INotifyPropertyChanged
    {
        #region Fields
        private int _id;
        private string _title;
        private string? _description;
        private string? _startTime;
        private string? _endTime;
        private bool _isDone = false;
        private DatabaseContext _databaseContext;
        private ObservableCollection<Task> _tasks;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");

                _databaseContext?.ExecuteCommand($"UPDATE tasks SET Title = '{_title}' WHERE Id = {_id}");
            }
        }

        public string? Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");

                _databaseContext?.ExecuteCommand($"UPDATE tasks SET Description = '{_description}' WHERE Id = {_id}");
            }
        }

        public string? StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged("StartTime");

                _databaseContext?.ExecuteCommand($"UPDATE tasks SET StartTime = '{_startTime}' WHERE Id = {_id}");
            }
        }
        public string? EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                OnPropertyChanged("EndTime");

                _databaseContext?.ExecuteCommand($"UPDATE tasks SET EndTime = '{_endTime}' WHERE Id = {_id}");
            }
        }
        public bool IsDone
        {
            get { return _isDone; }
            set
            {
                _isDone = value;
                OnPropertyChanged("IsDone");

                _databaseContext?.ExecuteCommand($"UPDATE tasks SET isDone = '{_isDone}' WHERE Id = {_id}");
            }
        }

        public RelayCommand DeleteTaskCommand { get; }
        public RelayCommand EditTaskCommand { get; }
        #endregion

        public Task(DatabaseContext databaseContext, ObservableCollection<Task> tasks)
        {
            _databaseContext = databaseContext;
            _tasks = tasks;

            DeleteTaskCommand = new RelayCommand(o => DeleteTask());
            EditTaskCommand = new RelayCommand(o => EditTask());
        }

        private void DeleteTask()
        {
            string query = $"DELETE FROM tasks WHERE Id = {this.Id}";
            _databaseContext.ExecuteCommand(query);
            _tasks.Remove(this);
        }

        private void EditTask()
        {
            EditTask editTask = new EditTask(this);
            editTask.Show();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
