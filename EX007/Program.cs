using System;
using System.Collections.Generic;
using System.Linq;

namespace notas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> notas = new List<double>();
            double nota_digitada = 0;

            Console.WriteLine(" Digite as nota dos alunos ou um valor negativo para sair:");

            while (true)
            {
                //Console.Write("Digite uma nota (ou -1 para sair): ");
                //nota_digitada = double.Parse(Console.ReadLine());

                if (!double.TryParse(Console.ReadLine(), out nota_digitada))
                {
                    Console.WriteLine("Por favor, digite um número válido.");
                }

                if (nota_digitada > 10)
                {
                    Console.WriteLine("Por favor, digite um número abaixo de 10");
                    continue;
                }

                if (nota_digitada < 0)
                {
                    double notas_validas = notas.Count();
                    double media = notas.Average();
                    double maior = notas.Max();
                    double menor = notas.Min();

                    Console.WriteLine($"A quantidade de notas validas é {notas_validas}");
                    Console.WriteLine($"A média da sala é {media:f2}");
                    Console.WriteLine($"A maior nota é {maior}");
                    Console.WriteLine($"A menor nota é {menor}");

                    break;
                }

                notas.Add(nota_digitada);

                if (notas.Count == 0)
                {
                    Console.WriteLine("Não existem notas para serem exibidas");
                    break;
                }
            }
        }
    }
}