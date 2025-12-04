using System.Globalization;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

class Program 
{
  public struct aluno
    {
        public string nome;
        public double nota1;
        public double nota2;
        public double media;
        public bool aprovacao;
    }
  static void Main(string[] args) 
    {
        const int TAM = 15;
        aluno[]alunos = new aluno[TAM];
        int contador;

        for (contador = 0; contador< TAM; contador ++) 
        {
            Console.Write("Digite o nome do {0}° aluno:", contador + 1);
            alunos[contador].nome = (Console.ReadLine());
            Console.Write("Digite a primeira nota:");
            alunos[contador].nota1 = double.Parse(Console.ReadLine());
            Console.Write("Digite a segunda nota:");
            alunos[contador].nota2 = double.Parse(Console.ReadLine());
            alunos[contador].media = alunos[contador].nota1 + alunos[contador].nota2 / 2;
            if (alunos[contador].media >= 7)
            {
                alunos[contador].aprovacao = true;
            }
            else 
            {
                alunos[contador].aprovacao = false;
            }
        }
        Console.Clear();
        Console.WriteLine("Boletim dos Alunos:");
        for (contador = 0; contador < TAM; contador++)
        {
            if (alunos[contador].aprovacao == true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nNome do {0}º aluno: {1}", contador + 1, alunos[contador].nome);
                Console.WriteLine("Nota 1: {0:N1}", alunos[contador].nota1);
                Console.WriteLine("Nota 2: {0:N1}" , alunos[contador].nota2);
                Console.WriteLine("Média: {0:N1}", alunos[contador].media);
                Console.WriteLine("Situação: Aprovado");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNome do {0} aluno: {1}",contador + 1, alunos[contador].nome);
                Console.WriteLine("Nota 1: {0:N1}", alunos[contador].nota1);
                Console.WriteLine("Nota 2: {0:N1}", alunos[contador].nota2);
                Console.WriteLine("Média: {0:N1}", alunos[contador].media);
                Console.WriteLine("Situação: Reprovado");
            }
            Console.ReadKey();
        }
    }
}
