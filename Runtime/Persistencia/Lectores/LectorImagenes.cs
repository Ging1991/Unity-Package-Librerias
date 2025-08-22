using System.IO;
using UnityEngine;

namespace Ging1991.Persistencia.Lectores {

	public static class LectorImagenes {

		public static Sprite LeerDesdeRecursos(string direccion) {
			if (string.IsNullOrEmpty(direccion))
				throw new System.ArgumentException("Debe especificar una dirección válida.", nameof(direccion));

			Sprite sprite = Resources.Load<Sprite>(direccion);
			if (sprite == null)
				Debug.LogWarning($"No se encontró el recurso en '{direccion}'.");
			return sprite;
		}


		public static Sprite LeerDesdeStream(string direccion) {
			if (string.IsNullOrEmpty(direccion))
				throw new System.ArgumentException("Debe especificar una ruta válida.", nameof(direccion));

			if (!File.Exists(direccion)) {
				Debug.LogWarning($"No se encontró el archivo en '{direccion}'.");
				return null;
			}

			byte[] datos = File.ReadAllBytes(direccion);
			Texture2D textura = new Texture2D(2, 2);
			if (!textura.LoadImage(datos)) {
				Debug.LogWarning($"No se pudo cargar la imagen desde '{direccion}'.");
				return null;
			}
			return Sprite.Create(textura, new Rect(0, 0, textura.width, textura.height), new Vector2(0.5f, 0.5f));
		}

	}
	
}