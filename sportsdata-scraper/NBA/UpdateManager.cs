using System.Diagnostics;
using FantasyData.Api.Client;
using FantasyData.Api.Client.Model.NBA;

namespace sportsdata_scraper.NBA;

internal class UpdateManager
{
	private NBAv3ScoresClient ScoresClient { get; }
	private NBAv3StatsClient StatsClient { get; }

	private readonly CancellationTokenSource _cancelTokenSource;

	private string DateString => FormatDate(DateTime.Today);
	
	private Season Season { get; set; }

	public UpdateManager()
	{
		this._cancelTokenSource = new CancellationTokenSource();
		
		var apiKey = Environment.GetEnvironmentVariable("SportsDataNBA");
		this.ScoresClient = new NBAv3ScoresClient(apiKey);
		this.StatsClient = new NBAv3StatsClient(apiKey);
		
		this.Season = this.StatsClient.GetCurrentSeason();
	}

	public void Start()
	{
		var token = this._cancelTokenSource.Token;
		
		RunTask(UpdateSeasonDetails, token, TimeSpan.FromHours(6));
		RunTask(UpdateTeams, token, TimeSpan.FromDays(30));
		RunTask(UpdateCurrentBoxScores, token, TimeSpan.FromMinutes(10));
		RunTask(UpdateWeeklyGames, token, TimeSpan.FromDays(1));
	}

	public void Stop()
	{
		this._cancelTokenSource.Cancel();
	}
	
	private void RunTask(Action<CancellationToken> method, CancellationToken token, TimeSpan sleepSpan)
	{
		async void Action()
		{
			while (!token.IsCancellationRequested)
			{
				method(token);
				await Task.Delay(sleepSpan, token);
			}
		}

		new Task(Action).Start();
	}

	private async void UpdateSeasonDetails(CancellationToken token)
	{
		this.Season = await this.StatsClient.GetCurrentSeasonAsync();
	}

	private async void UpdateCurrentBoxScores(CancellationToken token)
	{
		var todaysGames = await this.StatsClient.GetBoxScoresAsync(this.DateString);
		todaysGames.AddRange(await this.StatsClient.GetBoxScoresAsync(FormatDate(DateTime.Today.AddDays(-1))));
		
		DatabaseManager.InsertBoxScores(todaysGames.ToBoxScoresWithLogos());
	}

	private async void UpdateWeeklyGames(CancellationToken token)
	{
		for (var i = 1; i <= 7; i++)
		{
			var date = FormatDate(DateTime.Today.AddDays(i));
			var boxScores = (await this.StatsClient.GetBoxScoresAsync(date)).ToBoxScoresWithLogos();
				
			DatabaseManager.InsertBoxScores(boxScores);
		}
	}

	private async void UpdateTeams(CancellationToken token)
	{
		var teams = await this.StatsClient.GetTeamsAsync();

		DatabaseManager.InsertTeams(teams);
	}
}