using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfCommands.Commands
{
    public class RelayCommand : ICommand
    {

        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;
        private readonly Func<bool> _canExecutefunc;

        //public void RaiseCanExecuteChanged()
        //{
        //    CanExecuteChanged(this, new EventArgs());
        //}  
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }
        public RelayCommand(Action<object> execute, Func<bool> canExecute = null)
        {
            this._execute = execute;
            this._canExecutefunc = canExecute;
        }
        
        public bool CanExecuteFunc(object parameter)
        {
            return _canExecutefunc == null || _canExecute(parameter);
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void ExecuteFunc(object parameter)
        {
            _execute(parameter);
        }
    }
}
