using System;
using System.Windows.Input;

namespace SpiderLaiR.Common
{
    public class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return DoCanExcute?.Invoke(parameter) == true;
        }

        public void Execute(object parameter)
        {
            DoExcute?.Invoke(parameter);
        }

        public Action<object> DoExcute { get; set; }

        public Func<object, bool> DoCanExcute { get; set; }
    }
}