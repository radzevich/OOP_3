using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Structure
{
    abstract class Guitar : StringedInstrument
    {
        public Material material { get; set; }

        public Guitar(string name) : base(name)
        {
        }
    }
}
