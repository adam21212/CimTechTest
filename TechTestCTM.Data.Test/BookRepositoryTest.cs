using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTestCTM.Data.Configuration;
using System.IO;

namespace TechTestCTM.Data.Test
{
    [TestClass]
    public class BookRepositoryTest
    {
        [TestMethod]
        public void When_given_config_BookRepository_returns_Book()
        {
            Mock<IBookRepositoryConfig> config = new Mock<IBookRepositoryConfig>();
            config.Setup(x => x.Books["42"]).Returns(new TechTestCTM.Data.Configuration.Book()
            {
                Id = "42",
                FilePath = "\\Books\\Test.txt"
            });
            var bookRepository = new BookRepository(config.Object);
            var book = bookRepository.GetById(42);
            Assert.AreEqual("42", book.Id);
            Assert.AreEqual("\\Books\\Test.txt", book.FilePath);
            Assert.AreEqual((new StreamReader(book.Stream)).ReadToEnd(), "The quick fox jumped over the lazy dog.");
        }
    }
}
