using Ging1991.Animaciones.Efectos;
using Ging1991.Animaciones.Transformaciones;
using Ging1991.Core.Interfaces;
using Ging1991.Relojes;
using UnityEngine;

namespace Ging1991.Animaciones.Continuos {

	public class MoverContinuo : Mover {

		[Tooltip("Usá -1 para indicar repeticiones infinitas")]
		public int repeticiones = -1;

		public override void Inicializar() {
			accionFinal = new AccionRevertir(this);
			transformacion = new TransformacionMover(objetivos, posicionInicial, posicionFinal, iteraciones);
			IniciarReloj();
		}


		public class AccionRevertir : IEjecutable {

			private readonly MoverContinuo objeto;

			public AccionRevertir(MoverContinuo objeto) {
				this.objeto = objeto;
			}

			private void Invertir() {
				(objeto.posicionFinal, objeto.posicionInicial) = (objeto.posicionInicial, objeto.posicionFinal);
				objeto.Inicializar();
			}

			public void Ejecutar() {
				if (objeto.repeticiones > 0) {
					objeto.repeticiones--;
					Invertir();
				}
				else if (objeto.repeticiones == -1) {
					Invertir();
				}
			}
		}


	}

}