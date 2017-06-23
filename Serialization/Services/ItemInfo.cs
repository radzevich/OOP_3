using System;
using System.Collections.Generic;

namespace Serialization.Services
{
    //Class using for data excanging between services.
    [Serializable]
    public class ItemInfo
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public List<string> Items { get; set; }
    }
}
