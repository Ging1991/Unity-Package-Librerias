using UnityEngine;

namespace Ging1991.Dialogos {

	public class Dialogo : MonoBehaviour, ITareaFinalizada {

		public GameObject botonSiguienteOBJ;
		public GameObject textoOBJ;
		public GameObject miniaturaOBJ;

		public void SetTexto(string texto) {
			botonSiguienteOBJ.SetActive(false);
			textoOBJ.GetComponent<Texto>().SetTexto(texto, this);
		}

		public void SetMiniatura(string nombre) {
			miniaturaOBJ.GetComponent<Miniatura>().SetImagen(nombre);
		}

        public void TareaFinalizada() {
			botonSiguienteOBJ.SetActive(true);
		}

	}

}