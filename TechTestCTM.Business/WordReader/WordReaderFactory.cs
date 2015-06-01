using TechTestCTM.Data;

namespace TechTestCTM.Business.WordReader
{
    internal class WordReaderFactory : IFactoryFromBook<IWordReader>
    {
        public IWordReader Create(IBookStream book)
        {
            return new WordReader(book);
        }
    }
}
