using System;
using Gtk;

namespace TestGrafList
{
	class MainClass
	{
		public static string file;

		public static void Main (string[] args)
		{
			if (args.Length > 0)
			{
				file = args [0];
			} 
			else 
			{
				file = "/home/ikinz/projects/git/Benchmark-exjobb/Test/Test-GrafList/DumpFile/dump.txt";
			}
				
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			win.Hide ();
			Application.Run ();
		}
	}
}
