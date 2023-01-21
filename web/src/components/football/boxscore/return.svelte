<script lang="ts">
  import type { FootballGame, KickPuntReturn, Team } from "$lib/football/footballgame";

  class TeamDefense {
    Team: Team;
    Stats: KickPuntReturn[];
    constructor(public team: Team, public stats: KickPuntReturn[]) {
      this.Team = team;
      this.Stats = stats.sort((a, b) => (b.KickReturnYards + b.PuntReturnYards) - (a.KickReturnYards + a.PuntReturnYards));
    }
  }

  let count = 0;
  function increment() {
    return count++;
  }

  export let game: FootballGame;

  const teams = [new TeamDefense(game.AwayTeam, game.AwayKickPuntReturns), new TeamDefense(game.HomeTeam, game.HomeKickPuntReturns)];
</script>

<div class="container">
  {#each teams as team}
    <div class="w-full">
      <div class="team-title mt-10">
        <img alt="{team.Team.Name}" src="{team.Team.WikipediaLogoUrl}" class="image" />
        <div class="font-extrabold">{team.Team.City} Returns</div>
      </div>

      <div class="divider mb-0 mt-0"></div>

      <div class="stats-left flex">
        <table class="table table-compact min-w-[160px] max-w-[160px]">
          <thead>
            <tr>
              <th>Players</th>
            </tr>
          </thead>
          <tbody>
            {#each team.Stats as player}
            <tr class="active">
              <td>{player.Name}</td>
            </tr>
            {/each}
          </tbody>
        </table>

        <div class="divider divider-horizontal ml-2 mr-2"></div>

        <table class="table table-compact w-full player-stats">
          <thead>
            <tr>
              <th>KR</th>
              <th>YDS</th>
              <th>AVG</th>
              <th>LONG</th>
              <th>TD</th>
              <th>PR</th>
              <th>YDS</th>
              <th>AVG</th>
              <th>LONG</th>
              <th>TD</th>
            </tr>
          </thead>
          <tbody>
            {#each team.Stats as player}
              <tr class="active">
                <td>{player.KickReturns}</td>
                <td>{player.KickReturnYards}</td>
                <td>{player.KickReturnYardsPerAttempt}</td>
                <td>{player.KickReturnLong}</td>
                <td>{player.KickReturnTouchdowns}</td>
                <td>{player.PuntReturns}</td>
                <td>{player.PuntReturnYards}</td>
                <td>{player.PuntReturnYardsPerAttempt}</td>
                <td>{player.PuntReturnLong}</td>
                <td>{player.PuntReturnTouchdowns}</td>
              </tr>
            {/each}
          </tbody>
        </table>

      </div>
    </div>
    {#if increment() < 1}
      <div class="divider divider-horizontal"></div>
    {/if}
  {/each}
</div>


<style>
  .container {
    display: flex;
    flex-direction: row;
    column-gap: 0.2rem;
  }
  @media (max-width: 1124px) {
    .container {
      flex-direction: column;
      row-gap: 0.4rem;
      /* align-items: center; */
    }
  }
  .team-title {
    display: flex;
    align-items: center;
  }
  .image {
    width: 28px;
    height: 28px;
    margin-right: 8px!important;
  }
  .player-stats :where(td, th) {
    text-align: center;
  }
  th {
    font-size: 12px;
  }
</style>