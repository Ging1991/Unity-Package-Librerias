using System.Collections.Generic;
using Ging1991.Animaciones.Transformaciones;
using Ging1991.Relojes;
using UnityEngine;

namespace Ging1991.Animaciones.Efectos {

	public class TrasparentarGrupo : AnimacionBase<CanvasGroup> {

		public List<CanvasGroup> objetivos;
		public float alfaInicial = 0;
		public float alfaFinal = 1;

		public void Inicializar(float alfaInicial, float alfaFinal, int iteraciones,
				List<CanvasGroup> objetivos = null,
				IEjecutable accionFinal = null) {

			this.objetivos = objetivos ?? this.objetivos;
			this.alfaInicial = Mathf.Clamp01(alfaInicial);
			this.alfaFinal = Mathf.Clamp01(alfaFinal);
			this.iteraciones = iteraciones;
			this.accionFinal = accionFinal;
			Inicializar();
		}


		public override void Inicializar() {
			transformacion = new TransformacionTrasparentarGrupo(objetivos, alfaInicial, alfaFinal, iteraciones);
			IniciarReloj();
		}


	}

}