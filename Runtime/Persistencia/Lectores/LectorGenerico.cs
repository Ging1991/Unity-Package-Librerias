using UnityEngine;

namespace Ging1991.Persistencia.Lectores {
		
	public abstract class LectorGenerico<T> : LectorJSON {

		protected TipoLector tipo;
		private T dato;

		public LectorGenerico(string direccion, TipoLector tipo) : base(direccion) {
			this.tipo = tipo;
		}

		public T Leer() {
			if (dato == null) {
				if (tipo == TipoLector.DINAMICO)
					dato = JsonUtility.FromJson<T>(LeerDesdeStream());
				if (tipo == TipoLector.RECURSOS)
					dato = JsonUtility.FromJson<T>(LeerDesdeRecursos(direccion));
			}
			return dato;
		}

		public void DescartarCambios() {
			dato = Leer();
		}

		public void Guardar(T dato) {
			if (tipo == TipoLector.DINAMICO)
				GuardarHaciaStream(JsonUtility.ToJson(dato));
			else
				Debug.LogWarning("Un lector de recursos no puede guardar. Use un lector de Stream.");
		}

		public void Guardar() {
			Guardar(dato);
		}

		public void InicializarPorDefecto(T defecto) {
			if (!ExistenDatos()) {
				GuardarHaciaStream(JsonUtility.ToJson(defecto));
			}
		}

	}

}