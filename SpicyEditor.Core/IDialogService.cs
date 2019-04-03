using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyEditor
{
    public interface IDialogService
    {
        void ShowMessage(string message);  
        string FilePath { get; set; }   // путь к выбранному файлу
        bool OpenFileDialog();  
        bool SaveFileDialog();
        bool SaveAsFileDialog();
    }
}
