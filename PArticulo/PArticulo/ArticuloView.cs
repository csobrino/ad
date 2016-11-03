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
				Articulo articulo = new Articulo();
				articulo.Nombre= entryNombre.Text;
				articulo.Precio = Convert.ToDecimal(spinButtonPrecio.Value);
				articulo.Categoria  = (long?)ComboboxHelper.GetId(comboBoxCategoria);			
				ArticuloDao.Save(articulo);

			};

			entryNombre.Changed += delegate {
				string content = entryNombre.Text.Trim();
				saveAction.Sensitive = content != string.Empty;
			};

			fill ();

		}
	private void fill(){
			IList list = categoriaDao.GetList ();
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

