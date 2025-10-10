using System.Collections.Generic;
using UnityEngine;

namespace Ging1991.Movimiento {

	public class Espacio : MonoBehaviour {

		public static GameObject ObjetoMasCercano(Transform transform, List<GameObject> objetos) {

			if (objetos.Count == 0) {
				return null;
			}

			if (objetos.Count == 1) {
				return objetos[0];
			}

			GameObject objetoMasCercano = null;
			float distanciaMasCercana = Mathf.Infinity;

			foreach (GameObject objeto in objetos) {
				float distancia = Vector3.Distance(objeto.transform.position, transform.position);
				if (distancia < distanciaMasCercana) {
					objetoMasCercano = objeto;
					distanciaMasCercana = distancia;
				}
			}

			return objetoMasCercano;
		}


	}

}