using Ging1991.Relojes.Acciones;
using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Relojes.Ejemplos {

	public class EjemploSegundero : MonoBehaviour, IContadorDeIteraciones {

		void Start() {
			ContadorDeIteraciones contador = new ContadorDeIteraciones(this, 0, false);
			Reloj.GetInstanciaGlobal().segundos.Suscribir(contador);
		}


		public void ActualizarContador(int valor) {
			GetComponentInChildren<Text>().text = valor.ToString();
		}


	}

}