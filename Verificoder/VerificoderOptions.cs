namespace Verificoder
{
    public class VerificoderOptions
    {
        public int DefaultLength { get; set; } = 5;
        public int DefualtMaxRepeatNumber { get; set; } = 1;
        public bool StartWithZero { get; set; } = false;
        public TimeSpan ScopeCodeAbsoluteExpiration { get; set; }  = TimeSpan.FromMinutes(1);
    }
}
