using System;

namespace Newton
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Exemplo: f(x) = x^3 -9x +3
            Func<double, double> f = x => Math.Pow(x, 3) - 9 * x + 3;
            // Derivada: f'(x) = 3x^2 -9 
            Func<double, double> df = x => 3 * Math.Pow(x, 2) - 9;

            double x0 = 3;    // chute inicial
            double tol = 1e-5;  // tolerância
            int maxIter = 3;

            double raiz = Newton(f, df, x0, tol, maxIter);

            Console.WriteLine($"\nRaiz aproximada: {raiz:F6}");
        }

        public static double Newton(Func<double, double> f, Func<double, double> df, double x0, double tol, int maxIter)
        {
            try
            {
                double x = x0;
                double erro = double.MaxValue;

                for (int i = 0; i < maxIter; i++)
                {
                    double fx = f(x);
                    double dfx = df(x);

                    if (i > 0)
                        Console.WriteLine($"Iteração {i + 1}: x = {x:F6}, f(x) = {fx:F6}, f'(x) = {dfx:F6}, erro = {erro:E6}");
                    else
                        Console.WriteLine($"Iteração {i + 1}: x = {x:F6}, f(x) = {fx:F6}, f'(x) = {dfx:F6}");

                    if (Math.Abs(fx) < tol || erro < tol)
                        return x;

                    if (Math.Abs(dfx) < 1e-12)
                        throw new Exception("Derivada próxima de zero. Método pode falhar.");

                    double xNovo = x - fx / dfx;
                    erro = Math.Abs(xNovo - x);
                    x = xNovo;
                }
                return x;
            }
            catch (Exception e) 
            { 
                Console.WriteLine($"Erro: {e.Message}");
                return 0;
            }
        }
    }
}
