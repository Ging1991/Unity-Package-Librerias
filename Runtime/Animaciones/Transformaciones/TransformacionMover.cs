using System.Collections.Generic;
using UnityEngine;

namespace Ging1991.Animaciones.Transformaciones {

	public class TransformacionMover : TransformacionBase<Transform> {

		private readonly Vector3 posicionInicial;
		private readonly Vector3 posicionFinal;

		public TransformacionMover(List<Transform> objetivos, Vector3 posicionInicial, Vector3 posicionFinal, int pasosTotales) :
				base(objetivos, pasosTotales) {

			this.posicionInicial = posicionInicial;
			this.posicionFinal = posicionFinal;
		}


		protected override void AplicarCambio() {
			float progreso = 1f - (float)pasosRestantes / pasosTotales;
			Vector3 nuevaPos = Vector3.Lerp(posicionInicial, posicionFinal, progreso);
			SetPosicion(nuevaPos);
		}


		private void SetPosicion(Vector3 posicion) {
			foreach (var transformador in objetivos) {
				transformador.localPosition = posicion;
			}
		}


	}

}