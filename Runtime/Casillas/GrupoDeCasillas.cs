using System.Collections.Generic;
using UnityEngine;

namespace Ging1991.Casillas {

	public class GrupoDeCasillas : MonoBehaviour, ICasillaObservador {

		public List<GameObject> casillas;
		private List<ICasillaObservador> observadores;
		public string codigo;
		public Vector3 posicionVisible;
		public Vector3 posicionInvisible;


		public void Iniciar() {
			observadores = new List<ICasillaObservador>();
			foreach (var casilla in casillas) {
				casilla.GetComponent<Casilla>().AgregarObservador(this);
			}
		}


		public void AgregarObservador (ICasillaObservador observador) {
			observadores.Add(observador);
		}


		public List<string> GetCasillasActivas() {
			List<string> ret = new List<string>();
			foreach(var casilla in casillas) {
				if (casilla.GetComponent<Casilla>() == true)
					ret.Add(casilla.GetComponent<Casilla>().codigo);
			}
			return ret;
		}


        public void PresionarCasilla(string codigo, bool valor) {
			foreach (ICasillaObservador observador in observadores) {
				observador.PresionarCasilla(codigo, valor);
			}
        }


		public void MostrarGrupo() {
			transform.position = posicionVisible;
		}


		public void EsconderGrupo() {
			transform.localPosition = posicionInvisible;
		}


    }

}