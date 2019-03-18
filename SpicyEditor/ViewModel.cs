using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SpicyEditor.Commands;
using SpicyEditor.Core;

namespace SpicyEditor
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private string _stupidText;
//        private ITextStructure _text;

        public ViewModel()
        {
            DialogService = new DialogService();
            FileService = new SimpleFileServer();
        }

        public IFileService FileService { get; }
        public IDialogService DialogService { get; }

        public string MainText
        {
            get => _stupidText;
            set
            {
                _stupidText = value;
                OnPropertyChanged(MainText);
            }
        }


        public SaveCommand SaveCommand { get; set; } = new SaveCommand();
        public SaveAsCommand SaveAsCommand { get; set; } = new SaveAsCommand();
        public OpenCommand OpenCommand { get; set; } = new OpenCommand();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void SetText(ITextStructure text)
        {
            _stupidText = text.AsString();
            //_text = text;
            OnPropertyChanged(nameof(MainText));
        }
    }
}