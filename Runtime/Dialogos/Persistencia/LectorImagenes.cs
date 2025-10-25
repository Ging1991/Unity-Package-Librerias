using Ging1991.Persistencia.Direcciones;
using Ging1991.Persistencia.Lectores;
using Ging1991.Persistencia.Lectores.Demandas;
using UnityEngine;

namespace Ging1991.Dialogos.Persistencia {

	public class LectorImagenes : LectorPorDemandaImagen, IGetImagen {

		public LectorImagenes(Direccion direccionCarpeta) : base(direccionCarpeta, TipoLector.RECURSOS) { }

		public Sprite GetImagen(string nombre) {
			return Leer(nombre);
		}

	}

}