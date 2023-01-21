<script lang="ts">
  import MediaQuery from "$components/MediaQuery.svelte";
  import type { FootballGame, Passing, Team } from "$lib/football/footballgame";

  export let game: FootballGame;

  class TeamPassing {
    Team: Team;
    Passing: Passing[];
    constructor(public team: Team, public stats: Passing[]) {
      this.Team = team;
      this.Passing = stats.sort((a, b) => b.PassingYards - a.PassingYards);
    }
  }
  let passingTeams = [new TeamPassing(game.AwayTeam, game.AwayPassing), new TeamPassing(game.HomeTeam, game.HomePassing)];

  let count = 0;
  function increment() {
    return count++;
  }
</script>

<div class="container">
  {#each passingTeams as passing}
    <div class="w-full">
      <div class="team-title">
        <img alt="{passing.Team.Name}" src="{passing.Team.WikipediaLogoUrl}" class="image" />
        <div class="font-extrabold">{passing.Team.City} Passing</div>
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
            {#each passing.Passing as player}
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
              <th>C/ATT</th>
              <th>YDS</th>
              <th>AVG</th>
              <th>TD</th>
              <th>INT</th>
              <th>SACKS</th>
              <th>RTG</th>
            </tr>
          </thead>
          <tbody>
            {#each passing.Passing as player}
              <tr class="active">
                <td>{player.PassingCompletions}/{player.PassingAttempts}</td>
                <td>{player.PassingYards}</td>
                <td>{player.PassingYardsPerAttempt}</td>
                <td>{player.PassingTouchdowns}</td>
                <td>{player.PassingInterceptions}</td>
                <td>{player.PassingSacks}</td>
                <td>{player.PassingRating}</td>
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
    justify-content: center;
    column-gap: 0.2rem;
  }
  @media (max-width: 1124px) {
    .container {
      flex-direction: column;
      row-gap: 0.4rem;
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