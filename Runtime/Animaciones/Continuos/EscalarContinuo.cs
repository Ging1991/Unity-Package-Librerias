using Ging1991.Animaciones.Efectos;
using Ging1991.Animaciones.Transformaciones;
using Ging1991.Relojes;
using UnityEngine;

namespace Ging1991.Animaciones.Continuos {

	public class EscalarContinuo : Escalar {

		[Tooltip("Usá -1 para indicar repeticiones infinitas")]
		public int repeticiones = -1;

		public override void Inicializar() {
			accionFinal = new AccionRevertir(this);
			transformacion = new TransformacionEscalar(objetivos, escalaInicial, escalaFinal, iteraciones);
			IniciarReloj();
		}


		public class AccionRevertir : IEjecutable {

			private readonly EscalarContinuo objeto;

			public AccionRevertir(EscalarContinuo objeto) {
				this.objeto = objeto;
			}

			private void Invertir() {
				(objeto.escalaFinal, objeto.escalaInicial) = (objeto.escalaInicial, objeto.escalaFinal);
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