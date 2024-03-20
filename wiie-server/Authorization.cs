using Npgsql;
using System;

public class Autenticacao
{
    public static bool FazerLogin()
    {
        Console.WriteLine("Digite seu e-mail:");
        string email = Console.ReadLine();

        Console.WriteLine("Digite sua senha:");
        string senha = Console.ReadLine();

        return AutenticarUsuario(email, senha);
    }

    private static bool AutenticarUsuario(string email, string senha)
    {
        string queryString = "SELECT COUNT(*) FROM Usuarios WHERE Email = @Email AND Senha = @Senha";
        int result = 0;

        using (NpgsqlConnection connection = new NpgsqlConnection(DatabaseConfig.ConnectionString))
        {
            connection.Open();

            using (NpgsqlCommand command = new NpgsqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Senha", senha);

                result = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        return result > 0;
    }
}
