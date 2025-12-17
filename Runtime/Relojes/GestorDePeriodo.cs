using System.Collections.Generic;
using Ging1991.Core.Interfaces;
using UnityEngine;

namespace Ging1991.Relojes {

	public class GestorDePeriodo {

		private readonly List<IEjecutable> acciones;
		private readonly float limite;
		private float marcaTemporal;

		public GestorDePeriodo(float limite) {
			this.limite = limite;
			acciones = new();
			marcaTemporal = Time.time;
		}


		public void ProcesarAcciones() {
			if (PeriodoCumplido())
				EjecutarAcciones();
		}


		private bool PeriodoCumplido() {
			if (Time.time - marcaTemporal >= limite) {
				marcaTemporal += limite;
				return true;
			}
			return false;
		}


		private void EjecutarAcciones() {
			foreach (var accion in new List<IEjecutable>(acciones))
				accion?.Ejecutar();
		}


		public void Reiniciar() {
			marcaTemporal = Time.time;
		}


		public void Suscribir(IEjecutable accion) {
			if (!acciones.Contains(accion))
				acciones.Add(accion);
		}


		public void Desuscribir(IEjecutable accion) {
			acciones.Remove(accion);
		}


	}

}