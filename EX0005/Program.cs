using System;
using System.Security.Cryptography.X509Certificates;

namespace dia_da_Semana
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Kzusas Calculator\n");

            int opcao = 0;
            int n1 = 0;
            int n2 = 0;
            try
            {
                Console.WriteLine("Digite o primeiro numero\n");
                n1 = int.Parse(Console.ReadLine());
                Console.Clear();

                Console.WriteLine("Qual operação deseja realizar?\n");

                Console.WriteLine("\t\n 1 => Somar");
                Console.WriteLine("\t\n 2 => Subtrair");
                Console.WriteLine("\t\n 3 => Multiplicar");
                Console.WriteLine("\t\n 4 => Dividir");
                 opcao = int.Parse(Console.ReadLine());
                Console.Clear();

                Console.WriteLine("Digite o segundo número");
                n2 = int.Parse(Console.ReadLine());
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Por favor digite apenas números");
            }
            


            switch (opcao)
            {
                case 1:
                    Console.WriteLine("vc escolheu somar");
                    somar();
                    break;
                case 2:
                    Console.WriteLine("Vc escolheu subtrair");
                    subtrair();
                    break;
                case 3:
                    Console.WriteLine("Vc escolheu multiplicar");
                    multiplicar();
                    break;
                case 4:
                    Console.WriteLine("Vc escolheu dividir");
                    dividir();
                    break;
                default:
                    Console.WriteLine("Vc escolheu uma opçao invalida");
                    break;
            }

            void somar()
            {
                int resultado = 0;
                resultado = n1 + n2;
                Console.WriteLine($"O resultado de {n1} + {n2} e igual a {resultado}");
            }
            void subtrair()
            {
                int resultado = n1 - n2;
                Console.WriteLine($"O resultado de {n1} - {n2} e igual a {resultado}");
            }
            void dividir()
            {
                int resultado = n1 / n2;
                Console.WriteLine($"O resultado de {n1} / {n2} e igual a {resultado}");
            }
            void multiplicar()
            {
                int resultado = n1 * n2;
                Console.WriteLine($"O resultado de {n1} * {n2} e igual a {resultado}");
            }
        }

    }

}




