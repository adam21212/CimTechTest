using TechTestCTM.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("TechTestCTM.Business.Test")]


namespace TechTestCTM.Business.WordReader
{
    internal class WordReader : IWordReader
    {
        public event WordReadEventHandler WordRead;
        private readonly IBookStream book;

        internal WordReader(IBookStream book)
        {
            this.book = book;
        }

        public void Read()
        {
            char ch;
            StringBuilder word = new StringBuilder();
            using (StreamReader streamReader = new StreamReader(book.Stream))
            {
                do
                {
                    ch = (char)streamReader.Read();
                    if (ch != '\'' && ch != '-' && (char.IsWhiteSpace(ch) || char.IsSeparator(ch) || char.IsPunctuation(ch)))
                    {
                        if (WordRead != null && word.Length > 0)
                        {
                            WordRead(word.ToString());
                            word.Clear();
                        }
                    }
                    else
                    {
                        word.Append(ch);
                    }
                } while (!streamReader.EndOfStream);
                if (WordRead != null && word.Length > 0) WordRead(word.ToString());
            }
        }
    }
}
