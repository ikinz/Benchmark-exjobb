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

			//Console.WriteLine(GC.GetTotalMemory (true));

			Stopwatch sw = new Stopwatch ();
			sw.Start();
			start (file, output);
			sw.Stop ();
			TimeSpan et = sw.Elapsed;
			Console.WriteLine (et.TotalMilliseconds);
			//Console.WriteLine(GC.GetTotalMemory (true));
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


			/*
			StreamReader sr = new StreamReader (file);
			StreamWriter sw = new StreamWriter (output);

			try {
				String line;
				while ((line = sr.ReadLine()) != null) {
					line = line.Replace("Tellus", "Terra");
					line = line.Replace("tellus", "terra");

					sw.WriteLine(line);
				}
			} catch (Exception e) {

			} finally {
				sr.Close ();
				sw.Close ();
			}
			*/
		}
	}
}
