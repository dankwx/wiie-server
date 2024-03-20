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
        Console.WriteLine("***********************");
        Console.WriteLine("Bem-vindo ao Animeko!");
        Console.WriteLine("***********************");
        Console.WriteLine("\nQue opção deseja?\n 1. Listar Animes.\n 2. Adicionar.\n 3. Excluir um anime.\n 4. Sair.");

        try
        {
            string escolha = Console.ReadLine()!;
            int escolhaNumber = int.Parse(escolha);

            switch (escolhaNumber)
            {
                case 1:
                    Console.Clear();
                    ListAnimes.GetAnimes();
                    ResetMenu();
                    break;

                case 2:
                    Console.Clear();
                    AddAnime.InsertAnimeFromInput();
                    ResetMenu();
                    break;
                case 3:
                    Console.Clear();
                    RemoveAnime.DeleteAnimeById();
                    ResetMenu();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Tchau tchau! :)");
                    break;

                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    ResetMenu();
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