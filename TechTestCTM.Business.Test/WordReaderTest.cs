using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTestCTM.Data;
using System.IO;
using System.Text;
using TechTestCTM.Business.WordReader;
using System.Collections.Generic;

namespace TechTestCTM.Business.Test
{
    [TestClass]
    public class WordReaderTest
    {
        private List<string> results;

        [TestMethod]
        public void When_WordReader_reads_a_simple_sentence_an_event_is_raised_for_each_word()
        {
            results = new List<string>();
            Mock<IBookStream> bookStream = new Mock<IBookStream>();
            bookStream.Setup(x => x.Stream).Returns(new MemoryStream(Encoding.ASCII.GetBytes("The quick brown fox jumped over lazy dog.")));
            IWordReader wordReader = new TechTestCTM.Business.WordReader.WordReader(bookStream.Object);
            wordReader.WordRead += new WordReadEventHandler(testCallback);
            wordReader.Read();
            Assert.AreEqual(8, results.Count);
            Assert.IsTrue(results.Contains("The"));
            Assert.IsTrue(results.Contains("quick"));
            Assert.IsTrue(results.Contains("brown"));
            Assert.IsTrue(results.Contains("fox"));
            Assert.IsTrue(results.Contains("jumped"));
            Assert.IsTrue(results.Contains("over"));
            Assert.IsTrue(results.Contains("lazy"));
            Assert.IsTrue(results.Contains("dog"));
        }

        public void testCallback(string word)
        {
            results.Add(word);
        }
    }
}
