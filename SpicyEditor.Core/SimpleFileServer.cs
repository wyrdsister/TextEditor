using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SpicyEditor.Core;

namespace SpicyEditor
{
    public class SimpleFileServer : IFileService
    {
        public ITextStructure Open(string filename)
        {
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(filename, true))
            {
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine());
                }
            }

            return new SimpleText(lines);
        }

        public void Save(string filename, string text)
        {
            using (var sw = new StreamWriter(filename))
            {
                sw.Write(text);
            }
        }
    }
}
