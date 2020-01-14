using System;

namespace Fxt2Txt
{
    public class InputFile
    {
        public string Path { get; }
        public bool IsFxt { get; }
        public bool IsTxt { get; }

        public InputFile(string path)
        {
            if(string.IsNullOrWhiteSpace(path)) throw new ArgumentException("Invalid path", nameof(path));

            Path = path;
            IsFxt = path.EndsWith(".FXT", StringComparison.InvariantCultureIgnoreCase);
            IsTxt = path.EndsWith(".TXT", StringComparison.InvariantCultureIgnoreCase);
        }

        public string ConvertedFilename() =>
            IsFxt
                ? Path.Replace(".fxt", ".txt").Replace(".FXT", ".TXT")
                : Path.Replace(".txt", ".fxt").Replace(".TXT", ".FXT");
    }
}