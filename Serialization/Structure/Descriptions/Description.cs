using System;

namespace Serialization.Structure.Descriptions
{
    public class Description
    {
        private string name;
        private string value;
        private string libPath;

        public virtual string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                name = value;
            }
        }

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

        public Description(string name)
        {
            Name = name;
        }
    }
}
