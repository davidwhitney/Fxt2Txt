using System;
using System.Linq;
using Fxt2Txt.Conversion;

namespace Fxt2Txt
{
    public class Program
    {
        public static Func<InputFile, string> Convert { get; set; }

        static Program()
        {
            var converter = new Converter(new FxtSerializer());
            Convert = converter.Execute;
        }

        public static int Main(string[] args)
        {
            if (!args.Any())
            {
                Console.Error.WriteLine($"No file contents found, could not convert.{Environment.NewLine}" +
                                        $"Usage examples:{Environment.NewLine}" +
                                        $"\tFxt2Txt.exe SOMEFILE.FXT [converts SOMEFILE.FXT to SOMEFILE.TXT]{Environment.NewLine}" +
                                        "\tFxt2Txt.exe SOMEFILE.TXT [converts SOMEFILE.TXT to SOMEFILE.FXT]");
                return -1;
            }

            Convert(new InputFile(args[0]));
            return 0;
        }
    }
}
