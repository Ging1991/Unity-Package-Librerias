using Ging1991.Animaciones.Efectos;
using Ging1991.Core.Interfaces;
using Ging1991.Relojes;
using UnityEngine;

namespace Ging1991.Animaciones.Ejemplos {

	public class ControlEjemplo : MonoBehaviour {

		void Start() {
			//GameObject.Find("Escalar").GetComponent<Escalar>().Inicializar(1, 0, 10, accionFinal: new Finalizar());
			//GameObject.Find("Colorizar").GetComponent<Colorizar>().Inicializar(Color.white, Color.red, 10, accionFinal: new Finalizar());
			//GameObject.Find("Trasparentar").GetComponent<Trasparentar>().Inicializar(1, 0, 10, accionFinal: new Finalizar());
			//GameObject.Find("Rotar").GetComponent<Rotar>().Inicializar(new Vector3(0, 0, 0), new Vector3(0, 0, 90), 10, accionFinal: new Finalizar());
			//GameObject.Find("Mover").GetComponent<Mover>().Inicializar(new Vector3(200, 0, 0), new Vector3(200, 100, 90), 10, accionFinal: new Finalizar());
			//			FindAnyObjectByType<MotorPrefab>().Animar(accionFinal: new Finalizar());
		}

		public class Finalizar : IEjecutable {
			public void Ejecutar() {
				Debug.Log("Animacion finalizada.");
			}
		}

	}

}