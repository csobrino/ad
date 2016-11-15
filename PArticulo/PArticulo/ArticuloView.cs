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
				MainWindow.refrescar.Activate();
	
			};

			entryNombre.Changed += delegate {
				string content = entryNombre.Text.Trim();
				saveAction.Sensitive = content != string.Empty;
			};

			fill ();

		}
	private void fill(){
			IList list = CategoriaDao.GetList ();
			ComboboxHelper.Fill (comboBoxCategoria, list, "Nombre");      

		}
	}


}
