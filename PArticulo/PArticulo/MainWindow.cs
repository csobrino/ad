using Gtk;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using Org.InstitutoSerpis.Ad;
using PArticulo;



public partial class MainWindow: Gtk.Window
{	
	public static Gtk.Action refrescar;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		refrescar = refreshAction;

		App.Instance.DbConnection = new MySqlConnection (
			"Database=dbprueba;User Id=root;Password=SISTEMAS"
			);
		App.Instance.DbConnection.Open ();
		fill ();

	
		treeView.Selection.Changed += delegate {
			bool selected = treeView.Selection.CountSelectedRows() > 0;
			editAction.Sensitive = selected;
			deleteAction.Sensitive = selected;
			Console.WriteLine ("treeView.Selection.Changed selected ={0}", selected);
		};

		newAction.Activated += delegate {
			new ArticuloView();



	};

		deleteAction.Activated += delegate {
			MessageDialog messageDialog = new MessageDialog(
				this,
				DialogFlags.Modal,
				MessageType.Question,
				ButtonsType.YesNo,
				"¿Desea eliminar el Registro?"
				);
			ResponseType response = (ResponseType)messageDialog.Run();// Detiene la ejecucion, hasta que el usuario cierre dialogo.
			messageDialog.Destroy();
			if (response == ResponseType.No)
				return;
			if (response == ResponseType.Yes)
				ArticuloDao.Delete(treeView);
				refreshAction.Activate();

			};

		refreshAction.Activated += delegate {
			fill();
		
		};
	}

	protected void fill(){
		editAction.Sensitive = false;
		deleteAction.Sensitive = false;
		IList list = ArticuloDao.getList();
		TreeViewHelper.Fill (treeView, list);
	
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		App.Instance.DbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}
}





//APUNTES.
//long mylong = null; (error)
//NO Se pueden convertir tipos "valor" a null
//mediante el "?" definimos que es tipo "nulable"