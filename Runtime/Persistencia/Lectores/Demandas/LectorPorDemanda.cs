using System.Collections.Generic;
using Ging1991.Persistencia.Direcciones;

namespace Ging1991.Persistencia.Lectores.Demandas {

	public abstract class LectorPorDemanda<T> {

		private readonly Dictionary<string, T> datos;
		private readonly Direccion direccionCarpeta;
		protected ILector<T> lectorInterno;

		public LectorPorDemanda(Direccion direccionCarpeta) {
			this.direccionCarpeta = direccionCarpeta;
			datos = new Dictionary<string, T>();
		}

		public T Leer(string nombre) {

			if (!datos.ContainsKey(nombre)) {
				datos.Add(
					nombre, lectorInterno.Leer(direccionCarpeta.Generar(nombre))
				);
			}

			return datos[nombre];
		}

		public void DescartarCache() {
			datos.Clear();
		}

	}

}