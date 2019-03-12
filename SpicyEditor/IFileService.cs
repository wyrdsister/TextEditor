using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyEditor
{
    interface IFileService
    {
        string Open(string filename);
        void Save(string filename, string MainText);
    }
}
