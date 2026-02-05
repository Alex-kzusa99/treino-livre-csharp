using System;
using System.Collections.Generic;
using System.Linq;

namespace treino_while
{
    class Program
    {
        private static readonly int numero_aleatorio;

        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Random random = new Random();
            int numero_digitado = 0;

            int numero_aleatorio = random.Next(1, 11);

            menu();

            void menu()
            {

                Console.WriteLine("=== Jogo de Adivinhação ===\n");

                Console.WriteLine("Digite um número entre 1 e 10: ");

                //int numero_digitado = int.Parse(Console.ReadLine());

                if (!int.TryParse(Console.ReadLine(), out numero_digitado))
                {
                    Console.WriteLine("Digite apenas números");
                    Thread.Sleep(2000);
                    Console.Clear();
                    menu();
                    return;
                }


                while (true)
                {
                    if (numero_digitado > 10 || numero_digitado < 1)
                    {
                        Console.WriteLine("Número inválido tente novamente!");
                        Thread.Sleep(2000);
                        Console.Clear();
                        menu();
                        return;
                    }


                    if (numero_digitado == numero_aleatorio)
                    {
                        list.Add(numero_digitado);
                        int quant_vezes = list.Count();
                        Console.WriteLine($"Parabens vc acertou em {quant_vezes} tentativas !!!!!\n");

                        Console.WriteLine("Deseja jogar novamente ? (S/N)");
                        string opcao = Console.ReadLine();

                        if (opcao.ToUpper() == "S")
                        {
                            numero_aleatorio = random.Next(1, 11);
                            Console.Clear();
                            list.Clear();
                            menu();
                        }
                        else if (opcao.ToUpper() == "N")
                        {
                            Console.WriteLine("Obrigado por utilizar nosso serviços");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Digite apenas (S/N)");
                            return;
                        }

                    }
                    else if (numero_digitado > numero_aleatorio)
                    {
                        Console.WriteLine("Tente um número menor");
                        Thread.Sleep(2000);

                        Console.Clear();
                        list.Add(numero_digitado);
                        menu();
                        return;
                    }
                    else if (numero_digitado < numero_aleatorio)
                    {
                        Console.WriteLine("Tente um número maior");
                        Thread.Sleep(2000);

                        Console.Clear();
                        list.Add(numero_digitado);
                        menu();

                        return;
                    }
                    break;
                }
            }
        }
    }
}