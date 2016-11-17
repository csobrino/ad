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
		public ArticuloView (Articulo articulo) : base(Gtk.WindowType.Toplevel)
		{

			this.Build ();

			entryNombre.Text = articulo.Nombre;
			spinButtonPrecio.Value = (double)articulo.Precio;
//			spinButtonPrecio.Value = 0; //stetic bug
			refreshActions ();
			saveAction.Activated += delegate {
				Console.WriteLine ( "save.Action.Activated");
//				Articulo articulo = new Articulo();
				articulo.Nombre= entryNombre.Text;
				articulo.Precio = Convert.ToDecimal(spinButtonPrecio.Value);
				articulo.Categoria  = (long?)ComboboxHelper.GetId(comboBoxCategoria);			
				ArticuloDao.Save(articulo);
				MainWindow.refrescar.Activate();	
			};
			entryNombre.Changed += delegate {
				refreshActions();
			};
		}
			private void fillComboBoxCategoria(object categoria){
			IList list = CategoriaDao.GetList ();
			ComboboxHelper.Fill (comboBoxCategoria, list, "Nombre", categoria);   
		

		}
		private void refreshActions(){
			string content = entryNombre.Text.Trim();
			saveAction.Sensitive = content != string.Empty;
		}
	}


}
