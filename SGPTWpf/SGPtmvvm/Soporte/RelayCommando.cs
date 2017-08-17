using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SGPTmvvm.Soporte
{
	public class RelayCommando : ICommand
	{
		private readonly Action<object> _Execute;
		private readonly Func<object, bool> _CanExecute;

		public RelayCommando(Action<object> execute)
			: this(execute, null)
		{

		}

		public RelayCommando(Action<object> execute, Func<object, bool> canExecute)
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
