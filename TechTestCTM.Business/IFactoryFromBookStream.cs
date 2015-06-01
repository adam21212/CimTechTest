using TechTestCTM.Data;

namespace TechTestCTM.Business
{
    public interface IFactoryFromBook<T> where T : class
    {
        T Create(IBookStream book);
    }
}
