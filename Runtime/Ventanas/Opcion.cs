using UnityEngine;

namespace Ging1991.Ventanas {

	public abstract class Opcion : MonoBehaviour {

		private VentanaOpcionMultiple ventana;

		public void Inicializar(VentanaOpcionMultiple ventana) {
			this.ventana = ventana;
		}

		void OnMouseDown() {
			ventana.PresionOpcion(this);
		}

		public abstract void SetSeleccionado(bool seleccionado);

	}

}