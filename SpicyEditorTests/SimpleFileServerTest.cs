using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpicyEditor;
using SpicyEditor.Core;

namespace SpicyEditorTests
{
    [TestClass]
    public class SimpleFileServerTest
    {
        [TestMethod]
        public void OpenTest()
        {
            string fileName = Path.GetTempFileName();
            StreamWriter w = File.CreateText(fileName);
            using (w)
            {
                w.Write("Test text");
            }

            SimpleFileServer fileServer = new SimpleFileServer();

            ITextStructure text = fileServer.Open(fileName);
            Assert.IsTrue(string.Equals(text.AsString().TrimEnd('\r','\n'), "Test text"));
            File.Delete(fileName);
        }

        [TestMethod]
        public void OpenNullTest()
        {
            string fileName = Path.GetTempFileName();
            File.CreateText(fileName);

            SimpleFileServer fileServer = new SimpleFileServer();

            ITextStructure text = fileServer.Open(fileName);
            Assert.IsTrue(string.Equals(text.AsString().TrimEnd('\r', '\n'), ""));
            File.Delete(fileName);
        }
    }
}