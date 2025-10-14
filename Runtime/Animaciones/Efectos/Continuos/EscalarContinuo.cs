using System.Collections.Generic;
using Ging1991.Relojes;
using UnityEngine;

namespace Ging1991.Animaciones.Efectos.Continuos {

	public class EscalarContinuo : Escalar {

		[Tooltip("Usá -1 para indicar repeticiones infinitas")]
		public int repeticiones = -1;


		public void Animar(List<Transform> transformadores, float escalaInicial, float escalaFinal, int iteraciones, int repeticiones) {
			if (transformadores == null || transformadores.Count == 0) {
				Debug.LogWarning("Escalar: no hay transformadores asignados.");
				return;
			}

			this.transformadores = transformadores;
			this.escalaInicial = escalaInicial;
			this.escalaFinal = escalaFinal;
			this.iteraciones = iteraciones;
			this.repeticiones = repeticiones;
			SetEscala(Vector3.one * escalaInicial);
			Iniciar(iteraciones);
		}


		public override void AnimacionDirecta() {
			if (transformadores == null || transformadores.Count == 0)
				return;

			SetEscala(Vector3.one * escalaInicial);
			var accion = new AccionRevertir(this);
			Iniciar(iteraciones, null, accionFinal: accion);
		}


		public class AccionRevertir : IEjecutable {

			private readonly EscalarContinuo objeto;

			public AccionRevertir(EscalarContinuo objeto) {
				this.objeto = objeto;
			}

			private void Invertir() {
				(objeto.escalaFinal, objeto.escalaInicial) = (objeto.escalaInicial, objeto.escalaFinal);
				objeto.Iniciar(objeto.iteraciones, accionFinal: new AccionRevertir(objeto));
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