using System;
using System.Data.SqlClient;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Caixa_Supermercado
{
    class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public double Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string UnidadeMedida { get; set; }
        public string Colaborador { get; set; }
        public DateTime DataValidade { get; set; }
    }

    class Usuarios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }
    }

    class Program
    {
        private static string conexao;
        private static string Perfil_funcionario;
        private static string colaborador;

        static void Main(string[] args)
        {
            List<Produto> produtos = new List<Produto>();
            List<Usuarios> usuarios = new List<Usuarios>();
            List<Produto> produtos_comprados = new List<Produto>();

            W_p1_carrega();
            Login();
            menu();


            void menu()
            {
                int opcao_digitada = 0;
                Perfil_funcionario = "GERENTE";

                W_p1_carrega();

                Console.WriteLine("**** Caixa Supermercado ****\n");
                Console.WriteLine("Escolha uma das opções abaixo\n");

                Console.WriteLine("1 - Cadastrar Produto");
                Console.WriteLine("2 - Realizar Compra do Cliente");
                Console.WriteLine("3 - Listar produtos cadastrados");
                Console.WriteLine("4 - Excluir produto");
                Console.WriteLine("5 - Editar Produto");
                Console.WriteLine("6 - Buscar por Produto");

                if (!int.TryParse(Console.ReadLine(), out opcao_digitada))
                {
                    Console.WriteLine("Por favor digite apenas números");
                    Thread.Sleep(3000);
                    Console.Clear();
                    menu();
                }

                switch (opcao_digitada)
                {
                    case 1:

                        if (Perfil_funcionario == "GERENTE" || Perfil_funcionario == "CAIXA")
                        {
                            while (true)
                            {
                                Console.WriteLine("Digite o nome do  produto ou digite (fim) para encerrar o cadastro: ");
                                string nome = Console.ReadLine();

                                if (nome.ToLower() == "fim")
                                {
                                    Console.Clear();
                                    menu();
                                    break;
                                }

                                Console.WriteLine("Digite a categoria do produto");
                                string categoria = Console.ReadLine();

                                Console.WriteLine("Digite a marca do produto");
                                string marca = Console.ReadLine();


                                bool controle_data = true;
                                double preco = 0;
                                DateTime data_validade = DateTime.Now;

                                while (true)
                                {
                                    Console.WriteLine("Digite o preço do  produto");
                                    preco = double.Parse(Console.ReadLine());

                                    if (preco < 0)
                                    {
                                        Console.WriteLine("Preço negativo não permitido\n");
                                    }
                                    else
                                        break;
                                }

                                Console.WriteLine("Digite a quantidade no estoque do produto");
                                string quant_estoq = Console.ReadLine();

                                Console.WriteLine("Digite a unidade de medida do produto");
                                string unidade_medida = Console.ReadLine();


                                DateTime data_atual = DateTime.Now;

                                while (true)
                                {
                                    Console.WriteLine("Digite a data de validade");
                                    data_validade = DateTime.Parse(Console.ReadLine());

                                    if (data_validade < data_atual)
                                    {
                                        Console.WriteLine("Data passada não permitida\n");
                                    }
                                    else
                                        break;
                                }

                                using (var conn = new SqlConnection(conexao))
                                {
                                    conn.Open();

                                    string sql = "INSERT INTO [dbo].[ProdutosSupermercado] (Nome,categoria, Preco, marca, QuantidadeEstoque, UnidadeMedida, DataValidade, Colaborador) VALUES (@a, @b, @c, @d, @e, @f, @g, @h)";

                                    using (var cmd = new SqlCommand(sql, conn))
                                    {
                                        cmd.Parameters.AddWithValue("@a", nome);
                                        cmd.Parameters.AddWithValue("@b", categoria);
                                        cmd.Parameters.AddWithValue("@c", preco);
                                        cmd.Parameters.AddWithValue("@d", marca);
                                        cmd.Parameters.AddWithValue("@e", quant_estoq);
                                        cmd.Parameters.AddWithValue("@f", unidade_medida);
                                        cmd.Parameters.AddWithValue("@g", data_validade);
                                        cmd.Parameters.AddWithValue("@h", colaborador);

                                        int linhasAfetadas = cmd.ExecuteNonQuery();

                                        if (linhasAfetadas > 0)
                                            Console.WriteLine("Produto inserido com sucesso!");
                                        else
                                            Console.WriteLine("Nenhum registro inserido.");
                                    }
                                }

                                produtos.Add(new Produto { Nome = nome, Preco = preco });

                                Thread.Sleep(2000);
                                Console.Clear();
                                Console.WriteLine("Cadastro de Produtos\n");
                            }
                        }
                        break;


                    case 2:

                        if (Perfil_funcionario == "GERENTE" || Perfil_funcionario == "CAIXA")
                        {
                            bool continuar = false;
                            double total = 0;
                            int produto_digitado;
                            do
                            {
                                while (true)
                                {
                                    Console.WriteLine("Digite o ID do produto");
                                    if (!int.TryParse(Console.ReadLine(), out produto_digitado))
                                    {
                                        Console.WriteLine("Por favor digite apenas números\n");
                                        continue;
                                    }
                                    else
                                        break;
                                }

                                foreach (var item_produto in produtos)
                                {
                                    if (produto_digitado == item_produto.Id)
                                    {
                                        if (item_produto.QuantidadeEstoque > 0)
                                        {
                                            if (item_produto.QuantidadeEstoque < 5)
                                            {
                                                Console.WriteLine($"ATENCÃO o produto {item_produto.Nome} está com {item_produto.QuantidadeEstoque} unidades em estoque");
                                            }

                                            int nova_quantidade = item_produto.QuantidadeEstoque - 1;

                                            using (var conn = new SqlConnection(conexao))
                                            {
                                                conn.Open();

                                                string sql = $"UPDATE [dbo].[ProdutosSupermercado] set QuantidadeEstoque = @nova_quantidade WHERE Id = @id";

                                                using (var cmd = new SqlCommand(sql, conn))
                                                {
                                                    cmd.Parameters.AddWithValue("@id", produto_digitado);
                                                    cmd.Parameters.AddWithValue("@nova_quantidade", nova_quantidade);

                                                    int linhasAfetadas = cmd.ExecuteNonQuery();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Produto não disponivel em estoque");
                                            return;
                                        }


                                        produtos_comprados.Add(new Produto { Id = item_produto.Id, Nome = item_produto.Nome, Preco = item_produto.Preco });

                                        total += item_produto.Preco;
                                        Console.WriteLine($"Produto {item_produto.Nome}");
                                        Console.WriteLine($"Preço {item_produto.Preco}");
                                        Console.WriteLine($"Item adicionado!\n");

                                        Console.WriteLine("Deseja adicionar um novo item (S/N)");
                                        string continuar_compra = Console.ReadLine();

                                        if (continuar_compra.ToUpper() == "S")
                                            continuar = true;
                                        else
                                        {
                                            continuar = false;
                                            break;
                                        }
                                    }

                                    if (produto_digitado > produtos.Count())
                                    {
                                        int total_lista = produtos.Count();
                                        Console.WriteLine("Esse ID nao existe...\n");
                                        Console.WriteLine($"Digite um ID igual ou menor que {total_lista}\n");

                                        while (true)
                                        {
                                            Console.WriteLine("Digite o ID do produto");
                                            if (!int.TryParse(Console.ReadLine(), out produto_digitado))
                                            {
                                                Console.WriteLine("Por favor digite apenas números\n");
                                                continue;
                                            }
                                            else
                                                break;
                                        }

                                        while (true)
                                        {
                                            if (produto_digitado > produtos.Count())
                                            {
                                                Console.WriteLine("Esse ID nao existe...");
                                                continue;
                                            }
                                            else
                                                break;
                                        }
                                    }
                                }

                            } while (continuar == true);
                            {
                                Console.Clear();

                                Console.WriteLine("---CUPOM FISCAL---\n");

                                foreach (var itens_comprados in produtos_comprados)
                                {
                                    Console.WriteLine($"Produto {itens_comprados.Nome} - Preço {itens_comprados.Preco}");
                                }

                                Console.WriteLine("------------------------------\n");
                                Console.WriteLine($"TOTAL: R$ {total:F2}\n");

                                Console.WriteLine("Informe o valor recebido em dinheiro");
                                double valor_recebido = double.Parse(Console.ReadLine());

                                double troco = valor_recebido - total;
                                Console.WriteLine($"Valor do troco para o cliente: {troco:F2} Reais.");

                                Console.WriteLine("------------------------------\n");
                                Console.WriteLine("Obrigado por comprar em nosso estabelecimento");
                            }
                        }
                        break;


                    case 3:

                        if (Perfil_funcionario == "GERENTE" || Perfil_funcionario == "CAIXA")
                        {
                            Console.WriteLine("Esses são os produtos cadastrados\n");

                            foreach (var item in produtos)
                            {
                                Console.WriteLine($" ID {item.Id} - Produto {item.Nome} - Preço {item.Preco} - Quantidade em Estoque = {item.QuantidadeEstoque}");
                            }

                            string retornar = string.Empty;

                            while (true)
                            {
                                Console.WriteLine("Digite 'sair' para voltar ao menu principal:");
                                string entrada = Console.ReadLine();

                                if (entrada.ToLower() == "sair")
                                {
                                    Console.WriteLine("Retornando ao menu principal...\n");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                    menu();
                                    break;
                                }

                                if (double.TryParse(entrada, out _))
                                {
                                    Console.WriteLine("Números não são permitidos. Tente novamente.\n");
                                    continue;
                                }
                                Console.WriteLine("Entrada inválida. Digite apenas 'sair' para voltar.\n");
                            }
                        }
                        return;


                    case 4:

                        if (Perfil_funcionario == "GERENTE")
                        {
                            int produto_excluir = 0;
                            bool exclusao = false;

                            Console.WriteLine("Digite o núemro do ID do produto que deseja excluir");

                            if (!int.TryParse(Console.ReadLine(), out produto_excluir))
                            {
                                Console.WriteLine("Por favor digite apenas números.");
                                return;
                            }

                            if (!produtos.Any())
                            {
                                Console.WriteLine("Não a produtos para serem excluidos");
                                return;
                            }

                            if (produtos.Any())
                            {
                                foreach (var item in produtos)
                                {
                                    if (item.Id == produto_excluir)
                                    {
                                        produtos.Remove(item);
                                        Console.WriteLine($"Confirma a exculsão do produto {item.Nome} (S/N)");
                                        string confirmacao = Console.ReadLine();

                                        if (confirmacao.ToUpper() == "S")
                                            exclusao = true;
                                        else
                                        {
                                            exclusao = true;
                                            return;
                                        }

                                        if (exclusao)
                                        {
                                            using (var conn = new SqlConnection(conexao))
                                            {
                                                conn.Open();

                                                string sql = "DELETE FROM [dbo].[ProdutosSupermercado] WHERE Id = @id";

                                                using (var cmd = new SqlCommand(sql, conn))
                                                {
                                                    cmd.Parameters.AddWithValue("@id", produto_excluir);

                                                    int linhasAfetadas = cmd.ExecuteNonQuery();

                                                    if (linhasAfetadas > 0)
                                                        Console.WriteLine("Produto excluído com sucesso!");
                                                    else
                                                        Console.WriteLine("Nenhum produto encontrado com esse ID.");

                                                    Thread.Sleep(3000);
                                                    Console.Clear();
                                                    menu();
                                                }
                                            }
                                            return;
                                        }
                                    }
                                }

                            }else
                            {
                                Console.WriteLine("Nenhum produto encontrado..");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Perfil não autoriado para essa função");
                            Thread.Sleep(3000);
                            Console.Clear();
                            menu();
                            return;
                        }
                        break;


                    case 5:

                        if (Perfil_funcionario == "GERENTE")
                        {
                            int editar_produto;

                            Console.WriteLine("Digite o ID do produto que deseja editar");

                            if (!int.TryParse(Console.ReadLine(), out editar_produto))
                            {
                                Console.WriteLine("Por favor digite apenas números");
                            }

                            var item = produtos.FirstOrDefault(x => x.Id == editar_produto);

                            if (item == null)
                            {
                                Console.WriteLine("ID não encontrado");
                                return;
                            }

                            Console.WriteLine($"Descrição completa do produto\n");
                            Console.WriteLine($"1 ID - {item.Id}");
                            Console.WriteLine($"2 Nome - {item.Nome}");
                            Console.WriteLine($"3 Marca - {item.Marca}");
                            Console.WriteLine($"4 Categoria - {item.Categoria}");

                            Console.WriteLine($"5 Quantidade Estoque - {item.QuantidadeEstoque}");
                            Console.WriteLine($"6 Data validade - {item.DataValidade}\n");
                            // Console.WriteLine($"7 Colaborador - {colaborador}\n");

                            Console.WriteLine("Digite o número correspondente a informação que deseja editar");
                            int opcao_informada = int.Parse(Console.ReadLine());

                            switch (opcao_informada)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("Não e possovel atualizar o ID");
                                        return;
                                    }

                                case 2:
                                    {
                                        AtualizarCampo("nome", "Informe o novo nome", editar_produto, conexao);
                                        break;
                                    }

                                case 3:
                                    {
                                        AtualizarCampo("marca", "Informe a nova marca", editar_produto, conexao);
                                        break;
                                    }
                                case 4:
                                    {
                                        AtualizarCampo("categoria", "Informe a nova categoria", editar_produto, conexao);
                                        break;
                                    }
                                case 5:
                                    {
                                        AtualizarCampo("QuantidadeEstoque", "Informe a nova quantidade em estoque", editar_produto, conexao);
                                        break;
                                    }
                                case 6:
                                    {
                                        AtualizarCampo("DataValidade", "Informe a nova data de validade", editar_produto, conexao);
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Perfil não autoriado para essa função");
                            Thread.Sleep(3000);
                            Console.Clear();
                            menu();
                            return;
                        }
                        break;

                    case 6:
                        {
                            Console.Write("Buscar por produto: ");
                            string nome_produto = Console.ReadLine().Trim();

                            var produtos_filtrados = produtos.Where(x => x.Nome.ToLower().Contains(nome_produto.ToLower())).ToList();

                            foreach (var item in produtos_filtrados)
                            {
                                Console.WriteLine($"Produto = {item.Nome}, Categoria = {item.Categoria}\n");
                            }

                            while (true)
                            {
                                Console.WriteLine("Digite 'sair' para voltar ao menu principal:\n");
                                string entrada = Console.ReadLine();

                                if (entrada.ToLower() == "sair")
                                {
                                    Console.WriteLine("Retornando ao menu principal...\n");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                    menu();
                                    break;
                                }

                                if (double.TryParse(entrada, out _))
                                {
                                    Console.WriteLine("Números não são permitidos. Tente novamente.\n");
                                    continue;
                                }
                                Console.WriteLine("Entrada inválida. Digite apenas 'sair' para voltar.\n");
                            }
                            break;
                        }


                    default:
                        {

                            Console.WriteLine("Opção inválida");
                            Thread.Sleep(3000);
                            Console.Clear();
                            menu();
                            return;
                        }
                }
            }

            void AtualizarCampo(string coluna, string mensagem, int id, string conexao)
            {
                Console.WriteLine("=== Atualizar Produto ===\n");

                Console.WriteLine(mensagem);
                string novo_nome = Console.ReadLine();


                string sql = $"UPDATE [dbo].[ProdutosSupermercado] SET {coluna} = @nome, colaborador = @colaborador WHERE Id = @id";

                using (SqlConnection conn = new SqlConnection(conexao))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", novo_nome);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@colaborador", colaborador);

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                            Console.WriteLine("Produto atualizado com sucesso!");
                        else
                            Console.WriteLine("Nenhum produto encontrado com esse ID.");
                    }
                }
                Console.WriteLine("Retornando ao menu principal.....");
                Thread.Sleep(3000);
                Console.Clear();
                menu();
                return;
            }

            void W_p1_carrega()
            {
                conexao = @"Server=KZUSA99;Database=master;Trusted_Connection=True;";

                produtos.Clear();
                using (SqlConnection conn = new SqlConnection(conexao))
                {
                    conn.Open();

                    string sql = "SELECT * FROM [dbo].[ProdutosSupermercado]";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    var leitor = cmd.ExecuteReader();

                    while (leitor.Read())
                    {
                        Produto p = new Produto
                        {
                            Id = (int)leitor["Id"],
                            Nome = leitor["Nome"].ToString(),
                            Categoria = leitor["Categoria"].ToString(),
                            Marca = leitor["Marca"].ToString(),
                            Preco = Convert.ToDouble(leitor["Preco"]),
                            QuantidadeEstoque = Convert.ToInt16(leitor["QuantidadeEstoque"]),
                            UnidadeMedida = leitor["UnidadeMedida"].ToString(),
                            Colaborador = leitor["Colaborador"] == DBNull.Value ? null : leitor["Colaborador"].ToString(),
                            // DataValidade = Convert.ToDateTime( leitor["UnidadeMedida"]),
                        };

                        produtos.Add(p);
                    }
                }
            }

            void Login()
            {
                usuarios.Clear();
                string login_funcionario = string.Empty;
                string senha_funcionario = string.Empty;

                Console.WriteLine("=== LOGIN DO SISTEMA ===\n");

                while (true)
                {
                    Console.WriteLine("Digite seu login");
                    login_funcionario = Console.ReadLine();

                    Console.WriteLine("Digite sua senha");
                    senha_funcionario = Console.ReadLine();

                    using (var conn = new SqlConnection(conexao))
                    {
                        conn.Open();

                        string sql = "SELECT * from [dbo].[Usuarios]";

                        using (var cmd = new SqlCommand(sql, conn))
                        {
                            var leitor = cmd.ExecuteReader();

                            while (leitor.Read())
                            {
                                Usuarios usu = new Usuarios
                                {
                                    Id = (int)leitor["Id"],
                                    Nome = leitor["Nome"].ToString(),
                                    Login = leitor["Login"].ToString(),
                                    Senha = leitor["Senha"].ToString(),
                                    Perfil = leitor["Perfil"].ToString(),
                                };

                                usuarios.Add(usu);
                            }
                        }
                    }

                    bool usuario_valido = false;

                    foreach (var item in usuarios)
                    {
                        if (login_funcionario == item.Login && senha_funcionario == item.Senha)
                        {
                            Perfil_funcionario = item.Perfil;
                            colaborador = item.Nome;
                            usuario_valido = true;
                            break;
                        }
                    }

                    if (usuario_valido)
                    {
                        Console.WriteLine("Login realizado com sucesso!\n");
                        Thread.Sleep(3000);
                        Console.Clear();
                        break;
                    }
                    else
                        Console.WriteLine("Usuário ou senha inválidos. Tente novamente!\n");
                }
            }
        }
    }
}