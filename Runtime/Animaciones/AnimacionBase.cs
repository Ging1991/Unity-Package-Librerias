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
		public enum UnidadTiempo { CENTECIMAS, DECIMAS, SEGUNDOS }
		public UnidadTiempo unidadTiempo = UnidadTiempo.DECIMAS;

		void Start() {
			if (autoiniciar)
				Inicializar();
		}


		public abstract void Inicializar();


		protected void IniciarReloj(Reloj reloj = null) {
			this.reloj = reloj != null ? reloj : Reloj.GetInstanciaGlobal();
			this.reloj.Desuscribir(this);
			if (unidadTiempo == UnidadTiempo.CENTECIMAS)
				this.reloj.centesimas.Suscribir(this);
			if (unidadTiempo == UnidadTiempo.DECIMAS)
				this.reloj.decimas.Suscribir(this);
			if (unidadTiempo == UnidadTiempo.SEGUNDOS)
				this.reloj.segundos.Suscribir(this);
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
				reloj.Desuscribir(this);
			}
			accionFinal?.Ejecutar();
		}


	}

}