using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting;
using SpicyEditor.Core;

namespace SpicyEditor
{
    internal class EditorViewModel : INotifyPropertyChanged
    {
        public EditorViewModel()
        {
            DialogService = new DialogService();
            FileService = new SimpleFileServer();

            AvalonEditor.TextChanged += (sender, args) => UpdateStates();
        }

        private void UpdateStates()
        {
            CountLines = AvalonEditor.Document.LineCount;
            CountSymbols = AvalonEditor.Document.TextLength;
        }

        public TextEditor AvalonEditor { get; } = new TextEditor();

        private TextDocument _smartText = new TextDocument();
        private Int32 _selectedStart;
        private int _selectedLength;

        private int _countLines = 0;

        public int CountLines
        {
            get => _countLines;
            set
            {
                if (_countLines == value) return;
                _countLines = value;
                OnPropertyChanged();
            }
        }

        private int _countSymbols = 0;
        private string _fileName = "untitled";

        public int CountSymbols
        {
            get => _countSymbols;
            set
            {
                if (_countSymbols == value) return;
                _countSymbols = value;
                OnPropertyChanged();
            }
        }

        public IFileService FileService { get; }
        public IDialogService DialogService { get; }

        public String FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                OnPropertyChanged();
            }
        }

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
            set
            {
                _selectedStart = value;
                OnPropertyChanged();
            }
        }

        public IReadOnlyCollection<IHighlightingDefinition> AllSyntax =>
            HighlightingManager.Instance.HighlightingDefinitions;

        public IHighlightingDefinition Language

        {
            get => AvalonEditor.SyntaxHighlighting;
            set
            {
                AvalonEditor.SyntaxHighlighting = value;
                OnPropertyChanged();
            }
        }

        private string _encodingName = "";
        
        public string Encoding
        {
            get => _encodingName;
            set
            {
                _encodingName = value;
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