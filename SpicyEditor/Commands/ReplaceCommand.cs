using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpicyEditor.Commands
{
    class ReplaceCommand : ICommand
    {
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var vm = parameter as ViewModel;
            if (vm == null)
                throw new ArgumentException("View Model Error");

            SearchWindow sw = new SearchWindow();
            vm.FindAndReplaceVM = new FindAndReplaceViewModel(true);
            sw.DataContext = vm;

            sw.Show();
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}