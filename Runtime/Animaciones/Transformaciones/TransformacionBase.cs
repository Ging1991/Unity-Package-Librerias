using System.Collections.Generic;
using UnityEngine;

namespace Ging1991.Animaciones.Transformaciones {

	public abstract class TransformacionBase<T> {

		public enum Estado { OK, ERROR, TERMINADO }
		public Estado estado;
		protected readonly int pasosTotales;
		protected int pasosRestantes;
		protected readonly List<T> objetivos;

		public TransformacionBase(List<T> objetivos, int pasosTotales) {
			this.objetivos = objetivos;
			this.pasosTotales = pasosTotales;
			pasosRestantes = pasosTotales;
			estado = Estado.OK;
		}


		public void ProcesarCuadro() {
			LimpiarObjetivos();
			if (estado != Estado.OK) {
				return;
			}
			AplicarCambio();
			pasosRestantes--;
			if (pasosRestantes == 0) {
				estado = Estado.TERMINADO;
				AplicarCambio();
			}
		}


		protected abstract void AplicarCambio();


		private void LimpiarObjetivos() {
			objetivos.RemoveAll(t => t == null);
			if (objetivos.Count == 0) {
				estado = Estado.ERROR;
				Debug.LogWarning("TransformacionEscalar: no hay transformadores asignados.");
			}
		}


	}

}