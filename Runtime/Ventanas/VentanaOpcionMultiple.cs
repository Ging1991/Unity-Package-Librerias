using System.Collections.Generic;
using Ging1991.Interfaces;

namespace Ging1991.Ventanas {

	public class VentanaOpcionMultiple : Ventana {

		private List<Opcion> opcionesDisponibles;
		private List<Opcion> opcionesSeleccionadas;
		private int cantidad;
		private bool requiereConfirmar;
		private IConfirmarSeleccionMultiple accion;

		public void Inicializar(IConfirmarSeleccionMultiple accion, string mensaje, List<Opcion> opcionesDisponibles, int cantidad, bool requiereConfirmar) {
			GetComponent<MarcoConTexto>().SetTexto(mensaje);
			this.opcionesDisponibles = opcionesDisponibles;
			this.cantidad = cantidad;
			this.requiereConfirmar = requiereConfirmar;
			this.accion = accion;
			foreach (Opcion opcion in opcionesDisponibles) {
				opcion.Inicializar(this);
			}
		}


		public void PresionOpcion(Opcion opcion) {
			opcion.SetSeleccionado(true);
			opcionesSeleccionadas.Add(opcion);
			accion.ConfirmarSeleccion(opcionesSeleccionadas);
			FinalizarVentana();
		}

	}

}