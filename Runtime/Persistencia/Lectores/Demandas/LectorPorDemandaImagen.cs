using Ging1991.Persistencia.Direcciones;
using UnityEngine;

namespace Ging1991.Persistencia.Lectores.Demandas {

	public class LectorPorDemandaImagen : LectorPorDemanda<Sprite> {

		public LectorPorDemandaImagen(Direccion direccionCarpeta, TipoLector tipo) : base(direccionCarpeta) {
			if (tipo == TipoLector.RECURSOS) {
				lectorInterno = new LectorInternoRecursos();
			}
			if (tipo == TipoLector.DINAMICO) {
				lectorInterno = new LectorInternoDinamico();
			}
		}


		public class LectorInternoRecursos : ILector<Sprite> {

			public Sprite Leer(string direccion) {
				return LectorImagenes.LeerDesdeRecursos(direccion);
			}

		}


		public class LectorInternoDinamico : ILector<Sprite> {

			public Sprite Leer(string direccion) {
				return LectorImagenes.LeerDesdeStream(direccion);
			}

		}


	}

}