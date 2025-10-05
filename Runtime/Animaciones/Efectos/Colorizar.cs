using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Animaciones.Efectos {

	public class Colorizar : AnimacionBase {

		public List<Image> imagenes;
		public Color colorInicial = Color.white;
		public Color colorFinal = Color.white;


		public void Animar(List<Image> imagenes, Color colorInicial, Color colorFinal, int iteraciones) {
			if (imagenes == null || imagenes.Count == 0) {
				Debug.LogWarning("Colorizar: no hay imágenes asignadas.");
				return;
			}

			this.imagenes = imagenes;
			this.colorInicial = colorInicial;
			this.colorFinal = colorFinal;

			SetColor(colorInicial);
			Iniciar(iteraciones);
		}


		public override void AnimacionDirecta() {
			if (imagenes == null || imagenes.Count == 0)
				return;

			SetColor(colorInicial);
			Iniciar(iteraciones);
		}


		protected override void AplicarCambio() {
			if (imagenes == null || imagenes.Count == 0)
				return;

			float progreso = 1f - (float)pasosRestantes / pasosTotales;
			Color nuevoColor = Color.Lerp(colorInicial, colorFinal, progreso);
			SetColor(nuevoColor);
		}


		private void SetColor(Color color) {
			if (imagenes == null) return;

			foreach (var imagen in imagenes) {
				if (imagen != null)
					imagen.color = color;
			}
		}

		
	}
	
}