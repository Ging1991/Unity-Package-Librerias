namespace Ging1991.Persistencia.Lectores.Directos {
		
	public class LectorEntero : LectorGenerico<LectorEntero.DatoBD> {

		public LectorEntero(string direccion, TipoLector tipo) : base(direccion, tipo) {}

		public void Guardar(int valor) {
			Guardar(new DatoBD
				{
					valor = valor
				}
			);
		}

		[System.Serializable]
		public class DatoBD {

			public int valor;

		}

	}

}