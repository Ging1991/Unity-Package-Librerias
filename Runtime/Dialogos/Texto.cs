using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Dialogos {

	public class Texto : MonoBehaviour {

		private string textoCompleto;
		private readonly float VELOCIDAD = 0.025f;
		private Coroutine rutinaActual;
		private ITareaFinalizada accion;

		public void SetTexto(string texto, ITareaFinalizada accion = null) {
			this.accion = null;
			DetenerRutina();
			textoCompleto = texto;
			this.accion = accion;
			GetComponent<Text>().text = "";
			rutinaActual = StartCoroutine(MostrarTexto());
		}

		public void MostrarTextoCompleto() {
			DetenerRutina();
			GetComponent<Text>().text = textoCompleto;
		}

		IEnumerator MostrarTexto() {
			int indice = 0;
			while (indice < textoCompleto.Length) {
				if (textoCompleto[indice] != ' ')
					yield return new WaitForSeconds(VELOCIDAD);

				GetComponent<Text>().text += textoCompleto[indice];
				indice++;
			}

			DetenerRutina();
		}

		private void DetenerRutina() {
			if (accion != null) {
				accion.TareaFinalizada();
			}
			if (rutinaActual != null) {
				StopCoroutine(rutinaActual);
				rutinaActual = null;
			}
		}

	}
}