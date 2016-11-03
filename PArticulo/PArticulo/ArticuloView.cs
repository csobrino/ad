using Gtk;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Org.InstitutoSerpis.Ad;


namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		public ArticuloView () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			spinButtonPrecio.Value = 0; //stetic bug
			saveAction.Sensitive = false;	

			saveAction.Activated += delegate {
				Console.WriteLine ( "save.Action.Activated");
				string nombre= entryNombre.Text;
				decimal precio = Convert.ToDecimal(spinButtonPrecio.Value);
				object categoria = ComboboxHelper.GetId(comboBoxCategoria);
				Console.WriteLine("value='{0}'", categoria);
				string insertSql = "insert into articulo(nombre, precio, categoria)" +
					"values (@nombre, @precio, @categoria)";

				IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
				dbCommand.CommandText = insertSql;
				DbCommandHelper.AddParameter(dbCommand, "nombre", nombre);
				DbCommandHelper.AddParameter(dbCommand, "precio", precio);
				DbCommandHelper.AddParameter(dbCommand, "categoria", categoria);
				dbCommand.ExecuteNonQuery();

			};

			entryNombre.Changed += delegate {
				string content = entryNombre.Text.Trim();
				saveAction.Sensitive = content != string.Empty;
			};

			fill ();

		}
	private void fill(){
			List<Categoria> list = new  List<Categoria> ();
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();

			string selectSql = "select * from categoria order by nombre";
			dbCommand.CommandText = selectSql;
			IDataReader dataReader = dbCommand.ExecuteReader ();
			while (dataReader.Read()) {
				long id = (long)dataReader ["id"]; //Al poner (long) hacemos una conversion FORZADA
				string nombre = (string)dataReader ["nombre"];
				Categoria categoria = new Categoria (id, nombre);
				list.Add (categoria);
			}
			dataReader.Close ();
			list.Add( new Categoria(1L, "categoria 1"));
			list.Add( new Categoria(2L, "categoria 2"));
			list.Add( new Categoria(3L, "categoria 3"));

			ComboboxHelper.Fill (comboBoxCategoria, list, "Nombre");      

		}
	}
	public class Categoria {
		public Categoria (long id, string nombre){
			Id = id;
			Nombre = nombre;
	}
		public long Id { get; set; }
		public string Nombre { get; set; }
	}
}

