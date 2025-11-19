using System.Collections.Generic;

namespace Bounds.Cartas.Persistencia.Datos {

	[System.Serializable]
	public class CartaBD {

		public int cartaID;
		public int nivel;
		public int defensa;
		public string nombre;
		public string clase;
		public string ambientacion;
		public string efecto;
		public List<string> informacion;
		public List<string> etiquetas;
		public CriaturaBD datoCriatura;
		public HechizoBD datoHechizo;
		public TrampaBD datoTrampa;
		public VacioBD datoVacio;
		public List<EfectoBD> efectos;
		public List<MaterialBD> materiales;

	}

}