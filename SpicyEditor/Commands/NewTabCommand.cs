using System;
using System.Windows.Input;

namespace SpicyEditor.Commands
{
    class CloseTabCommand : ICommand
    {

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var vm = parameter as TabsViewModel;
            if (vm == null)
                throw new ArgumentException("View Model Error");

            vm.Tabs.Remove(vm.SelectedTab);
        }

        public event EventHandler CanExecuteChanged;
    }

    class NewTabCommand : ICommand
    {
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var vm = parameter as TabsViewModel;
            if (vm == null)
                throw new ArgumentException("View Model Error");

            EditorViewModel tab = new EditorViewModel();
            vm.Tabs.Add(tab);
            vm.SelectedTab = tab;
        }

        public event EventHandler CanExecuteChanged;
    }
}