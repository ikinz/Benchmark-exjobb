using System;
using System.IO;
using System.Diagnostics;

namespace TestIO
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			String file = "dump.txt";
			String output = "res.txt";
			for (int i = 0; i < args.Length; i++) {
				if (args [i].Equals ("-f")) {
					file = args [++i];
				} else if (args [i].Equals ("-o")) {
					output = args [++i];
				}
			}

			start (file, output);

		}

		public static void start(string file, string output) {
			if (System.IO.File.Exists (output)) {
				System.IO.File.Delete (output);
			}

			String txt = File.ReadAllText (file);
			String[] arr = txt.Split ('\n');

			for (int i = 0; i < arr.Length; i++) {
				arr [i] = arr [i].Replace ("Tellus", "Terra");
				arr [i] = arr [i].Replace ("tellus", "terra");
			}

			File.WriteAllText(output, String.Join ("\n", arr));
		}
	}
}
