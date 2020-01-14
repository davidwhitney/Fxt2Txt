using System;
using System.IO;
using System.Linq;

namespace Fxt2Txt.Conversion
{
    public class Converter
    {
        private readonly InputFile _inputFile;
        private readonly FxtSerializer _serializer;

        public Converter(InputFile inputFile, FxtSerializer serializer)
        {
            _inputFile = inputFile;
            _serializer = serializer;
        }

        public string Process()
        {
            var outBytes = _inputFile switch
            {
                { IsFxt: true } => _serializer.DeserializeToBytes(File.ReadAllBytes(_inputFile.Path)),
                { IsTxt: true } => _serializer.Serialize(File.ReadLines(_inputFile.Path)),
                _ => throw new InvalidOperationException("Unknown format.")
            };

            File.WriteAllBytes(_inputFile.ConvertedFilename(), outBytes.ToArray());
            return _inputFile.ConvertedFilename();
        }
    }
}