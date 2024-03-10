using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToDoList.Command;
using ToDoList.Views;
using ToDoList_DatabaseTest.Model;

namespace ToDoList.ViewModels
{
    internal class MainWindowVM
    {
        private IRepository<ToDoTask> _database;

        public string DateTimeNow { get => DateTime.Now.ToString("D"); }
        public ObservableCollection<ToDoTask> Tasks { get; }
        
        public ICommand EditTaskCommand { get; }
        public ICommand OpenAddTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }

        public MainWindowVM()
        {
            _database = new TaskRepository();
            Tasks = new ObservableCollection<ToDoTask>(_database.GetAll());
            
            OpenAddTaskCommand = new RelayCommand(o => OpenAddTaskWindow());
            DeleteTaskCommand = new RelayCommand(o => DeleteTask((int) o));
            EditTaskCommand = new RelayCommand(o => MessageBox.Show("Edit"));
        }

        private void DeleteTask(int id)
        {
            MessageBox.Show("fsa");
            Tasks.RemoveAt(id - 1);
            _database.Delete(id);
        }

        private void OpenAddTaskWindow()
        {
            AddTaskWindow window = new AddTaskWindow(Tasks, _database);
            window.ShowDialog();
        }
    }
}
