using System.Configuration;

namespace TechTestCTM.Data.Configuration
{
    public class Book : ConfigurationElement, IBook
    {
        [ConfigurationProperty("id", IsRequired = true)]
        public string Id
        {
            get
            {
                return this["id"] as string;
            }
            set
            {
                this["id"] = value;
            }
        }

        [ConfigurationProperty("filePath", IsRequired = true)]
        public string FilePath
        {
            get
            {
                return this["filePath"] as string;
            }
            set
            {
                this["filePath"] = value;
            }
        }
    }
}
