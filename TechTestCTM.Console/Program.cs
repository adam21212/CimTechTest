using System.Linq;
using TechTestCTM.Business;
using TechTestCTM.Utility.IsPrime;

namespace TechTestCTM.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IBookService bookService = new BookService();
            BookInfo bookInfo = bookService.GetBookInfo(1);
            int count = 0;
            foreach (WordInfo wordInfo in bookInfo.WordInfo.OrderBy(x => x.Word))
            {
                System.Console.WriteLine(@"{0}     {1}[{2}]",
                                            wordInfo.Word,
                                            wordInfo.Count,
                                            wordInfo.Count.IsPrime() ? "Is Prime" : "Is Not Prime");
                if (++count % (System.Console.WindowHeight - 1) == 0) System.Console.ReadKey();
            }
        }
    }
}
