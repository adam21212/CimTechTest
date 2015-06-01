using System.Configuration;

namespace TechTestCTM.Data.Configuration
{
    public class Books : ConfigurationElementCollection
    {
        public Book this[int index]
        {
            get { return base.BaseGet(index) as Book; }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public virtual new Book this[string responseString]
        {
            get { return (Book)BaseGet(responseString); }
            set
            {
                if (BaseGet(responseString) != null)
                {
                    BaseRemoveAt(BaseIndexOf(BaseGet(responseString)));
                }
                BaseAdd(value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new Book();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Book)element).Id;
        }
    }
}
