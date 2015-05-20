using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using Gtk;

namespace TestGrafList
{
	public class TestGrafList
	{
		public static void Main(string[] args)
		{
			Application.Init ();

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
			new TestGrafList ().start (file, output);
			sw.Stop ();
			TimeSpan et = sw.Elapsed;
			Console.WriteLine (et.TotalMilliseconds);

			//return;
			Application.Run ();
		}

		public void start(string file, string output) 
		{
			win_one (file, output);
		}

		private void win_one(string file, string output) {
			Win_one frame = new Win_one ();
			frame.DeleteEvent += delete_event;
			frame.Show ();

			if (System.IO.File.Exists (output)) {
				System.IO.File.Delete (output);
			}

			StreamReader sr = new StreamReader (file);
			StreamWriter sw = new StreamWriter (output);

			try {
				string line;
				int counter = 0;
				while ((line = sr.ReadLine()) != null) {
					frame.AddItem(++counter, line);
				}

				frame.mvItems ("tellus");
			} catch (Exception e) {
				Console.WriteLine (e.ToString());
			} finally {
				sr.Close ();
				sw.Close ();
			}
		}

		static void delete_event (object obj, DeleteEventArgs args)
		{
			Application.Quit ();
		}
	}
}

