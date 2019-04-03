using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows;


namespace SpicyEditor
{
    public class DialogService : IDialogService
    {
        public string FilePath { get; set; }

        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                SpicyEditor.Core.Properties.Settings.Default.FilePath = FilePath;
                return true;
            }
            return false;
        }

        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (SpicyEditor.Core.Properties.Settings.Default.FilePath.Length > 1)
            {
                FilePath = SpicyEditor.Core.Properties.Settings.Default.FilePath;
                return true;
            }
            else if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                SpicyEditor.Core.Properties.Settings.Default.FilePath = FilePath;
                return true;
            }
            return false;
        }
        public bool SaveAsFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                return true;
            }
            return false;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
