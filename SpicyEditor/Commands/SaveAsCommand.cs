using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpicyEditor.Commands
{
    class SaveAsCommand: ICommand
    {
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var vm = parameter as EditorViewModel;
            if (vm == null)
                throw new ArgumentException("View Model Error");

            if (vm.DialogService.SaveAsFileDialog())
                vm.FileService.Save(vm.DialogService.FilePath, vm.MainText.Text); //  плохие side-эффекты
        }

        public event EventHandler CanExecuteChanged;
    }
}
