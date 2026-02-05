using System;


namespace conversor_de_moedas
{
    class Program
    {
        static double valor = 0;
        static double dolar = 5;
         
        static double real = 5;
        static double libra = 6.40;

        public static void Main(string[] args)
        {
            int numero = 0;

            while (numero >0 && numero <= 5 )
            {
                
                
                    Console.WriteLine("Bem vindo ao Kzusas Conversor\n");
                    Console.WriteLine(" Escolha umas das opções abaixo\n");
                    Console.WriteLine(" 1 - converter real em dolar");
                    Console.WriteLine(" 2 - converter dolar em real");
                    Console.WriteLine(" 3 - converte real em libra esterlina");
                    Console.WriteLine(" 4 - converte libras em reias");
                    Console.WriteLine(" 5 - Para somar diferentes moedas\n");
                    Console.WriteLine(" Qual sua escolha ?");
                    numero = int.Parse(Console.ReadLine());

                    Console.Clear();


                try
                {
                    numero = int.Parse(Console.ReadLine());

                    if ( numero < 0 || numero > 5)
                    {
                        numero = 1;
                        Console.WriteLine(" Instrução invalida");
                    }
                    else
                    {


                    }


                }
                
                catch (Exception ex)
                {
                    Console.WriteLine(" Por favor digite apenas números");
                    Console.WriteLine(" Digite enter para retornar");
                }




                switch (numero)
                {
                    case 1:

                        Console.WriteLine(" Qual o valor q deseja converter ?");
                        valor = double.Parse(Console.ReadLine());

                        RealDolar();
                        break;

                    case 2:
                        Console.WriteLine(" Qual o valor q deseja converter ?");
                        valor = double.Parse(Console.ReadLine());

                        DolarReal();
                        break;
                    case 3:
                        Console.WriteLine(" Qual o valor q deseja converter ?");
                        valor = double.Parse(Console.ReadLine());

                        RealLibra();
                        break;
                    case 4:
                        Console.WriteLine(" Qual o valor q deseja converter ?");
                        valor = double.Parse(Console.ReadLine());

                        LibraReal();
                        break;
                    case 5:
                        SomarMoedas();

                        break;

                }
            }
            
               

            


            
          
        }

        public static void RealDolar()
        {
            
            int Dolar = 5;
            double conversaoDolar = valor * Dolar;
            Console.WriteLine($" O valor de {valor} reais sao {conversaoDolar} dolares");
        }

        public static void DolarReal()
        {
            
            
            double conversaoReal = valor / real;
            Console.WriteLine($" O valor de {valor} dolares são {conversaoReal} reais ");
        }

        public static  void RealLibra()
        {
            double converteLibra = valor * libra;
            Console.WriteLine($" O valor de {valor} libras são {converteLibra} reias.");
        }

        public static void LibraReal()
        {
            double converteRealEmLibra = valor / libra;
            Console.WriteLine($" O valor de {valor} reias são { converteRealEmLibra} libras.");
        }

        public static void SomarMoedas()
        {
            Console.WriteLine("Quais moedas deseja somar ?\n ");
            Console.WriteLine(" 1 - dolar + real ");
            Console.WriteLine(" 2 - dolar + libra");

                

            valor = double.Parse(Console.ReadLine());

            switch (valor)
            {
                case 1:
                    Console.Clear();

                    Console.WriteLine("digite a quantidade de dolar");
                    int nun1 =int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite a quantidade de real");
                    int num2 =int.Parse(Console.ReadLine());

                    Console.WriteLine(" A soma de real e dolar convertida em reias é: " + (nun1 * dolar + num2));
                    break;
            }

            Console.WriteLine(" didite enter para retornar ao menu pricipal");
            
        }

      
    }



}