using System.Collections.Generic;
using UnityEngine;

namespace Ging1991.Animaciones.Transformaciones {

	public class TransformacionRotar : TransformacionBase<Transform> {

		private readonly Vector3 rotacionInicial;
		private readonly Vector3 rotacionFinal;

		public TransformacionRotar(List<Transform> objetivos, Vector3 rotacionInicial, Vector3 rotacionFinal, int pasosTotales) :
				base(objetivos, pasosTotales) {

			this.rotacionInicial = rotacionInicial;
			this.rotacionFinal = rotacionFinal;
		}


		protected override void AplicarCambio() {
			float progreso = 1f - (float)pasosRestantes / pasosTotales;
			Vector3 nuevaRotacion = new(
				Mathf.LerpAngle(rotacionInicial.x, rotacionFinal.x, progreso),
				Mathf.LerpAngle(rotacionInicial.y, rotacionFinal.y, progreso),
				Mathf.LerpAngle(rotacionInicial.z, rotacionFinal.z, progreso)
			);
			SetRotacion(nuevaRotacion);
		}


		private void SetRotacion(Vector3 vector) {
			foreach (var objetivo in objetivos) {
				objetivo.localRotation = Quaternion.Euler(vector);
			}
		}


	}

}