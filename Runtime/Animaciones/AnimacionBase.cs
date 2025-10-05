using Ging1991.Relojes;
using UnityEngine;

namespace Ging1991.Animaciones {
	
	public abstract class AnimacionBase : MonoBehaviour, IEjecutable {

		public bool autoiniciar = false;
		public int iteraciones = 10;
		protected int pasosRestantes;
		protected int pasosTotales;
		protected Reloj reloj;
		protected IEjecutable accionFinal;
		protected bool estaCancelada = false;

		void Start() {
			if (autoiniciar)
				Iniciar(iteraciones);
		}


		public bool SigueAnimando() {
			return !estaCancelada && pasosRestantes > 0;
		}


		public void Ejecutar() {
			if (estaCancelada)
				return;
			ProcesarCuadro();
		}


		protected void Iniciar(int iteraciones, Reloj reloj = null, IEjecutable accionFinal = null) {
			this.iteraciones = iteraciones;
			pasosRestantes = iteraciones;
			pasosTotales = iteraciones;
			estaCancelada = false;
			this.accionFinal = accionFinal;

			this.reloj = reloj != null ? reloj : Reloj.GetInstanciaGlobal();
			this.reloj.decimas.Desuscribir(this);
			this.reloj.decimas.Suscribir(this);
		}


		protected abstract void AplicarCambio();


		public abstract void AnimacionDirecta();


		public void ProcesarCuadro() {
			if (estaCancelada)
				return;

			if (SigueAnimando()) {
				AplicarCambio();
				pasosRestantes--;
			
			} else {
				AplicarCambio();
				Finalizar();
			}
		}


		public void Cancelar(bool ejecutarCallback = false) {
			if (estaCancelada)
				return;
				
			estaCancelada = true;
			pasosRestantes = 0;

			if (reloj != null) {
				reloj.decimas.Desuscribir(this);
			}

			if (ejecutarCallback && accionFinal != null) {
				accionFinal.Ejecutar();
			}
		}


		private void Finalizar() {
			if (reloj != null) {
				reloj.decimas.Desuscribir(this);
			}
			accionFinal?.Ejecutar();
		}

	}

}