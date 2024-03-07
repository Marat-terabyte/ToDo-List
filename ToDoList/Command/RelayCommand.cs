using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToDoList.Command
{
    internal class RelayCommand : ICommand
    {
        private readonly Action<object> _command;

        
        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action<object> action)
        {
            _command = action;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _command(parameter);
        }
    }
}