using SpicyEditor.Core;

namespace SpicyEditor
{
    public interface IFileService
    {
        ITextStructure Open(string filename);
        void Save(string filename, string text);
    }
}