using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Animaciones.Transformaciones {

	public class TransformacionTrasparentar : TransformacionBase<Image> {

		private readonly float alfaInicial;
		private readonly float alfaFinal;

		public TransformacionTrasparentar(List<Image> objetivos, float alfaInicial, float alfaFinal, int pasosTotales) :
				base(objetivos, pasosTotales) {

			this.alfaInicial = alfaInicial;
			this.alfaFinal = alfaFinal;
		}


		protected override void AplicarCambio() {
			float progreso = 1f - (float)pasosRestantes / pasosTotales;
			float nuevoAlfa = Mathf.Lerp(alfaInicial, alfaFinal, progreso);
			SetAlfa(nuevoAlfa);
		}


		private void SetAlfa(float alfa) {
			foreach (var objetivo in objetivos) {
				Color color = objetivo.color;
				color.a = alfa;
				objetivo.color = color;
			}
		}


	}

}