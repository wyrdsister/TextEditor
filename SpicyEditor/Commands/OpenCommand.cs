using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting;

namespace SpicyEditor.Commands
{
    class OpenCommand : ICommand
    {
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var vm = parameter as EditorViewModel;
            if (vm == null)
                throw new ArgumentException("View Model Error");

            if (vm.DialogService.OpenFileDialog())
            {
                string path = vm.DialogService.FilePath;
                vm.AvalonEditor.Load(path);
                vm.Language = HighlightingManager.Instance.GetDefinitionByExtension(Path.GetExtension(path));
                vm.Encoding = vm.AvalonEditor.Encoding.EncodingName;
                vm.FileName = Path.GetFileName(path);

            }
        }

        public event EventHandler CanExecuteChanged;
    }
}