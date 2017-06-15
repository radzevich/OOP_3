using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization.Services
{
    class Serializer
    {
        private readonly BinaryFormatter _formatter;

        public void Serialize(object obj, string path)
        {           
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                _formatter.Serialize(fs, obj);
            }
        }

        public object Deserialize(string path)
        {
            object deserialized;
            // десериализация из файла people.dat
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                deserialized = _formatter.Deserialize(fs);
            }
            return deserialized;
        }

        public Serializer()
        {
            _formatter = new BinaryFormatter();
        }
    }
}
