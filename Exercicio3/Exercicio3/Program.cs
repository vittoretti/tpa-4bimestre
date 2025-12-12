using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usuario
{
    internal class Program
    {
        public struct Carro
        {
            public string Modelo;
            public int Ano;
            public string Cor;

            public Carro(string modelo, int ano, string cor)
            {
                Modelo = modelo;
                Ano = ano;
                Cor = cor;
            }
        }
        public class GerenciadorCarros
        {
            private const int MAX_CARROS = 500;
            private static Carro[] _cadastroCarros = new Carro[MAX_CARROS];
            private static int _totalCarros = 0; 

            private static string CadastrarCarro(Carro carro)
            {
                if (carro.Modelo == null) return "digite algo";

                return $"Modelo: {carro.Modelo,-20} | Ano: {carro.Ano} | Cor: {carro.Cor}";
            }

            public static void Main(string[] args)
            {
                int opcao = -1;

                while (opcao != 0)
                {
                    ExibirMenu();
                    if (int.TryParse(Console.ReadLine(), out opcao))
                    {
                        Console.WriteLine("------------------------------------------");
                        switch (opcao)
                        {
                            case 1: CadastredeCarro(); break;

                            case 2: ConsultarPorAno(); break;

                            case 3: ConsultarPorModelo(); break;

                            case 4: ConsultarPorCor(); break;

                            case 5: ExibirTodos(); break;

                            case 6: AltereoCarro(); break;

                            case 7: ExcluirCarro(); break;

                            case 0: Console.WriteLine("Programa encerrado."); break;
                            default: Console.WriteLine("Opção inválida. Selecione uma opção válida."); break;
                        }
                        Console.WriteLine("------------------------------------------\n");
                    }
                    else if (opcao != 0)
                    {
                        Console.WriteLine("\nEntrada inválida. Digite um número.");
                    }
                }
            }

            private static void ExibirMenu()
            {
                Console.WriteLine($"\nCadastro de Carros (Máx: {MAX_CARROS}, Atuais: {_totalCarros}) ");
                Console.WriteLine("1 - Cadastre o carro");
                Console.WriteLine("2 - Consultar o carro pelo ano de fabricação");
                Console.WriteLine("3 - Consultar carro pelo modelo");
                Console.WriteLine("4 - Consultar carro pela cor");
                Console.WriteLine("5 - Exibir todos os carros cadastrados");
                Console.WriteLine("6 - Alterar algum dado de um carro");
                Console.WriteLine("7 - Excluir um carro");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolher uma opção: ");
            }


            private static void CadastredeCarro()
            {
                if (_totalCarros >= MAX_CARROS)
                {
                    Console.WriteLine($"Erro: Limite máximo de {MAX_CARROS} carros atingido.");
                    return;
                }

                Console.WriteLine("Cadastro de Novo Carro:");

                Console.Write("Modelo do carro: ");
                string modelo = Console.ReadLine();

                Console.Write("Ano de fabricação: ");
                int ano;
                while (!int.TryParse(Console.ReadLine(), out ano) || ano < 1886 || ano > DateTime.Now.Year + 1)
                {
                    Console.Write("Ano inválido. Digite um ano válido: ");
                }

                Console.Write("Cor do carro: ");
                string cor = Console.ReadLine();

                _cadastroCarros[_totalCarros] = new Carro(modelo, ano, cor);
                _totalCarros++;

                Console.WriteLine($"\nCarro '{modelo}' cadastrado com sucesso! Total de carros: {_totalCarros}.");
            }


            private static void ExibirTodos()
            {
                Console.WriteLine($" Todos os carros cadastrados: ({_totalCarros} Encontrado(s))");
                if (_totalCarros == 0)
                {
                    Console.WriteLine("Nenhum carro cadastrado.");
                    return;
                }

                for (int i = 0; i < _totalCarros; i++)
                {
                    Console.WriteLine($"[{i,3}] - {CadastrarCarro(_cadastroCarros[i])}");
                }
            }


            private static void ConsultarPorAno()
            {
                Console.Write("Digite o ano de fabricação para consulta: ");
                if (int.TryParse(Console.ReadLine(), out int anoConsulta))
                {
                    var resultados = _cadastroCarros.Take(_totalCarros).Where(c => c.Ano == anoConsulta).ToList();
                    ExibirResultadosConsulta(resultados, $"Carros fabricados em {anoConsulta}");
                }
                else
                {
                    Console.WriteLine("Entrada inválida.");
                }
            }

            private static void ConsultarPorModelo()
            {
                Console.Write("Digite o modelo para consulta: ");
                string modeloConsulta = Console.ReadLine();

                var resultados = _cadastroCarros.Take(_totalCarros)
                    .Where(c => c.Modelo != null && c.Modelo.ToLower().Contains(modeloConsulta.ToLower()))
                    .ToList();

                ExibirResultadosConsulta(resultados, $"Carros do modelo '{modeloConsulta}'");
            }

            private static void ConsultarPorCor()
            {
                Console.Write("Digite a cor para consulta: ");
                string corConsulta = Console.ReadLine();

                var resultados = _cadastroCarros.Take(_totalCarros)
                    .Where(c => c.Cor != null && c.Cor.ToLower().Equals(corConsulta.ToLower()))
                    .ToList();

                ExibirResultadosConsulta(resultados, $"Carros da cor '{corConsulta}'");
            }

            private static void ExibirResultadosConsulta(List<Carro> resultados, string titulo)
            {
                Console.WriteLine($"\n--- {titulo} ({resultados.Count} Encontrado(s)) ---");
                if (resultados.Any())
                {
                    foreach (var carro in resultados)
                    {
                        Console.WriteLine(CadastrarCarro(carro));
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum carro encontrado.");
                }
            }


            private static void AltereoCarro()
            {
                if (_totalCarros == 0)
                {
                    Console.WriteLine("Nenhum carro cadastrado para alterar.");
                    return;
                }

                ExibirTodos();
                Console.Write("\nDigite o índice do carro que deseja alterar: ");
                if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 0 && indice < _totalCarros)
                {

                    Carro carroParaAlterar = _cadastroCarros[indice];

                    Console.WriteLine($"\nDados atuais: {CadastrarCarro(carroParaAlterar)}");

                    Console.WriteLine("Qual campo deseja alterar?");

                    Console.WriteLine("1 - Modelo");

                    Console.WriteLine("2 - Ano");

                    Console.WriteLine("3 - Cor");

                    Console.Write("Opção: ");

                    if (int.TryParse(Console.ReadLine(), out int campo) && campo >= 1 && campo <= 3)
                    {
                        switch (campo)
                        {
                            case 1:
                                Console.Write("Novo Modelo: ");
                                carroParaAlterar.Modelo = Console.ReadLine();
                                break;
                            case 2:
                                Console.Write("Novo Ano: ");
                                if (int.TryParse(Console.ReadLine(), out int novoAno))
                                {
                                    carroParaAlterar.Ano = novoAno;
                                }
                                else { Console.WriteLine("Ano inválido. Alteração cancelada."); return; }
                                break;
                            case 3:
                                Console.Write("Nova Cor: ");
                                carroParaAlterar.Cor = Console.ReadLine();
                                break;
                        }

                        _cadastroCarros[indice] = carroParaAlterar;

                        Console.WriteLine("\nDado alterado com sucesso!");
                        Console.WriteLine($"Novo dado: {CadastrarCarro(_cadastroCarros[indice])}");
                    }
                    else
                    {
                        Console.WriteLine("Opção de campo inválida.");
                    }
                }
                else
                {
                    Console.WriteLine("Índice inválido.");
                }
            }

            private static void ExcluirCarro()
            {

                ExibirTodos();
                Console.Write("\nDigite o índice do carro que deseja excluir: ");
                if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 0 && indice < _totalCarros)
                {
                    Console.WriteLine($"\nVocê realmente deseja excluir o carro: {CadastrarCarro(_cadastroCarros[indice])}? Esta ação é irrervesível. (S/N)");
                    string confirmacao = Console.ReadLine();

                    if (confirmacao.Trim().ToUpper() == "S")
                    {
                        for (int i = indice; i < _totalCarros - 1; i++)
                        {
                            _cadastroCarros[i] = _cadastroCarros[i + 1];
                        }

                        _totalCarros--;

                        _cadastroCarros[_totalCarros] = new Carro();

                        Console.WriteLine("\nCarro excluído com sucesso!");
                        Console.WriteLine($"Total de carros restantes: {_totalCarros}");
                    }
                    else
                    {
                        Console.WriteLine("\nExclusão cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine("Índice inválido.");
                }
            }
        }
    }
}
