using System.Collections.Generic;
using UnityEngine;

namespace Ging1991.Interfaces.Temas {

	public class Tema {

		private readonly Dictionary<string, Color> colores;

		public Tema () {
			colores = new Dictionary<string, Color>();
		}


		public void AgregarColor(string codigo, Color color) {
			colores.Add(codigo, color);
		}


		public Color TraerColor(string codigo) {
			if (colores.ContainsKey(codigo))
				return colores[codigo];
			
			Debug.LogWarning("Color no encontrado: " + codigo);
			return Color.white;
		}


	}

}