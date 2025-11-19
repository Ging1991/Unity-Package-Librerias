using System.Collections.Generic;
using Bounds.Persistencia.Carta;

namespace Bounds.Cartas.Persistencia.Datos {

	[System.Serializable]
	public class HechizoBD {

		public string tipo;
		public string jugador;
		public int cantidad;
		public string etiqueta;
		public DatoBloqueCondicion condicionCarta;
		public List<string> fuentes;
		public int costeLP;
		public bool esAleatorio;
		public string tipoObjetivo;
		public int cantidadObjetivos;
		public string habilidad;
		public int bono;
		public int costeDescartar;
		public int costeSacrificio;
		public int nPrimeras;
		public int parametroID;
		public int parametroN;
		public int parametroJ;
		public DatoBloqueCondicion bloqueCondicion;

	}

}