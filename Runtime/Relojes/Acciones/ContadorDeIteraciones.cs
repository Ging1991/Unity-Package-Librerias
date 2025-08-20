using System;

namespace Ging1991.Relojes.Acciones {

	public class ContadorDeIteraciones : IEjecutable {

		private readonly IContadorDeIteraciones observador;
		private readonly bool esRegresivo;
		private int contador;

		public ContadorDeIteraciones(IContadorDeIteraciones observador, int valorInicial = 0, bool esRegresivo = false) {
			this.observador = observador ?? throw new ArgumentNullException(nameof(observador));
			this.contador = valorInicial;
			this.esRegresivo = esRegresivo;
		}


		public void Ejecutar() {
			observador.ActualizarContador(esRegresivo ? --contador : ++contador);
		}


	}

}