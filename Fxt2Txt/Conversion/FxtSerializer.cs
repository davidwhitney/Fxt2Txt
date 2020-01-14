using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fxt2Txt.Conversion
{
    public class FxtSerializer : IFxtSerializer
    {
        private const byte ExtendedIsoCharsetPrefix = 196;
        private readonly int[] _headerMask = {100, 199, 141, 25, 49, 97, 193, 129};

        public IEnumerable<byte> Deserialize(IEnumerable<byte> bytes) => Encoding.ASCII.GetBytes(string.Join('\n', DeserializeAsStrings(bytes)));

        public IEnumerable<string> DeserializeAsStrings(IEnumerable<byte> bytes)
        {
            var inputStream = new Queue<int>(bytes.ToArray().Select(x => (int)x));
            var overloads = new Queue<int>(_headerMask);

            var lineBuffer = new StringBuilder();

            while (inputStream.Any())
            {
                var value = inputStream.Dequeue();

                if (overloads.Any())
                {
                    value -= overloads.Dequeue();
                    lineBuffer.Append((char)value.Mod(256));
                    continue;
                }

                switch (value)
                {
                    case 255:
                        break;
                    case 196:
                        value = inputStream.Dequeue() + 64;
                        lineBuffer.Append((char)--value);
                        break;
                    case 1:
                        yield return lineBuffer.ToString();
                        lineBuffer.Clear();
                        break;
                    default:
                        lineBuffer.Append((char)--value);
                        break;
                }
            }

            if (lineBuffer.Length > 0)
            {
                yield return lineBuffer.ToString();
            }
        }

        public IEnumerable<byte> Serialize(IEnumerable<string> entries, bool addFooter = false)
        {
            var input = string.Join('\n', entries);
            return Serialize(Encoding.UTF8.GetBytes(input), addFooter);
        }

        public IEnumerable<byte> Serialize(IEnumerable<byte> bytes, bool addFooter = false)
        {
            var inputStream = new Queue<int>(bytes.ToArray().Select(x => (int) x));
            var overloads = new Queue<int>(_headerMask);

            while (inputStream.Any())
            {
                var value = inputStream.Dequeue();

                if (overloads.Any())
                {
                    value += overloads.Dequeue();
                    yield return (byte) value;
                    continue;
                }

                if (value > 191)
                {
                    value -= 64;
                    yield return ExtendedIsoCharsetPrefix;
                }

                yield return value == '\n' ? (byte) 1 : (byte) (value + 1);
            }

            if (addFooter)
            {
                yield return 1;
                yield return 92;
                yield return 94;
                yield return 27;

                yield return 1;
                yield return 92;
                yield return 94;
            }
        }
    }

    public static class MathExtensions
    {
        public static int Mod(this int x, int m) => (x % m + m) % m;
    }
}