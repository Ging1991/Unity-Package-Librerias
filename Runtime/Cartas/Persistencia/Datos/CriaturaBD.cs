using System.Collections.Generic;

namespace Bounds.Cartas.Persistencia.Datos {

	[System.Serializable]
	public class CriaturaBD {

		public int ataque;
		public int defensa;
		public string perfeccion;
		public List<string> tipos;
		public List<EfectoBD> efectos;

	}

}