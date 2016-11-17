using Gtk;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using Org.InstitutoSerpis.Ad;
using PArticulo;



public partial class MainWindow: Gtk.Window
{	
	public static Gtk.Action refrescar;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		refrescar = refreshAction;

		App.Instance.DbConnection = new MySqlConnection (
			"Database=dbprueba;User Id=root;Password=SISTEMAS"
			);
		App.Instance.DbConnection.Open ();

		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
		dbCommand.CommandText =  "update articulo set precio = 0 where precio is null";
		dbCommand.ExecuteNonQuery();		
fill ();

	
		treeView.Selection.Changed += delegate {
			bool selected = treeView.Selection.CountSelectedRows() > 0;
			editAction.Sensitive = selected;
			deleteAction.Sensitive = selected;
			Console.WriteLine ("treeView.Selection.Changed selected ={0}", selected);
		};

		newAction.Activated += delegate {			
			Articulo articulo = new Articulo();
			articulo.Precio = 0; // hasta que se permitan nulos
			articulo.Nombre = String.Empty;//Los entry esperan que no sean null.
			new ArticuloView(articulo);
		};
		editAction.Activated += delegate {
			Articulo articulo = ArticuloDao.Load((long)TreeViewHelper.GetId(treeView));
			new ArticuloView(articulo);
	};
		deleteAction.Activated += delegate {
			if (WindowsHelper.Confirm(this, "¿Quieres eliminar el registro?"))
				ArticuloDao.Delete(treeView);
				refreshAction.Activate();

			};

		refreshAction.Activated += delegate {
			fill();
		
		};
	}

	private void fill() {
		editAction.Sensitive = false;
		deleteAction.Sensitive = false;
		//IList list = ArticuloDao.GetList ();
		IList list = EntityDao.GetList<Articulo> ();
		TreeViewHelper.Fill (treeView, list);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		App.Instance.DbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}
}





//APUNTES.
//long mylong = null; (error)
//NO Se pueden convertir tipos "valor" a null
//mediante el "?" definimos que es tipo "nulable"