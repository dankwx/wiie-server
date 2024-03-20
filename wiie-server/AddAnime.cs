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

        Console.WriteLine("Insira a nota para o anime:");
        int notaAnime = int.Parse(Console.ReadLine());

        InsertAnime(nomeAnime, generoAnime, notaAnime);
    }

    public static void InsertAnime(string name, string genre, int rating)
    {
        using (var connection = new NpgsqlConnection(DatabaseConfig.ConnectionString))
        {
            connection.Open();

            using (var cmd = new NpgsqlCommand("INSERT INTO public.animes (name, genre, rating) VALUES (@name, @genre, @rating)", connection))
            {
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("genre", genre);
                cmd.Parameters.AddWithValue("rating", rating);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Anime inserido com sucesso!");
            }
        }
    }
}
