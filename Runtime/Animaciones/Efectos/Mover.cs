using System.Collections.Generic;
using Ging1991.Animaciones.Transformaciones;
using Ging1991.Relojes;
using UnityEngine;

namespace Ging1991.Animaciones.Efectos {

	public class Mover : AnimacionBase<Transform> {

		public List<Transform> objetivos;
		public Vector3 posicionInicial;
		public Vector3 posicionFinal;

		public void Inicializar(Vector3 posicionInicial, Vector3 posicionFinal, int iteraciones,
				List<Transform> objetivos = null,
				IEjecutable accionFinal = null) {

			this.objetivos = objetivos ?? this.objetivos;
			this.posicionInicial = posicionInicial;
			this.posicionFinal = posicionFinal;
			this.iteraciones = iteraciones;
			this.accionFinal = accionFinal;
			Inicializar();
		}


		public override void Inicializar() {
			transformacion = new TransformacionMover(objetivos, posicionInicial, posicionFinal, iteraciones);
			IniciarReloj();
		}


	}

}