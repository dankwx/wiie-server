using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite seu e-mail:");
        string email = Console.ReadLine();

        Console.WriteLine("Digite sua senha:");
        string senha = Console.ReadLine();

        if (!Autenticacao.FazerLogin());
        {
            Console.WriteLine("Usuário autenticado com sucesso!");
            MenuOptions.MenuList(); // Executar o menu apenas se o usuário estiver autenticado
        }
        else
        {
            Console.WriteLine("Email ou senha incorretos. Tente novamente.");
        }
    }
}
