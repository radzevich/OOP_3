using System;
using System.Collections.Generic;

namespace Serialization.Structure
{
    [Serializable]
    public class Description
    {
        private string name;
        private string value;
        private string libPath;

        public virtual string LibPath
        {
            get { return libPath; }
            set
            {
                libPath = value;
            }
        }

        public virtual string Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
            }
        }

        public virtual string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        public Description(string name)
        {
            Name = name;
        }

        public virtual List<Description> getDescription()
        {
            var descriptionList = new List<Description>();

            descriptionList.Add(this);
            return descriptionList;
        }
    }
}
