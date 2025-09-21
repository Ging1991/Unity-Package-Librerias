using System.Collections.Generic;
using UnityEngine;

namespace Ging1991.Core {

	public class Estadisticas : SingletonMonoBehaviour<Estadisticas> {

		[SerializeField]
		public Dictionary<string, int> mapaDatos;

		private Dictionary<string, int> TraerMapa() {
			if (mapaDatos == null) {
				mapaDatos = new Dictionary<string, int>();
			}
			return mapaDatos;
		}


		public int GetValor(string codigo) {
			Dictionary<string, int> mapa = TraerMapa();
			if (!mapa.ContainsKey(codigo))
				mapa[codigo] = 0;
			return mapa[codigo];
		}


		public void SetValor(string codigo, int valor) {
			Dictionary<string, int> mapa = TraerMapa();
			if (!mapa.ContainsKey(codigo))
				mapa.Add(codigo, valor);
			else
				mapa[codigo] = valor;
		}


		public void Incrementar(string codigo) {
			SetValor(codigo, GetValor(codigo) + 1);
		}


		public void ModificarValor(string codigo, int valor) {
			SetValor(codigo, GetValor(codigo) + valor);
		}


	}

}