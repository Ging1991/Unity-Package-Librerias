using Ging1991.Core.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Relojes.Ejemplos {

	public class ColorCambiante : MonoBehaviour, IEjecutable {

		private int contador = 0;
		private Image imagen;

		public void Awake() {
			imagen = GetComponentInChildren<Image>();
		}


		void Start() {
			Reloj.GetInstanciaGlobal().decimas.Suscribir(this);
		}


		public void Ejecutar() {
			contador++;
			SetColor((contador % 256) / 255f);
		}


		private void SetColor(float valorRGB) {
			if (imagen != null) {
				imagen.color = new Color(1 - valorRGB, valorRGB, 0);
			}
		}


		private void OnDestroy() {
			//Reloj.GetInstanciaGlobal().Desuscribir(this);
		}


	}

}