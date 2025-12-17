using Ging1991.Core.Interfaces;
using UnityEngine;

namespace Ging1991.Relojes {

	public class Reloj : MonoBehaviour {

		public GestorDePeriodo centesimas;
		public GestorDePeriodo decimas;
		public GestorDePeriodo segundos;
		public GestorDePeriodo minutos;

		public static string NOMBRE_RELOJ_GLOBAL = "RelojGlobal";

		void Awake() {
			centesimas = new GestorDePeriodo(0.01f);
			decimas = new GestorDePeriodo(0.1f);
			segundos = new GestorDePeriodo(1f);
			minutos = new GestorDePeriodo(60f);
			Reiniciar();
		}


		public void Reiniciar() {
			centesimas.Reiniciar();
			decimas.Reiniciar();
			segundos.Reiniciar();
			minutos.Reiniciar();
		}


		void FixedUpdate() {
			centesimas.ProcesarAcciones();
			decimas.ProcesarAcciones();
			segundos.ProcesarAcciones();
			minutos.ProcesarAcciones();
		}


		public static Reloj GetInstanciaGlobal() {
			GameObject relojOBJ = GameObject.Find(NOMBRE_RELOJ_GLOBAL);

			if (relojOBJ == null) {
				Debug.LogWarning($"No se encontró un objeto con nombre '{NOMBRE_RELOJ_GLOBAL}'. Asegurate de que exista si querés usar el Reloj global.");
				return null;
			}

			Reloj relojComponente = relojOBJ.GetComponent<Reloj>();
			if (relojComponente == null) {
				Debug.LogWarning($"El objeto '{NOMBRE_RELOJ_GLOBAL}' existe, pero no tiene un componente Reloj.");
				return null;
			}

			return relojComponente;
		}


		public void Desuscribir(IEjecutable accion) {
			centesimas.Desuscribir(accion);
			decimas.Desuscribir(accion);
			segundos.Desuscribir(accion);
			minutos.Desuscribir(accion);
		}


	}

}