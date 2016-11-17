using Gtk;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Org.InstitutoSerpis.Ad
{
	public class ComboboxHelper
	{

			public static void Fill(ComboBox comboBox, IList list, string propertyName, object id){
				Type listType = list.GetType ();
				Type elementType = listType.GetGenericArguments () [0];
				PropertyInfo idPropertyInfo = elementType.GetProperty ("Id");
				PropertyInfo namePropertyInfo = elementType.GetProperty (propertyName);
				ListStore listStore = new ListStore (typeof(object));
				TreeIter initialTreeIter = listStore.AppendValues (Null.value);

				foreach (object item in list) { 
				TreeIter treeIter = listStore.AppendValues (item);
				//if item.id == id --> initialTreeIter = treeIter		
				if (idPropertyInfo.GetValue (item, null).Equals (id)) 
					initialTreeIter = treeIter;
			}


				CellRendererText cellRendererText = new CellRendererText();

				comboBox.Model = listStore;
				comboBox.SetActiveIter (initialTreeIter);
				comboBox.PackStart(cellRendererText, false);
				comboBox.SetCellDataFunc (cellRendererText,
				    delegate(CellLayout cell_layout, CellRenderer cell, TreeModel tree_model, TreeIter iter) {					 
					//				Categoria categoria = (Categoria) tree_model.GetValue(iter, 0);
					//				cellRendererText.Text = categoria.Nombre;
					object item = tree_model.GetValue(iter, 0);
					object value = item == Null.value ?
					"<sin asignar>" : namePropertyInfo.GetValue(item, null);
					cellRendererText.Text = value.ToString();


				}
			);
		}

		public static object GetId(ComboBox comboBox){
			TreeIter treeIter;
			comboBox.GetActiveIter (out treeIter);
			object item = comboBox.Model.GetValue (treeIter, 0);
//			if (item == Null.value)
//				return null;
//			Type elementType = item.GetType ();
//			PropertyInfo propertyInfo = elementType.GetProperty ("Id");
//			return propertyInfo.GetValue(item, null);
			return item == Null.value ? null : 
				item.GetType ().GetProperty ("Id").GetValue (item, null);
		}
		}

}


	


