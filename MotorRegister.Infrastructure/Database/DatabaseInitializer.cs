using Microsoft.Data.Sqlite;

namespace MotorRegister.Infrastrucutre.Database;

public class DatabaseInitializer
{
    public static SqliteConnection EnsureDatabaseCreated(string environment, string databaseFileName)
    {
        string rootPath;

        if (environment == "Development")
        {
            rootPath = Path.Combine(Directory.GetCurrentDirectory(), "../../..");
        }
        else
        {
            rootPath = Path.Combine(Directory.GetCurrentDirectory(), "../");
        }

        string databaseFilePath = Path.Combine(rootPath, databaseFileName);

        if (!Directory.Exists(rootPath))
        {
            Directory.CreateDirectory(rootPath);
        }
        
        SqliteConnection connection = new SqliteConnection($"Data Source={databaseFilePath}");
        connection.Open();

        return connection;
    }
}