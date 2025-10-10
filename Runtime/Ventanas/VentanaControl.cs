using System;
using Ging1991.Core;
using UnityEngine;

namespace Ging1991.Ventanas {

	public class VentanaControl : MonoBehaviour {

		public GameObject ventanaAceptarOBJ;
		public GameObject ventanaConfirmarOBJ;
		public GameObject ventanaOpcionMultipleOBJ;

		public static string LIENZO = "LienzoVentanas";

		public static GameObject CrearVentanaConfirmar(string mensaje, IPresionarBoton accion = null) {
			RevisarRequisitos();
			VentanaControl control = FindAnyObjectByType<VentanaControl>();
			GameObject ventana = InstanciarVentana(control.ventanaConfirmarOBJ, "VentanaConfirmar");
			ventana.GetComponent<Ventana>().Inicializar(mensaje, accion);
			return ventana;
		}


		public static GameObject CrearVentanaAceptar(string mensaje, IPresionarBoton accion = null) {
			RevisarRequisitos();
			VentanaControl control = FindAnyObjectByType<VentanaControl>();
			GameObject ventana = InstanciarVentana(control.ventanaAceptarOBJ, "VentanaAceptar");
			ventana.GetComponent<Ventana>().Inicializar(mensaje, accion);
			return ventana;
		}


		private static GameObject InstanciarVentana(GameObject objeto, string nombre) {
			GameObject instancia = Instantiate(objeto, Vector3.zero, Quaternion.identity);
			instancia.transform.SetParent(GameObject.Find(LIENZO).transform);
			instancia.transform.localPosition = Vector3.zero;
			instancia.name = nombre;
			Bloqueador.BloquearGrupo("GLOBAL", true);
			return instancia;
		}


		private static void RevisarRequisitos() {
			if (GameObject.Find(LIENZO)  == null) {
				throw new Exception($"No se encontro {LIENZO}, creelo en la escena con el nombre correspondiente");
			}
		}


	}

}