using System.Collections.Generic;
using UnityEngine;

namespace Ging1991.Animaciones.Efectos {

	public class Rotar : AnimacionBase {

		public Vector3 rotacionInicial;
		public Vector3 rotacionFinal;
		public List<Transform> transformadores;

		public void Animar(List<Transform> transformadores, Vector3 rotacionInicial, Vector3 rotacionFinal, int iteraciones) {
			if (transformadores == null || transformadores.Count == 0) {
				Debug.LogWarning("Rotar: no hay transformadores asignados.");
				return;
			}

			this.transformadores = transformadores;
			this.rotacionInicial = rotacionInicial;
			this.rotacionFinal = rotacionFinal;
			this.iteraciones = iteraciones;

			SetRotacion(rotacionInicial);
			Iniciar(iteraciones);
		}


		public override void AnimacionDirecta() {
			if (transformadores == null || transformadores.Count == 0)
				return;

			SetRotacion(rotacionInicial);
			Iniciar(iteraciones);
		}


		protected override void AplicarCambio() {
			if (transformadores == null || transformadores.Count == 0)
				return;

			float progreso = 1f - (float)pasosRestantes / pasosTotales;

			Vector3 nuevaRotacion = new Vector3(
				Mathf.LerpAngle(rotacionInicial.x, rotacionFinal.x, progreso),
				Mathf.LerpAngle(rotacionInicial.y, rotacionFinal.y, progreso),
				Mathf.LerpAngle(rotacionInicial.z, rotacionFinal.z, progreso)
			);

			SetRotacion(nuevaRotacion);
		}


		private void SetRotacion(Vector3 euler) {
			foreach (var transformador in transformadores) {
				if (transformador != null)
					transformador.localRotation = Quaternion.Euler(euler);
			}
		}


	}
	
}