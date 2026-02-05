using System;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace notas
{
    class Program
    {
        static void Main(string[] args)
        {
            int saldo = 1000;
            int num2 = 0;
            Console.WriteLine("Bem vindo ao Kzusas Bank \n");
            menuprincipal();

            void menuprincipal()
            {
                Console.WriteLine("Menu Bancário\n");

                Console.WriteLine("1 - consultar saldo");
                Console.WriteLine("2 - depositar dinheiro");
                Console.WriteLine("3 - Sacar dinheiro");
                Console.WriteLine("4 - sair\n");

                int opcao_escolhida = int.Parse(Console.ReadLine());

                switch (opcao_escolhida)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"Seu saldo Atual e de {saldo} reais. \n");
                        menuprincipal();
                        return;

                    case 2:
                        Console.WriteLine("Digite  o valor para deposito\n");

                        num2 = int.Parse(Console.ReadLine());

                        saldo = saldo + num2;

                        Console.Clear();
                        Console.WriteLine($"seu saldo atual e de {saldo}");
                        menuprincipal();
                        return;

                    case 3:
                        Console.WriteLine("Digite o valor para saque\n");

                        num2 = int.Parse(Console.ReadLine() + Environment.NewLine);

                        if (num2 > saldo)
                        {
                            Console.WriteLine("Saldo insuficiente");
                            menuprincipal();
                            return;
                        }

                        saldo = saldo - num2;
                        Console.Clear();
                        Console.WriteLine($" Seu saldo atual é {saldo}");
                        menuprincipal();
                        return;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Obrigado por utilizar nossos serviços!");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção invalida.\n");
                        menuprincipal();
                        return;

                }
            }
        }
    }
}