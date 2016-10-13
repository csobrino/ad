using Gtk;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using Org.InstitutoSerpis.Ad;
using PArticulo;



public partial class MainWindow: Gtk.Window
{	
	private IDbConnection dbConnection;
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		dbConnection = new MySqlConnection (
			"Database=dbprueba;User Id=root;Password=SISTEMAS"
			);
		dbConnection.Open ();

		List<Articulo>list =  new List<Articulo>();
		//TODO Rellenar desde la tabla articulo
		string selectSql = "Select * from articulo";
		IDbCommand dbCommand = dbConnection.CreateCommand ();
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


		//long mylong = null; (error)
		//NO Se pueden convertir tipos "valor" a null
		//mediante el "?" definimos que es tipo "nulable"



		TreeViewHelper.Fill (treeView, list);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		dbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}
}
