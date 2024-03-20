using System;
using Npgsql;

public static class RemoveAnime
{
    public static void DeleteAnimeById()
    {
        ListAnimes.GetAnimes("withid");
        Console.WriteLine("Insira o ID do anime que deseja excluir:");
        int idAnime;
        while (!int.TryParse(Console.ReadLine(), out idAnime))
        {
            Console.WriteLine("Por favor, insira um ID válido.");
        }

        DeleteAnime(idAnime);
    }

    public static void DeleteAnime(int id)
    {
        using (var connection = new NpgsqlConnection(DatabaseConfig.ConnectionString))
        {
            connection.Open();

            using (var cmd = new NpgsqlCommand("DELETE FROM public.animes WHERE id = @id", connection))
            {
                cmd.Parameters.AddWithValue("id", id);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Anime excluído com sucesso!");
                }
                else
                {
                    Console.WriteLine("Nenhum anime encontrado com o ID fornecido.");
                }
            }
        }
    }
}
