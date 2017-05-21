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
        //abstract public int Identifier { get; protected set; }
        public virtual List<Description> Description { get; protected set; }
  
        public Company company { get; set; }
        public Country country { get; set; }
        public Model model { get; set; }

        public MusicalInstrument(string name) : base(name)
        {
            Description.Add(new Description(name));
            country.libFile = "E:\\Универ\\2 course\\ООП\\3rd_lab\\Serialization\\Serialization\\Structure\\Descriptions\\Libs\\common\\Countries.txt";
        }
    }
}
