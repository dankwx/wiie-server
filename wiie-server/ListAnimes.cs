using System;
using Npgsql;

public static class ListAnimes
{
    public static void GetAnimes()
    {
        using (var connection = new NpgsqlConnection(DatabaseConfig.ConnectionString))
        {
            connection.Open();

            using (var cmd = new NpgsqlCommand("SELECT name, genre, rating FROM public.animes", connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("Animes:");
                    while (reader.Read())
                    {
                        string rating = reader.IsDBNull(2) ? "Sem avaliação" : reader.GetInt16(2).ToString();
                        Console.WriteLine($"Name: {reader.GetString(0)}, Genre: {reader.GetString(1)}, Rating: {rating}");
                    }
                }
            }
        }
    }
}
