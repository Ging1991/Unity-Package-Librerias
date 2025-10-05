using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Animaciones.Efectos {

	public class Trasparentar : AnimacionBase {

		public List<Image> imagenes;
		public float alfaInicial = 0;
		public float alfaFinal = 1;

		public override void AnimacionDirecta() {
			if (imagenes == null || imagenes.Count == 0)
				return;

			SetAlfa(imagenes, alfaInicial);
			Iniciar(iteraciones);
		}


		public void Animar(List<Image> imagenes, float alfaInicial, float alfaFinal, int iteraciones) {
			if (imagenes == null || imagenes.Count == 0) {
				Debug.LogWarning("Trasparentar: no hay imágenes asignadas.");
				return;
			}

			this.imagenes = imagenes;
			this.alfaInicial = Mathf.Clamp01(alfaInicial);
			this.alfaFinal = Mathf.Clamp01(alfaFinal);

			SetAlfa(imagenes, alfaInicial);
			Iniciar(iteraciones);
		}


		protected override void AplicarCambio() {
			if (imagenes == null || imagenes.Count == 0)
				return;

			float progreso = 1f - (float)pasosRestantes / pasosTotales;
			float nuevoAlfa = Mathf.Lerp(alfaInicial, alfaFinal, progreso);
			SetAlfa(imagenes, nuevoAlfa);
		}


		private void SetAlfa(List<Image> imagenes, float alfa) {
			if (imagenes == null) return;

			foreach (var img in imagenes) {
				if (img == null) continue;

				Color c = img.color;
				c.a = alfa;
				img.color = c;
			}
		}

	}
	
}