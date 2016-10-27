using Gtk;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using Org.InstitutoSerpis.Ad;
using PArticulo;



public partial class MainWindow: Gtk.Window
{	

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		App.Instance.DbConnection = new MySqlConnection (
			"Database=dbprueba;User Id=root;Password=SISTEMAS"
			);
		App.Instance.DbConnection.Open ();
		fill ();

	
		treeView.Selection.Changed += delegate {
			bool selected = treeView.Selection.CountSelectedRows() > 0;
			editAction.Sensitive = selected;
			deleteAction.Sensitive = selected;
			Console.WriteLine ("treeView.Selection.Changed selected ={0}", selected);
		};

		newAction.Activated += delegate {
			new ArticuloView();

	};

		refreshAction.Activated += delegate {
			fill();
		
		};
	}









	protected void fill(){

		List<Articulo>list =  new List<Articulo>();
		//TODO Rellenar desde la tabla articulo
		string selectSql = "Select * from articulo";
		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
		dbCommand.CommandText = selectSql;
		IDataReader dataReader = dbCommand.ExecuteReader ();


		while (dataReader.Read()) {

			long id = (long)dataReader ["id"]; //Al poner (long) hacemos una conversion FORZADA
			string nombre = (string)dataReader ["nombre"];
			decimal? precio = dataReader ["precio"] is DBNull ? null : (decimal?)dataReader["precio"];
			long? categoria = dataReader ["categoria"] is DBNull ? null : (long?)dataReader ["categoria"];
			Articulo articulo = new Articulo(id, nombre, precio, categoria);
			list.Add (articulo);
		}
		dataReader.Close ();

		editAction.Sensitive = false;
		deleteAction.Sensitive = false;
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