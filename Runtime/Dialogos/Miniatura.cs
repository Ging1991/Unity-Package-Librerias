using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Dialogos {

	public class Miniatura : MonoBehaviour {

		public Image ilustracionOBJ;
		private IProveedorImagen proveedor;

		public void Inicializar(IProveedorImagen proveedor) {
			this.proveedor = proveedor;
		}

		public void SetImagen(string imagen) {
			if (proveedor != null)
				ilustracionOBJ.sprite = proveedor.GetImagen(imagen);
			else
				Debug.LogError("Miniatura: debe inicializar este componente antes de utilizarlo.");
		}

	}

}