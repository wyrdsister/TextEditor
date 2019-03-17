namespace SpicyEditor
{
    public interface IFileService
    {
        string Open(string filename);
        void Save(string filename, string text);
    }
}