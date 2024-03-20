using System;
using Npgsql;

public static class AddAnime
{
    public static void InsertAnimeFromInput()
    {
        Console.WriteLine("Insira o nome do anime:");
        string nomeAnime = Console.ReadLine()!;

        Console.WriteLine("Insira o gênero do anime:");
        string generoAnime = Console.ReadLine()!;

        InsertAnime(nomeAnime, generoAnime);
    }

    public static void InsertAnime(string name, string genre)
    {
        using (var connection = new NpgsqlConnection(DatabaseConfig.ConnectionString))
        {
            connection.Open();

            using (var cmd = new NpgsqlCommand("INSERT INTO public.animes (name, genre) VALUES (@name, @genre)", connection))
            {
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("genre", genre);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Anime inserido com sucesso!");
            }
        }
    }
}
