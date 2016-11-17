using Gtk;
using System;

namespace Org.InstitutoSerpis.Ad
{
	public class WindowsHelper
	{
		public static bool Confirm(Window parent, string message){
			MessageDialog messageDialog = new MessageDialog(
				parent,
				DialogFlags.Modal,
				MessageType.Question,
				ButtonsType.YesNo,
				message
				);
			messageDialog.Title = parent.Title;
			ResponseType response = (ResponseType)messageDialog.Run();
			// Detiene la ejecucion, hasta que el usuario cierre dialogo.
			messageDialog.Destroy();
			return response == ResponseType.Yes;

		}


	}
}

