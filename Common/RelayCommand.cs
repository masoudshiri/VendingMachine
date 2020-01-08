using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace VendoreMachine.Common
{
    public sealed class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<bool> canExecute;
        private readonly List<EventHandler> invocationList = new List<EventHandler>();
        public RelayCommand(Action<object> execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return canExecute();
        }
        public void Execute(object parameter)
        {
            execute(parameter);
        }
        public void RaiseCanExecuteChanged()
        {
            foreach (var elem in invocationList)
            {
                elem(null, EventArgs.Empty);
            }
        }
        public event EventHandler CanExecuteChanged
        {
            add { invocationList.Add(value); }
            remove { invocationList.Remove(value); }
        }
    }
}
