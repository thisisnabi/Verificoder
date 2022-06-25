using Microsoft.Extensions.Options;

namespace Verificoder
{
    public class Verificode : IVerificode
    {
        private readonly VerificodeOptions _options;

        public Verificode(IOptions<VerificodeOptions> options)
        {
            _options = _options.Value;
        }

        public string TakeOne()
        {
            return Generator(_options.DefaultLength,
                _options.DefualtMaxRepeatNumber);
        }

        public string TakeOne(int length)
        {
            return Generator(length,
                  _options.DefualtMaxRepeatNumber);
        }

        public string TakeOne(int length, int maxRepeatNumber)
        { 
            return Generator(length,
                  maxRepeatNumber);
        }


        public string TakeOnGroup(string key)
        {
            //return Generator(_options.DefaultLength,
            //    _options.DefualtMaxRepeatNumber);

            throw new NotImplementedException();
        }

        public string TakeOnGroup(string key,int length)
        {
            //return Generator(length,
            //      _options.DefualtMaxRepeatNumber);

            throw new NotImplementedException();
        }

        public string TakeOnGroup(string key, int length, int maxRepeatNumber)
        {
            //return Generator(length,
            //      maxRepeatNumber);

            throw new NotImplementedException();
        }

        public static void EnsureConfiguration(int length, int maxRepeatNumber)
        {
            if (length == 0)
                throw new ArgumentException("length can not be zero.");

            if (length < 1 && length > 8)
                throw new ArgumentException("length must between 1 and 8.");

            if (maxRepeatNumber > length)
                throw new ArgumentException("maxRepeatNumber mus lower than length.");   
        }

        public static string Generator(int length, int maxRepeatNumber)
        {
            // throw clear exception
            EnsureConfiguration(length, maxRepeatNumber);


            // here we calculate the number


            // it's not implemented
            return string.Empty;
        }
    }
}