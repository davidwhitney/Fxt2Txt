using System;
using System.IO;
using System.Linq;

namespace Fxt2Txt
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var inputFile = new InputFile(args[0]);

            if (!args.Any() || inputFile.IsNotSupported)
            {
                ShowUsage();
                return -1;
            }

            var serializer = new FxtSerializer();

            var outBytes = inputFile switch
            {
                { IsFxt: true } => serializer.DeserializeToBytes(File.ReadAllBytes(inputFile.Path)),
                { IsTxt: true } => serializer.Serialize(File.ReadLines(inputFile.Path)),
                _ => throw new InvalidOperationException("Unknown format.")
            };

            File.WriteAllBytes(inputFile.ConvertedFilename(), outBytes.ToArray());
            return 0;
        }

        private static void ShowUsage()
        {
            Console.Error.WriteLine("No file contents found, could not convert.");
            Console.Error.WriteLine("Usage examples:");
            Console.Error.WriteLine("\t\t.exe SOMEFILE.FXT [converts SOMEFILE.FXT to SOMEFILE.TXT]");
            Console.Error.WriteLine("\t\t.exe SOMEFILE.TXT [converts SOMEFILE.TXT to SOMEFILE.FXT]");
        }
    }
}
