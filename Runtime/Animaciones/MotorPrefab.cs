using System.Collections.Generic;
using UnityEngine;

namespace Ging1991.Animaciones {

	public class MotorPrefab : MonoBehaviour {

		public List<AnimacionBase> animaciones;

		public void Animar() {
			if (animaciones == null || animaciones.Count == 0)
				return;

			foreach (var animacion in animaciones) {
				if (animacion != null)
					animacion.AnimacionDirecta();
			}
		}

	}
	
}