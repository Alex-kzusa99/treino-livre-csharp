using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Gerenciador_Tarefas
{
    class Program
    {
        public string titulo { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Prioridade { get; set; }
        public bool Concluida { get; set; } = false;
        public DateTime DataCriacao { get; set; } = DateTime.Now;


        static void Main(string[] args)
        {

            List<string> tarefas = new List<string>();

            Console.WriteLine("=== Gerenciador de Tarefas ===\n");

            Console.WriteLine("1) Adicionar tarefa");
            Console.WriteLine("2) Listar tarefas");
            Console.WriteLine("3) Marcar tarefa como concluída");
            Console.WriteLine("4) Remover tarefa");
            Console.WriteLine("5) Buscar tarefas");
            Console.WriteLine("6) Salvar tarefas");
            Console.WriteLine("7) Carregar tarefas");
            Console.WriteLine("0) Sair\n");
            Console.Write("Escolha: ");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1: Adicionar_tarefa(); break;

            }

           


        }
        static void Adicionar_tarefa()
        {

        }

    }

}