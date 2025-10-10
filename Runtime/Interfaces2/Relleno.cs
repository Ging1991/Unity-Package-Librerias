using Ging1991.Interfaces.Temas;
using UnityEngine;
using UnityEngine.UI;

namespace Ging1991.Interfaces {

	public class Relleno : MonoBehaviour, ITematizable {

		public string temaRelleno;
		public bool esPersonalizado;

		public void SetImagenRelleno(Sprite imagen) {
			GetComponent<Image>().sprite = imagen;
		}


		public virtual void SetColorRelleno(Color color) {
			GetComponent<Image>().color = color;
		}


		public virtual void AplicarTema(Tema tema) {
			if (!esPersonalizado)
				SetColorRelleno(tema.TraerColor(temaRelleno));
		}


    }

}