using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Animaciones.Transformaciones {

	public class TransformacionColorizar : TransformacionBase<Image> {

		private Color colorInicial;
		private Color colorFinal;

		public TransformacionColorizar(List<Image> objetivos, Color colorInicial, Color colorFinal, int pasosTotales) :
				base(objetivos, pasosTotales) {

			this.colorInicial = colorInicial;
			this.colorFinal = colorFinal;
		}


		protected override void AplicarCambio() {
			float progreso = 1f - (float)pasosRestantes / pasosTotales;
			Color nuevoColor = Color.Lerp(colorInicial, colorFinal, progreso);
			SetColor(nuevoColor);
		}


		private void SetColor(Color color) {
			foreach (var objetivo in objetivos) {
				objetivo.color = color;
			}
		}


	}

}