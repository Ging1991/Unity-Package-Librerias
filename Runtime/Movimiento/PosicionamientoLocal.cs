using UnityEngine;

namespace Ging1991.Movimiento {

	public class PosicionamientoLocal : MonoBehaviour {

		private readonly float DIFERENCIA_ACEPTABLE = 0.001f;
		private float velocidad = 0.1f;
		private bool debePosicionarse = false;
		private ILlegar accion;
		private Vector3 direccion;


		public void Posicionar(Vector3 direccion, float velocidad, ILlegar accion=null) {
			this.direccion = direccion;
			this.accion = accion;
			this.velocidad = velocidad;
			debePosicionarse = true;
		}


		public void SetVelocidad(float velocidad) {
			this.velocidad = velocidad;
		}


		void FixedUpdate() {
			ProcesarPosicionamiento();
		}
		

		private void ProcesarPosicionamiento() {
			if (debePosicionarse) {
				transform.localPosition = Vector3.MoveTowards(transform.localPosition, direccion, velocidad);
				if (Vector3.Distance(transform.localPosition, direccion) < DIFERENCIA_ACEPTABLE) {
					debePosicionarse = false;
					if (accion != null) {
						accion.Llegar();
					}
				}
			}
		}


	}
		
}