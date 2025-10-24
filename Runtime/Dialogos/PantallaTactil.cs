using Ging1991.Relojes;
using UnityEngine;

namespace Ging1991.Dialogos {

	public class PantallaTactil : MonoBehaviour {

		private IEjecutable accion;

		public void Inicializar(IEjecutable accion) {
			this.accion = accion;
		}

		void OnMouseDown() {
			accion.Ejecutar();
		}

	}

}