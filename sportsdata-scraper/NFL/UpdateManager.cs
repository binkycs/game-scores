using FantasyData.Api.Client;
using FantasyData.Api.Client.Model.NFLv3;

namespace sportsdata_scraper.NFL;

internal class UpdateManager
{
	private NFLv3ScoresClient ScoresClient { get; }
	private NFLv3StatsClient StatsClient { get; }

	private readonly CancellationTokenSource _cancelTokenSource;

	private string DateString => FormatDate(DateTime.Today);

	private Timeframe? Season { get; set; }

	public UpdateManager()
	{
		this._cancelTokenSource = new CancellationTokenSource();

		var apiKey = Environment.GetEnvironmentVariable("SportsDataNFL");
		this.ScoresClient = new NFLv3ScoresClient(apiKey);
		this.StatsClient = new NFLv3StatsClient(apiKey);

		this.Season = this.ScoresClient.GetTimeframes("current").First();
	}

	public void Start()
	{
		var token = this._cancelTokenSource.Token;

		RunTask(UpdateSeasonDetails, token, TimeSpan.FromHours(6));
		RunTask(UpdateTeams, token, TimeSpan.FromDays(30));
		RunTask(UpdateCurrentBoxScores, token, TimeSpan.FromMinutes(10));
		RunTask(UpdateWeeklyGames, token, TimeSpan.FromHours(18));
	}

	public void Stop()
	{
		this._cancelTokenSource.Cancel();
	}

	private void RunTask(Action<CancellationToken> method, CancellationToken token, TimeSpan sleepSpan)
	{
		new Task(async () =>
		{
			while (!token.IsCancellationRequested)
			{
				method(token);
				await Task.Delay(sleepSpan, token);
			}
		}).Start();
	}

	private async void UpdateSeasonDetails(CancellationToken token)
	{
		var timeframes = await this.StatsClient.GetTimeframesAsync("current");
		if (timeframes != null) this.Season = timeframes.First();
	}

	private async void UpdateCurrentBoxScores(CancellationToken token)
	{
		// TODO: Do this by delta. Active scores is deprecated by the API.
		var activeGames = (await this.StatsClient.GetActiveBoxScoresAsync()).ToBoxScoresWithLogos();

		DatabaseManager.InsertBoxScores(activeGames);
	}

	private async void UpdateWeeklyGames(CancellationToken token)
	{
		while (this.Season == null)
			await Task.Delay(TimeSpan.FromSeconds(10), token);

		if (this.Season.HasEnded)
			return;

		var boxScores = (await this.StatsClient.GetBoxScoresAsync(this.Season.ApiSeason,
			this.Season.Week!.Value)).ToBoxScoresWithLogos();

		DatabaseManager.InsertBoxScores(boxScores);

	}

	private async void UpdateTeams(CancellationToken token)
	{
		while (this.Season == null)
			await Task.Delay(TimeSpan.FromSeconds(10), token);

		var teams = await this.StatsClient.GetTeamsAsync();

		DatabaseManager.InsertTeams(teams);
	}
}