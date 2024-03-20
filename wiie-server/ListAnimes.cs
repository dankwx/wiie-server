using System;
using Npgsql;

public static class ListAnimes
{
    public static void GetAnimes()
    {
        using (var connection = new NpgsqlConnection(DatabaseConfig.ConnectionString))
        {
            connection.Open();

            using (var cmd = new NpgsqlCommand("SELECT name, genre FROM public.animes", connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("Animes:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Name: {reader.GetString(0)}, Genre: {reader.GetString(1)}");
                    }
                }
            }
        }
    }
}
