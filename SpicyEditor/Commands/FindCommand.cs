using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpicyEditor.Commands
{
    class FindCommand : ICommand
    {
        private Boolean _isAnyFindWindowOpen = false;

        public bool CanExecute(object parameter)
        {
            var vm = parameter as ViewModel;
            if (vm == null)
                throw new ArgumentException("View Model Error");

            return true || !_isAnyFindWindowOpen && vm.MainText.LineCount == 0;
        }

        public void Execute(object parameter)
        {
            var vm = parameter as ViewModel;
            if (vm == null)
                throw new ArgumentException("View Model Error");
        
            SearchWindow sw = new SearchWindow();
            vm.FindAndReplaceVM = new FindAndReplaceViewModel(false);
            sw.DataContext = vm;

            sw.Show();
            _isAnyFindWindowOpen = true;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }

    class HelpCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            System.Diagnostics.Process.Start("https://github.com/wyrdsister/TextEditor/blob/master/README.md");
        }

        public event EventHandler CanExecuteChanged;
    }
}
