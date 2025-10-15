using System.Collections.Generic;
using Ging1991.Relojes;
using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Animaciones {

	public class MotorPrefab : MonoBehaviour {

		public List<GameObject> animaciones;
		public GameObject animacionDeAccion;


		public void Animar(IEjecutable accionFinal = null) {
			if (animaciones == null || animaciones.Count == 0)
				return;

			if (accionFinal != null && animacionDeAccion != null) {
				if (animacionDeAccion.TryGetComponent<AnimacionBase<Image>>(out var animacion1))
					animacion1.accionFinal = accionFinal;
				if (animacionDeAccion.TryGetComponent<AnimacionBase<Transform>>(out var animacion2))
					animacion2.accionFinal = accionFinal;
			}

			foreach (var animacion in animaciones) {
				if (animacion.TryGetComponent<AnimacionBase<Image>>(out var animacion1))
					animacion1.Inicializar();
				if (animacion.TryGetComponent<AnimacionBase<Transform>>(out var animacion2))
					animacion2.Inicializar();
			}

		}


	}

}