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
	public class categoriaDao
	{
		private const string 	SELECT_SQL = "select * from categoria order by nombre";
		public static List<Categoria> GetList (){
			List<Categoria> list = new  List<Categoria> ();
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();

		
			dbCommand.CommandText = SELECT_SQL;
			IDataReader dataReader = dbCommand.ExecuteReader ();
			while (dataReader.Read()) {
				long id = (long)dataReader ["id"]; //Al poner (long) hacemos una conversion FORZADA
				string nombre = (string)dataReader ["nombre"];
				Categoria categoria = new Categoria (id, nombre);
				list.Add (categoria);
			}
			dataReader.Close ();
			return list;
		}
	}
}

