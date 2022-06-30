using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace TaskManager
{
    public sealed class BinarySerializer
    {
        public byte[] Serialize<T>(T value)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, value);

                stream.Flush();
                stream.Position = 0;

                return stream.ToArray();
            }
        }

        public T Deserialize<T>(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                stream.Seek(0, SeekOrigin.Begin);
                var formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}


