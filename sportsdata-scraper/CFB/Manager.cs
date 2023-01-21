using FantasyData.Api.Client;
using FantasyData.Api.Client.Model.CFB;

namespace sportsdata_scraper.CFB;

public class Manager
{
	internal CFBv3ScoresClient ScoresClient = new CFBv3ScoresClient("");
	internal CFBv3StatsClient StatsClient { get; }

	protected internal Season SeasonDetails { get; set; }

	internal string SeasonType = "";

	public Manager()
	{
		var apiKey = Environment.GetEnvironmentVariable("SportsDataCFB", EnvironmentVariableTarget.User);
		this.ScoresClient = new CFBv3ScoresClient(apiKey);
		this.StatsClient = new CFBv3StatsClient(apiKey);
		this.SeasonDetails = this.ScoresClient.GetCurrentSeasonDetails();
	}

	public void Start()
	{
		this.SeasonDetails = this.ScoresClient.GetCurrentSeasonDetails();
		UpdateManager updateManager = new UpdateManager(this);
		updateManager.Start();

		new Task(() =>
		{
			Thread.Sleep(1500);
			updateManager.Stop();
		});//.Start();
	}
}