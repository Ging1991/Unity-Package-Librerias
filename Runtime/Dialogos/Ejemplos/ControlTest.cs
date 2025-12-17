using Ging1991.Dialogos;
using Ging1991.Dialogos.Persistencia;
using Ging1991.Dialogos.Test;
using Ging1991.Persistencia.Direcciones;
using UnityEngine;

namespace Ging1991.Persistencia.Tests {

	public class ControlTest : MonoBehaviour {

		public Dialogo<AccionTest> dialogo;

		void Start() {
			string direccion = new DireccionRecursos("datos", "dialogo").Generar();
			LectorListaGenerica<AccionTest> lector = new(direccion, Lectores.TipoLector.RECURSOS);
			LectorImagenes lectorImagenes = new(new DireccionRecursos("imagenes"));
			dialogo.Inicializar(lector.GetLista(), lectorImagenes, lectorImagenes);
		}

	}

}