using System.Collections.Generic;
using System;

namespace Serialization.Structure.Instrument
{
    [Serializable]
    public abstract class MusicalInstrument : Description
    {  
        public Description company { get; protected set; }
        public Description country { get; protected set; }
        public Description model { get; set; }

        public MusicalInstrument() : base("Тип")
        {
            base.LibPath = "..\\..\\Structure\\Instruments\\Libs\\Instruments.txt";
            company = new Description("Производитель");
            country = new Description("Страна");
            model = new Description("Модель");

            country.LibPath = "..\\..\\Structure\\Descriptions\\Libs\\common\\Countries.txt";
        }

        public override List<Description> getDescription()
        {
            var baseDescriptionList = base.getDescription();

            baseDescriptionList.Add(company);
            baseDescriptionList.Add(model);
            baseDescriptionList.Add(country);

            return baseDescriptionList;
        }
    }
}
