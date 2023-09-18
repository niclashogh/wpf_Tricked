using System;
using System.Windows.Input;

namespace wpf_Tricked.ViewModel.Commands
{
    public abstract class BaseCMD : ICommand
    {
        //EventHandler
        public event EventHandler? CanExecuteChanged;

        //Bool test
        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        //Execution
        public abstract void Execute(object? parameter);

        //Update event
        protected void ExecutionStateChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
