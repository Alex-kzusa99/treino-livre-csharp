int controlador = 1;

while (controlador > 0 && controlador <= 5)
{
    Console.WriteLine("\nAbaixo segue o menu de instruções do sistema\n");
    Console.WriteLine("\t1 - Opção 01");
    Console.WriteLine("\t2 - Opção 02");
    Console.WriteLine("\t3 - Opção 03");
    Console.WriteLine("\t4 - Opção 04");
    Console.WriteLine("\t5 - Opção 05");
    Console.WriteLine("\t0 - SAIR");

    try
    {
        controlador = Convert.ToInt32(Console.ReadLine());

        if (controlador < 0 || controlador > 5)
        {
            controlador = 1;
            throw new Exception("Instrução Inválida.");
        }
        else //Dentro desta ESTRUTURA ELSE, está a DITA execução do meu PROGRAMA
        {
            switch (controlador)
            {
                case 1:
                    Console.WriteLine("\n\tExecução da opção 01\n");
                    Console.WriteLine("\tDigite uma nota:");
                    string sNota = Console.ReadLine();
                    double dNota = Convert.ToDouble(sNota.Replace(",", "."));
                    Console.WriteLine("\tA nota digitada foi: " + dNota);
                    break;
                case 2:
                    Console.WriteLine("\n\tExecução da opção 02\n");
                    break;
                case 3:
                    Console.WriteLine("\n\tExecução da opção 03\n");
                    break;
                case 4:
                    Console.WriteLine("\n\tExecução da opção 04\n");
                    break;
                case 5:
                    Console.WriteLine("\n\tExecução da opção 05\n");
                    break;
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erro: " + ex.Message + " -- [Digite novamente]");
    }
}