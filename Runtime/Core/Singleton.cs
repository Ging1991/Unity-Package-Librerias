namespace Ging1991.Core {
	
	public class Singleton<T> where T : class, new() {

		private static T _instancia;
		public static T Instancia => _instancia ??= new T();

	}

}