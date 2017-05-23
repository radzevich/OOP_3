using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serialization.Structure.Descriptions;

namespace Serialization.Structure.Instrument
{
    abstract class MusicalInstrument : Description
    {  
        public Company company { get; protected set; }
        public Country country { get; protected set; }
        public Model model { get; set; }

        public MusicalInstrument(string name) : base(name)
        {
            country.libFile = "..\\..\\Structure\\Descriptions\\Libs\\common\\Countries.txt";
        }

        public override List<Description> description
        {
            get
            {
                var baseDescriptionList = base.description;

                baseDescriptionList.Add(company);
                baseDescriptionList.Add(country);
                baseDescriptionList.Add(model);

                return baseDescriptionList;
            }
        }
    }
}
