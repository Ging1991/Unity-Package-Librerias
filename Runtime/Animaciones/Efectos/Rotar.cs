using System.Collections.Generic;
using Ging1991.Animaciones.Transformaciones;
using Ging1991.Core.Interfaces;
using Ging1991.Relojes;
using UnityEngine;

namespace Ging1991.Animaciones.Efectos {

	public class Rotar : AnimacionBase<Transform> {

		public List<Transform> objetivos;
		public Vector3 rotacionInicial;
		public Vector3 rotacionFinal;

		public void Inicializar(Vector3 rotacionInicial, Vector3 rotacionFinal, int iteraciones,
				List<Transform> objetivos = null,
				IEjecutable accionFinal = null) {

			this.objetivos = objetivos ?? this.objetivos;
			this.rotacionInicial = rotacionInicial;
			this.rotacionFinal = rotacionFinal;
			this.iteraciones = iteraciones;
			this.accionFinal = accionFinal;
			Inicializar();
		}


		public override void Inicializar() {
			transformacion = new TransformacionRotar(objetivos, rotacionInicial, rotacionFinal, iteraciones);
			IniciarReloj();
		}


	}

}