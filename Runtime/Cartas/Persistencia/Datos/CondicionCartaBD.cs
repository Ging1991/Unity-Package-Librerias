using System.Collections.Generic;

namespace Bounds.Persistencia.Carta {

	[System.Serializable]
	public class CondicionCartaBD {

		public string tipoCriatura;
		public List<string> tiposCriatura;
		public string clase;
		public List<string> clases;
		public string perfeccion;
		public List<string> perfecciones;

		public string tipo;
		public string controlador;
		public int nivel = -1;
		public int minimo = -1;
		public int maximo = -1;
		public bool soloPerfectos;
		public bool esPerfecta;
		public bool soloImperfectos;

	}

}