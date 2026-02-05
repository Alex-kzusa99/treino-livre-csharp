using System;

namespace dia_da_semana
{

    class Program
    {

        static void main(string[] args)
        {
            Console.WriteLine(" Digite um numero de 1 a 7 :");
            int numero = int.Parse(Console.ReadLine());


            switch (numero)
            {
                case 1:
                    Console.WriteLine(" esse numero corresponde a domingo");
                    break;
                case 2:
                    Console.WriteLine(" esse numero corresponde a segunda");
                    break;
                case 3:
                    Console.WriteLine(" esse numero corresponde a terça");
                    break;
            }

        }

    }

}