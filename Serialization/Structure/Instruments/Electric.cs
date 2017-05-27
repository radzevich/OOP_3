using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instrument
{
    [Serializable]
    class Electric : Guitar
    {
        public Description pickups { get; set; }

        public Electric() : base()
        {
            Value = "Электрогитара";

            pickups = new Description("Звукосниматели");
            pickups.LibPath = "..\\..\\Structure\\Descriptions\\Libs\\guitar\\Pickups.txt";
        }

        public override List<Description> getDescription()
        {
            var baseDescriptionList = base.getDescription();

            baseDescriptionList.Add(pickups);

            return baseDescriptionList;
        }
    }
}
