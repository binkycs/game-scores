<script lang="ts">
  import type { FootballGame, Kicking, Team } from "$lib/football/footballgame";

  class TeamDefense {
    Team: Team;
    Stats: Kicking[];
    constructor(public team: Team, public stats: Kicking[]) {
      this.Team = team;
      this.Stats = stats;
    }
  }

  let count = 0;
  function increment() {
    return count++;
  }

  export let game: FootballGame;

  const teams = [new TeamDefense(game.AwayTeam, game.AwayKicking), new TeamDefense(game.HomeTeam, game.HomeKicking)];
</script>

<div class="container">
  {#each teams as team}
    <div class="w-full">
      <div class="team-title mt-10">
        <img alt="{team.Team.Name}" src="{team.Team.WikipediaLogoUrl}" class="image" />
        <div class="font-extrabold">{team.Team.City} Kicking</div>
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
              <th>FGM</th>
              <th>FGA</th>
              <th>PCT</th>
              <th>LONG</th>
              <th>XPM</th>
              <th>XPA</th>
              <th>PTS</th>
            </tr>
          </thead>
          <tbody>
            {#each team.Stats as player}
              <tr class="active">
                <td>{player.FieldGoalsMade}</td>
                <td>{player.FieldGoalsAttempted}</td>
                <td>{player.FieldGoalPercentage}</td>
                <td>{player.FieldGoalsLongestMade}</td>
                <td>{player.ExtraPointsMade}</td>
                <td>{player.ExtraPointsAttempted}</td>
                <td>{player.ExtraPointsMade + (player.FieldGoalsMade * 3)}</td>
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