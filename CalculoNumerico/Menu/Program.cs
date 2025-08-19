using System;

namespace metodos_numericos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nEscolha o método:");
                Console.WriteLine("1 - Bisseção");
                Console.WriteLine("2 - Posição Falsa");
                Console.WriteLine("3 - Newton");
                Console.WriteLine("4 - Cordas (Secante)");
                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");
                string opcao = Console.ReadLine();

                if (opcao == "0")
                    break;

                // Exemplo: f(x) = x^3 - 9x + 3
                Func<double, double> f = x => Math.Pow(x, 3) - 9 * x + 3;
                // Derivada para Newton
                Func<double, double> df = Derivada(f);

                switch (opcao)
                {
                    case "1":
                        Console.Write("a: ");
                        double a = double.Parse(Console.ReadLine());
                        Console.Write("b: ");
                        double b = double.Parse(Console.ReadLine());
                        Console.Write("Tolerância: ");
                        double tolB = double.Parse(Console.ReadLine());
                        Console.Write("Máx. Iterações: ");
                        int maxIterB = int.Parse(Console.ReadLine());
                        double raizB = Bissecao.Program.Bissecao(f, a, b, tolB, maxIterB);
                        if(raizB != 0)
                            Console.WriteLine($"\nRaiz aproximada: {raizB:F6}");
                        break;

                    case "2":
                        Console.Write("a: ");
                        double aPF = double.Parse(Console.ReadLine());
                        Console.Write("b: ");
                        double bPF = double.Parse(Console.ReadLine());
                        Console.Write("Tolerância: ");
                        double tolPF = double.Parse(Console.ReadLine());
                        Console.Write("Máx. Iterações: ");
                        int maxIterPF = int.Parse(Console.ReadLine());
                        double raizPF = Posicao_falsa.Program.PosicaoFalsa(f, aPF, bPF, tolPF, maxIterPF);
                        Console.WriteLine($"\nRaiz aproximada: {raizPF:F6}");
                        break;

                    case "3":
                        Console.Write("x0 (chute inicial): ");
                        double x0N = double.Parse(Console.ReadLine());
                        Console.Write("Tolerância: ");
                        double tolN = double.Parse(Console.ReadLine());
                        Console.Write("Máx. Iterações: ");
                        int maxIterN = int.Parse(Console.ReadLine());
                        double raizN = Newton.Program.Newton(f, df, x0N, tolN, maxIterN);
                        Console.WriteLine($"\nRaiz aproximada: {raizN:F6}");
                        break;

                    case "4":
                        Console.Write("x0 (primeiro chute): ");
                        double x0C = double.Parse(Console.ReadLine());
                        Console.Write("x1 (segundo chute): ");
                        double x1C = double.Parse(Console.ReadLine());
                        Console.Write("Tolerância: ");
                        double tolC = double.Parse(Console.ReadLine());
                        Console.Write("Máx. Iterações: ");
                        int maxIterC = int.Parse(Console.ReadLine());
                        double raizC = Cordas.Program.Cordas(f, x0C, x1C, tolC, maxIterC);
                        Console.WriteLine($"\nRaiz aproximada: {raizC:F6}");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }     
            
        }
        static Func<double, double> Derivada(Func<double, double> f)
        {
            return x =>
            {
                double h = 1e-6;
                return (f(x + h) - f(x - h)) / (2 * h);
            };
        }
    }
}
