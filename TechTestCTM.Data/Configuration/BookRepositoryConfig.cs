using System.Configuration;

namespace TechTestCTM.Data.Configuration
{
    public class BookRepositoryConfig : ConfigurationSection, IBookRepositoryConfig
    {
        public static IBookRepositoryConfig GetConfig()
        {
            return (BookRepositoryConfig)System.Configuration.ConfigurationManager.GetSection("BookRepository") ?? new BookRepositoryConfig();
        }

        [System.Configuration.ConfigurationProperty("Books")]
        [ConfigurationCollection(typeof(Books), AddItemName = "Book")]
        public Books Books
        {
            get
            {
                object o = this["Books"];
                return o as Books;
            }
        }

    }
}
