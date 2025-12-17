using System;
using Ging1991.Core.Interfaces;

namespace Ging1991.Relojes.Acciones {

	public class Repeticion : IEjecutable {

		private readonly IEjecutable accion;
		private readonly int cantidad;
		private int contador;
		private readonly Reloj reloj;
		public int ContadorActual => contador;

		public Repeticion(IEjecutable accion, int cantidad, Reloj reloj = null) {
			this.accion = accion ?? throw new ArgumentNullException(nameof(accion));
			if (cantidad <= 0)
				throw new ArgumentException("La cantidad debe ser mayor a 0", nameof(cantidad));
			this.cantidad = cantidad;
			this.reloj = reloj;
			contador = 0;
		}


		public void Ejecutar() {
			accion.Ejecutar();
			contador++;
			if (contador >= cantidad) {
				if (reloj != null)
					reloj.Desuscribir(this);
				else
					Reloj.GetInstanciaGlobal().Desuscribir(this);
			}
		}


	}
}