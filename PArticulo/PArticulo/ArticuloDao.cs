using Gtk;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Reflection;
using Org.InstitutoSerpis.Ad;
using PArticulo;


namespace PArticulo
{





	public class ArticuloDao
	{

		private static string SELECT_SQL = "select * from articulo";

		public static IList<Articulo> getList ()
		{

			List<Articulo>list =  new List<Articulo>();
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = SELECT_SQL;
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
			return list;
		}

		private static string INSERT_SQL = "insert into articulo(nombre, precio, categoria)" +
			"values (@nombre, @precio, @categoria)";
		private static void insert (Articulo articulo){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = INSERT_SQL;
			DbCommandHelper.AddParameter (dbCommand, "nombre", articulo.Nombre);
			DbCommandHelper.AddParameter (dbCommand, "precio", articulo.Precio);
			DbCommandHelper.AddParameter (dbCommand, "categoria", articulo.Categoria);
			dbCommand.ExecuteNonQuery ();
		}


		private const string UPDATE_SQL = "update articulo set nombre = @nombre, " +
		"precio = @precio, categoria = @categoria where id = @id";
		private static void update (Articulo articulo){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = UPDATE_SQL;
			DbCommandHelper.AddParameter (dbCommand, "nombre", articulo.Nombre);
			DbCommandHelper.AddParameter (dbCommand, "precio", articulo.Precio);
			DbCommandHelper.AddParameter (dbCommand, "categoria", articulo.Categoria);
			DbCommandHelper.AddParameter (dbCommand, "id", articulo.Id);
			dbCommand.ExecuteNonQuery ();
		}


		public static void Save(Articulo articulo){
	
			if (articulo.Id == 0) {
				insert (articulo);
			} else {
			update(articulo);
				
			}
		}
		private static string DELETE_SQL = "delete from articulo where  id =@id";
		public static void Delete(TreeView treeView){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
			dbCommand.CommandText = DELETE_SQL;

			long id = (long)TreeViewHelper.GetId (treeView);
			DbCommandHelper.AddParameter (dbCommand, "id", id);
			dbCommand.ExecuteNonQuery ();
			//TODO lanzar una excepcion en caso de no eliminar ningun registro.
		}
		private static string SELECT_ID_SQL = "select * from articulo where id = @id";

		public static Articulo Load (long id)
		{

			List<Articulo>list =  new List<Articulo>();
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = SELECT_ID_SQL;
			DbCommandHelper.AddParameter (dbCommand, "id",id);
			IDataReader dataReader = dbCommand.ExecuteReader ();

			dataReader.Read ();
			//TODO if !Read --> lanzar exception
//				long id = (long)dataReader ["id"]; //Al poner (long) hacemos una conversion FORZADA
				string nombre = (string)dataReader ["nombre"];
				decimal? precio = dataReader ["precio"] is DBNull ? null : (decimal?)dataReader["precio"];
				long? categoria = dataReader ["categoria"] is DBNull ? null : (long?)dataReader ["categoria"];
				Articulo articulo = new Articulo(id, nombre, precio, categoria);
				list.Add (articulo);

				dataReader.Close();
				return articulo;
			}

	
			
		}
}



