using FantasyData.Api.Client.Model.NFLv3;

namespace sportsdata_scraper.NFL;

[Serializable]
public class BoxScoreWithLogos
{
	public Team? HomeTeam { get; set; }
	
	public Team? AwayTeam { get; set; }
	
	public Game? Game { get; set; }
	
	public Score? Score { get; set; }
	
	public ScoringPlay[]? ScoringPlays { get; set; }
	
	public ScoringDetail[]? ScoringDetails { get; set; }
	
	public PlayerPassing[]? AwayPassing { get; set; }
	
	public PlayerRushing[]? AwayRushing { get; set; }
	
	public PlayerReceiving[]? AwayReceiving { get; set; }
	
	public PlayerKicking[]? AwayKicking { get; set; }
	
	public PlayerPunting[]? AwayPunting { get; set; }
	
	public PlayerKickPuntReturns[]? AwayKickPuntReturns { get; set; }
	
	public PlayerDefense[]? AwayDefense { get; set; }
	
	public PlayerPassing[]? HomePassing { get; set; }
	
	public PlayerRushing[]? HomeRushing { get; set; }
	
	public PlayerReceiving[]? HomeReceiving { get; set; }
	
	public PlayerKicking[]? HomeKicking { get; set; }
	
	public PlayerPunting[]? HomePunting { get; set; }
	
	public PlayerKickPuntReturns[]? HomeKickPuntReturns { get; set; }
	
	public PlayerDefense[]? HomeDefense { get; set; }
		

	public BoxScoreWithLogos() {}

	public BoxScoreWithLogos(BoxScore boxScore)
	{
		this.Game = boxScore.Game;
		this.Score = boxScore.Score;
		this.ScoringPlays = boxScore.ScoringPlays;
		
		this.AwayPassing = boxScore.AwayPassing;
		this.AwayRushing = boxScore.AwayRushing;
		this.AwayReceiving = boxScore.AwayReceiving;
		this.AwayKicking = boxScore.AwayKicking;
		this.AwayPunting = boxScore.AwayPunting;
		this.AwayKickPuntReturns = boxScore.AwayKickPuntReturns;
		this.AwayDefense = boxScore.AwayDefense;
		
		this.HomePassing = boxScore.HomePassing;
		this.HomeRushing = boxScore.HomeRushing;
		this.HomeReceiving = boxScore.HomeReceiving;
		this.HomeKicking = boxScore.HomeKicking;
		this.HomePunting = boxScore.HomePunting;
		this.HomeKickPuntReturns = boxScore.HomeKickPuntReturns;
		this.HomeDefense = boxScore.HomeDefense;

		var teams = DatabaseManager.FindTeams(boxScore.Score.GlobalHomeTeamID, this.Score.GlobalAwayTeamID).Result;

		this.HomeTeam = teams.HomeTeam;
		this.AwayTeam = teams.AwayTeam;
	}
}