<script lang="ts">
  import type { PlayerGame } from "$lib/basketball/basketballgame";
  import { getAbbreviatedName } from "$lib/helper";
  export let players: PlayerGame[];
  export let title: string;
</script>

<table class="table p-1 leading-5">
  <thead>
    <th>{title}</th>
    <th>PTS</th>
    <th>REB</th>
    <th>AST</th>
    <th>FG</th>
    <th>3P</th>
    <th>FT</th>
    <th>PF</th>
    <th>MIN</th>
    <th>STL</th>
    <th>BLK</th>
    <th>TO</th>
    <th>+/-</th>
  </thead>
  <tbody>
    {#each players as player}
      <tr>
        <td>{getAbbreviatedName(player.Name)}</td>
        <td>{Math.round(player.Points)}</td>
        <td>{Math.round(player.Rebounds)}</td>
        <td>{Math.round(player.Assists)}</td>
        <td>{`${Math.round(player.FieldGoalsAttempted)}/${Math.round(player.FieldGoalsMade)}`}</td>
        <td>{`${Math.round(player.ThreePointersAttempted)}/${Math.round(player.ThreePointersMade)}`}</td>
        <td>{`${Math.round(player.FreeThrowsAttempted)}/${Math.round(player.FreeThrowsMade)}`}</td>
        <td>{`${Math.round(player.PersonalFouls)}`}</td>
        <td>{`${Math.round(player.Minutes)}`}</td>
        <td>{`${Math.round(player.Steals)}`}</td>
        <td>{`${Math.round(player.BlockedShots)}`}</td>
        <td>{`${Math.round(player.Turnovers)}`}</td>
        <td>{`${Math.round(player.PlusMinus)}`}</td>
      </tr>
    {/each}
  </tbody>
</table>

<style>
  table {
    width: 595px;
  }
  .table :where(th, td):is(:first-child) {
    width: 145px;
  }
  .table :where(th, td):not(:first-child) {
    padding: 0.5rem;
    text-align: right;
  }

  thead th:nth-child(n) {
    font-weight: 900;
    font-size: 0.75rem;
    line-height: 1rem;
    column-width: 0;
  }
</style>