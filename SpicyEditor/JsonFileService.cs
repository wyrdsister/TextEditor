using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SpicyEditor
{
    public class JsonFileService : IFileService
    {
        public string Open(string filename)
        {
            string text;
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(string));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            using (StreamReader sr = new StreamReader(fs))
            {
                text = sr.ReadToEnd(); //jsonFormatter.ReadObject(fs) as string;
            }

            return text;
        }

        public void Save(string filename, string text)
        {
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(string));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, text);
            }
        }
    }
}
