using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Structure
{
    abstract class MusicalInstrument
    {
        //abstract public int Identifier { get; protected set; }
        public virtual List<Description> description { get; protected set; }
  
        public Company company { get; set; }
        public Country country { get; set; }
        public Model model { get; set; }

        public MusicalInstrument(string name)
        {
            description.Add(new Description(name));
        }
    }
}
