using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Formatter
    {
        public delegate byte[] FormatterHandler(byte[] stream);

        public FormatterHandler Handler { get; set; }
    }
}
