using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Dialogos {

	public class Personaje : MonoBehaviour {

		private IProveedorImagen proveedor;

		public void Inicializar(IProveedorImagen proveedor) {
			this.proveedor = proveedor;
		}

		public void SetImagen(string imagen) {
			if (proveedor != null)
				GetComponent<Image>().sprite = proveedor.GetImagen(imagen);
			else
				Debug.LogError("Personaje: debe inicializar este componente antes de utilizarlo.");
		}

		public void SetPosicion(int x, int y) {
			transform.localPosition = new Vector3(x, y, 0);
		}

	}

}