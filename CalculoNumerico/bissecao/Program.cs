using System;

namespace Bissecao
{
    public class Program
    {
        static void Main(string[] args)
        {
            // f(x) = x * log10(x) - 1
            Func<double, double> f = x => x * Math.Log10(x) - 1;

            double a = 2.0;
            double b = 3.0;
            double tol = 1e-3;
            int maxIter = 100;

            double raiz = Bissecao(f, a, b, tol, maxIter);

            Console.WriteLine($"\nRaiz aproximada: {raiz:F6}");
        }

        public static double Bissecao(Func<double, double> f, double a, double b, double tol, int maxIter)
        {
            try
            {
                if (f(a) * f(b) >= 0)
                    throw new ArgumentException("f(a) e f(b) devem ter sinais opostos.");

                double c = a;
                for (int i = 0; i < maxIter; i++)
                {
                    c = (a + b) / 2.0;
                    double fc = f(c);

                    Console.WriteLine($"Iteração {i + 1}: a = {a:F6}, b = {b:F6}, c = {c:F6}, f(c) = {fc:F6}");

                    if (Math.Abs(fc) < tol || (b - a) / 2.0 < tol)
                        return c;

                    if (f(a) * fc < 0)
                        b = c;
                    else
                        a = c;
                }
                return c;
            }
            catch (Exception e) { 
                Console.WriteLine($"Erro: {e.Message}");
                return 0;
            }
            
        }
    }
}
