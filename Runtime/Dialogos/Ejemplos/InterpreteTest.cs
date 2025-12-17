using Ging1991.Dialogos.Test;
using UnityEngine;

namespace Ging1991.Dialogos.Interpretes {

	public class InterpreteTest : Interprete<AccionTest> {

		public override bool InterpretarAccionEspecial(AccionTest accion) {
			Debug.Log("Texto especial: " + accion.textoDebug);
			return true;
		}

	}

}