using Ging1991.Dialogos;
using UnityEngine;

public class ControlTest : MonoBehaviour {

	public Dialogo dialogo;

	void Start() {
		//dialogo.Inicializar(new Imaginador(), new Imaginador());
	}

	public class Imaginador : IProveedorImagen {
		public Sprite GetImagen(string nombre) {
			return null;
		}
	}

}