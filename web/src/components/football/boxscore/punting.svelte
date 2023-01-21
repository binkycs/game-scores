<script lang="ts">
  import type { FootballGame, Punting, Team } from "$lib/football/footballgame";

  class TeamRushing {
    Team: Team;
    Stats: Punting[];
    constructor(public team: Team, public stats: Punting[]) {
      this.Team = team;
      this.Stats = stats.sort((a, b) => b.PuntYards - a.PuntYards);
    }
  }

  let count = 0;
  function increment() {
    return count++;
  }

  export let game: FootballGame;

  const teams = [new TeamRushing(game.AwayTeam, game.AwayPunting), new TeamRushing(game.HomeTeam, game.HomePunting)];
</script>

<div class="container">
  {#each teams as team}
    <div class="w-full">
      <div class="team-title mt-10">
        <img alt="{team.Team.Name}" src="{team.Team.WikipediaLogoUrl}" class="image" />
        <div class="font-extrabold">{team.Team.City} Punting</div>
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
              <th>PUNTS</th>
              <th>AVG</th>
              <th>IN20</th>
              <th>TB</th>
            </tr>
          </thead>
          <tbody>
            {#each team.Stats as player}
              <tr class="active">
                <td>{player.Punts}</td>
                <td>{player.PuntAverage}</td>
                <td>{player.PuntInside20}</td>
                <td>{player.PuntTouchbacks}</td>
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