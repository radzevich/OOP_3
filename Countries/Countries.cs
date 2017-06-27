using System.Collections.Generic;
using PluginInterface;

namespace Countries
{
    public class Countries : IContentPlugin
    {
        public string Name => "Countries";
        public string PublicKey => null;

        public List<string> Content => new List<string>
        {
            "Германия",
            "Индонезия",
            "Китай",
            "Мексика",
            "Россия",
            "США",
            "Япония"
        };
    }
}
