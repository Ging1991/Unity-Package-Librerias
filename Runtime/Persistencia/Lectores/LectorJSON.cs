using System;
using System.IO;
using UnityEngine;

namespace Ging1991.Persistencia.Lectores {

	public abstract class LectorJSON {

		protected readonly string direccion;

		protected LectorJSON(string direccion) {
			ValidarParametro(direccion, $"Debe especificar una dirección válida: {direccion}");
			this.direccion = direccion;
		}


		public bool ExistenDatos() {
			return File.Exists(direccion);
		}


		public void EliminarDatos() {
			try {
				if (ExistenDatos())
					File.Delete(direccion);
			}
			catch (Exception ex) {
				Debug.LogWarning($"No se pudo eliminar el archivo '{direccion}': {ex.Message}");
			}
		}


		protected string LeerDesdeStream() {
			if (!ExistenDatos())
				throw new FileNotFoundException($"El archivo '{direccion}' no existe.");
			return File.ReadAllText(direccion);
		}


		protected void GuardarHaciaStream(string contenido) {
			ValidarParametro(direccion, $"No se puede guardar contenido nulo: {contenido}");
			File.WriteAllText(direccion, contenido);
		}


		protected string LeerDesdeRecursos(string direccionRecurso) {
			ValidarParametro(direccionRecurso, $"Debe especificar la dirección del recurso: {direccionRecurso}");
			TextAsset recurso = Resources.Load<TextAsset>(direccionRecurso);
			if (recurso == null) {
				Debug.LogWarning($"No se encontró el recurso en '{direccionRecurso}'. Se devuelve string vacío.");
				return string.Empty;
			}
			return recurso.text;
		}


		public void InicializarDesdeRecursos(string direccionRecurso) {
			ValidarParametro(direccionRecurso, $"Debe especificar la dirección del recurso: {direccionRecurso}");
			if (!ExistenDatos()) {
				GuardarHaciaStream(LeerDesdeRecursos(direccionRecurso));
			}
		}


		private static void ValidarParametro(string valor, string mensaje) {
			if (string.IsNullOrEmpty(valor))
				throw new ArgumentException(mensaje);
		}


	}

}