using Gtk;
using System;
using System.Collections.Generic;

namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		public ArticuloView () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			spinButtonPrecio.Value = 0;
			saveAction.Sensitive = false;

			List<Categoria> list = new  List<Categoria> ();
			list.Add( new Categoria(1L, "categoria 1"));
			list.Add( new Categoria(2L, "categoria 2"));
			ListStore listStore = new ListStore (typeof(object));
			foreach (object item in list)
				listStore.AppendValues (item);



			comboBoxCategoria.Model = ListStore;

			
			entryNombre.Changed += delegate {
				string value = entryNombre.Text.Trim();
				saveAction.Sensitive = !value.Equals("");

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

