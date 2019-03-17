using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Interactivity;
using Microsoft.Win32;
using System.Windows;


namespace SpicyEditor 
{
    class ViewModel : INotifyPropertyChanged
    {
        IFileService fileService;
        IDialogService dialogService;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
           if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop)); // почему-то не работает
        }

        private string mainText;
        public string MainText
        {
            get { return mainText; }
            set
            {
                mainText = value;
                OnPropertyChanged("MainText");
            }
        }

        public ViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;
        }


        // команда сохранения файла
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SaveFileDialog() == true)
                          {
                              fileService.Save(dialogService.FilePath, MainText);
                              //dialogService.ShowMessage("Файл сохранен");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        // команда открытия файла
        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog() == true)
                          {
                              var text = fileService.Open(dialogService.FilePath);
                              MainText = "";
                              foreach (var p in text)
                                  MainText += p;
                              //dialogService.ShowMessage("Файл открыт");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }


    }
}
