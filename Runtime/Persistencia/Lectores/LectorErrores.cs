using System;
using System.Collections.Generic;
using Ging1991.Persistencia.Direcciones;

namespace Ging1991.Persistencia.Lectores {

	public class LectorErrores {

		private readonly LectorInterno lectorInterno;
		private static LectorErrores instancia;

		public static LectorErrores GetInstancia() {
			if (instancia == null)
				instancia = new LectorErrores();
			return instancia;
		}


		private LectorErrores() {
			lectorInterno = new LectorInterno(new DireccionDinamica("AUDITORIA", "ERRORES.json").Generar());
			lectorInterno.InicializarPorDefecto(new DatoListaBD());
		}


		public void Guardar(string mensaje) {
			DatoBD datoNuevo = new()
			{
				mensaje = mensaje,
				fecha = DateTime.Now
			};

			DatoListaBD datoLista = lectorInterno.Leer();
			datoLista.lista.Add(datoNuevo);
			lectorInterno.Guardar(datoLista);
		}


		public List<DatoBD> Leer() {
			return lectorInterno.Leer().lista;
		}


		private class LectorInterno : LectorGenerico<DatoListaBD> {

			public LectorInterno(string direccion) : base(direccion, TipoLector.DINAMICO) { }

		}
		
		[Serializable]
		public class DatoListaBD {

			public List<DatoBD> lista;

		}

		[Serializable]
		public class DatoBD {

			public DateTime fecha;
			public string mensaje;

		}
	
	}

}