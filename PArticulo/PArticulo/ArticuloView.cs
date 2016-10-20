using Gtk;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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

			List<Categoria> list = new  List<Categoria> ();
			list.Add( new Categoria(1L, "categoria 1"));
			list.Add( new Categoria(2L, "categoria 2"));
			list.Add( new Categoria(3L, "categoria 3"));

			ComboboxHelper.Fill (comboBoxCategoria, list, "Nombre");      


			entryNombre.Changed += delegate {
				string content = entryNombre.Text.Trim();
				saveAction.Sensitive = content != string.Empty;

			};
			saveAction.Activated += delegate {
				Console.WriteLine ( "save.Action.Activated");
			
		};

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

