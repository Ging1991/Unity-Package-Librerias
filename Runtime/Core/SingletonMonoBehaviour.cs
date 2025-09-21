using UnityEngine;

namespace Ging1991.Core {
	
	public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour {
	
		public static T Instancia { get; private set; }

		protected virtual void Awake() {
			if (Instancia != null && Instancia != this as T) {
				Destroy(gameObject);
				return;
			}
			Instancia = this as T;
		}

	}

}