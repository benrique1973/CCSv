using System;
using System.Windows.Input;

namespace SGPTmvvm.Soporte
{
    public class CommandHandler:ICommand
    {
        #region
            private Action _actionP;
            private bool _canExecute;
            public CommandHandler(Action actionp, bool canExecute)
            {
                _actionP = actionp;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute;
            }

            public event EventHandler CanExecuteChanged; //lo implementamos pq asi lo demanda la interfaz

            public void Execute(object parameter)
            {
                _actionP();
            } 
            #endregion
    }
}
