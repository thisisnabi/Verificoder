using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verificoder
{
    public static class Extentions
    {
        public static void IServiceCollection AddVerificode(this IServiceCollection sc) 
        {
            sc.AddSingletone<IVerificode, Verificode>();
        }
    }
}
