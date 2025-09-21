using System.Collections.Generic;

namespace Ging1991.Core {

	public abstract class Listador<T> {

		private Dictionary<string, List<T>> mapaDatos;

		public virtual void Inicializar() {
			mapaDatos = new Dictionary<string, List<T>>();
		}


		public void AgregarLista(string clave, List<T> lista) {
			mapaDatos[clave] = lista;
		}


		public void RemoverLista(string clave) {
			if (mapaDatos.ContainsKey(clave)) {
				mapaDatos.Remove(clave);
			}
		}


		public void RemoverElemento(T elemento) {
			foreach (List<T> lista in mapaDatos.Values) {
				if (lista.Contains(elemento)) {
					lista.Remove(elemento);
				}
			}
		}


		public void AgregarElemento(T elemento, string clave) {
			RemoverElemento(elemento);
			mapaDatos[clave].Add(elemento);
		}


		public T SiguienteElemento(string clave) {
			List<T> lista = mapaDatos[clave];
			if (lista.Count > 0)
				return lista[0];
			return default(T);
		}


		public T SiguienteElemento(string clave, int posicion) {
			List<T> lista = mapaDatos[clave];
			if (lista.Count > posicion)
				return lista[posicion-1];
			return default(T);
		}


		public List<T> GetLista(string clave) {
			return mapaDatos[clave];
		}


		public List<T> GetListaNueva(string clave) {
			return new List<T>(mapaDatos[clave]);
		}


	}

}