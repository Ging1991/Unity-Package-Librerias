using System.Collections.Generic;

namespace Ging1991.Core.Ejemplos {

	public class ListadorDeFiguras : Listador<string> {

		public override void Inicializar() {
			base.Inicializar();
			AgregarLista("3 angulos", new List<string>());
			AgregarLista("4 angulos", new List<string>());
			AgregarLista("5 angulos", new List<string>());

		}

	}

}