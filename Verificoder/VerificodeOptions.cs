using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verificoder
{
    public class VerificodeOptions
    {
        public int DefaultLength { get; set; } = 5;
        public int DefualtMaxRepeatNumber { get; set; } = 1;
        public bool StartWithZero { get; set; } = false;
    }
}
