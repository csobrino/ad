using Gtk;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Collections;
using Org.InstitutoSerpis.Ad;
using PArticulo;


namespace PArticulo
{
	public class ArticuloDao
	{
		private static string selectSql = "select * from articulo";
		public static IList getList ()
		{

			List<Articulo>list =  new List<Articulo>();
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
			return list;
		}
		public static void Save(Articulo articulo){
			string insertSql = "insert into articulo(nombre, precio, categoria)" +
				"values (@nombre, @precio, @categoria)";

			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
			dbCommand.CommandText = insertSql;
			DbCommandHelper.AddParameter(dbCommand, "nombre", articulo.Nombre);
			DbCommandHelper.AddParameter(dbCommand, "precio", articulo.Precio);
			DbCommandHelper.AddParameter(dbCommand, "categoria", articulo.Categoria);
			dbCommand.ExecuteNonQuery();
		}
	}
}

