using System.Collections.Generic;
using UnityEngine;

namespace Ging1991.Animaciones.Transformaciones {

	public class TransformacionTrasparentarGrupo : TransformacionBase<CanvasGroup> {

		private readonly float alfaInicial;
		private readonly float alfaFinal;

		public TransformacionTrasparentarGrupo(List<CanvasGroup> objetivos, float alfaInicial, float alfaFinal, int pasosTotales) :
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
				objetivo.alpha = alfa;
			}
		}


	}

}