using System;
using System.Collections.Generic;

namespace Serialization.Structure
{
    public class Description
    {
        private string name;
        private string value;
        private string libPath;

        public virtual List<Description> description { get; }

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
                this.name = value;
            }
        }

        public Description(string name)
        {
            this.name = name;

            description.Add(this);
        }
    }
}
