using System;

namespace posicao_falsa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Exemplo: f(x) = x*log(x) - 1
            //Func<double, double> f = x => x * Math.Log(x) - 1;
            Func<double, double> f = x => Math.Pow(x, 3) - 9 * x + 3;

            double a = 2.0;
            double b = 3.0;
            double tol = 1e-3; // ou 0.001
            int maxIter = 4;

            double raiz = PosicaoFalsa(f, a, b, tol, maxIter);

            Console.WriteLine($"Raiz aproximada: {raiz}");
        }

        static double PosicaoFalsa(Func<double, double> f, double a, double b, double tol, int maxIter)
        {
            double fa = f(a);
            double fb = f(b);

            if (fa * fb >= 0)
                throw new ArgumentException("f(a) e f(b) devem ter sinais opostos.");

            double c = a;
            for (int i = 0; i < maxIter; i++)
            {
                c = (a * fb - b * fa) / (fb - fa);
                double fc = f(c);

                Console.WriteLine($"Iteração {i + 1}: a = {a:F6}, b = {b:F6}, c = {c:F6}, f(c) = {fc:F6}");

                if (Math.Abs(fc) < tol)
                    return c;

                if (fa * fc < 0)
                {
                    b = c;
                    fb = fc;
                }
                else
                {
                    a = c;
                    fa = fc;
                }
            }
            return c;
        }
    }
}