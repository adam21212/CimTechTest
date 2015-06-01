using TechTestCTM.Data.Configuration;
using System.IO;

namespace TechTestCTM.Data
{
    public class BookRepository : IRepository<Book>
    {
        private readonly IBookRepositoryConfig config;

        public BookRepository()
        {
            config = BookRepositoryConfig.GetConfig();
        }

        public BookRepository(IBookRepositoryConfig config)
        {
            this.config = config;
        }

        public Book GetById(int id)
        {
            Configuration.Book book = config.Books[id.ToString()];
            return new Book()
            {
                Id = book.Id,
                FilePath = book.FilePath,
                Stream = new FileStream(System.Environment.CurrentDirectory + book.FilePath,
                                         FileMode.Open,
                                         FileAccess.Read,
                                         FileShare.Delete | FileShare.ReadWrite)
            };
        }
    }
}
