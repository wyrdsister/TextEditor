using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ICSharpCode.AvalonEdit.Document;

namespace SpicyEditor.Commands
{
    class FindTextCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
//            var vm = parameter as ViewModel;
//            if (vm == null)
//                throw new ArgumentException("View Model Error");

            return true;
        }

        public void Execute(object parameter)
        {
            var vm = parameter as ViewModel;
            if (vm == null)
                throw new ArgumentException("View Model Error");

            var index = -1;
            do
            {
                var nextStart = index == -1 ? 0 : index + vm.FindAndReplaceVM.FindText.Length;
                if (vm.FindAndReplaceVM.FindText.Length + nextStart >= vm.MainText.TextLength)
                    break;
                index = vm.MainText.IndexOf(vm.FindAndReplaceVM.FindText, nextStart, vm.MainText.TextLength - nextStart,
                    StringComparison.OrdinalIgnoreCase);

                if (index >= 0)
                {
                    vm.AvalonEditor.SelectionStart = index;
                    vm.AvalonEditor.SelectionLength = vm.FindAndReplaceVM.FindText.Length;
                    if (vm.FindAndReplaceVM.IsReplace != Visibility.Collapsed)
                    {
                        vm.AvalonEditor.Document.Replace(index, vm.FindAndReplaceVM.FindText.Length,
                            new StringTextSource(vm.FindAndReplaceVM.ReplaceText));
                    } 
                    else break;
                }
            } while (index >= 0);
        }

        public event EventHandler CanExecuteChanged;
    }
}