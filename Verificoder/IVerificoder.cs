
namespace Verificoder
{
    public interface IVerificoder
    {
        string TakeOne();
        string TakeOne(int length);
        string TakeOne(int length, int maxRepeatNumber);

        string TakeOnScope(string key);
        string TakeOnScope(string key, int length);
        string TakeOnScope(string key, int length, int maxRepeatNumber);

        bool IsValidOnScope(string key, string code);

        bool CanTakeOnScope(string key);
    }
}
