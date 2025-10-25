using System;

namespace Ging1991.Dialogos.Persistencia {

	[Serializable]
	public class AccionEstandar {

		public string tipo;
		public string texto;
		public string nombre;
		public string imagen;
		public float escalaX;
		public float escalaY;
		public int posX;
		public int posY;
		public int alto;
		public int ancho;
		public bool inmediato;

	}

}