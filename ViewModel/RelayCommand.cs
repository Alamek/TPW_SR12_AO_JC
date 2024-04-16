using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class RelayCommand : ICommand
    {
        private readonly Func<MyCommandParameters, bool> _canExecute;
        private readonly Action<MyCommandParameters> _execute;

        public RelayCommand(Action<MyCommandParameters> execute, Func<MyCommandParameters, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute ?? ((obj) => true);
        }

        public bool CanExecute(object parameter)
        {

            return true;

        }

        public void Execute(object parameter)
        {
            if (parameter is MyCommandParameters commandParameters)
            {
                _execute(commandParameters);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
