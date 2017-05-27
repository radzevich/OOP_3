using System;
using System.Collections.Generic;

namespace Serialization.Structure.Instrument
{
    [Serializable]
    class Synthesizer : KeyboardInstrument
    {
        public Description buttonNum { get; set; }

        public Synthesizer() : base()
        {
            Value = "Синтезатор";

            buttonNum = new Description("Количество клавиш");

            model.LibPath = "..\\..\\Structure\\Descriptions\\Libs\\synthesizer\\Models.txt";
            buttonNum.LibPath = "..\\..\\Structure\\Descriptions\\Libs\\synthesizer\\ButtonNum.txt";
        }
        
        public override List<Description> getDescription()
        {
            {
                var baseDescriptionList = base.getDescription();

                baseDescriptionList.Add(buttonNum);

                return baseDescriptionList;
            }
        }
    }
}
