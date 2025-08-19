using System;

namespace Cordas
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Exemplo: f(x) = x^3 -9x +3
            Func<double, double> f = x => Math.Pow(x, 3) - 9 * x + 3;

            double x0 = 2.5;   // primeiro chute
            double x1 = 3.0;   // segundo chute
            double tol = 1e-5; // tolerância
            int maxIter = 10;

            double raiz = Cordas(f, x0, x1, tol, maxIter);

            Console.WriteLine($"\nRaiz aproximada: {raiz:F6}");
        }

        public static double Cordas(Func<double, double> f, double x0, double x1, double tol, int maxIter)
        {
            double erro = double.MaxValue;
            double xAnt = x0;
            double x = x1;

            for (int i = 0; i < maxIter; i++)
            {
                double fxAnt = f(xAnt);
                double fx = f(x);

                if (Math.Abs(fx - fxAnt) < 1e-12)
                    throw new Exception("Divisão por zero na fórmula da corda.");

                double xNovo = x - fx * (x - xAnt) / (fx - fxAnt);
                erro = Math.Abs(xNovo - x);

                Console.WriteLine($"Iteração {i + 1}: x_{i} = {xAnt:F6}, x_{i + 1} = {x:F6}, f(x_{i + 1}) = {fx:F6}, erro = {erro:E6}");

                if (Math.Abs(f(xNovo)) < tol || erro < tol)
                    return xNovo;

                xAnt = x;
                x = xNovo;
            }
            return x;
        }
    }
}
