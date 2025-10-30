using Ging1991.Relojes.Acciones;
using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Relojes.Ejemplos {

	public class EjemploContadorPausable : MonoBehaviour, IContadorDeIteraciones {

		private AccionPausable accionPausable;
		private ContadorDeIteraciones contador;
		private Text textoOBJ;

		void Start() {
			textoOBJ = GetComponentInChildren<Text>();
			contador = new ContadorDeIteraciones(this, 0, false);
			accionPausable = new AccionPausable(contador);
			Reloj.GetInstanciaGlobal().segundos.Suscribir(accionPausable);
		}


		void Update() {
			if (Input.GetKeyDown(KeyCode.Space)) {
				if (accionPausable.EstaPausado) {
					accionPausable.Reanudar();
				}
				else {
					accionPausable.Pausar();
					textoOBJ.text = $"PAUSADO";
				}
			}
		}


		public void ActualizarContador(int valor) {
			textoOBJ.text = $"AVANZANDO: {valor}";
		}


	}

}
