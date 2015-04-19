using System;
using System.IO;
using System.Diagnostics;

namespace TestIO
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string file = "dump.txt";
			string output = "res.txt";
			for (int i = 0; i < args.Length; i++) {
				if (args [i].Equals ("-f")) {
					file = args [++i];
				} else if (args [i].Equals ("-o")) {
					output = args [++i];
				}
			}

			Stopwatch sw = new Stopwatch ();
			sw.Start();
			start (file, output);
			sw.Stop ();
			TimeSpan et = sw.Elapsed;
			Console.WriteLine (et.TotalMilliseconds);
		}

		public static void start(string file, string output) {
			if (System.IO.File.Exists (output)) {
				System.IO.File.Delete (output);
			}

			/*string txt = File.ReadAllText (file);
			string[] arr = txt.Split ('\n');

			for (int i = 0; i < arr.Length; i++) {
				arr [i] = arr [i].Replace ("Tellus", "Terra");
				arr [i] = arr [i].Replace ("tellus", "terra");
			}

			File.WriteAllText(output, String.Join ("\n", arr));
			*/

			StreamReader sr = new StreamReader (file);
			StreamWriter sw = new StreamWriter (output);

			try {
				String line;
				while ((line = sr.ReadLine()) != null) {
					line = line.Replace("Tellus", "Terra");
					line = line.Replace("tellus", "terra");

					sw.WriteLine(line);
				}

				/*
				string txt = sr.ReadToEnd();
				string[] arr = txt.Split('\n');
				for (int i = 0; i < arr.Length; i++) {
					arr[i] = arr[i].Replace("Tellus", "Terra");
					arr[i] = arr[i].Replace("tellus", "terra");
				}
				File.WriteAllText(output, string.Join("\n", arr));
				*/
			} catch (Exception e) {

			} finally {
				sr.Close ();
				sw.Close ();
			}
		}
	}
}
