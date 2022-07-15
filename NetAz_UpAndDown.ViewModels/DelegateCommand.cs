using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetAz_UpAndDown.ViewModels
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add
            {
                if (_canExecute is not null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute is not null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        public readonly Action _execute;
        public readonly Func<bool>? _canExecute;

        public DelegateCommand(Action execute, Func<bool>? canExecute = null)
        {
            ArgumentNullException.ThrowIfNull(execute);

            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return (_canExecute is null) ? true : _canExecute();
        }

        public void Execute(object? parameter)
        {
            _execute();
        }
    }
}
