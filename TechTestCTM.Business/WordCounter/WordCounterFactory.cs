

namespace TechTestCTM.Business.WordCounter
{
    internal class WordCounterFactory : IFactory<IWordCounter>
    {
        public IWordCounter Create()
        {
            return new WordCounter();
        }
    }
}
