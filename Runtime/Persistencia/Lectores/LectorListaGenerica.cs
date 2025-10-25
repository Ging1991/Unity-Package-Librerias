using System;
using System.Collections.Generic;
using Ging1991.Persistencia.Lectores;

namespace Ging1991.Dialogos.Persistencia {

	public class LectorListaGenerica<T> : LectorGenerico<LectorListaGenerica<T>.ListaDato<T>> {

		public LectorListaGenerica(string direccion, TipoLector tipo) : base(direccion, tipo) { }

		public List<T> GetLista() {
			return Leer().lista;
		}


		[Serializable]
		public class ListaDato<K> {

			public List<K> lista;

		}

	}

}