using UnityEngine;

namespace Ging1991.Core {

	public class CamaraObjetivo : MonoBehaviour {

		private Transform objetivo;

		private void LateUpdate() {
			if (objetivo != null) {
				Vector3 posicionDeseada = new Vector3(
					objetivo.position.x,
					objetivo.position.y,
					transform.position.z
				);
				transform.position = Vector3.Lerp(transform.position, posicionDeseada, Time.deltaTime * 5f);
			}
		}


		public void CambiarObjetivo(Transform objetivo) {
			this.objetivo = objetivo;
		}


	}
	
}