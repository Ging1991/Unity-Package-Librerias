using System;

namespace Ging1991.Relojes.Acciones {

	public class Temporizador : IEjecutable {

		private readonly IEjecutable accion;
		private readonly int limite;
		private readonly bool repetir;
		private int contador;
		private readonly Reloj reloj;

		public Temporizador(int limite, IEjecutable accion, bool repetir = false, Reloj reloj = null) {
			if (accion == null)
				throw new ArgumentNullException(nameof(accion));
			if (limite <= 0)
				throw new ArgumentException("El límite debe ser mayor a 0", nameof(limite));

			this.limite = limite;
			this.accion = accion;
			this.repetir = repetir;
			this.reloj = reloj;
			contador = 0;
		}


		public void Ejecutar() {
			contador++;
			if (contador == limite) {
				accion.Ejecutar();
				if (repetir)
					contador = 0;
				else
					if (reloj != null)
					reloj.Desuscribir(this);
				else
					Reloj.GetInstanciaGlobal().Desuscribir(this);
			}
		}


	}

}