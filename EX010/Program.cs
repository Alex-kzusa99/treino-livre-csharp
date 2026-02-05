using System;

namespace triangulo
{

    class Program
    {
        static void Main(string[] args)
        {

            // Declaração das variáveis para as notas
            double nota1, nota2, media;

            // Entrada das notas
            Console.WriteLine("Digite a nota da primeira parcial:");
            nota1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite a nota da segunda parcial:");
            nota2 = double.Parse(Console.ReadLine());

            // Cálculo da média
            media = (nota1 + nota2) / 2;

            // Atribuição do conceito
            string conceito;
            if (media >= 9.0)
            {
                conceito = "A";
            }
            else if (media >= 7.5)
            {
                conceito = "B";
            }
            else if (media >= 6.0)
            {
                conceito = "C";
            }
            else if (media >= 4.0)
            {
                conceito = "D";
            }
            else
            {
                conceito = "E";
            }

            // Apresentação da média e conceito
            Console.WriteLine("Média: " + media);
            Console.WriteLine("Conceito: " + conceito);
        }
    }
}