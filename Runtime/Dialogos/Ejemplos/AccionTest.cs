using System;
using Ging1991.Dialogos.Persistencia;

namespace Ging1991.Dialogos.Test {

	[Serializable]
	public class AccionTest : IAccionEspecial {

		public string tipo;
		public string texto;
		public string imagen;
		public string textoDebug;
		public int posX;
		public int posY;
		public float escalaX;
		public float escalaY;
		public int alto;
		public int ancho;
		public bool inmediato;
		public string nombre;

		public AccionEstandar GetAccionEstandar() {
			if (tipo == "ESPECIAL")
				return null;

			AccionEstandar accion = new() {
				tipo = tipo,
				texto = texto,
				imagen = imagen,
				posX = posX,
				posY = posY,
				escalaX = escalaX,
				escalaY = escalaY,
				alto = alto,
				ancho = ancho,
				inmediato = inmediato,
				nombre = nombre
			};
			return accion;
		}

	}

}