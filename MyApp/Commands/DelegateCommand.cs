using System;
using System.Windows.Input;

namespace MyApp.Commands
{
    public class DelegateCommand : ICommand
    {
        Action<object>  _execute;
        Action  _executeT;
        Func<object, bool> _canExecute;

        // Событие, необходимое для ICommand
        public event EventHandler CanExecuteChanged;

        // Два конструктора
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }
        
        public DelegateCommand(Action<object> execute)
        {
            this._execute = execute;
            this._canExecute = this.AlwaysCanExecute;
        }

        public DelegateCommand(Action execute)
        {
            this._executeT = execute;
            this._canExecute = this.AlwaysCanExecute;
        }
        
        // Методы, необходимые для ICommand
        public void Execute(object param)
        {
            if (param != null)
                _execute(param);
            else
                _executeT();
        }

        public bool CanExecute(object param)
        {
            return _canExecute(param);
        }

        // Метод, необходимый для IDelegateCommand
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }

        // Метод CanExecute по умолчанию
        private bool AlwaysCanExecute(object param)
        {
            return true;
        }
    }
}