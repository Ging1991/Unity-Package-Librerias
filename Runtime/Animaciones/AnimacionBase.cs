using Ging1991.Animaciones.Transformaciones;
using Ging1991.Relojes;
using UnityEngine;

namespace Ging1991.Animaciones {

	public abstract class AnimacionBase<T> : MonoBehaviour, IEjecutable {

		public bool autoiniciar = false;
		public int iteraciones = 10;
		protected TransformacionBase<T> transformacion;
		protected Reloj reloj;
		public IEjecutable accionFinal;

		void Start() {
			if (autoiniciar)
				Inicializar();
		}


		public abstract void Inicializar();


		protected void IniciarReloj(Reloj reloj = null) {
			this.reloj = reloj != null ? reloj : Reloj.GetInstanciaGlobal();
			this.reloj.decimas.Desuscribir(this);
			this.reloj.decimas.Suscribir(this);
		}


		public bool SigueAnimando() {
			return transformacion.estado == TransformacionBase<T>.Estado.OK;
		}


		public void Ejecutar() {
			ProcesarCuadro();
		}


		protected void AplicarCambio() {
			transformacion.ProcesarCuadro();
		}


		public void ProcesarCuadro() {

			if (SigueAnimando()) {
				AplicarCambio();
			}
			else {
				AplicarCambio();
				Finalizar();
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