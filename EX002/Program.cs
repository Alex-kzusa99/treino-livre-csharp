using System;

namespace cadastro_produto
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> preco = new List<double>();
            List<string> produto = new List<string>();

            double preco_produto = 0;
            string nome_produto = string.Empty;



            Console.WriteLine("Bem vindo ao cadastro de produtos\n");
            Console.WriteLine("MENU\n");
            menu_pricipal();


            void menu_pricipal()
            {
                Console.WriteLine("1 - Cadastrar produto");
                Console.WriteLine("2 - Listar produto");
                Console.WriteLine("3 - Calcular total em estoque");
                Console.WriteLine("4 - Sair\n");

                Console.WriteLine("Escolha uma opção:");

                int numero;

                string opcao_escolhida = Console.ReadLine();

                if (!int.TryParse(opcao_escolhida, out numero))
                {
                    Console.WriteLine("Entrada inválida! Digite apenas números.");
                    Thread.Sleep(3000);

                    Console.Clear();
                    menu_pricipal();
                    return;
                }

               int opcoes = int.Parse(opcao_escolhida);

                switch (opcoes)
                {
                    case 1:
                        Console.WriteLine("Digite o nome do produto:");
                        nome_produto = Console.ReadLine();
                        produto.Add(nome_produto);

                        Console.WriteLine("Digite o preço do produto:");
                        preco_produto = double.Parse(Console.ReadLine());
                        preco.Add(preco_produto);

                        Console.WriteLine("Produto cadastrado com suceso");
                        Thread.Sleep(3000);

                        Console.Clear();
                        menu_pricipal();

                        return;

                    case 2:

                        Console.WriteLine("Produtos cadastrados :\n");

                        var combinados = produto.Zip(preco, (produto, preco) => $" Produto {produto} - {preco} reias");

                        foreach (var item_produto in combinados)
                        {
                            Console.WriteLine(item_produto);
                        }

                        Thread.Sleep(3000);
                        Console.Clear();
                        menu_pricipal();

                        return;

                    case 3:

                        Console.WriteLine("Valor total dos itens em estoque");

                        double soma = preco.Sum();
                        Console.WriteLine($"A soma dos valores de {soma} reias");

                        Thread.Sleep(3000);
                        Console.Clear();
                        menu_pricipal();

                        return;

                    case 4:

                        Console.WriteLine("Obrigado por utilizar nossos serviços");
                        break;

                    default:

                        Console.WriteLine("Opção inválida");

                        break;
                }
            }

        }
    }
}

