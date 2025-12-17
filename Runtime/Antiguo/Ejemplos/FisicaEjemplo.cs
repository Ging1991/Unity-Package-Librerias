namespace Ging1991.Core.Ejemplos {

	public class FisicaEjemplo : Singleton<FisicaEjemplo> {

		public ListadorDeFiguras listador;

		public FisicaEjemplo() {
			listador = new ListadorDeFiguras();
			listador.Inicializar();
		}

	}

}