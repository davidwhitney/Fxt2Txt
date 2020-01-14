# Fxt2Txt

This is a C# re-implementation of the Grand Theft Auto "FXT file converter" Fxt2Txt - originally authored by Michael Mendelsohn (mendel@informatik.uni-bremen.de) on 12/97.
It's distinct (shares no source) with the original implementation, but offers the same functionality.

This tool converts GTA1 text resource files (found in the /GTADATA directory, named LANGUAGE.FXT) to plain text files.

If you provide an FXT file as a parameter, it'll be converted to text, and if you provide a TXT file, it'll get encoded to a valid FXT file.

You can use this converter to author localised strings that are loaded by GTA when referred to in your `mission.ini` file.

## Usage

```bash
	Fxt2Txt.exe SOMEFILE.FXT 	[converts SOMEFILE.FXT to SOMEFILE.TXT]
	Fxt2Txt.exe SOMEFILE.TXT 	[converts SOMEFILE.TXT to SOMEFILE.FXT]
```

## Runtime

It's provided as a .NETCore 3.0 command line application - so it'll work cross platform on Windows / Linux / Mac.

## Binaries

I imagine the audience for this tool is exceptionally small. Please compile from sources.
Feel free to get in touch if you can't do that.

## License

MIT licensed. Have at it.

## References

Michael's presumably dead and defunct page - https://gta.mendelsohn.de/Welcome.html