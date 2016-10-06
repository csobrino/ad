using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Data;
using Org.InstitutoSerpis.Ad;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		TreeViewHelper.AppendColumns (treeView, new string[] { "id", "nombre","precio" });
		ListStore listStore = new ListStore (typeof(long), typeof(string), typeof(decimal));
		listStore.AppendValues (1L, "articulo 1", 1.5m);
		listStore.AppendValues (2L, "articulo 2", 3.2m);
		treeView.Model = listStore;



// 		treeView.AppendColumn ("id", new CellRendererText (), "text", 0);
//		treeView.AppendColumn ("nombre", new CellRendererText (), "text", 0);
//		ListStore listStore = new ListStore (typeof(long), typeof(string));
//		treeView.Model = listStore;
//		listStore.AppendValues (1L, "categoria 1");
//


	
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
