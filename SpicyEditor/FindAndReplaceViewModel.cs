using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using SpicyEditor.Commands;

namespace SpicyEditor
{
    class FindAndReplaceViewModel : INotifyPropertyChanged
    {
        private bool _isReplace;

        public FindAndReplaceViewModel(bool isReplace)
        {
            _isReplace = isReplace;
        }

        public FindAndReplaceViewModel()
        {
            _isReplace = false;
        }

        public String FindText { get; set; }
        public String ReplaceText { get; set; }

        public Visibility IsReplace
        {
            get => _isReplace ? Visibility.Visible : Visibility.Collapsed;
        }

        public FindTextCommand FindAndReplaceCommand { get; set; } = new FindTextCommand();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}