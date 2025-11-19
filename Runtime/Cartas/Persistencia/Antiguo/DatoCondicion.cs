using System.Collections.Generic;

namespace Bounds.Persistencia.Carta {

	[System.Serializable]
	public class DatoCondicion {

		public string tipo;
		public string tipoCriatura;
		public string controlador;
		public List<string> tiposCriatura;
		public List<string> clases;
		public string perfeccion;
		public List<string> perfecciones;
		public string clase;
		public int nivel = -1;
		public int minimo = -1;
		public int maximo = -1;
		public bool soloPerfectos;
		public bool esPerfecta;
		public bool soloImperfectos;
		
	}

}