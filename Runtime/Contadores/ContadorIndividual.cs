using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Contadores {

	public class ContadorIndividual : MonoBehaviour {

		public Sprite imgActivo, imgInactivo, imgInhabilitado;

		public void SetColor(Color color) {
			GetComponent<Image>().color = color;
		}


		public void SetValor(bool estaActivo) {
			GetComponent<Image>().sprite = estaActivo ? imgActivo : imgInactivo;
		}


		public void SetInhabilitado() {
			GetComponent<Image>().sprite = imgInhabilitado;
		}


	}

}