using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Structure.Descriptions
{
    class Material : Description
    {
        public string libFile { get; set; }

        public Material(string name) : base(name) { }
    }
}
