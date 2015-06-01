
namespace TechTestCTM.Business.WordCounter
{
    public interface IWordCounter
    {
        void CountWord(string word);
        int GetWordCount(string word);
        string[] Words { get; }
    }
}
