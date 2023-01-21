using FantasyData.Api.Client;

namespace sportsdata_scraper.CFB;

internal class UpdateManager
{
	private Manager ParentManager { get; set; }

	private CFBv3StatsClient StatsClient => this.ParentManager.StatsClient;

	private CFBv3ScoresClient ScoresClient => this.ParentManager.ScoresClient;

	private readonly CancellationTokenSource _cancelTokenSource;

	public UpdateManager(Manager manager)
	{
		this.ParentManager = manager;
		
		this._cancelTokenSource = new CancellationTokenSource();
	}

	public void Start()
	{
		var token = this._cancelTokenSource.Token;
		
		new Task(UpdateSeasonDetails, token).Start();
		new Task(UpdateBoxScores, token).Start();
	}

	public void Stop()
	{
		this._cancelTokenSource.Cancel();
	}

	private async void UpdateSeasonDetails()
	{
		while (!this._cancelTokenSource.IsCancellationRequested)
		{
			this.ParentManager.SeasonDetails = await this.StatsClient.GetCurrentSeasonDetailsAsync();
			await Task.Delay(TimeSpan.FromHours(6), this._cancelTokenSource.Token);
		}
	}

	private async void UpdateBoxScores()
	{
		while (!this._cancelTokenSource.IsCancellationRequested)
		{
			if (this.ParentManager.SeasonDetails.ApiWeek.HasValue)
			{
				await this.StatsClient.GetBoxScoresByWeekDeltaAsync(this.ParentManager.SeasonType,
					this.ParentManager.SeasonDetails.ApiWeek.Value, "1");
			}
			
			// sleep 60 seconds
			await Task.Delay(TimeSpan.FromSeconds(60), this._cancelTokenSource.Token);
		}
	}
}