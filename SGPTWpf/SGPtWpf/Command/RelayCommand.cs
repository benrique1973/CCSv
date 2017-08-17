//http://msdn.microsoft.com/en-us/magazine/dd419663.aspx#id0090030
//https://gist.github.com/schuster-rainer/2648922
////https://code.msdn.microsoft.com/windowsdesktop/Get-Password-from-df012a86
using System;
using System.Windows.Input;

namespace SGPTWpf.Comando
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {

        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute", "Execute cannot be null.");
            }

            _Execute = execute;
            _CanExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _Execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            if (_CanExecute == null)
            {
                return true;
            }

            return _CanExecute(parameter);
        }
    }
}
