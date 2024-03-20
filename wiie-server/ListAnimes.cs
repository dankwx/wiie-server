using System;
using Npgsql;

public static class ListAnimes
{
    public static void GetAnimes(string condition = "") // theres only a "withid" condition
    {
        string query = "SELECT ";

        // Escolha das colunas a serem selecionadas com base na condição
        if (string.IsNullOrEmpty(condition))
            query += "name, genre, rating";
        else if (condition.ToLower() == "withid")
            query += "id, name, genre, rating";
        else
            throw new ArgumentException("Condition not recognized.");

        query += " FROM public.animes";

        using (var connection = new NpgsqlConnection(DatabaseConfig.ConnectionString))
        {
            connection.Open();

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("Animes:");
                    while (reader.Read())
                    {
                        if (condition.ToLower() == "withid")
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string genre = reader.GetString(2);
                            string rating = reader.IsDBNull(3) ? "Sem avaliação" : reader.GetInt16(3).ToString();
                            Console.WriteLine($"ID: {id}, Name: {name}, Genre: {genre}, Rating: {rating}");
                        }
                        else
                        {
                            string name = reader.GetString(0);
                            string genre = reader.GetString(1);
                            string rating = reader.IsDBNull(2) ? "Sem avaliação" : reader.GetInt16(2).ToString();
                            Console.WriteLine($"Name: {name}, Genre: {genre}, Rating: {rating}");
                        }
                    }
                }
            }
        }
    }
}
