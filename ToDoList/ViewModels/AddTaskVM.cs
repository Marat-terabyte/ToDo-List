using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ToDoList.Command;
using ToDoList.Models.Validators;
using ToDoList.Views;
using ToDoList_DatabaseTest.Model;

namespace ToDoList.ViewModels
{
    internal class AddTaskVM
    {
        private ObservableCollection<ToDoTask> _tasks;
        private IRepository<ToDoTask> _db;
        private AddTaskWindow _window;

        public ToDoTask TaskToAdd { get; set; }
        public ICommand AddTaskCommand { get; set; }

        public AddTaskVM(ObservableCollection<ToDoTask> collection, IRepository<ToDoTask> repository, AddTaskWindow window)
        {
            _window = window;
            TaskToAdd = new ToDoTask();
            _tasks = collection;
            _db = repository;

            AddTaskCommand = new RelayCommand(o => AddToDoTask());
        }

        private async void AddToDoTask()
        {
            bool isTaskValid = ToDoTaskValidator.CheckValidity(TaskToAdd);
            if (isTaskValid)
            {
                _tasks.Add(TaskToAdd);
                
                await Task.Run(() =>
                {
                    _db.Add(TaskToAdd);
                    _db.SaveAsync();
                });

                _window.Close();
            }
            else
            {
                MessageBox.Show("Name field is required");
            }
        }
    }
}
