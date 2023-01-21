using System.ComponentModel;
using System.Runtime.Serialization;
using FantasyData.Api.Client.Model.NBA;

namespace sportsdata_scraper.NBA;

[Serializable]
public class BoxScoreWithLogos
{
	public Team? HomeTeam { get; set; }
	
	public Team? AwayTeam { get; set; }
	
	public Game? Game { get; set; }
	
	public TeamGame[]? TeamGames { get; set; }
	
	public Quarter[]? Quarters { get; set; }
	
	public PlayerGame[]? PlayerGames { get; set; }
	
	public BoxScoreWithLogos() {}

	public BoxScoreWithLogos(BoxScore boxScore)
	{
		this.Game = boxScore.Game;
		this.TeamGames = boxScore.TeamGames;
		this.Quarters = boxScore.Quarters;
		this.PlayerGames = boxScore.PlayerGames;
		var teams = DatabaseManager.FindTeams(this.Game.GlobalHomeTeamID, this.Game.GlobalAwayTeamID);
		this.HomeTeam = teams.HomeTeam;
		this.AwayTeam = teams.AwayTeam;
	}
}