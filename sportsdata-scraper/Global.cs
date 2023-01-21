using System.Runtime.CompilerServices;
using MongoDB.Driver;
namespace sportsdata_scraper;

static class Global
{
	public static MongoClient? Client { get; private set; }
	public static void Initialize()
	{
        var root = AppContext.BaseDirectory;
        LoadDotEnv(Path.Combine(root, ".env"));

		var settings = MongoClientSettings.FromConnectionString(Environment.GetEnvironmentVariable("MONGODB_URI"));

		Client = new MongoClient(settings);
	}

    private static void LoadDotEnv(string filePath)
    {
        if (!File.Exists(filePath))
            return;

        foreach (var line in File.ReadAllLines(filePath))
        {
            var variable = line.Split('=', StringSplitOptions.RemoveEmptyEntries);

            if (variable.Length != 2)
                continue;

            Console.WriteLine("Adding " + line);
            Environment.SetEnvironmentVariable(variable[0], variable[1], EnvironmentVariableTarget.Process);
        }
    }

    public static IMongoDatabase? MongoDatabase => Client?.GetDatabase("scores");

	public static string FormatDate(DateTime date)
	{
		return date.ToString("yyyy-MMM-dd").ToUpper();
	}
}