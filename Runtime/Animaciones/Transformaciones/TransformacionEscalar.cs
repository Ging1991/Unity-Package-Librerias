using System.Collections.Generic;
using UnityEngine;

namespace Ging1991.Animaciones.Transformaciones {

	public class TransformacionEscalar : TransformacionBase<Transform> {

		private readonly float escalaInicial;
		private readonly float escalaFinal;

		public TransformacionEscalar(List<Transform> objetivos, float escalaInicial, float escalaFinal, int pasosTotales) :
				base(objetivos, pasosTotales) {

			this.escalaInicial = escalaInicial;
			this.escalaFinal = escalaFinal;
		}


		protected override void AplicarCambio() {
			float progreso = Mathf.Clamp01(1f - (float)pasosRestantes / pasosTotales);
			float nuevaEscala = Mathf.Lerp(escalaInicial, escalaFinal, progreso);
			SetEscala(Vector3.one * nuevaEscala);
		}


		private void SetEscala(Vector3 escala) {
			foreach (var objetivo in objetivos) {
				objetivo.localScale = escala;
			}
		}


	}

}