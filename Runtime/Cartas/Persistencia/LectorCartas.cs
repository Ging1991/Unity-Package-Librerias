using System.Collections.Generic;
using Bounds.Cartas.Persistencia.Datos;
using Ging1991.Persistencia.Direcciones;
using Ging1991.Persistencia.Lectores;

namespace Bounds.Cartas.Persistencia {

	public class LectorCartas : LectorGenerico<CartaBD> {

		private readonly Dictionary<int, CartaBD> datos = new();
		private readonly Direccion carpeta;

		public LectorCartas(string direccion, TipoLector tipo) : base(direccion, tipo) {
			carpeta = new DireccionRecursos(direccion);
		}


		public CartaBD LeerDatos(int cartaID) {
			if (!datos.ContainsKey(cartaID)) {
				LectorInterno lectorInterno = new(carpeta.Generar("carta" + cartaID), tipo);
				datos.Add(cartaID, lectorInterno.Leer());
			}
			return datos[cartaID];
		}


	}


	public class LectorInterno : LectorGenerico<CartaBD> {

		public LectorInterno(string direccion, TipoLector tipo) : base(direccion, tipo) { }
	}


}