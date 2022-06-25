namespace Verificoder
{
    using Microsoft.Extensions.Options;

    public class Verificoder : IVerificoder
    {
        private readonly VerificodeOptions _options;

        public Verificoder(IOptions<VerificodeOptions> options)
        {
            _options = options.Value;
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

        private void EnsureConfiguration(int length, int maxRepeatNumber)
        {
            if (length == 0)
                throw new ArgumentException("length can not be zero.");

            if (length < 1 && length > 8)
                throw new ArgumentException("length must between 1 and 8.");

            if (maxRepeatNumber > length)
                throw new ArgumentException("maxRepeatNumber mus lower than length.");   
        }

        private string Generator(int length, int maxRepeatNumber)
        {
            // throw clear exception
            EnsureConfiguration(length, maxRepeatNumber);

            var digits = new List<int>(length);

            for (int i = 0; i < length; i++)
            {
                int digit;

                do
                {
                    digit = new Random().Next((false ? 0 : 1), 9);
                }
                while (digits.Any(d => d == digit) &&
                        digits.Where(d => d == digit).Count() >= maxRepeatNumber);

                digits.Add(digit);
            }

            return string.Join("", digits);
        }
    }
}