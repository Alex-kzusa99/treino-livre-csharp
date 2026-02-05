using System;

namespace Calculadora
{
    public class Program
    {

        static double LerValor(string mensagem)
        {
            Console.WriteLine(mensagem);

            while (true) 
            {


                try
                {
                    double valor = double.Parse(Console.ReadLine());
                    if (valor < 0)
                    {
                        Console.WriteLine("Digite apenas numeros positivos");
                        continue;
                    }
                    if (valor > 10)
                    {
                        Console.WriteLine("Digite numeros abaixo de 10");
                        continue;
                    }
                    return valor;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Digite apenas numeros");

                }
            }
        }

        static void Main(string[] args)
        {

            double media = 0;

            try
            {

               
                double n1 = LerValor("Digite a primeira nota");
               
                double n2 = LerValor("Digite a segunda nota");
              
                double n3 = LerValor("Digite a terceira nota");
                
                double n4 = LerValor("Digite a quarta nota");

                media = (n1 + n2 + n3 + n4) / 4;
                Console.WriteLine($"Sua nota foi: {media}");

            } catch (Exception ex)
            {
                Console.WriteLine("\nPor favor digite apenas numeros");
            }




            // if (media >= 7)
            //  {
            //       Console.WriteLine(" Parabens vc foi aprovado");
            //
            //  }
            //   else
            //   {
            //      if (media < 4)
            //      {
            //         if (media == 0)
            //  {
            //      Console.WriteLine("Voce tirou zero");
            //  }else
          //  {
          //      Console.WriteLine(" Voce foi reprovado");
          //  }

            //     }
            //     else
            //     {
            //        Console.WriteLine("Vc esta de recuperação");
            //    }
            //  }
            if (media ==0)
            {
                Console.WriteLine("Voce tirou zero");
                return;
            }
            if (media < 4)
            {
                Console.WriteLine("Voce foi reprovado");
                return;
            }
            if(media < 7)
            {
                Console.WriteLine(" Voce esta de recuperaçaõ ");
                return;
            }

            Console.WriteLine("Parabens, voce foi aprovado");


        } 
    }
}