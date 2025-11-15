using UnityEngine;

namespace Ging1991.Idiomas {

	public class IdiomaFactory : MonoBehaviour {

		public string direccionClases;
		public string direccionPerfecciones;
		public string direccionTipos;

		public Idioma GetIdiomaClases() {
			return new Idioma(direccionClases);
		}

		public Idioma GetIdiomaPerfecciones() {
			return new Idioma(direccionPerfecciones);
		}

		public Idioma GetIdiomaTipos() {
			return new Idioma(direccionTipos);
		}

	}

}