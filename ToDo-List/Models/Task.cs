using System.ComponentModel;
using System.Runtime.CompilerServices;

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
            }
        }
        
        public string? Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public string? StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged("StartTime");
            }
        }
        public string? EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                OnPropertyChanged("EndTime");
            }
        }
        public bool IsDone
        {
            get { return _isDone; }
            set
            {
                _isDone = value;
                OnPropertyChanged("IsDone");
                
                if (_databaseContext != null)
                    _databaseContext.ExecuteCommand($"UPDATE tasks SET isDone = '{_isDone}' WHERE Id = {_id}");
            }
        }
        #endregion
        
        public Task() { }

        public Task(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
