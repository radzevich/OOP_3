using System.IO;
using System.Text;

namespace Serialization.Services
{
    class FileReader
    {
        public string[] Read(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            return File.ReadAllLines(filePath, Encoding.Default);
        } 
    }
}
