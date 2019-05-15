using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Xml.Serialization;
using SpicyEditor.Commands;

namespace SpicyEditor
{
    internal class TabsViewModel : INotifyPropertyChanged
    {
        private EditorViewModel _selectedTab;

        public TabsViewModel()
        {
            Tabs = new ObservableCollection<EditorViewModel>();
            Tabs.Add(new EditorViewModel());
        }

        public ObservableCollection<EditorViewModel> Tabs { get; set; }

        public EditorViewModel SelectedTab
        {
            get => _selectedTab;
            set
            {
                _selectedTab = value;
                OnPropertyChanged();
            }
        }

        public HelpCommand HelpCommand { get; set; } = new HelpCommand();
        public FindCommand FindCommand { get; set; } = new FindCommand();
        public ReplaceCommand ReplaceCommand { get; set; } = new ReplaceCommand();
        public SaveCommand SaveCommand { get; set; } = new SaveCommand();
        public SaveAsCommand SaveAsCommand { get; set; } = new SaveAsCommand();
        public OpenCommand OpenCommand { get; set; } = new OpenCommand();
        public ICommand NewTabCommand { get; set; } = new NewTabCommand();

        public ICommand CloseTabCommand => new CloseTabCommand();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}