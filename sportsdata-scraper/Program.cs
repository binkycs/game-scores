global using static sportsdata_scraper.Global;
using MongoDB.Bson.Serialization.Conventions;


var conventionPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
ConventionRegistry.Register("IgnoreExtraElements", conventionPack, type => true);

Initialize();

new sportsdata_scraper.NBA.UpdateManager().Start();
new sportsdata_scraper.NFL.UpdateManager().Start();

Console.ReadLine();