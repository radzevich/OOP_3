using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Structure.Descriptions
{
    class Model : Description
    {
        public string libFile { get; set; }

        public Model(string name) : base(name) { }
    }
}
