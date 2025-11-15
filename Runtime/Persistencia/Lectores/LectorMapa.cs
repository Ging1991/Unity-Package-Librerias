using System.Collections.Generic;
using Ging1991.Persistencia.Datos;

namespace Ging1991.Persistencia.Lectores {

	public class LectorMapa<K, V> : LectorGenerico<ListaDatoBD<K, V>> {

		public LectorMapa(string direccion, TipoLector tipo) : base(direccion, tipo) { }

		public Dictionary<K, V> LeerMapa() {
			Dictionary<K, V> mapa = new Dictionary<K, V>();
			foreach (var elemento in Leer().valor) {
				mapa[elemento.clave] = elemento.valor;
			}
			return mapa;
		}
	}

	public class ListaDatoBD<T, K> {

		public List<MapaBD<T, K>> valor;

	}

}