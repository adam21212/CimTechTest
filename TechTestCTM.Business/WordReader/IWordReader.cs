
namespace TechTestCTM.Business.WordReader
{
    public interface IWordReader
    {
        void Read();
        event WordReadEventHandler WordRead;
    }
}
