using System.Collections.Generic;
using Ging1991.Dialogos.Interpretes;
using Ging1991.Dialogos.Persistencia;
using Ging1991.Relojes;
using UnityEngine;

namespace Ging1991.Dialogos {

	public abstract class Dialogo<T> : MonoBehaviour, IEjecutable where T : IAccionEspecial {

		public PantallaTactil pantallaTactil;
		public Interprete<T> interprete;
		private List<T> acciones;
		public int indice;

		public void Inicializar(List<T> acciones, IGetImagen ilustradorMiniatura, IGetImagen ilustradorPersonajes) {
			this.acciones = acciones;
			pantallaTactil.Inicializar(this);
			interprete.Inicializar(ilustradorMiniatura, ilustradorPersonajes);
			indice = 0;
		}

		public void Ejecutar() {
			bool ejecutarSiguienteAccion = false;
			if (interprete.secuenciandoTexto) {
				interprete.textoSecuencial.MostrarTextoCompleto();
			}
			else {
				if (acciones.Count > indice) {
					ejecutarSiguienteAccion = interprete.InterpretarAccion(acciones[indice]);
					indice++;
				}
			}
			if (ejecutarSiguienteAccion)
				Ejecutar();
		}

	}

}