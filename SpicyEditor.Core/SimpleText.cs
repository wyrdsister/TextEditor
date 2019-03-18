using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyEditor.Core
{
    public interface ITextStructure
    {
        String AsString(int startLine, int lineCount);
        String AsString();

        //void AppendChar(Int32 index, Char c);
    }

    public class SimpleText: ITextStructure
    {
        public SimpleText(String s)
        {
            _data = s.Split(new [] {Environment.NewLine}, StringSplitOptions.None).ToList();
        }
        public SimpleText(IReadOnlyCollection<String> lineArray)
        {
            _data = lineArray.ToList();
        }

        private List<String> _data;

        public string AsString(int startLine, int lineCount)
        {
            var page = _data.Skip(startLine).Take(lineCount);
            StringBuilder sb = new StringBuilder();

            foreach (var st in page)
            {
                sb.AppendLine(st);
            }

            return sb.ToString();
        }

        public string AsString() => AsString(0, _data.Count);

        public void AppendString(Int32 index, String input)
        {
            throw new NotImplementedException();
        }
    }

}
