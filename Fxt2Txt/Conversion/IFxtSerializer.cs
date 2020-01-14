using System.Collections.Generic;

namespace Fxt2Txt.Conversion
{
    public interface IFxtSerializer
    {
        IEnumerable<byte> Deserialize(IEnumerable<byte> bytes);
        IEnumerable<string> DeserializeAsStrings(IEnumerable<byte> bytes);

        IEnumerable<byte> Serialize(IEnumerable<string> entries, bool addFooter = false);
        IEnumerable<byte> Serialize(IEnumerable<byte> entries, bool addFooter = false);
    }
}