namespace Ging1991.Persistencia.Lectores.Directos {
		
	public class LectorCadena : LectorGenerico<LectorCadena.DatoBD> {

		public LectorCadena(string direccion, TipoLector tipo) : base(direccion, tipo) {}

		public void Guardar(string valor) {
			Guardar(new DatoBD
				{
					valor = valor
				}
			);
		}

		[System.Serializable]
		public class DatoBD {

			public string valor;

		}

	}

}