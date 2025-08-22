using System.Collections.Generic;

namespace Ging1991.Persistencia.Lectores.Directos {
		
	public class LectorListaEnteros : LectorGenerico<LectorListaEnteros.DatoBD> {
		
		public LectorListaEnteros(string direccion, TipoLector tipo) : base(direccion, tipo) {}
		
		public  void Guardar(List<int> valor) {
			Guardar(new DatoBD
				{
					valor = valor
				}
			);
		}

		[System.Serializable]
		public class DatoBD {

			public List<int> valor;

		}

	}

}