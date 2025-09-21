using System;
using System.Collections.Generic;

namespace Ging1991.Core {

	public class Azar<T> {
		
		private static readonly Random generador = new Random();


		public static int GenerarEnteroEntre(int minimo, int maximo) {
			return generador.Next(minimo, maximo);
		}


		public static T ValorAleatorio(List<T> elementos) {
			return elementos[GenerarEnteroEntre(0, elementos.Count)];
		}

	}

}