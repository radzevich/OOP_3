using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Structure.Descriptions
{
    class Country : Description
    {
        public string libFile { get; set; }

        public Country(string name) : base(name) { }
    }
}
