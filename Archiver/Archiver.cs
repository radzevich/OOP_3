using PluginInterface;
using System.IO;
using System.IO.Compression;

namespace Archiver
{
    public class Archiver : IFuntionalPlugin
    {
        public byte[] TransformTo(byte[] content)
        {
            using (var target = new MemoryStream())
            {
                using (var compressionStream = new GZipStream(target, CompressionMode.Compress))
                {
                    compressionStream.Write(content, 0, content.Length);
                    return target.ToArray();
                }
            }
        }

        public byte[] TransformFrom(byte[] stream)
        {
            using (var source = new MemoryStream())
            {
                using (var target = new MemoryStream(stream))
                {
                    using (GZipStream decompressionStream = new GZipStream(target, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(source);
                        return source.ToArray();
                    }
                }
            }
        }
    }
}
