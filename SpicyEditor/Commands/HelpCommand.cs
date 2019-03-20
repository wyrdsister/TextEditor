using System;
using System.Windows.Input;

namespace SpicyEditor.Commands
{
    class HelpCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            System.Diagnostics.Process.Start("https://github.com/wyrdsister/TextEditor/tree/using-custom-textbox");
        }

        public event EventHandler CanExecuteChanged;
    }
}