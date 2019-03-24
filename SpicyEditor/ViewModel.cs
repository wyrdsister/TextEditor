using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using SpicyEditor.Commands;
using SpicyEditor.Core;

namespace SpicyEditor
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private TextEditor m_AvalonEditor = new TextEditor();
        public TextEditor AvalonEditor => m_AvalonEditor;

        private TextDocument _smartText = new TextDocument();
        private Int32 _selectedStart;
        private int _selectedLength;
//        private ITextStructure _text;

        public ViewModel()
        {
            DialogService = new DialogService();
            FileService = new SimpleFileServer();
        }

        public IFileService FileService { get; }
        public IDialogService DialogService { get; }

        public FindAndReplaceViewModel FindAndReplaceVM { get; set; }

        public TextDocument MainText
        {
            get => AvalonEditor.Document;
            set
            {
                 AvalonEditor.Document = new TextDocument(value);
                 OnPropertyChanged(nameof(MainText));

            }
        }

        public HelpCommand HelpCommand { get; set; } = new HelpCommand();
        public FindCommand FindCommand { get; set; } = new FindCommand();
        public ReplaceCommand ReplaceCommand { get; set; } = new ReplaceCommand();
        public SaveCommand SaveCommand { get; set; } = new SaveCommand();
        public SaveAsCommand SaveAsCommand { get; set; } = new SaveAsCommand();
        public OpenCommand OpenCommand { get; set; } = new OpenCommand();

        public Int32 SelectedLength
        {
            get => _selectedLength;
            set
            {
                _selectedLength = value;
                OnPropertyChanged(nameof(SelectedLength));
            }
        }

        public Int32 SelectedStart
        {
            get => _selectedStart;
            set { _selectedStart = value;
                OnPropertyChanged(nameof(SelectedStart)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void SetText(ITextStructure text)
        {
            _smartText = new TextDocument(text.AsString().AsEnumerable());
            OnPropertyChanged(nameof(MainText));
        }
    }
}