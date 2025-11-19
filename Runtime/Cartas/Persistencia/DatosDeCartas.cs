using Ging1991.Core;
using Ging1991.Persistencia.Lectores;

namespace Bounds.Cartas.Persistencia {

	public class DatosDeCartas : SingletonMonoBehaviour<DatosDeCartas> {

		public string direccion;
		public LectorCartas lector;

		public void Inicializar() {
			lector = new LectorCartas(direccion, TipoLector.RECURSOS);
		}

	}

}