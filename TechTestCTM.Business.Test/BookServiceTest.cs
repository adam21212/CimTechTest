using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTestCTM.Data;
using TechTestCTM.Business.WordCounter;
using TechTestCTM.Business.WordReader;
using System.IO;
using System.Text;
using System.Linq;
namespace TechTestCTM.Business.Test
{
    [TestClass]
    public class BookServiceTest
    {
        [TestMethod]
        public void BookService_returns_BookInfo()
        {
            Mock<IRepository<Book>> bookRepository = new Mock<IRepository<Book>>();
            Mock<IFactory<IWordCounter>> wordCounterFactory = new Mock<IFactory<IWordCounter>>();
            Mock<IWordCounter> wordCounter = new Mock<IWordCounter>();
            Mock<IFactoryFromBook<IWordReader>> wordReaderFactory = new Mock<IFactoryFromBook<IWordReader>>();
            Mock<IWordReader> wordReader = new Mock<IWordReader>();

            bookRepository.Setup(x => x.GetById(42)).Returns(new Book()
            {
                Id = "42",
                FilePath = "FilePath",
                Stream = new MemoryStream(Encoding.ASCII.GetBytes("The quick brown fox jumped over the lazy dog."))
            });

            wordCounter.Setup(x => x.Words).Returns(new string[] { "the", "quick", "brown", "fox", "jumped", "over", "lazy", "dog" });
            wordCounter.Setup(x => x.GetWordCount("the")).Returns(11);
            wordCounter.Setup(x => x.GetWordCount("quick")).Returns(22);
            wordCounter.Setup(x => x.GetWordCount("brown")).Returns(33);
            wordCounter.Setup(x => x.GetWordCount("fox")).Returns(44);
            wordCounter.Setup(x => x.GetWordCount("jumped")).Returns(55);
            wordCounter.Setup(x => x.GetWordCount("over")).Returns(66);
            wordCounter.Setup(x => x.GetWordCount("lazy")).Returns(77);
            wordCounter.Setup(x => x.GetWordCount("dog")).Returns(88);

            wordCounterFactory.Setup(x => x.Create()).Returns(wordCounter.Object);

            wordReaderFactory.Setup(x => x.Create(It.IsAny<IBookStream>())).Returns(wordReader.Object);

            BookService bookService = new BookService(bookRepository.Object, wordCounterFactory.Object, wordReaderFactory.Object);

            BookInfo bookInfo = bookService.GetBookInfo(42);

            Assert.AreEqual(8, bookInfo.WordInfo.Count());
            Assert.AreEqual(11, (from w in bookInfo.WordInfo where w.Word == "the" select w.Count).FirstOrDefault());
            Assert.AreEqual(22, (from w in bookInfo.WordInfo where w.Word == "quick" select w.Count).FirstOrDefault());
            Assert.AreEqual(33, (from w in bookInfo.WordInfo where w.Word == "brown" select w.Count).FirstOrDefault());
            Assert.AreEqual(44, (from w in bookInfo.WordInfo where w.Word == "fox" select w.Count).FirstOrDefault());
            Assert.AreEqual(55, (from w in bookInfo.WordInfo where w.Word == "jumped" select w.Count).FirstOrDefault());
            Assert.AreEqual(66, (from w in bookInfo.WordInfo where w.Word == "over" select w.Count).FirstOrDefault());
            Assert.AreEqual(77, (from w in bookInfo.WordInfo where w.Word == "lazy" select w.Count).FirstOrDefault());
            Assert.AreEqual(88, (from w in bookInfo.WordInfo where w.Word == "dog" select w.Count).FirstOrDefault());

        }
    }
}
