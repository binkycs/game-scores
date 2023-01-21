<script lang="ts">
  import type { FootballGame } from "$lib/football/footballgame";
  import { getPassingName, getPassingStats, getReceivingName, getReceivingStats, getRushingName, getRushingStats } from "$lib/football/helper";

  export let game: FootballGame;
</script>

<table class="table p-2 leading-5">
  <thead>
    <th colspan="3" />
    <th>{game.AwayTeam.Name}</th>
    <th>{game.HomeTeam.Name}</th>
  </thead>
  <tbody>
    <tr class="tr-stats">
      <td colspan="3">PASS</td>
      <td>
        <div>{getPassingName(game.AwayPassing)}</div>
        <br />
        <div>{getPassingStats(game.AwayPassing)}</div>
      </td>
      <td>
        <div>{getPassingName(game.HomePassing)}</div>
        <br />
        <div>{getPassingStats(game.HomePassing)}</div>
      </td>
    </tr>
    <tr class="tr-stats">
      <td colspan="3">RUSH</td>
      <td>
        <div>{getRushingName(game.AwayRushing)}</div>
        <br />
        <div>{getRushingStats(game.AwayRushing)}</div>
      </td>
      <td>
        <div>{getRushingName(game.HomeRushing)}</div>
        <br />
        <div>{getRushingStats(game.HomeRushing)}</div>
      </td>
    </tr>
    <tr class="tr-stats">
      <td colspan="3">REC</td>
      <td>
        <div>{getReceivingName(game.AwayReceiving)}</div>
        <br />
        <div>{getReceivingStats(game.AwayReceiving)}</div>
      </td>
      <td>
        <div>{getReceivingName(game.HomeReceiving)}</div>
        <br />
        <div>{getReceivingStats(game.HomeReceiving)}</div>
      </td>
    </tr>
  </tbody>
</table>

<style>
  table {
    min-width: 24rem;
    max-width: 24rem;
    --tw-bg-opacity: 1;
    background-color: hsl(var(--b1) / var(--tw-bg-opacity));
  }
  th {
    line-height: 1rem;
    font-size: 0.9rem;
    font-weight: bolder;
  }
  .tr-stats td:nth-child(n) {
    line-height: 0.5rem;
  }
  .tr-stats td:nth-child(1) {
    font-weight: bolder;
  }
  .tr-stats td div:nth-child(1) {
    font-weight: 600;
    font-size: 0.9rem;
  }
  .tr-stats td div:nth-child(n+2) {
    font-size: 0.7rem;
  }
  td {
    border-style: none;
  }
</style>