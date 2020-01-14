using System.Collections.Generic;
using System.IO;

namespace Fxt2Txt.Conversion
{
    public interface IFxtSerializer
    {
        IEnumerable<string> Deserialize(Stream stream);
        IEnumerable<byte> DeserializeToBytes(IEnumerable<byte> bytes);
        IEnumerable<string> Deserialize(IEnumerable<byte> bytes);
        IEnumerable<byte> Serialize(IEnumerable<string> entries, bool addFooter = false);
    }
}