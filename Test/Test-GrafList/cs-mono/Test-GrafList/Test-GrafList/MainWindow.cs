using System;
using Gtk;
using System.Collections.Generic;
using System.IO;

public partial class MainWindow: Gtk.Window
{
	string[] fileLines;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();

		String txt = File.ReadAllText (TestGrafList.MainClass.file);
		fileLines = txt.Split ('\n');


	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	private void InitList()
	{

	}
}
