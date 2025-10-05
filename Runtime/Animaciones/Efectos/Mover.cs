using System.Collections.Generic;
using UnityEngine;

namespace Ging1991.Animaciones.Efectos {

	public class Mover : AnimacionBase {

		public Vector3 posicionInicial;
		public Vector3 posicionFinal;
		public List<Transform> transformadores;

		public void Animar(List<Transform> transformadores, Vector3 posicionInicial, Vector3 posicionFinal, int iteraciones) {
			if (transformadores == null || transformadores.Count == 0) {
				Debug.LogWarning("Mover: no hay transformadores asignados.");
				return;
			}

			this.transformadores = transformadores;
			this.posicionInicial = posicionInicial;
			this.posicionFinal = posicionFinal;

			SetPosicion(posicionInicial);
			Iniciar(iteraciones);
		}


		public override void AnimacionDirecta() {
			if (transformadores == null || transformadores.Count == 0)
				return;

			SetPosicion(posicionInicial);
			Iniciar(iteraciones);
		}


		protected override void AplicarCambio() {
			if (transformadores == null || transformadores.Count == 0)
				return;

			float progreso = 1f - (float)pasosRestantes / pasosTotales;
			Vector3 nuevaPos = Vector3.Lerp(posicionInicial, posicionFinal, progreso);
			SetPosicion(nuevaPos);
		}


		private void SetPosicion(Vector3 posicion) {
			foreach (var transformador in transformadores) {
				if (transformador != null)
					transformador.localPosition = posicion;
			}
		}


	}
	
}