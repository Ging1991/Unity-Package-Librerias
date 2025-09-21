using System.Collections.Generic;
using UnityEngine;

namespace Ging1991.Core {

	public class GestorDeSonidos : MonoBehaviour {

		[SerializeField] private string carpetaResources = "Sonidos";
		[SerializeField] private int maxInstancias = 3;

		private readonly Dictionary<string, List<AudioSource>> mapaContenedores = new();
		private readonly Dictionary<string, AudioClip> archivos = new();


		public void ReproducirSonido(string nombre, float volumen = 0.5f) {
			AudioSource contenedor = TraerContenedor(nombre);
			if (contenedor != null) {
				contenedor.volume = volumen;
				contenedor.Play();
			}
			else {
				Debug.LogWarning("No se encontro el contenedor");
			}
		}


		private AudioSource TraerContenedor(string nombre) {
			List<AudioSource> contenedores = TraerContenedores(nombre);

			foreach (var contenedor in contenedores) {
				if (!contenedor.isPlaying)
					return contenedor;
			}

			if (contenedores.Count < maxInstancias) {
				AudioSource contenedor = CrearContenedor(nombre);
				contenedor.clip = TraerAudio(nombre);
				contenedores.Add(contenedor);
				return contenedor;
			}
			else {
				Debug.LogWarning($"[GestorDeSonidos] Límite de {maxInstancias} instancias alcanzado para '{nombre}'.");
			}
			return null;
		}


		private List<AudioSource> TraerContenedores(string nombre) {
			if (!mapaContenedores.ContainsKey(nombre)) {
				mapaContenedores[nombre] = new List<AudioSource>();
			}
			return mapaContenedores[nombre];
		}


		private AudioSource CrearContenedor(string clave) {
			GameObject objeto = new("Audio_" + clave);
			objeto.transform.parent = transform;
			return objeto.AddComponent<AudioSource>();
		}


		private AudioClip TraerAudio(string nombre) {
			if (archivos.ContainsKey(nombre))
				return archivos[nombre];

			AudioClip archivo = LeerAudio(nombre);
			if (archivo != null)
				archivos[nombre] = archivo;

			return archivo;
		}


		private AudioClip LeerAudio(string nombre) {
			AudioClip archivo = Resources.Load<AudioClip>($"{carpetaResources}/{nombre}");
			if (archivo == null)
				Debug.LogError($"No se encontró el audio: {nombre}");
			return archivo;
		}


	}

}