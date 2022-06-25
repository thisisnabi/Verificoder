
namespace Verificoder
{
    public interface IVerificode
    {
        string TakeOne();
        string TakeOne(int length);
        string TakeOne(int length, int maxRepeatNumber);

        string TakeOnGroup(string key);
        string TakeOnGroup(string key, int length);
        string TakeOnGroup(string key, int length, int maxRepeatNumber);
    }
}
