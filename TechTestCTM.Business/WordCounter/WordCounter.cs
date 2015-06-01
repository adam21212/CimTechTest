using System.Collections.Generic;
using System.Linq;

namespace TechTestCTM.Business.WordCounter
{
    internal class WordCounter : IWordCounter
    {
        private Dictionary<string, int> wordCounts = new Dictionary<string, int>();

        public string[] Words
        {
            get
            {
                return wordCounts.Keys.ToArray();
            }
        }

        public void CountWord(string word)
        {
            word = word.ToLower();
            if (wordCounts.ContainsKey(word))
            {
                wordCounts[word]++;
            }
            else
            {
                wordCounts.Add(word, 1);
            }
        }

        public int GetWordCount(string word)
        {
            if (wordCounts.ContainsKey(word))
            {
                return wordCounts[word];
            }
            else
            {
                return 0;
            }
        }
    }
}
