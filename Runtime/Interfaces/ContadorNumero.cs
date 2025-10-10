namespace Ging1991.Interfaces {

	public class ContadorNumero : MarcoConTexto {

		public int valor;


		public void SetValor(int valor) {
			this.valor = valor;
			SetTexto($"{valor}");
		}
		

	}

}