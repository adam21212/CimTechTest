using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TechTestCTM.Business.Test
{
    [TestClass]
    public class WordCounterTest
    {
        [TestMethod]
        public void When_WordCounter_is_called_with_words_regardless_of_case_counts_words()
        {
            WordCounter.WordCounter wordCounter = new WordCounter.WordCounter();
            wordCounter.CountWord("The");
            wordCounter.CountWord("quick");
            wordCounter.CountWord("brown");
            wordCounter.CountWord("fox");
            wordCounter.CountWord("jumped");
            wordCounter.CountWord("over");
            wordCounter.CountWord("the");
            wordCounter.CountWord("lazy");
            wordCounter.CountWord("dog");

            Assert.AreEqual(8, wordCounter.Words.Length);
            Assert.AreEqual(2, wordCounter.GetWordCount("the"));
            Assert.AreEqual(1, wordCounter.GetWordCount("quick"));
            Assert.AreEqual(1, wordCounter.GetWordCount("brown"));
            Assert.AreEqual(1, wordCounter.GetWordCount("fox"));
            Assert.AreEqual(1, wordCounter.GetWordCount("jumped"));
            Assert.AreEqual(1, wordCounter.GetWordCount("over"));
            Assert.AreEqual(1, wordCounter.GetWordCount("lazy"));
            Assert.AreEqual(1, wordCounter.GetWordCount("dog"));
        }
    }
}
