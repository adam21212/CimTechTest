using System.IO;

namespace TechTestCTM.Data
{
    public class Book : IBook, IBookStream
    {
        public Stream Stream { get; set; }
        public string Id { get; set; }
        public string FilePath { get; set; }
    }
}
