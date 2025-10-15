using System.Collections.Generic;
using Ging1991.Animaciones.Transformaciones;
using Ging1991.Relojes;
using UnityEngine;

namespace Ging1991.Animaciones.Efectos {

	public class Escalar : AnimacionBase<Transform> {

		public List<Transform> objetivos;
		public float escalaInicial;
		public float escalaFinal;


		public void Inicializar(float escalaInicial, float escalaFinal, int iteraciones,
				List<Transform> objetivos = null,
				IEjecutable accionFinal = null) {

			this.objetivos = objetivos ?? this.objetivos;
			this.escalaInicial = escalaInicial;
			this.escalaFinal = escalaFinal;
			this.iteraciones = iteraciones;
			this.accionFinal = accionFinal;
			Inicializar();
		}


		public override void Inicializar() {
			transformacion = new TransformacionEscalar(objetivos, escalaInicial, escalaFinal, iteraciones);
			IniciarReloj();
		}


	}

}