using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Structure
{
    class Company : Description
    {
        public Company(string name) : base(name) { }

        /*public short sinceYear { get; set; }
        public List<Country> ManufactoryCountries { get; set; }
        public List<Model> Models { get; set; }*/
    }
}
