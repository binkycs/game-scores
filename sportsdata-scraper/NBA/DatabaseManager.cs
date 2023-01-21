using System.Diagnostics;
using FantasyData.Api.Client;
using FantasyData.Api.Client.Model.NBA;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace sportsdata_scraper.NBA;

public static class DatabaseManager
{
	private const string League = "nba";
	public static void InsertBoxScores(IEnumerable<BoxScoreWithLogos> games)
	{
		var collection = MongoDatabase?.GetCollection<BoxScoreWithLogos>($"{League}.scores");
		if (collection == null)
			throw new Exception("Database error");

		// TODO: Use an update model instead
		var replace = games
		.Select(game => new
		{
			value = game,
			filter = Builders<BoxScoreWithLogos>.Filter.Eq(x => x.Game!.GlobalGameID, game.Game!.GlobalGameID)
		}).Select(y => new ReplaceOneModel<BoxScoreWithLogos>(y.filter, y.value) { IsUpsert = true });

		collection?.BulkWriteAsync(replace, new BulkWriteOptions { IsOrdered = false});
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
	public static (Team? HomeTeam, Team? AwayTeam) FindTeams(int homeGlobalId, int awayGlobalId)
	{
		var collection = MongoDatabase?.GetCollection<Team>($"{League}.teams");
		if (collection == null)
			throw new Exception("Database error");

		// I'd like to use linq here but every way I've tried is at least twice as slow.

		Team? homeTeam = null;
		Team? awayTeam = null;
		foreach (var v in collection.AsQueryable())
		{
			if (v.GlobalTeamID == homeGlobalId)
				homeTeam = v;
			else if (v.GlobalTeamID == awayGlobalId)
				awayTeam = v;
		}

		return (homeTeam, awayTeam);
	}
}