namespace Ging1991.Persistencia.Lectores.Demandas {

	public interface ILector<T> {

		public T Leer(string direccion);

	}

}