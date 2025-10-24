using Ging1991.Interfaces;
using Ging1991.Relojes;
using UnityEngine;

public class ControlInterfacesTest : MonoBehaviour {

	public TextoSecuencial textoSecuencial;

	void Start() {
		textoSecuencial.SetTexto("Texto de prueba", accion: new AccionFinalizar());
		textoSecuencial.MostrarTextoCompleto();
	}

	public class AccionFinalizar : IEjecutable {
		public void Ejecutar() {
			Debug.Log("Accion completada");
		}
	}

}