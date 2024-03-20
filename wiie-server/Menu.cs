using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class MenuOptions
{
    public static void ResetMenu()
    {
        Console.WriteLine("Pressione uma tecla para continuar.");
        Console.ReadKey();
        Console.Clear();
        MenuList();
    }
    public static void MenuList()
    {
        Console.WriteLine("Que opção deseja? 1. Listar Animes. 2. Adicionar. 3. Sair.");

        try
        {
            string escolha = Console.ReadLine()!;
            int escolhaNumber = int.Parse(escolha);

            switch (escolhaNumber)
            {
                case 1:
                    ListAnimes.GetAnimes();
                    ResetMenu();
                    break;

                case 2:
                    AddAnime.InsertAnimeFromInput();
                    ResetMenu();
                    break;
                case 3:
                    Console.WriteLine("Tchau tchau :)");
                    break;

                default:
                    Console.WriteLine("Opção incorreta.");
                    break;
            }
        }catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Verifique se você está inserindo um número.");
            Thread.Sleep(1000);
            ResetMenu();
        }

    }
}