using Ging1991.Core.Interfaces;
using Ging1991.Dialogos.Persistencia;
using Ging1991.Interfaces;
using Ging1991.Relojes;
using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Dialogos.Interpretes {

	public abstract class Interprete<T> : MonoBehaviour, IEjecutable where T : IAccionEspecial {

		public TextoSecuencial textoSecuencial;
		public bool secuenciandoTexto;
		public Image ilustracionMiniatura;
		public GameObject miniaturaOBJ;
		private IGetImagen ilustradorMiniatura;
		private IGetImagen ilustradorPersonajes;
		public GameObject personajeClaseOBJ;
		public Transform padrePersonajes;

		public void Inicializar(IGetImagen ilustradorMiniatura, IGetImagen ilustradorPersonajes) {
			this.ilustradorMiniatura = ilustradorMiniatura;
			this.ilustradorPersonajes = ilustradorPersonajes;
		}


		public bool InterpretarAccion(T accion) {
			bool ejecutarSiguienteAccion;
			AccionEstandar estandar = accion.GetAccionEstandar();
			if (estandar != null) {
				ejecutarSiguienteAccion = InterpretarAccionEstandar(estandar);
			}
			else {
				ejecutarSiguienteAccion = InterpretarAccionEspecial(accion);
			}
			return ejecutarSiguienteAccion;
		}


		private bool InterpretarAccionEstandar(AccionEstandar accion) {

			if (accion.tipo == "PERSONAJE_CREAR") {
				GameObject instancia = Instantiate(personajeClaseOBJ);
				instancia.name = accion.nombre;
				instancia.transform.SetParent(padrePersonajes);
				instancia.GetComponent<Image>().sprite = ilustradorPersonajes.GetImagen(accion.imagen);
				RectTransform recta = instancia.GetComponent<RectTransform>();
				recta.localScale = Vector3.one;
				recta.sizeDelta = new Vector2(accion.ancho, accion.alto);
			}

			if (accion.tipo == "PERSONAJE_POSICIONAR") {
				GameObject instancia = GameObject.Find(accion.nombre);
				RectTransform recta = instancia.GetComponent<RectTransform>();
				recta.localPosition = new Vector3(accion.posX, accion.posY, 0);
			}

			if (accion.tipo == "PERSONAJE_APARECER") {
				GameObject instancia = GameObject.Find(accion.nombre);
				instancia.GetComponent<Personaje>().aparecer.Inicializar();
			}

			if (accion.tipo == "PERSONAJE_ACERCAR") {
				GameObject instancia = GameObject.Find(accion.nombre);
				instancia.GetComponent<Personaje>().acercar.Inicializar();
			}

			if (accion.tipo == "PERSONAJE_ALEJAR") {
				GameObject instancia = GameObject.Find(accion.nombre);
				instancia.GetComponent<Personaje>().alejar.Inicializar();
			}

			if (accion.tipo == "PERSONAJE_MOVER") {
				GameObject instancia = GameObject.Find(accion.nombre);
				Vector3 posInicial = instancia.transform.localPosition;
				Vector3 posFinal = new Vector3(accion.posX, accion.posY, 0);
				instancia.GetComponent<Personaje>().mover.Inicializar(posInicial, posFinal, 100);
			}

			if (accion.tipo == "PERSONAJE_DESAPARECER") {
				GameObject instancia = GameObject.Find(accion.nombre);
				instancia.GetComponent<Personaje>().desaparecer.Inicializar();
			}

			if (accion.tipo == "PERSONAJE_ESCALAR") {
				GameObject instancia = GameObject.Find(accion.nombre);
				RectTransform recta = instancia.GetComponent<RectTransform>();
				recta.localScale = new Vector3(accion.escalaX, accion.escalaY, 0);
			}

			if (accion.tipo == "MOSTRAR_TEXTO") {
				textoSecuencial.SetTexto(accion.texto, accion: this);
				secuenciandoTexto = true;
			}
			if (accion.tipo == "MOSTRAR_MINIATURA") {
				if (accion.imagen == "DESACTIVAR") {
					miniaturaOBJ.SetActive(false);
				}
				else {
					miniaturaOBJ.SetActive(true);
					ilustracionMiniatura.sprite = ilustradorMiniatura.GetImagen(accion.imagen);
				}
			}

			return accion.inmediato;
		}


		public abstract bool InterpretarAccionEspecial(T accion);


		public void Ejecutar() {
			secuenciandoTexto = false;
		}


	}

}