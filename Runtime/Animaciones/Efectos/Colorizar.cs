using System.Collections.Generic;
using Ging1991.Animaciones.Transformaciones;
using Ging1991.Core.Interfaces;
using Ging1991.Relojes;
using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Animaciones.Efectos {

	public class Colorizar : AnimacionBase<Image> {

		public List<Image> objetivos;
		public Color colorInicial = Color.white;
		public Color colorFinal = Color.white;


		public void Inicializar(Color colorInicial, Color colorFinal, int iteraciones,
				List<Image> objetivos = null,
				IEjecutable accionFinal = null) {

			this.objetivos = objetivos ?? this.objetivos;
			this.colorInicial = colorInicial;
			this.colorFinal = colorFinal;
			this.iteraciones = iteraciones;
			this.accionFinal = accionFinal;
			Inicializar();
		}


		public override void Inicializar() {
			transformacion = new TransformacionColorizar(objetivos, colorInicial, colorFinal, iteraciones);
			IniciarReloj();
		}


	}

}