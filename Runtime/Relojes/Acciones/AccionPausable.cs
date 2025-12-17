using System;
using Ging1991.Core.Interfaces;

namespace Ging1991.Relojes.Acciones {

	public class AccionPausable : IEjecutable {

		private readonly IEjecutable accion;
		private bool estaPausado;
		public bool EstaPausado => estaPausado;

		public AccionPausable(IEjecutable accion) {
			this.accion = accion ?? throw new ArgumentNullException(nameof(accion));
			estaPausado = false;
		}

		public void Ejecutar() {
			if (!estaPausado)
				accion.Ejecutar();
		}

		public void Pausar() {
			estaPausado = true;
		}

		public void Reanudar() {
			estaPausado = false;
		}

	}

}