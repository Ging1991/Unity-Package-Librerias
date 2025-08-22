using System.Collections.Generic;

namespace Ging1991.Persistencia.Lectores.Directos {
		
	public class LectorListaCadenas : LectorGenerico<LectorListaCadenas.DatoBD> {

		public LectorListaCadenas(string direccion, TipoLector tipo) : base(direccion, tipo) {}

		public void Guardar(List<string> valor) {
			Guardar(new DatoBD
				{
					valor = valor
				}
			);
		}

		[System.Serializable]
		public class DatoBD {

			public List<string> valor;

		}

	}

}