class Program
{

    public struct data
    {
        public int dia;
        public int mes;
        public int ano;
    }

    public static void Main(string[] args)
    {
        data dataatual;
        Console.WriteLine("Informe a data atual:");
        Console.Write("Informe o dia:");
        dataatual.dia = int.Parse(Console.ReadLine());
        Console.Write("Informe o mês:");
        dataatual.mes = int.Parse(Console.ReadLine());
        Console.Write("Informe o ano:");
        dataatual.ano = int.Parse(Console.ReadLine());
        if (dataatual.dia <= 31 && dataatual.mes <= 12 && dataatual.ano <= 2025)
        {
            Console.WriteLine("A data informada é válida.");
        }
        else if (dataatual.dia <= 28 && dataatual.mes == 2 && dataatual.ano <= 2025) 
        {
            Console.WriteLine("A data informada é válida.");
        }
        else 
        {
            Console.WriteLine("A data informada é inválida.");
        }
    }
}