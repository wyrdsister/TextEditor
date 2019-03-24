using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpicyEditor.Commands
{
    class SaveCommand: ICommand
    {
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var vm = parameter as ViewModel;
            if (vm == null)
                throw new ArgumentException("View Model Error");

            if (vm.DialogService.SaveFileDialog())
                vm.FileService.Save(vm.DialogService.FilePath, vm.MainText.Text); //  плохие side-эффекты
        }

        public event EventHandler CanExecuteChanged;
    }
}
