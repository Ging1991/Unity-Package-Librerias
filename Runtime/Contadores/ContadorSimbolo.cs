using UnityEngine;

namespace Ging1991.Contadores {

	public class ContadorSimbolo : MonoBehaviour {

		public void SetValor(Color color, int valor, int valorMaxVisible, int valorMaxHabilitado) {

			int indice = 0;

			foreach (Transform hijo in transform) {

				ContadorIndividual contador = hijo.GetComponent<ContadorIndividual>();
				if (contador != null) {

					contador.SetColor(color);
					contador.SetValor(indice < valor);

					if (indice >= valorMaxHabilitado) {
						contador.SetInhabilitado();
					}

					hijo.gameObject.SetActive(indice < valorMaxVisible);

					indice++;
				}
				
			}

		}


	}

}