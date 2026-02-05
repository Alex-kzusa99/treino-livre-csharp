using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace aumento_de_salario
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list_itens = new List<string>();
            string itens_digitados = "";

            menu();

            void menu()
            {
                Console.WriteLine("Bem vindo ao gerenciador de compras\n");
                Console.WriteLine("MENU PRINCIPAL\n");

                Console.WriteLine("1 - Adicionar item");
                Console.WriteLine("2 - Exibir lista");
                Console.WriteLine("3 - Remover item");
                Console.WriteLine("0 - sair\n");

                int opcao_escolhida = int.Parse(Console.ReadLine());

                switch (opcao_escolhida)
                {
                    case 1:

                        Console.WriteLine("Digite itens para adicionar à lista (ou digite 'sair' para encerrar):");

                        while (true)
                        {
                            itens_digitados = Console.ReadLine();

                            if (itens_digitados.ToLower() == "sair")
                            {
                                break;
                            }

                            list_itens.Add(itens_digitados);
                        }


                        Console.WriteLine("Item adicionados com sucesso");
                        Thread.Sleep(3000);
                        Console.Clear();
                        menu();

                        return;
                    case 2:

                        Console.WriteLine("Seus itens da lista são:\n");

                        if (!list_itens.Any())
                        {
                            Console.WriteLine("A lista esta vazia");
                        }

                        foreach (var item in list_itens)
                        {
                            Console.WriteLine($"{item}");
                        }

                        Thread.Sleep(3000);
                        Console.Clear();
                        menu();


                        return;

                    case 3:

                        Console.WriteLine("Esses são os itens cadastrados\n");

                        foreach (var item in list_itens)
                        {
                            Console.WriteLine($"{item}");
                        }

                        Console.WriteLine("Escolha um item para ser removido\n");

                        string item_removido = Console.ReadLine();

                        list_itens.Remove(item_removido);

                        Console.WriteLine("Item removido com sucesso\n");

                        Thread.Sleep(3000);
                        Console.Clear();
                        menu();

                        return;

                    case 0:

                        Console.WriteLine("Obrigado por utilizar nosso serviços");

                        break;

                    default:

                        Console.WriteLine("Opação invalida");
                        Thread.Sleep(3000);
                        Console.Clear();
                        menu();

                        break;
                }
            }






            //double salarioAtual;
            //int PercentualAumento;
            //double AumentoAplicado;
            //double NovoSalario;

            //Console.WriteLine(" Informe seu salario atual");
            //salarioAtual = double.Parse(Console.ReadLine());


            //if (salarioAtual > 0 && salarioAtual < 2800)
            //{
            //    PercentualAumento = 20;
            //    AumentoAplicado = (salarioAtual * PercentualAumento) / 100;
            //    NovoSalario = (salarioAtual + AumentoAplicado);
            //    Console.WriteLine($" Seu antigo salario era: {salarioAtual}");
            //    Console.WriteLine($" Seu aumento foi de {20}%");
            //    Console.WriteLine($" SEu aumento foi de {AumentoAplicado} Reais.");
            //    Console.WriteLine($" Seu novo salario será {NovoSalario}");


            //}
            //else if (salarioAtual >= 2801 && salarioAtual <= 7000)
            //{
            //    PercentualAumento = 15;
            //    AumentoAplicado = (salarioAtual * PercentualAumento) / 100;
            //    NovoSalario = (salarioAtual + AumentoAplicado);
            //    Console.WriteLine($" Seu antigo salario era: {salarioAtual}");
            //    Console.WriteLine($" Seu aumento foi de {10}%");
            //    Console.WriteLine($" SEu aumento foi de {AumentoAplicado} Reais.");
            //    Console.WriteLine($" Seu novo salario será {NovoSalario}");

            //}
            //else if (salarioAtual > 7001 && salarioAtual <= 15000)
            //{
            //    PercentualAumento = 10;
            //    AumentoAplicado = (salarioAtual * PercentualAumento) / 100;
            //    NovoSalario = (salarioAtual + AumentoAplicado);
            //    Console.WriteLine($" Seu antigo salario era: {salarioAtual}");
            //    Console.WriteLine($" Seu aumento foi de {5}%");
            //    Console.WriteLine($" SEu aumento foi de {AumentoAplicado} Reais.");
            //    Console.WriteLine($" Seu novo salario será {NovoSalario}");


            //}
            //else if (salarioAtual > 15001)
            //{
            //    PercentualAumento = 5;
            //    AumentoAplicado = (salarioAtual * PercentualAumento) / 100;
            //    NovoSalario = (salarioAtual + AumentoAplicado);
            //    Console.WriteLine($" Seu antigo salario era: {salarioAtual}");
            //    Console.WriteLine($" Seu aumento foi de {5}%");
            //    Console.WriteLine($" SEu aumento foi de {AumentoAplicado} Reais.");
            //    Console.WriteLine($" Seu novo salario será {NovoSalario}");


            //}
        }

    }
}