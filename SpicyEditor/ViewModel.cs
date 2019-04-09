using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting;
using SpicyEditor.Commands;
using SpicyEditor.Core;

namespace SpicyEditor
{
    internal class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            DialogService = new DialogService();
            FileService = new SimpleFileServer();

            _avalonEditor.TextChanged += (sender, args) => UpdateStates();
        }

        private void UpdateStates()
        {
            CountLines = _avalonEditor.Document.LineCount;
            CountSymbols = _avalonEditor.Document.TextLength;
            Encoding = _avalonEditor.Encoding;
        }

        private readonly TextEditor _avalonEditor = new TextEditor();
        public TextEditor AvalonEditor => _avalonEditor;
        

        private TextDocument _smartText = new TextDocument();
        private Int32 _selectedStart;
        private int _selectedLength;

        private int _countLines = 0;
        public int CountLines
        {
            get => _countLines;
            set
            {
                if (_countLines != value)
                {
                    _countLines = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _countSymbols = 0;
        public int CountSymbols
        {
            get => _countSymbols;
            set
            {
                if (_countSymbols != value)
                {
                    _countSymbols = value;
                    OnPropertyChanged();
                }
            }
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
                OnPropertyChanged();
            }
        }

        public Int32 SelectedStart
        {
            get => _selectedStart;
            set { _selectedStart = value;
                OnPropertyChanged(); }
        }

        public IReadOnlyCollection<IHighlightingDefinition> AllSyntax => HighlightingManager.Instance.HighlightingDefinitions;

        public IHighlightingDefinition Language
        {
            get => _avalonEditor.SyntaxHighlighting;
            set
            {
                _avalonEditor.SyntaxHighlighting = value;
                OnPropertyChanged();
            }
        }

        public Encoding Encoding
        {
            get => _avalonEditor.Encoding;
            set
            {
                _avalonEditor.Encoding = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}