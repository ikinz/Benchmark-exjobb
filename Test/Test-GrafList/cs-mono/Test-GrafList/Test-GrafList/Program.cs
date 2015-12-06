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
				file = "test.txt";
			}

			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
