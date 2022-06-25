using Microsoft.Extensions.DependencyInjection;

namespace Verificoder
{
    public static class Extentions
    {
        public static IServiceCollection AddVerificoder(this IServiceCollection sc, Action<VerificodeOptions> options)
        {
            sc.Configure(options);
            sc.AddSingleton<IVerificoder, Verificoder>();

            return sc;
        }
    }
}
