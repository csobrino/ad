using System;
using PArticulo;

namespace Org.InstitutoSerpis.Ad
{
	public interface IEntityDao
	{
		Articulo Load(object id);
	}
}

