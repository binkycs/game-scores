
namespace sportsdata_scraper;

public static class ExtensionMethods
{
	public static IEnumerable<NBA.BoxScoreWithLogos> ToBoxScoresWithLogos(this IEnumerable<FantasyData.Api.Client.Model.NBA.BoxScore> boxScores)
	{
		return boxScores.Select(score => new NBA.BoxScoreWithLogos(score));
	}

	public static IEnumerable<NFL.BoxScoreWithLogos> ToBoxScoresWithLogos(
		this IEnumerable<FantasyData.Api.Client.Model.NFLv3.BoxScore> boxScores)
	{
		return boxScores.Select(score => new NFL.BoxScoreWithLogos(score));
	}
}