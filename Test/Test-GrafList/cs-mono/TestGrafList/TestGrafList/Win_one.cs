using System;
using System.Collections.Generic;

namespace TestGrafList
{
	public partial class Win_one : Gtk.Window
	{
		private Gtk.ListStore store1;
		private Gtk.ListStore store2;

		public Win_one () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();

			store1 = new Gtk.ListStore (typeof(int), typeof(string));
			store2 = new Gtk.ListStore (typeof(int), typeof(string));

			treeview1.AppendColumn ("Row", new Gtk.CellRendererText (), "text", 0);
			treeview1.AppendColumn ("String", new Gtk.CellRendererText (), "text", 1);

			treeview2.AppendColumn ("Row", new Gtk.CellRendererText (), "text", 0);
			treeview2.AppendColumn ("String", new Gtk.CellRendererText (), "text", 1);

			treeview1.Model = store1;
			treeview2.Model = store2;
		}

		public void AddItem(int row, string item) {
			store1.AppendValues (row, item);
		}

		public void mvItems (string search) {
			Gtk.TreeIter iter;
			store1.GetIterFirst (out iter);

			for (int i = 0; i < store1.IterNChildren (); i++) {
				int row = Convert.ToInt32(store1.GetValue (iter, 0));
				string str = store1.GetValue (iter, 1) as string;

				if (str.Contains(search)) {
					store2.AppendValues (row, str);
				}


				store1.IterNext (ref iter);
			}

			/*store1.Foreach( (Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter) => {
				string val = model.GetValue(iter, 1) as string;
				Console.WriteLine(val);

				if (val.Contains(search)) {
					int row = Int32.Parse(model.GetValue(iter, 0) as string);

					//Console.WriteLine(row + ": " + val);

					store2.AppendValues(row, val);
				}

				return true;
			});*/
		}
	}
}

