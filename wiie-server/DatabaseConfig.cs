using System;

public static class DatabaseConfig
{
    public static string ConnectionString
    {
        get
        {
            return "Host=localhost;Username=postgres;Password=root;Database=animeco";
        }
    }
}