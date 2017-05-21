using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Serialization.Services
{
    class FileReader
    {
        public FileReader() { }
        
        public string[] read(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            return File.ReadAllLines(filePath);
        } 
    }
}
