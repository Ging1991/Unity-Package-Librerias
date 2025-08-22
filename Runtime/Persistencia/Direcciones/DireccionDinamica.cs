using System;
using System.IO;

namespace Ging1991.Persistencia.Direcciones {

	public class DireccionDinamica : Direccion {

		public static readonly string CARPETA_RAIZ = "TEMPORAL";

		public DireccionDinamica(string carpeta, string archivo = "") : base(carpeta, archivo) {
			Carpeta.CrearSiNoExiste(GenerarRutaCarpeta());
		}

		public override string Generar() {
			if (string.IsNullOrEmpty(archivo))
				throw new InvalidOperationException("No hay un archivo cargado. Use [Direccion.Generar(string archivo)] en su lugar.");
			return Generar(archivo);
		}

		public override string Generar(string archivo) {
			return Path.Combine(Carpeta.GetDirectorioRaiz(), CARPETA_RAIZ, carpeta, archivo);
		}

		private string GenerarRutaCarpeta() {
			return Path.Combine(Carpeta.GetDirectorioRaiz(), CARPETA_RAIZ, carpeta);
		}

	}

}