using System;
using System.IO;
using System.Linq;

namespace Fxt2Txt.Conversion
{
    public class Converter
    {
        private readonly IFxtSerializer _serializer;
        public Converter(IFxtSerializer serializer) => _serializer = serializer;

        public string Execute(InputFile inputFile)
        {
            var file = File.ReadAllBytes(inputFile.Path);
            var outBytes = inputFile switch
            {
                { IsFxt: true } => _serializer.Deserialize(file),
                { IsTxt: true } => _serializer.Serialize(file),
                _ => throw new InvalidOperationException("Unknown format.")
            };

            File.WriteAllBytes(inputFile.ConvertedFilename(), outBytes.ToArray());
            return inputFile.ConvertedFilename();
        }
    }
}