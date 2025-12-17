using System;
using Ging1991.Core.Interfaces;

namespace Ging1991.Relojes.Acciones {

	public class ActionEjecutable : IEjecutable {

		private readonly Action accion;

		public ActionEjecutable(Action accion) {
			this.accion = accion ?? throw new ArgumentNullException(nameof(accion));
		}

		public void Ejecutar() {
			accion();
		}

	}

}