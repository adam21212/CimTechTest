using TechTestCTM.Business.WordCounter;
using TechTestCTM.Business.WordReader;
using TechTestCTM.Data;
using System.Linq;

namespace TechTestCTM.Business
{
    public class BookService : IBookService
    {
        readonly IRepository<Book> bookRepository;
        readonly IFactory<IWordCounter> wordCounterFactory;
        readonly IFactoryFromBook<IWordReader> wordReaderFactory;

        public BookService()
        {
            bookRepository = new BookRepository();
            wordCounterFactory = new WordCounterFactory();
            wordReaderFactory = new WordReaderFactory();
        }

        public BookService(IRepository<Book> bookRepository, IFactory<IWordCounter> wordCounterFactory, IFactoryFromBook<IWordReader> wordReaderFactory)
        {
            this.bookRepository = bookRepository;
            this.wordCounterFactory = wordCounterFactory;
            this.wordReaderFactory = wordReaderFactory;
        }

        public BookInfo GetBookInfo(int bookId)
        {
            Book book = bookRepository.GetById(bookId);
            IWordCounter wordCounter = wordCounterFactory.Create();
            IWordReader reader = wordReaderFactory.Create(book);
            reader.WordRead += new WordReadEventHandler(wordCounter.CountWord);
            reader.Read();
            BookInfo bookInfo = new BookInfo()
            {
                WordInfo = (from w in wordCounter.Words
                            select new WordInfo()
                            {
                                Word = w,
                                Count = wordCounter.GetWordCount(w)
                            }).AsQueryable()
            };
            return bookInfo;
        }
    }
}
