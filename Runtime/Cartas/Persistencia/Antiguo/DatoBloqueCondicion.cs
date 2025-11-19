using System.Collections.Generic;

namespace Bounds.Persistencia.Carta {

	[System.Serializable]
	public class DatoBloqueCondicion {

		public DatoCondicion condicion = null;
		public List<DatoCondicion> condicionesY;
		public List<DatoCondicion> condicionesO;
		
	}

}