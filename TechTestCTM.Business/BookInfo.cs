using System.Linq;

namespace TechTestCTM.Business
{
    public class BookInfo
    {
        public IQueryable<WordInfo> WordInfo { get; set; }
    }
}
