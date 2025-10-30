using Ging1991.Relojes.Acciones;
using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Relojes.Ejemplos {

	public class EjemploTemporizador : MonoBehaviour, IEjecutable {

		public void Ejecutar() {
			GetComponentInChildren<Text>().text = "XXX";
		}

		void Start() {
			GetComponentInChildren<Text>().text = "OOO";
			Reloj.GetInstanciaGlobal().segundos.Suscribir(new Temporizador(5, this));
		}


	}

}