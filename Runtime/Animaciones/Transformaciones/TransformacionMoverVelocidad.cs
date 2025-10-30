using System.Collections.Generic;
using UnityEngine;

namespace Ging1991.Animaciones.Transformaciones {

	public class TransformacionMoverVelocidad : TransformacionBase<Transform> {

		private readonly Vector3 posicionFinal;
		private readonly Vector3 posicionInicial;
		private readonly float distanciaTotal;
		private float distanciaRecorrida;
		private readonly float velocidadPorTick;
		private readonly bool usarLocal;

		public TransformacionMoverVelocidad(
			List<Transform> objetivos, Vector3 posicionInicial, Vector3 posicionFinal, float velocidadPorTick,
			bool usarLocal = true) : base(objetivos, -1) {

			this.posicionFinal = posicionFinal;
			this.posicionInicial = posicionInicial;
			this.velocidadPorTick = velocidadPorTick;
			this.usarLocal = usarLocal;
			distanciaTotal = Vector3.Distance(posicionInicial, posicionFinal);
			distanciaRecorrida = 0f;
			SetPosicion(posicionInicial);
		}


		protected override void AplicarCambio() {
			if (distanciaRecorrida >= distanciaTotal) {
				SetPosicion(posicionFinal);
				estado = Estado.TERMINADO;
				return;
			}

			distanciaRecorrida += velocidadPorTick;
			float t = Mathf.Clamp01(distanciaRecorrida / distanciaTotal);
			Vector3 nuevaPos = Vector3.Lerp(posicionInicial, posicionFinal, t);

			SetPosicion(nuevaPos);

			if (t >= 1f) {
				SetPosicion(posicionFinal);
				estado = Estado.TERMINADO;
			}
		}


		private void SetPosicion(Vector3 posicion) {
			foreach (var transformador in objetivos) {
				if (usarLocal)
					transformador.localPosition = posicion;
				else
					transformador.position = posicion;
			}
		}

	}

}