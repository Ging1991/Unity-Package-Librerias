using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Core {

	public class Bloqueador : MonoBehaviour {

		public List<string> grupos = new List<string>() {"GLOBAL"};
		private int capaOriginal;
		private int capaBloqueadora;
		public static readonly string CAPA_BLOQUEADORA = "Ignore Raycast";

		void Start() {
			capaOriginal = gameObject.layer;
			capaBloqueadora = LayerMask.NameToLayer(CAPA_BLOQUEADORA);
		}


		public void Bloquear(bool debeBloquear) {
			gameObject.layer = debeBloquear ? capaBloqueadora : capaOriginal;

			if (TryGetComponent<Button>(out var button)) {
				button.interactable = !debeBloquear;
			}
		}


		public static void BloquearGrupo(string grupo, bool debeBloquear) {
			foreach (Bloqueador bloqueador in FindObjectsOfType<Bloqueador>()) {
				if (bloqueador.grupos.Contains(grupo)) {
					bloqueador.Bloquear(debeBloquear);
				}
			}
		}


	}

}