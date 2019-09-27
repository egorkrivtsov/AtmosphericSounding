using System;
using System.Windows.Input;

namespace WpfUI.Common
{
    public class Command : ICommand
    {
        private readonly Action action;

        public Command(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }

        public void Execute()
        {
            Execute(null);
        }

        public event EventHandler CanExecuteChanged;
    }

    public class Command<T> : ICommand where T : class
    {
        private readonly Action<T> action;

        public Command(Action<T> action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action(parameter as T);
        }

        public void Execute()
        {
            Execute(null);
        }

        public event EventHandler CanExecuteChanged;
    }
}
