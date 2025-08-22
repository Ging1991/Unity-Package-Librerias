namespace Ging1991.Persistencia.Lectores.Directos {
		
	public class LectorBooleano : LectorGenerico<LectorBooleano.DatoBD> {

		public LectorBooleano(string direccion, TipoLector tipo) : base(direccion, tipo) {}

		public void Guardar(bool valor) {
			Guardar(new DatoBD
				{
					valor = valor
				}
			);
		}

		[System.Serializable]
		public class DatoBD {

			public bool valor;

		}

	}

}