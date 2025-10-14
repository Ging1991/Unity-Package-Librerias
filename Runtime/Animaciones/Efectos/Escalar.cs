using System.Collections.Generic;
using UnityEngine;

namespace Ging1991.Animaciones.Efectos {

	public class Escalar : AnimacionBase {

		public float escalaInicial;
		public float escalaFinal;
		public List<Transform> transformadores;

		public void Animar(List<Transform> transformadores, float escalaInicial, float escalaFinal, int iteraciones) {
			if (transformadores == null || transformadores.Count == 0) {
				Debug.LogWarning("Escalar: no hay transformadores asignados.");
				return;
			}

			this.transformadores = transformadores;
			this.escalaInicial = escalaInicial;
			this.escalaFinal = escalaFinal;
			this.iteraciones = iteraciones;

			SetEscala(Vector3.one * escalaInicial);
			Iniciar(iteraciones);
		}


		public override void AnimacionDirecta() {
			if (transformadores == null || transformadores.Count == 0)
				return;

			SetEscala(Vector3.one * escalaInicial);
			Iniciar(iteraciones);
		}


		protected override void AplicarCambio() {
			if (transformadores == null || transformadores.Count == 0)
				return;

			float progreso = 1f - (float)pasosRestantes / pasosTotales;
			float nuevaEscala = Mathf.Lerp(escalaInicial, escalaFinal, progreso);
			SetEscala(Vector3.one * nuevaEscala);
		}


		protected void SetEscala(Vector3 escala) {
			foreach (var transformador in transformadores) {
				if (transformador != null)
					transformador.localScale = escala;
			}
		}


	}

}