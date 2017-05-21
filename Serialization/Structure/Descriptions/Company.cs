using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Structure.Descriptions
{
    class Company : Description
    {
        public string libFile { get; set; }

        public Company(string name) : base(name)
        {
        }

        /*public short sinceYear { get; set; }
        public List<Country> ManufactoryCountries { get; set; }
        public List<Model> Models { get; set; }*/
    }
}
