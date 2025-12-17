using System.Collections.Generic;
using UnityEngine;
using Ging1991.Persistencia.Lectores;
using Ging1991.Persistencia.Lectores.Directos;
using Ging1991.Persistencia.Direcciones;

namespace Ging1991.Persistencia.Ejemplos {

	public class LectorEjemplo : MonoBehaviour {

		void Start() {
			EscribirDatos();
			LeerDatos();
		}


		public void EscribirDatos() {
			Direccion direccionEntero = new DireccionDinamica("TEST", "TestEntero.json");
			LectorEntero lectorEntero = new LectorEntero(direccionEntero.Generar(), TipoLector.DINAMICO);
			lectorEntero.Guardar(42);

			Direccion direccionListaEnteros = new DireccionDinamica("TEST", "TestListaEnteros.json");
			LectorListaEnteros lectorLista = new LectorListaEnteros(direccionListaEnteros.Generar(), TipoLector.DINAMICO);
			lectorLista.Guardar(new List<int> { 1, 2, 3, 4, 5 });

			Debug.Log("Datos escritos en memoria con lectores directos.");
		}


		public void LeerDatos() {
			Direccion direccionEntero = new DireccionDinamica("TEST", "TestEntero.json");
			LectorEntero lectorEntero = new LectorEntero(direccionEntero.Generar(), TipoLector.DINAMICO);
			int valor = lectorEntero.Leer().valor;
			Debug.Log("Entero leído: " + valor);

			Direccion direccionListaEnteros = new DireccionDinamica("TEST", "TestListaEnteros.json");
			LectorListaEnteros lectorLista = new LectorListaEnteros(direccionListaEnteros.Generar(), TipoLector.DINAMICO);
			List<int> lista = lectorLista.Leer().valor;
			Debug.Log("Lista de enteros leída: " + string.Join(", ", lista));
		}


	}

}