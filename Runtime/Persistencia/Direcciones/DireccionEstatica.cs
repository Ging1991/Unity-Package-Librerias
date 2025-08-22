using System;
using System.IO;

namespace Ging1991.Persistencia.Direcciones {

	public static class DireccionEstatica {

		private static readonly string CARPETA_RAIZ = "TEMPORAL";

		public static string GenerarRutaDinamica(string carpeta, string archivo) {
			ValidarParametro("carpeta", carpeta);
			ValidarParametro("archivo", archivo);
			return Path.Combine(Carpeta.GetDirectorioRaiz(), CARPETA_RAIZ, Carpeta.Normalizar(carpeta), archivo);
		}

		public static string GenerarRutaRecursos(string carpeta, string archivo) {
			ValidarParametro("carpeta", carpeta);
			ValidarParametro("archivo", archivo);
			return Path.Combine(Carpeta.Normalizar(carpeta), Path.GetFileNameWithoutExtension(archivo)).Replace("\\", "/");
		}

		private static void ValidarParametro(string nombre, string parametro) {
			if (string.IsNullOrEmpty(parametro))
				throw new ArgumentException($"Debe especificar un {nombre}.", nameof(parametro));
		}

	}

}