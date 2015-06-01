
namespace TechTestCTM.Data
{
    public interface IRepository<T> where T : class
    {
        T GetById(int Id);
    }
}
