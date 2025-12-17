using Ging1991.Core.Interfaces;
using Ging1991.Relojes;
using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Interfaces {

	public class TextoSecuencial : MonoBehaviour, IEjecutable {

		public Text componente;
		private string textoCompleto;
		private IEjecutable accion;
		private Reloj reloj;
		private int indice;

		public void SetTexto(string textoCompleto, IEjecutable accion = null, Reloj reloj = null) {
			this.textoCompleto = textoCompleto;
			this.accion = accion;
			this.reloj = reloj != null ? reloj : Reloj.GetInstanciaGlobal();

			this.reloj.Desuscribir(this);
			this.reloj.centesimas.Suscribir(this);
			indice = 0;
			componente.text = "";
		}


		public void Ejecutar() {
			if (textoCompleto.Length > indice) {
				componente.text += textoCompleto[indice];
				indice++;
			}
			else {
				FinalizarAnimacion();
			}
		}


		public void MostrarTextoCompleto() {
			componente.text = textoCompleto;
			FinalizarAnimacion();
		}


		private void FinalizarAnimacion() {
			reloj.Desuscribir(this);
			if (accion != null) {
				accion.Ejecutar();
			}
		}

	}

}