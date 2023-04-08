using System;
using System.Windows.Input;

namespace ToDo_List
{
    internal class RelayCommand : ICommand
    {
        private readonly Action<object> _command;

        public RelayCommand(Action<object> action)
        {
            _command = action;
        }

        public event EventHandler? CanExecuteChanged;

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
