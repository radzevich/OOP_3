using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instrument
{
    [Serializable]
    class Bass : Guitar
    {
        public Description stringNumber { get; set; }

        public Bass()
        {
            Value = "Бас-гитара";

            stringNumber = new Description("Количество струн");
            stringNumber.LibPath = "..\\..\\Structure\\Descriptions\\Libs\\guitar\\StringNumber.txt";
        }

        public override List<Description> getDescription()
        {
            var baseDescriptionList = base.getDescription();

            baseDescriptionList.Add(stringNumber);

            return baseDescriptionList;
        }
    }
}
