using System;
using System.Collections.Generic;

namespace Serialization.Structure
{
    [Serializable]
    public class Description : IDescription
    {
        public string Name { get; set; }
        public string Value { get; set; }


        public virtual List<Description> getDescription()
        {
            var descriptionList = new List<Description>();

            descriptionList.Add(this);
            return descriptionList;
        }
    }
}
