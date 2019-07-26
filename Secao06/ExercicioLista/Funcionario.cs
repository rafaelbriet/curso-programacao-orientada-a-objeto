using System.Globalization;

namespace ExercicioLista
{
	class Funcionario
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public double Salario { get; set; }

		public Funcionario(int id, string nome, double salario)
		{
			Id = id;
			Nome = nome;
			Salario = salario;
		}

		public void AumentoSalario(double porcentagem)
		{
			Salario += (Salario * porcentagem) / 100.0;
		}

		public override string ToString()
		{
			return Id + ", " + Nome + ", " + Salario.ToString("F2", CultureInfo.InvariantCulture);
		}
	}
}
