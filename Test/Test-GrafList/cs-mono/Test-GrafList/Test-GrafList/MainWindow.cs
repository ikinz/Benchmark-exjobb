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

		InitList ();

		Environment.Exit (0);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	private void InitList()
	{
		Gtk.TreeViewColumn col1 = new Gtk.TreeViewColumn ();
		col1.Title = "Text";
		treeview1.AppendColumn (col1);
		Gtk.ListStore texts = new Gtk.ListStore (typeof (string));

		for (int i = 0; i < fileLines.Length; i++) {
			texts.AppendValues (fileLines [i]);
		}

		treeview1.Model = texts;

		Gtk.CellRendererText textRender = new Gtk.CellRendererText ();
		col1.PackStart (textRender, true);
		col1.AddAttribute (textRender, "text", 0);
	}
}
