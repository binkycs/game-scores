using FantasyData.Api.Client.Model.NFLv3;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace sportsdata_scraper.NFL;

public static class DatabaseManager
{
	private const string League = "nfl";

	public static void InsertBoxScores(IEnumerable<BoxScoreWithLogos> games)
	{
		var collection = MongoDatabase?.GetCollection<BoxScoreWithLogos>($"{League}.scores");
		if (collection == null)
			throw new Exception("Database error");

		// TODO: Use an update model instead
		var replace = games.Select(game => new
		{
			value = game,
			filter = Builders<BoxScoreWithLogos>.Filter.Eq(x => x.Score!.GlobalGameID, game.Score!.GlobalGameID)
		}).Select(y => new ReplaceOneModel<BoxScoreWithLogos>(y.filter, y.value) { IsUpsert = true });

		collection.BulkWriteAsync(replace, new BulkWriteOptions { IsOrdered = false});
		
		Console.WriteLine($"[{League.ToUpper()}] [{DateTime.Now.ToString("t")}] wrote BoxScores");
	}

	public static void InsertTeams(IEnumerable<Team> teams)
	{
		var collection = MongoDatabase?.GetCollection<Team>($"{League}.teams");
		if (collection == null)
			throw new Exception("Database error");

		// TODO: Use an update model instead
		var replaceModel = teams.Select(team => new
		{
			value = team,
			filter = Builders<Team>.Filter.Eq(x => x.GlobalTeamID, team.GlobalTeamID)
		}).Select(y => new ReplaceOneModel<Team>(y.filter, y.value) { IsUpsert = true });

		collection.BulkWriteAsync(replaceModel, new BulkWriteOptions { IsOrdered = false });
		
		Console.WriteLine($"[{League.ToUpper()}] [{DateTime.Now.ToString("t")}] wrote Teams");
	}

	public static Task<(Team? HomeTeam, Team? AwayTeam)> FindTeams(int? homeGlobalId, int? awayGlobalId)
	{
		var collection = MongoDatabase?.GetCollection<Team>($"{League}.teams");
		if (collection == null)
			throw new Exception("Database error");

		// I'd like to use linq here but every way I've tried is at least twice as slow.

		Team? homeTeam = null;
		Team? awayTeam = null;
		foreach (var team in collection.AsQueryable())
			if (team.GlobalTeamID == homeGlobalId)
				homeTeam = team;
			else if (team.GlobalTeamID == awayGlobalId)
				awayTeam = team;

		return Task.FromResult((homeTeam, awayTeam));
	}
}