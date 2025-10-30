using Ging1991.Relojes.Acciones;
using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Relojes.Ejemplos {

	public class EjemploRegresion : MonoBehaviour, IContadorDeIteraciones {

		private ContadorDeIteraciones contador;

		void Start() {
			contador = new ContadorDeIteraciones(this, 1000, true);
			Reloj.GetInstanciaGlobal().decimas.Suscribir(contador);
		}


		public void ActualizarContador(int valor) {
			GetComponentInChildren<Text>().text = valor.ToString();
			if (valor <= 0) {
				Reloj.GetInstanciaGlobal().Desuscribir(contador);
			}
		}


	}

}