using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Interfaces {

	public class Boton : MarcoConTexto {

		public GameObject candadoOBJ;


		public void Bloquear(bool bloqueado) {
			GetComponentInChildren<Button>().interactable = !bloqueado;
			if (candadoOBJ != null)
				candadoOBJ.SetActive(bloqueado);
		}


	}

}