namespace Verificoder
{
    using Microsoft.Extensions.DependencyInjection;
    
    public static class Extensions
    {
        public static IServiceCollection AddVerificoder(this IServiceCollection services, Action<VerificoderOptions> options)
        {
            // requirement
            services.AddMemoryCache(options => { 
                options.ExpirationScanFrequency = TimeSpan.FromSeconds(5);
            });

            // services
            services.Configure(options);
            services.AddSingleton<IVerificoder, Verificoder>();

            return services;
        }
    }
}
