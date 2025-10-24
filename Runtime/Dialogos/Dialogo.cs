using Ging1991.Interfaces;
using Ging1991.Relojes;
using UnityEngine;

namespace Ging1991.Dialogos {

	public class Dialogo : MonoBehaviour {

		public TextoSecuencial textoOBJ;
		public Miniatura miniaturaOBJ;

		public void Inicializar(IProveedorImagen proveedorMiniatura) {
			miniaturaOBJ.Inicializar(proveedorMiniatura);
		}

		//public void ProcesarElemento()

	}

}