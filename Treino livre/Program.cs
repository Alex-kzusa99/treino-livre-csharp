using System;

namespace template001
{
    class MainClass
    {
        static Calculator calculator = new Calculator();

        public static void Main(string[] args)
        {
            

            while (true)
            {

                int numeros = 0;

                try
                {
                    Console.WriteLine($"Seu dinheiro atual é: ${calculator.Valor:f2}");
                    Console.WriteLine("");
                    Console.WriteLine("1 - Soma");
                    Console.WriteLine("2 - Subtração");
                    Console.WriteLine("3 - Dividir");
                    Console.WriteLine("4 - Multiplicar");
                    Console.WriteLine("5 - Para exibir historico");
                    Console.WriteLine("6 - Para sair");
                    Console.WriteLine("");
                    Console.WriteLine("Qual sua escolha?");

                    numeros = int.Parse(Console.ReadLine());

                    Console.Clear();


                }
                catch (Exception erro)
                {
                    Console.WriteLine("Por favor digite apenas numeros :)");
                    Console.WriteLine(" Digite enter para retonar!");


                }
                int resultado = 0;
                resultado = numeros;



                Console.Clear();



                switch (numeros)
                {
                    case 1:
                        CallSum();
                        break;

                    case 2:
                        CallSubtract();
                        break;
                    case 3:
                        CalculoDivisao();
                        break;
                    case 4:
                        CalculoMultiplicacao();
                        break;
                    case 5:
                        Historico();
                        break;
                    case 6: return;
                   

                }

                Console.Clear();
            }
        }

        private static void CallSum()
        {
            Console.WriteLine("Quanto voce deseja adicionar?");
            Console.WriteLine("");

            double userInput = Convert.ToDouble(Console.ReadLine());

            calculator.Somar(userInput);
        }

        private static void CallSubtract()
        {
            Console.WriteLine("Quanto deseja subtrair?");
            Console.WriteLine("");

            double userInput = Convert.ToDouble(Console.ReadLine());

            calculator.Subtrair(userInput);
        }
        private static void CalculoDivisao()
        {
            Console.WriteLine("Por Quanto vc dseja dividir?");
            Console.WriteLine("");

            double userInput = Convert.ToDouble(Console.ReadLine());

            calculator.Dividir(userInput);
        }
        private static void CalculoMultiplicacao()
        {
            Console.WriteLine("Por quanto deseja multiplicar?");
            Console.WriteLine("");

            double userInput = Convert.ToDouble(Console.ReadLine());

            calculator.Multiplicar(userInput);

        }
        public static void Historico()
        {
            List<int> historico = new List<int>();
            calculator.MostrarHistorico();
            Console.ReadKey();
        }
    }
        
    class Calculator
    {
        public double Valor = 0.0f;
        public List <string> historico = new List<string>();

        public void MostrarHistorico()
        {
            Console.WriteLine("MOSTRADO HISTORICO");
            foreach (string elemento in historico)
            {
                Console.WriteLine(elemento);
            }
        }

        public void Somar(double value)
        {
            historico.Add($"Adicionou valor {value}");
            this.Valor += value;
        }

        public void Subtrair(double value)
        {
            historico.Add($" Voce subtraiu o  valor {value}");
            this.Valor -= value; 
        }

        public void Dividir(double value)
        {
            historico.Add($" Voce dividiu pelo  valor {value}");
            this.Valor /= value;
        }

        public void Multiplicar(double value)
        {
            historico.Add($" Voce multiplicou pelo  valor {value}");
            this.Valor *= value;
        }
    }

   
         
    
}
