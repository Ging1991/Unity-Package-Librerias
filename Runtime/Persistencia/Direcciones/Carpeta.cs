using System.IO;
using UnityEngine;

namespace Ging1991.Persistencia.Direcciones {

	public static class Carpeta {


		public static bool CrearSiNoExiste(string direccionCarpeta, bool log = false) {
			if (!Directory.Exists(direccionCarpeta)) {
				Directory.CreateDirectory(direccionCarpeta);
				if (log)
					Debug.Log($"Carpeta: La carpeta se ha creado correctamente en {direccionCarpeta}.");
				return true;
			}
			return false;
		}


		public static string GetDirectorioRaiz() {
#if UNITY_EDITOR
			return Application.dataPath;
#else
			return Application.persistentDataPath;
#endif
		}


		public static string Normalizar(string direccion) {
			direccion = direccion.Replace("\\", "/");
			direccion = direccion.Replace("//", "/");
			return direccion;
		}


	}

}