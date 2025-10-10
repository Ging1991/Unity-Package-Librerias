using Ging1991.Core;
using Ging1991.Interfaces;
using UnityEngine;

namespace Ging1991.Ventanas {

	public class Ventana : MonoBehaviour {

		private IPresionarBoton accion;

		public virtual void Inicializar(string mensaje, IPresionarBoton accion) {
			GetComponent<MarcoConTexto>().SetTexto(mensaje);
			this.accion = accion;
		}


		protected void FinalizarVentana() {
			Bloqueador.BloquearGrupo("GLOBAL", false);
			Destroy(gameObject);
		}


		public void BotonAceptar() {
			accion?.PresionarBoton(TipoBoton.ACEPTAR);
			FinalizarVentana();
		}


		public void BotonCancelar() {
			accion?.PresionarBoton(TipoBoton.CANCELAR);
			FinalizarVentana();
		}


	}

}