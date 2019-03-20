using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICSharpCode.AvalonEdit.Document;

namespace SpicyEditor.Commands
{
    class OpenCommand : ICommand
    {
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var vm = parameter as ViewModel;
            if (vm == null)
                throw new ArgumentException("View Model Error");

            if (vm.DialogService.OpenFileDialog())
            {
                vm.MainText = new TextDocument(vm.FileService.Open(vm.DialogService.FilePath).AsString());
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}