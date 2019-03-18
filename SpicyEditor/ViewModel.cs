using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ICSharpCode.AvalonEdit.Document;
using SpicyEditor.Commands;
using SpicyEditor.Core;

namespace SpicyEditor
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private TextDocument _smartText = new TextDocument();
//        private ITextStructure _text;

        public ViewModel()
        {
            DialogService = new DialogService();
            FileService = new SimpleFileServer();
        }

        public IFileService FileService { get; }
        public IDialogService DialogService { get; }

        public TextDocument MainText
        {
            get => _smartText;
            set
            {
                _smartText = value;
                OnPropertyChanged(nameof(MainText));
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
            _smartText = new TextDocument(text.AsString().AsEnumerable());
            //_text = text;
            OnPropertyChanged(nameof(MainText));
        }


    }
}